using ComandaDigitalBaresERestaurantes.Aplicacao.Context;
using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Service.Repository
{
    public class ClientRepository : IRepository<Client>, IClientRepository
    {
        DatabaseContext _context;
        public ClientRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Add(Client entity)
        {
            _context.Add(entity);
        }

        public void Delete(Client entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> Get(Expression<Func<Client, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Client GetOne(Expression<Func<Client, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
