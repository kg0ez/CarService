using System;
namespace CarService.Model.Models
{
    public class CarStore:BaseStore
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}

