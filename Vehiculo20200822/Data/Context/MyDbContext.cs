using Vehiculo20200822.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Vehiculo20200822.Data.Context;

public class Vehiculo20200822DbContext : DbContext, IVehiculoDbContext
{
    public Vehiculo20200822DbContext(DbContextOptions options) : base(options)
    {

    }
    public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}

public interface IVehiculoDbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }

    public int SaveChanges();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}