using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity
{
    public class OrderIten
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public int IdOrder { get; set; }
    }
}
