using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Service.Mappers
{
    public class ProductMapper : IProductMapper
    {
        public IReadOnlyList<ProductDto> DtoToMap(IEnumerable<Product> source) =>
          source.Select(MapToDto)
                .ToList()
                .AsReadOnly();

        public ProductDto MapToDto(Product source) =>
            source != null
            ? new ProductDto
            {
                Id = source.Id,
                Name = source.Name,
                UrlImagem = source.UrlImage,
                Value = source.Value,
                Category = source.Category.Name
            } : null;
    }
}
