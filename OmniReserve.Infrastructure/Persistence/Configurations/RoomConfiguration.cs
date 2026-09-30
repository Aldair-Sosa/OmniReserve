using OmniReserve.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace OmniReserve.Infrastructure.Persistence.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("Rooms");

         builder.Property(p => p.Id);

         builder.Property(p => p.RoomNumber)
         .IsRequired()
         .HasMaxLength(100); 

         builder.Property(p => p.PricePerNight)
         .IsRequired()
         .HasPrecision(18, 2); 

         builder.Property(p => p.Type)
         .IsRequired()
         .HasConversion<string>();
    }
}