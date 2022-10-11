using System;
namespace CarService.Model.Models
{
    public class PurchaseHistory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Img { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime PurchaseTime { get; set; } = DateTime.Now;
    }
}

