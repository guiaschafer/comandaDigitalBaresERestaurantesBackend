using ComandaDigitalBaresERestaurantes.Interface;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Mappers;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;

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

        public void Insert(ProductDto productDto)
        {
            try
            {
                var product = new Product();
                if (product != null)
                {
                    product.IdCategory = productDto.IdCategory;
                    product.Name = productDto.Name;
                    product.UrlImage = productDto.UrlImagem;
                    product.Value = Double.Parse(productDto.Value);
                    product.Description = productDto.Description;

                    unitOfWork.ProductRepository.Add(product);
                    unitOfWork.Commit();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(ProductDto productDto)
        {
            try
            {
                var product = unitOfWork.ProductRepository.GetOne(p => p.Id == productDto.Id);

                if(product != null)
                {
                    product.IdCategory = productDto.IdCategory;
                    product.Name = productDto.Name;
                    product.UrlImage = productDto.UrlImagem;
                    product.Value = Double.Parse(productDto.Value);
                    product.Description = productDto.Description;

                    unitOfWork.Commit();
                }
            }
            catch (Exception e)
            {
                throw new Exception (e.Message);
            }
        }
    }
}
