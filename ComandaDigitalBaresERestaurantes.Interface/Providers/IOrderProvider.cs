﻿using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.Interface.Providers
{
    public interface IOrderProvider
    {
        void ConfirmOrder(ICollection<OrderDto> orderItens, string user);
        List<OrderHistoryDto> GetAllOrders(string user);
        Task<bool> ConfirmPayment(PaymentDto paymentDto);
    }
}
