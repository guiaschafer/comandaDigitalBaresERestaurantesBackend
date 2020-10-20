using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Mappers
{
    public interface IBaseMapper<T, TEntity> where TEntity : BaseEntity where T : BaseDto
    {
        IReadOnlyList<T> MapToDto(IEnumerable<TEntity> source);

        T MapToDto(TEntity source);
    }
}
