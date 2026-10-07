using OmniReserve.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace OmniReserve.Infrastructure.Peristence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

         builder.Property(p => p.Id);
         

         builder.Property(p => p.Email)
         .IsRequired()
         .HasMaxLength(100); 

         
         builder.Property(p => p.FirstName)
         .IsRequired()
         .HasMaxLength(75); 

         builder.Property(p => p.LastName)
         .IsRequired()
         .HasMaxLength(75); 

    }

    
}