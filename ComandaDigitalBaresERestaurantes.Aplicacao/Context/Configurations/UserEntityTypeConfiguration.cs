using ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Context.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Login).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Active).IsRequired();
            builder.Property(u => u.Perfil).IsRequired();
        }
    }
}
