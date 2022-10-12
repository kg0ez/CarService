using System;
using System.Text.Json;
using CarService.BusinessLogic.Services;
using CarService.Common.ModelDto;

namespace CarService.Serv.Services
{
    public class StoreJsonService: IStoreJsonService
    {
        private readonly IStoreService _storeService;

        public StoreJsonService(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public string Get()
        {
            var store = _storeService.Get();

            var response = JsonSerializer.Serialize<StoreDto>(store);

            return response;
        }
    }
}

