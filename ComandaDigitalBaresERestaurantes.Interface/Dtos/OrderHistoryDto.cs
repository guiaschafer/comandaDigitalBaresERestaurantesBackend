using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Dtos
{
    public class OrderHistoryDto : BaseDto
    {
        public List<OrderDto> Itens { get; set; }
        public string Status { get; set; }
        public int CodigoStatus { get; set; }
        public double ValorTotal { get; set; }

        public string NameClient { get; set; }
        public string CpfClient { get; set; }
    }
}
