using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public virtual Category Category { get; set; }
        public int IdCategory { get; set; }
    }
}
