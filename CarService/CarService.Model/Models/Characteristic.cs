using System;
namespace CarService.Model.Models
{
    public class Characteristic
    {
        public int Id { get; set; }
        public string Transmission { get; set; } = null!;
        public string Carcase { get; set; } = null!;
        public string EngineType { get; set; } = null!;
        public string DriveUnit { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Mileage { get; set; }

        public Car Car { get; set; }
    }
}

