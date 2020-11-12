using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
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
        static HttpClient client = new HttpClient();

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


            if (order != null)
            {
                //MundiAPIClient client = new MundiAPIClient("sk_test_OKxVB791Fei8dwy9", null);

                var mundiPaggItems = new MundiPaggItemDto();
                mundiPaggItems.items = new List<MundiPaggItensDto>();
                mundiPaggItems.items.Add(new MundiPaggItensDto
                {
                    Amount = 1,//(int)totalOrder,
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
