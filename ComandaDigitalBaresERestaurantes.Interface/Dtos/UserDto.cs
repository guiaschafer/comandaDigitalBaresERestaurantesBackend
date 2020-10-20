using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Dtos
{
    public class UserDto : BaseDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Perfil { get; set; }
    }
}
