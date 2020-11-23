using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Enum
{
    public enum Status
    {
        [Description("Aberto")]
        Open = 0,
        [Description("Bebidas entregues")]
        DrinksSent = 1,
        [Description("Preparando comida")]
        InProgress = 2,
        [Description("Preparando comida e bebidas entregues")]
        InProgressDrinksSent = 3,
        [Description("Comida pronta")]
        FoodFinished = 4,
        [Description("Comida pronta e bebidas entregues")]
        FoodFinishedAndDrinksSent = 5,
        [Description("Pedido entregue")]
        OrderSent = 6,
        [Description("Pago")]
        Payed = 7
    }
}
