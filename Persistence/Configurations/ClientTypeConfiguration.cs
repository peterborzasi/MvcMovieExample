using Domain.Entities.Clients;
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
                    .HasMaxLength(20)
                    .IsRequired();

                name.Property(pp => pp.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(20)
                    .IsRequired();
            });

            builder.Property(p => p.Email)
                .HasConversion(p => p.Value, email => Email.Create(email).Value)
                .HasColumnName("Email")
                .IsRequired();

            builder.OwnsOne(p => p.Address, address =>
            {
                address.Property(pp => pp.Street)
                    .HasColumnName("Street")
                    .HasMaxLength(20)
                    .IsRequired();

                address.Property(pp => pp.Number)
                    .HasColumnName("Number")
                    .HasMaxLength(10)
                    .IsRequired();

                address.Property(pp => pp.City)
                    .HasColumnName("City")
                    .HasMaxLength(20)
                    .IsRequired();

                address.Property(pp => pp.County)
                    .HasColumnName("County")
                    .HasMaxLength(20)
                    .IsRequired();

                address.Property(pp => pp.Postcode)
                    .HasColumnName("Postcode")
                    .HasMaxLength(10)
                    .IsRequired();

                address.Property(pp => pp.Country)
                    .HasColumnName("Country")
                    .HasMaxLength(20)
                    .IsRequired();
            });
        }
    }
}