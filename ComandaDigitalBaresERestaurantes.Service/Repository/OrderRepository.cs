using ComandaDigitalBaresERestaurantes.Aplicacao.Context;
using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Service.Repository
{
    public class OrderRepository : IRepository<Order>, IOrderRepository
    {
        DatabaseContext _context;
        public OrderRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Get(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Order GetOne(Expression<Func<Order, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
