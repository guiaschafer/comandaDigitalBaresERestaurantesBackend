using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.Interface.Providers
{
    public interface IBaseProvider<T, TEntity> where T : BaseDto where TEntity : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetOneAsync(long id);
        //Task<DataPaged<IReadOnlyList<T>>> GetPagedListAsync(IFilterDefinition<T> filter);
    }
}
