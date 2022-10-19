using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Clients;
using Domain.Clients.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ClientTypeConfiguration : BasicEntityTypeConfiguration<Client>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients").HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.OwnsOne(p => p.Name, name =>
            {
                name.Property(pp => pp.FirstName)
                    .HasColumnName("FirstName")
                    .HasMaxLength(50)
                    .IsRequired();

                name.Property(pp => pp.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(50)
                    .IsRequired();
            });

            builder.Property(p => p.Email)
                .HasConversion(p => p.Value, email => Email.Create(email).Value)
                .HasColumnName("Email")
                .IsRequired();
        }
    }
}
