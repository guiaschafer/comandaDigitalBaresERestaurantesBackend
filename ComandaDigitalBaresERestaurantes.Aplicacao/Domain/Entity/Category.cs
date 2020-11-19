using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity
{
    public class Category : BaseEntity
    {     
        public string Url { get; set; }
        public string Name { get; set; }
        public ICollection<Product> ListOfProducts { get; set; }
    }
}
