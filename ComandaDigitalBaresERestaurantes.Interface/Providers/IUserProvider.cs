using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.Interface.Providers
{
    public interface IUserProvider
    {
        UserDto GetUserAsync(string login);
        int AddUser(UserDto user);

    }
}
