using ComandaDigitalBaresERestaurantes.Interface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComandaDigitalBaresERestaurantes.WebApi.Response
{
    public class LoginResponse
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
        public string HashRecoverPassword { get; set; }
    }
}
