using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Enum;
using ComandaDigitalBaresERestaurantes.Interface;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void ConfirmPayment(PaymentDto paymentDto)
        {
            var order = unitOfWork.OrderRepository.GetOne(o => o.Id == paymentDto.Id);
            var totalOrder = 0.00;

            foreach (var item in order.ListOfItens)
            {
                totalOrder += (item.Quantity * item.Product.Value);
            }


            if (order != null)
            {
                //MundiAPIClient client = new MundiAPIClient("sk_test_OKxVB791Fei8dwy9", null);

                //var items = new List<CreateOrderItemRequest> {
                //     new CreateOrderItemRequest {
                //     Amount = 1,//(int)totalOrder,
                //     Description = "Pedido nº" + order.Id,
                //     Quantity = 1
                //     }
                // };
                //var customer = new CreateCustomerRequest
                //{
                //    Name = order.Client.Fullname,
                //    Email = order.Client.Email,
                //};

                //var payments = new List<CreatePaymentRequest> {
                //     new CreatePaymentRequest {
                //         PaymentMethod = "credit_card",
                //         CreditCard = new CreateCreditCardPaymentRequest {
                //              Card = new CreateCardRequest {
                //                    HolderName = paymentDto.CardName,
                //                    Number = paymentDto.CardNumber,
                //                    ExpMonth = Int32.Parse(paymentDto.ValidUntil.Substring(0, 2)),
                //                    ExpYear = Int32.Parse(paymentDto.ValidUntil.Substring(3, 2)),
                //                    Cvv = paymentDto.Cvv
                //              }
                //         }
                //     }
                //};

                //var request = new CreateOrderRequest
                //{
                //    Items = items,
                //    Customer = customer,
                //    Payments = payments
                //};

                //var response = client.Orders.CreateOrder(request);

                //if(response.Status != "paid")
                //{
                //    var error = (MundiAPI.PCL.Models.GetCreditCardTransactionResponse)response.Charges[0].LastTransaction;
                //    throw new Exception(error.AcquirerMessage);                    
                //}
                //else
                //{
                //    order.Status = Status.Payed;
                //    unitOfWork.Commit();
                //}
            }
        }

        public List<OrderHistoryDto> GetAllOrders(string user)
        {
            var client = unitOfWork.ClientRepository.GetOne(c => c.User.Login == user);

            var history = unitOfWork.OrderRepository.Get(o => o.Client.User.Login == user && o.Status != Aplicacao.Domain.Enum.Status.Payed);

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
                        Value = item.Product.Value,
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

    }
}
