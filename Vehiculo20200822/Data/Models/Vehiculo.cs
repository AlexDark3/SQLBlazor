using System.ComponentModel.DataAnnotations;
namespace Vehiculo20200822.Data.Models;

public class Vehicle
{

    public int Id { get; set; }
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int Year { get; set; }
    public string Color { get; set; } = null!;


    public static Vehicle Crear(string brand, string color, string model, int year)
    {
        return new Vehicle()
        {
            Id = 0,
            Brand = brand,
            Model = model,
            Year = year,
            Color = color
        };
    }

    public void Update(string brand, string model, int year, string color)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Color = color;

    }
}
