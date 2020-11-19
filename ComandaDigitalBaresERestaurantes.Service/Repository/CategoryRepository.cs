using ComandaDigitalBaresERestaurantes.Aplicacao.Context;
using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Service.Repository
{
    public class CategoryRepository : IRepository<Category>, ICategoryRepository
    {
        DatabaseContext _context;
        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Add(Category entity)
        {
            _context.Category.Add(entity);
        }

        public void Delete(Category entity)
        {
            _context.Category.Remove(entity);
        }

        public IEnumerable<Category> Get()
        {
            return _context.Category.ToList();
        }

        public IEnumerable<Category> Get(Expression<Func<Category, bool>> predicate)
        {
            return _context.Category.Where(predicate);
        }

        public Category GetOne(Expression<Func<Category, bool>> predicate)
        {
            return _context.Category.First(predicate); 
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
