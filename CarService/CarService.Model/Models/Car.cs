﻿using System;
namespace CarService.Model.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Img { get; set; } = null!;

        public int CharacteristicsId { get; set; }
        public Characteristic Characteristics { get; set; }

        public int CostId { get; set; }
        public Cost Cost { get; set; }

        public CarStore CarStore { get; set; }
    }
}
