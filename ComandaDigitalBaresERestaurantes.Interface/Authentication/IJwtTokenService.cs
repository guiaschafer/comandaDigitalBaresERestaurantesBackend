using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Authentication
{
    public interface IJwtTokenService
    {
        string GetToken(long id, int perfil, string username);
    }
}
