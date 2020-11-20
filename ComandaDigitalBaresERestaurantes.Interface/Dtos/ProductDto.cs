using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Dtos
{
    public class ProductDto : BaseDto
    {
        public string UrlImagem { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get;set; }
        public string Value { get; set; }
        public string IdCategory { get; set; }
    }
}
