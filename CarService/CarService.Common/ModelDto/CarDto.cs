using System;
using System.Reflection.PortableExecutable;

namespace CarService.Common.ModelDto
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Img { get; set; } = null!;
        public decimal Cost { get; set; }

        public int CharacteristicsId { get; set; }
        public CharacteristicDto Characteristics { get; set; }

        public int AdditionalCharacteristicId { get; set; }
        public AdditionalCharacteristicDto AdditionalCharacteristic { get; set; }
    }
}

