using ComandaDigitalBaresERestaurantes.Interface;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Mappers;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ComandaDigitalBaresERestaurantes.Service.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductMapper mapper;
        

        public ProductProvider(IUnitOfWork unitOfWork,
            IProductMapper mapper
            )
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public ICollection<ProductDto> GetAll()
        {
            var produtos = unitOfWork.ProductRepository.Get();
            var p = new List<ProductDto>();

            foreach (var item in produtos.ToList())
            {
                p.Add(mapper.MapToDto(item));
            }

            return p;
        }
    }
}
