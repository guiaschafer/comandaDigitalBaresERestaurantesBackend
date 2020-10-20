using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using ComandaDigitalBaresERestaurantes.Interface.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Service.Mappers
{
    public class UserMapper : IUserMapper
    {
        public IReadOnlyList<UserDto> MapToDto(IEnumerable<User> source) =>
          source.Select(MapToDto)
                .ToList()
                .AsReadOnly();

        public UserDto MapToDto(User source) =>
            source != null
            ? new UserDto
            {
                Id = source.Id,
                Login = source.Login,
                Password = source.Password,
                Perfil = (int)source.Perfil
            } : null;
    }
}
