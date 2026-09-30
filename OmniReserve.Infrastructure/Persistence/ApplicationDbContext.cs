using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace OmniReserve.Infrastructure.Peristence; 

public class ApplicationDbContext : DbContext
{
    //La aplicacion del db de agrego de manera correcta en la capa Infrastructure
    public ApplicationDbContext (DbContextOptions <ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }


}