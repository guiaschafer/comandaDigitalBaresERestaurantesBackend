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
    public class UserRepository : IRepository<User>, IUserRepository
    {
        DatabaseContext _context;
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Add(User entity)
        {
            _context.User.Add(entity);
        }

        public void Delete(User entity)
        {
            _context.User.Remove(entity);
        }

        public IEnumerable<User> Get()
        {
            return _context.User.ToList();
        }

        public IEnumerable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _context.User.Where(predicate);
        }

        public User GetOne(Expression<Func<User, bool>> predicate)
        {
            return _context.User.FirstOrDefault(predicate);
        }

        public void Update(User entity)
        {
            _context.User.Update(entity);
        }
    }
}
