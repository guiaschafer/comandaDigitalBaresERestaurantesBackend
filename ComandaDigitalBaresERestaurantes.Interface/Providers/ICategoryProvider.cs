using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Providers
{
    public interface ICategoryProvider
    {
        List<CategoryDto> GetAll();
        void Update(CategoryDto categoryDto);
        void Insert(CategoryDto categoryDto);
    }
}
