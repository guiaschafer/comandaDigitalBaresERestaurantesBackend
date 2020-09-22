using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.UniOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext context;

        public UnitOfWork(TContext context)
        {
            this.context = context;
        }

        public int SaveChanges()
        {
            var entities = context.ChangeTracker
             .Entries<BaseEntity>()
             .Where(e => e.State == EntityState.Added
                 || e.State == EntityState.Modified)
             .ToList();

            return context.SaveChanges();
        }
    }
}
