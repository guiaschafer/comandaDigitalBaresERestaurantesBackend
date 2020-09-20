using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Context.Configurations
{
    public class OrderItenEntityTypeConfiguration : IEntityTypeConfiguration<OrderIten>
    {
        public void Configure(EntityTypeBuilder<OrderIten> builder)
        {
            builder.ToTable("OrderIten");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Quantity).IsRequired();

            builder.HasOne(o => o.Product).WithOne().HasForeignKey<OrderIten>(o => o.IdProduct);
        }
    }
}
