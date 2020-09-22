using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity
{
    public class Order: BaseEntity
    {
        public Client Client { get; set; }
        public int IdClient { get; set; }
        public Status Status{ get; set; }
        public List<OrderIten> ListOfItens { get; set; }
    }
}
