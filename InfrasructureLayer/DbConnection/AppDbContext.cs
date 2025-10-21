using System.Reflection;
using CoreLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InfrasructureLayer.DbConnection;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    
    public DbSet<CarModel>? Cars { get; set; } 
    public DbSet<EngineModel>? Engines { get; set; }
    public DbSet<OrderModel>? Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        
        //One -> many
        modelBuilder.Entity<OrderModel>().HasOne(o => o.Car).WithMany(o => o.Orders).HasForeignKey(o => o.CarId);
            
        //Many -> many
        modelBuilder.Entity<CarModel>().HasMany(c => c.Engines).WithMany(e => e.Cars)
            .UsingEntity(j => j.ToTable("CarEngine"));

    }
    
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=NewCarShowRoomDb;Username=postgres;Password=1111");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}