using ComandaDigitalBaresERestaurantes.Aplicacao.Context;
using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using ComandaDigitalBaresERestaurantes.Interface;
using ComandaDigitalBaresERestaurantes.Interface.Repository;
using ComandaDigitalBaresERestaurantes.Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        public DatabaseContext _context;
        private Repository<User> _userRepository;
        private ProductRepository _productRepository;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IRepository<User> UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new Repository<User>(_context);
            }
        }

        public IRepository<Product> ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(_context);
            }
        }

        public int Commit()
        {
           return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
