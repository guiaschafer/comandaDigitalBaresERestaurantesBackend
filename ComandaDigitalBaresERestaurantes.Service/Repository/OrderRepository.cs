using ComandaDigitalBaresERestaurantes.Aplicacao.Context;
using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _context.Add(entity);
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Get()
        {
            return _context.Order
                .Include(o => o.Client)
                .Include(o => o.ListOfItens)
                .ThenInclude(l => l.Product)
                .ToList();
        }

        public IEnumerable<Order> Get(Expression<Func<Order, bool>> predicate)
        {
            return _context.Order.Include(o => o.Client)
                .Include(o => o.ListOfItens)
                .ThenInclude(o => o.Product)
                .Where(predicate);
        }

        public Order GetOne(Expression<Func<Order, bool>> predicate)
        {
            return _context.Order.Include(o => o.Client)
              .Include(o => o.ListOfItens)
              .ThenInclude(o => o.Product)
              .FirstOrDefault(predicate);
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
