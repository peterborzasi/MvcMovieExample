using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MovieTypeConfiguration : BasicEntityTypeConfiguration<Movie>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies")
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(p => p.Title)
                .HasColumnName("Title")
                .IsRequired();

            builder.Property(p => p.ReleaseDate)
                .HasColumnName("ReleaseDate");

            builder.Property(p => p.Price)
                .HasColumnName("Price");

            builder.Property(p => p.Genre)
                .HasColumnName("Genre")
                .HasMaxLength(30);

            builder.Property(p => p.ClientId)
                .HasColumnName("ClientId")
                .IsRequired(false);

            builder.HasOne(p => p.Client)
                .WithMany(p => p.OwnedMovies)
                .HasForeignKey(fk => fk.ClientId);
        }
    }
    
}
