﻿using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Enum;
using ComandaDigitalBaresERestaurantes.Interface;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Dtos.MundiPagg;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.Service.Providers
{
    public class OrderProvider : IOrderProvider
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderProvider(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void ConfirmOrder(ICollection<OrderDto> orderItens, string user)
        {
            var client = unitOfWork.ClientRepository.GetOne(c => c.User.Login == user);
            List<OrderIten> items = new List<OrderIten>();
            foreach (var item in orderItens)
            {
                items.Add(new OrderIten
                {
                    IdProduct = item.Id,
                    Quantity = item.Quantity
                });
            }

            var order = new Aplicacao.Domain.Entity.Order
            {
                IdClient = client.Id,
                Status = Aplicacao.Domain.Enum.Status.Open,
                ListOfItens = items
            };

            unitOfWork.OrderRepository.Add(order);
            unitOfWork.Commit();
        }

        public async Task<bool> ConfirmPayment(PaymentDto paymentDto)
        {
            var order = unitOfWork.OrderRepository.GetOne(o => o.Id == paymentDto.Id);
            var totalOrder = 0.00;

            foreach (var item in order.ListOfItens)
            {
                totalOrder += (item.Quantity * item.Product.Value);
            }

            var totalOrderString = totalOrder.ToString();

            if (totalOrderString.Contains("."))
            {
                if(totalOrderString.Substring(totalOrderString.IndexOf(".")+1).Length == 1)
                {
                    totalOrderString += "0";
                }

                totalOrderString = totalOrderString.Replace(".", "");
            }
            else
            {
                totalOrderString += "00";
            }

            if (order != null)
            {
                var mundiPaggItems = new MundiPaggItemDto();
                mundiPaggItems.items = new List<MundiPaggItensDto>();
                mundiPaggItems.items.Add(new MundiPaggItensDto
                {
                    Amount = Int32.Parse(totalOrderString),
                    Description = "Pedido nº" + order.Id,
                    Quantity = 1
                });

                var customer = new MundiPaggCustomerDto
                {
                    Name = order.Client.Fullname,
                    Email = order.Client.Email,
                };

                var payments = new List<MundiPaggPaymentsDto>();
                payments.Add(new MundiPaggPaymentsDto
                {
                    payment_method = "credit_card",
                    credit_card = new MundiPaggCrediCardDto
                    {
                        card = new MundiPaggCardDto
                        {
                            holder_name = paymentDto.CardName,
                            number = paymentDto.CardNumber,
                            exp_month = Int32.Parse(paymentDto.ValidUntil.Substring(0, 2)),
                            exp_year = Int32.Parse(paymentDto.ValidUntil.Substring(3, 2)),
                            cvv = paymentDto.Cvv
                        }
                    }

                });
                var request = new
                {
                    items = mundiPaggItems.items,
                    customer = customer,
                    payments = payments
                };

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.mundipagg.com/core/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "c2tfdGVzdF9PS3hWQjc5MUZlaThkd3k5Og==");
                var requestJson = JsonConvert.SerializeObject(request);
                HttpResponseMessage response = await client.PostAsync(
              "v1/orders/", new StringContent(requestJson, Encoding.UTF8, "application/json"));

                var responseObject = JsonConvert.DeserializeObject<MundiPaggResponse>(response.Content.ReadAsStringAsync().Result);

                if(responseObject.status != "paid")
                {
                    var error = responseObject.charges.First().last_transaction.acquirer_message;
                    throw new Exception(error);
                }
                else
                {
                    order.Status = Status.Payed;
                    unitOfWork.Commit();
                }             
            }

            return true;
        }

        public List<OrderHistoryDto> GetAllOrders(string user)
        {
            var client = unitOfWork.ClientRepository.GetOne(c => c.User.Login == user);

            var history = unitOfWork.OrderRepository.Get(o => o.Client.User.Login == user);

            var orderhistory = new List<OrderHistoryDto>();
            foreach (var order in history)
            {
                var itens = new List<OrderDto>();
                double total = 0;
                foreach (var item in order.ListOfItens)
                {
                    itens.Add(new OrderDto
                    {
                        Name = item.Product.Name,
                        Value = item.Product.Value.ToString(),
                        Id = item.IdProduct,
                        Quantity = item.Quantity
                    });

                    total += item.Quantity * item.Product.Value;
                }

                orderhistory.Add(new OrderHistoryDto
                {
                    Id = order.Id,
                    Status = Util.GetDescription<Status>(order.Status),
                    CodigoStatus = (int)order.Status,
                    Itens = itens,
                    ValorTotal = total
                });
            }

            return orderhistory.OrderByDescending(o => o.Id).ToList();
        }

        public List<OrderHistoryDto> GetAllOrders()
        {
            var history = unitOfWork.OrderRepository.Get();

            var orderhistory = new List<OrderHistoryDto>();
            foreach (var order in history)
            {
                var itens = new List<OrderDto>();
                double total = 0;
                foreach (var item in order.ListOfItens)
                {
                    itens.Add(new OrderDto
                    {
                        Name = item.Product.Name,
                        Value = item.Product.Value.ToString(),
                        Id = item.IdProduct,
                        Quantity = item.Quantity
                    });

                    total += item.Quantity * item.Product.Value;
                }

                orderhistory.Add(new OrderHistoryDto
                {
                    NameClient = order.Client.Fullname,
                    CpfClient = order.Client.Cpf,
                    Id = order.Id,
                    Status = Util.GetDescription<Status>(order.Status),
                    CodigoStatus = (int)order.Status,
                    Itens = itens,
                    ValorTotal = total
                });
            }

            return orderhistory.OrderByDescending(o => o.Id).ToList();
        }

        public List<OrderHistoryDto> GetAllOrders(Perfil perfil)
        {
            IEnumerable<Order> listOfOrders = null;
            if (perfil == Perfil.Kitchen)
            {
                listOfOrders = unitOfWork.OrderRepository.Get(o => (int)o.Status < (int)Status.FoodFinished);                                        
            }
            else if(perfil == Perfil.Bar)
            {
                listOfOrders = unitOfWork.OrderRepository.Get(o => o.Status != Status.Payed);
            }

            if(listOfOrders != null)
            {
                var orderhistory = new List<OrderHistoryDto>();
                foreach (var order in listOfOrders)
                {
                    var itens = new List<OrderDto>();
                    double total = 0;
                    foreach (var item in order.ListOfItens)
                    {
                        itens.Add(new OrderDto
                        {
                            Name = item.Product.Name,
                            Value = item.Product.Value.ToString(),
                            Id = item.IdProduct,
                            Quantity = item.Quantity
                        });

                        total += item.Quantity * item.Product.Value;
                    }

                    orderhistory.Add(new OrderHistoryDto
                    {
                        NameClient = order.Client.Fullname,
                        CpfClient = order.Client.Cpf,
                        Id = order.Id,
                        Status = Util.GetDescription<Status>(order.Status),
                        CodigoStatus = (int)order.Status,
                        Itens = itens,
                        ValorTotal = total
                    });
                }

                return orderhistory.OrderBy(o => o.Id).ToList();
            }

            return null;
        }
        public void UpdateStatusOrder(OrderDto orderDto)
        {
            var order = unitOfWork.OrderRepository.GetOne(o => o.Id == orderDto.Id);

            if(order != null)
            {
                if(orderDto.Status == (int)Status.DrinksSent)
                {
                    if(order.Status == Status.Open)
                    {
                        order.Status = Status.DrinksSent;
                    }
                    else if(order.Status == Status.InProgress)
                    {
                        order.Status = Status.InProgressDrinksSent;
                    }
                    else if (order.Status == Status.FoodFinishedAndDrinksSent)
                    {
                        order.Status = Status.OrderSent;
                    }
                    else if(order.Status == Status.FoodFinished)
                    {
                        order.Status = Status.FoodFinishedAndDrinksSent;
                    }
                }
                else if (orderDto.Status == (int)Status.InProgress)
                {
                    if (order.Status == Status.Open)
                    {
                        order.Status = Status.InProgress;
                    }
                    else if (order.Status == Status.DrinksSent)
                    {
                        order.Status = Status.InProgressDrinksSent;
                    }
                }
                else if(orderDto.Status == (int)Status.FoodFinished)
                {
                    if (order.Status == Status.InProgressDrinksSent)
                    {
                        order.Status = Status.FoodFinishedAndDrinksSent;
                    }
                    else if (order.Status == Status.InProgress)
                    {
                        order.Status = Status.FoodFinished;
                    }
                }
                else if(orderDto.Status == (int)Status.OrderSent)
                {
                    order.Status = Status.OrderSent;
                }

                unitOfWork.Commit();
            }
        }
    }
}
