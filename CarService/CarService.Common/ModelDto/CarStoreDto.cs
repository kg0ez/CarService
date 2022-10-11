using System;
using System.Runtime.ConstrainedExecution;

namespace CarService.Common.ModelDto
{
    public class CarStoreDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int CarId { get; set; }
        public CarDto Car { get; set; }
    }
}

