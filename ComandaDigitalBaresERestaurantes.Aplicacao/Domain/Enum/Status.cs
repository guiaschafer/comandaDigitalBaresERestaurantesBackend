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
        [Description("Prep. comida")]
        InProgress = 2,
        [Description("Prep. Comida, bebida entreg.")]
        InProgressDrinksSent = 3,
        [Description("Comida ok")]
        FoodFinished = 4,
        [Description("Comida ok  e bebidas entreg.")]
        FoodFinishedAndDrinksSent = 5,
        [Description("Pedido entregue")]
        OrderSent = 6,
        [Description("Pago")]
        Payed = 7
    }
}
