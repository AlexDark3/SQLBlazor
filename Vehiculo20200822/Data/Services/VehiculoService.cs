using Vehiculo20200822.Data.Context;
using Vehiculo20200822.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Vehiculo20200822.Data.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehiculoDbContext _context;

    public VehicleService(IVehiculoDbContext context)
    {
        _context = context;
    }


    public async Task<int> Crear(string brand, string model, int year, string color)
    {
        try
        {
            var vehicle = Vehicle.Crear(brand, color, model, year);
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle.Id;
        }
        catch
        {
            return 0;
        }
    }
    public async Task<List<Vehicle>> Consultar(string filtro = "")
    {
        try
        {

            var vehicles = await _context.Vehicles
            .Where(p => p.Brand.Contains(filtro))
            .ToListAsync();

            return vehicles;
        }
        catch
        {
            return null!;
        }
    }

    public async Task Editar(int Id, string brand, string model, int year, string color)
    {
        var vehicle = await _context.Vehicles
        .FirstOrDefaultAsync(p => p.Id == Id);
        if (vehicle != null)
        {
            vehicle.Update(brand, model, year, color);
            await _context.SaveChangesAsync();
        }
    }
    public async Task Eliminar(int Id)
    {
        var vehicle = await _context.Vehicles
        .FirstOrDefaultAsync(p => p.Id == Id);
        if (vehicle != null)
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }
    }
}
public interface IVehicleService
{
    public Task<int> Crear(string brand, string model, int year, string color);
    public Task<List<Vehicle>> Consultar(string filtro = "");
    public Task Editar(int Id, string brand, string model, int year, string color);
    public Task Eliminar(int Id);
}