using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.Interface.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string username, string password);
    }
}
