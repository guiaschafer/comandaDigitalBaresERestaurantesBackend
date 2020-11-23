using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Enum;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.Interface.Providers
{
    public interface IOrderProvider
    {
        void ConfirmOrder(ICollection<OrderDto> orderItens, string user);
        void UpdateStatusOrder(OrderDto orderDto);
        List<OrderHistoryDto> GetAllOrders(Perfil perfil);
        List<OrderHistoryDto> GetAllOrders(string user);
        List<OrderHistoryDto> GetAllOrders();
        Task<bool> ConfirmPayment(PaymentDto paymentDto);

    }
}
