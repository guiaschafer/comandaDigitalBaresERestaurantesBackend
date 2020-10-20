using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.Interface.Providers
{
    public interface IAuthenticationProvider
    {
        Task<(string hashRecoverPassword, string Token, UserDto User)> AuthenticateAsync(string username, string password, int profileId = 0);
        Task<(string, string, UserDto)?> VerificaSenhaExpirada(string username);
    }
}
