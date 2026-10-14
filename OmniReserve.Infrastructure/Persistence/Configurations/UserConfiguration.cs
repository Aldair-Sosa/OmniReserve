using OmniReserve.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniReserve.Domain.ValueObjects;

namespace OmniReserve.Infrastructure.Peristence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

         builder.Property(p => p.Id);
         

         builder.Property(user => user.Email)
               .HasConversion(
                   emailObj => emailObj.Value, // Cómo grabar (C# a SQL)
                   emailStr => new EmailAddress(emailStr) // Cómo leer (SQL a C#)
               )
               .HasColumnName("Email") // Fuerza el nombre de la columna en la BD
               .HasMaxLength(255)
               .IsRequired();

        builder.HasIndex(user => user.Email)
               .IsUnique();

         
         builder.Property(p => p.FirstName)
         .IsRequired()
         .HasMaxLength(75); 

         builder.Property(p => p.LastName)
         .IsRequired()
         .HasMaxLength(75); 

    }

    
}