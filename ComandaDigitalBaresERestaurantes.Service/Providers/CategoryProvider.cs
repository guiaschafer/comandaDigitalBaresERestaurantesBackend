using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Interface;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Service.Providers
{
    public class CategoryProvider : ICategoryProvider
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryProvider(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<CategoryDto> GetAll()
        {
            var categories = unitOfWork.CategoryRepository.Get();
            var retorno = new List<CategoryDto>();

            foreach (var item in categories)
            {
                retorno.Add(new CategoryDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Url = item.Url
                });
            }

            return retorno;
        }

        public void Insert(CategoryDto categoryDto)
        {
            try
            {
                var category = new Category();

                category.Name = categoryDto.Name;
                category.Url = categoryDto.Url;

                unitOfWork.CategoryRepository.Add(category);
                unitOfWork.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(CategoryDto categoryDto)
        {
            try
            {
                var category = unitOfWork.CategoryRepository.GetOne(c => c.Id == categoryDto.Id);

                if (category != null)
                {
                    category.Name = categoryDto.Name;
                    category.Url = categoryDto.Url;

                    unitOfWork.Commit();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
