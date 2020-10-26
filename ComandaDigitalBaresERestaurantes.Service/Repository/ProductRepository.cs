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
    public class ProductRepository : IRepository<Product>, IProductRepository
    {
        DatabaseContext _context;
        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        void IRepository<Product>.Add(Product entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<Product>.Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Product> IRepository<Product>.Get()
        {
            return _context.Product.Include(p => p.Category).ToList();
        }

        IEnumerable<Product> IRepository<Product>.Get(Expression<Func<Product, bool>> predicate)
        {
            return _context.Product.Include(p => p.Category).ToList();
        }

        Product IRepository<Product>.GetOne(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        void IRepository<Product>.Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
