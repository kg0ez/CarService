using System;
namespace CarService.Common.ModelDto
{
    public class DetailStoreDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int DetailId { get; set; }
        public DetailDto Detail { get; set; }
    }
}

