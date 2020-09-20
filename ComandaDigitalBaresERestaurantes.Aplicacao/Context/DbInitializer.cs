using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Context
{
    public static class DbInitializer
    {
        public static void Seed(DatabaseContext context)
        {
            var client = new Client
            {
                Name = "Severino",
                LastName = "Conceição",
                Cpf = "00385634285",
                Email = "severino@gmail.com",
                Cellphone = "96999972824",
                User = new User
                {
                    Active = true,
                    Login = "severino@gmail.com",
                    Password = "zQgLIGzejB",
                    Perfil = Domain.Enum.Perfil.Client

                }
            };

            var clientBar = new Client
            {
                Name = "Bar",
                LastName = "Bar",
                Cpf = "00385634285",
                Email = "bar@gmail.com",
                Cellphone = "96999972824",
                User = new User
                {
                    Active = true,
                    Login = "bar@gmail.com",
                    Password = "zQgLIGzejB",
                    Perfil = Domain.Enum.Perfil.Bar

                }
            };

            var clientKitchen = new Client
            {
                Name = "Kitchen",
                LastName = "Conceição",
                Cpf = "00385634285",
                Email = "kitchen@gmail.com",
                Cellphone = "96999972824",
                User = new User
                {
                    Active = true,
                    Login = "kitchen@gmail.com",
                    Password = "zQgLIGzejB",
                    Perfil = Domain.Enum.Perfil.Kitchen

                }
            };

            var clientCashier = new Client
            {
                Name = "Cashier",
                LastName = "Conceição",
                Cpf = "00385634285",
                Cellphone = "96999972824",
                Email = "cashier@gmail.com",
                User = new User
                {
                    Active = true,
                    Login = "cashier@gmail.com",
                    Password = "zQgLIGzejB",
                    Perfil = Domain.Enum.Perfil.Cashier

                }
            };

            context.Client.Add(client);
            context.Client.Add(clientBar);
            context.Client.Add(clientKitchen);
            context.Client.Add(clientCashier);

            context.SaveChanges();

        }
    }
}
