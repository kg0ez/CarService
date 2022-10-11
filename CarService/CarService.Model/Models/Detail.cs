using System;
namespace CarService.Model.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Img { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Weight { get; set; }

        public int CostId { get; set; }
        public Cost Cost { get; set; }

        public DetailStore DetailStore { get; set; }

        public Basket Basket { get; set; }
    }
}

