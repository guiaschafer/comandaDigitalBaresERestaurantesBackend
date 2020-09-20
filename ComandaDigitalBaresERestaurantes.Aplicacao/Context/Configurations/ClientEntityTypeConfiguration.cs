using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Context.Configurations
{
    public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.LastName).IsRequired();
            builder.Property(c => c.Cpf).IsRequired();

            builder.HasOne(c => c.User).WithOne(u => u.Client).HasForeignKey<Client>(c => c.IdUser);
            builder.HasMany(c => c.ListOfOrders).WithOne(o => o.Client).HasForeignKey(o=> o.IdClient);
        }
    }
}
