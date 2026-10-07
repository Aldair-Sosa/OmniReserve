using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OmniReserve.Domain.Entities;

namespace OmniReserve.Infrastructure.Peristence; 

public class ApplicationDbContext : DbContext
{
    //La aplicacion del db de agrego de manera correcta en la capa Infrastructure
    public ApplicationDbContext (DbContextOptions <ApplicationDbContext> options) : base(options)
    {
        
    }

//Hola como estas 
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }


}