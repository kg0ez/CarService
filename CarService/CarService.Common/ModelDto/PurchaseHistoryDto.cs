using System;
namespace CarService.Common.ModelDto
{
    public class PurchaseHistoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Img { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime PurchaseTime { get; set; }
    }
}

