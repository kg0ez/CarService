using System;
namespace CarService.Model.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Img { get; set; } = null!;
        public decimal Cost { get; set; }

        public int CharacteristicsId { get; set; }
        public Characteristic Characteristics { get; set; }

        public int AdditionalCharacteristicId { get; set; }
        public AdditionalCharacteristic AdditionalCharacteristic { get; set; }

        public CarStore CarStore { get; set; }
    }
}

