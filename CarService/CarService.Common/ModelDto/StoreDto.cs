using System;
namespace CarService.Common.ModelDto
{
    public class StoreDto
    {
        public List<CarStoreDto> CarStores { get; set; }
        public List<DetailStoreDto> DetailStores { get; set; }
    }
}

