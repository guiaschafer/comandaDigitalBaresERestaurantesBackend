using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Dtos
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public string Password { get; set; }
        public int Perfil { get; set; }
        public string Login { get; set; }
    }
}
