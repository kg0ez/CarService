using System;
namespace CarService.Common.ModelDto
{
    public class CharacteristicDto
    {
        public string Transmission { get; set; } = null!;
        public string Carcase { get; set; } = null!;
        public string EngineType { get; set; } = null!;
        public string DriveUnit { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Mileage { get; set; }
    }
}

