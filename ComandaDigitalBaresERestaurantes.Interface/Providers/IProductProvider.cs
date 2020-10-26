using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Providers
{
    public interface IProductProvider
    {
        ICollection<ProductDto> GetAll();
    }
}
