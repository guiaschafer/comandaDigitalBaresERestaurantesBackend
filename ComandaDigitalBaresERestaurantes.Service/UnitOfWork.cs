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
        private OrderRepository _orderRepository;
        private ClientRepository _clientRepository;
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

        public IRepository<Client> ClientRepository
        {
            get
            {
                return _clientRepository = _clientRepository ?? new ClientRepository(_context);
            }
        }
        public IRepository<Order> OrderRepository
        {
            get
            {
                return _orderRepository = _orderRepository ?? new OrderRepository(_context);
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
