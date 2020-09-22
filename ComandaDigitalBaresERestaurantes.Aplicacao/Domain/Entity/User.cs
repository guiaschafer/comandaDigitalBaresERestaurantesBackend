using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity
{
    public class User :BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public Perfil Perfil { get; set; }
        public virtual Client Client { get; set; }
    }
}
