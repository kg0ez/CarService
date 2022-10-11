using System;
namespace CarService.Model.Models
{
    public class Cost
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal CostDelivery { get; set; }
        public string TimeDelivery { get; set; } = null!;

        public Detail Detail { get; set; }
    }
}

