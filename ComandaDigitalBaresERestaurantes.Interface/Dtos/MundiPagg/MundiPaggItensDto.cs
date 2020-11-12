using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Dtos.MundiPagg
{
    public class MundiPaggItemDto
    {
        public List<MundiPaggItensDto> items { get; set; }
    }
    public class MundiPaggItensDto
    {
        public int Amount { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
