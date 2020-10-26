using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Context.Configurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Value).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.UrlImage).IsRequired();

            builder.HasOne<Category>(p => p.Category).WithMany(c => c.ListOfProducts).HasForeignKey(p => p.IdCategory);

            
        }
    }
}
