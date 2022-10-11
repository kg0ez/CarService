﻿using System;
using System.Reflection.PortableExecutable;

namespace CarService.Common.ModelDto
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Img { get; set; } = null!;

        public int CharacteristicsId { get; set; }
        public CharacteristicDto Characteristics { get; set; }

        public CostDto Cost { get; set; }
    }
}

