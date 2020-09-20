using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cellphone { get; set; }
        public string Fullname { get { return Name + " " + LastName; } }
        public virtual User User { get; set; }
        public int IdUser { get; set; }
        public ICollection<Order> ListOfOrders { get; set; }
    }
}
