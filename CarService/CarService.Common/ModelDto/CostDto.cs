using System;
using System.Runtime.ConstrainedExecution;

namespace CarService.Common.ModelDto
{
    public class CostDto
    {
        public decimal Price { get; set; }
        public decimal CostDelivery { get; set; }
        public string TimeDelivery { get; set; } = null!;
    }
}

