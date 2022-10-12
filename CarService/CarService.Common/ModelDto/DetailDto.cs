using System;
namespace CarService.Common.ModelDto
{
    public class DetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Img { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Weight { get; set; }

        public CostDto Cost { get; set; }

        public SimpleDetailStore DetailStore { get; set; }

    }
}

