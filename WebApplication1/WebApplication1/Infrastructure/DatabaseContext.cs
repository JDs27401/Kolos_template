using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<Komponent> Components { get; set; } 
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; } 
    public DbSet<ComponentTypes> ComponentTypes { get; set; } 
    public DbSet<PCs> PCs { get; set; }
    public DbSet<PcComponents> PcComponents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PCs>().HasData([
            new PCs { Id = 1, Name = "ROG Strix", Warranty = 5, Weight = 10.5f, CreatedAt = DateTime.Now, PcComponents = {}, Stock = 10},
            new PCs { Id = 2, Name = "ROG Strix", Warranty = 5, Weight = 9.5f, CreatedAt = DateTime.Now, PcComponents = {}, Stock = 9},
            new PCs { Id = 3, Name = "ROG Strix", Warranty = 5, Weight = 8.5f, CreatedAt = DateTime.Now, PcComponents = {}, Stock = 8}
        ]);
    }
}