using System;
namespace CarService.Common.ModelDto
{
    public class BasketDto
    {
        public int Id { get; set; }

        public int DetailId { get; set; }
        public DetailDto Detail { get; set; }
    }
}

