using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Dtos
{
    public class OrderDto : BaseDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Value { get; set; }
    }
}
