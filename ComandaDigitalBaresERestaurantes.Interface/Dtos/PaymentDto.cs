using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Dtos
{
    public class PaymentDto: BaseDto
    {
        public string CardNumber { get; set; }
        public string ValidUntil { get; set; }
        public string Cvv { get; set; }
        public string CardName { get; set; }
    }
}
