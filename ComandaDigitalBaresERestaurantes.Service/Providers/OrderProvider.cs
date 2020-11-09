using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Service.Providers
{
    public class OrderProvider : IOrderProvider
    {
        public void ConfirmOrder(ICollection<OrderDto> orderItens, string user)
        {
            
        }
    }
}
