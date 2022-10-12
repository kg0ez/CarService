using System;
using System.Text.Json;
using CarService.BusinessLogic.Services;
using CarService.Common.ModelDto;

namespace CarService.Serv.Services
{
    public class PurchaseHistoryJsonService: IPurchaseHistoryJsonService
    {
        private readonly IPurchaseHistoryService _purchaseHistoryService;

        public PurchaseHistoryJsonService(IPurchaseHistoryService purchaseHistoryService)
        {
            _purchaseHistoryService = purchaseHistoryService;
        }

        public string Get()
        {
            var history = _purchaseHistoryService.Get();

            var response = JsonSerializer.Serialize<List<PurchaseHistoryDto>>(history);

            return response;
        }

        public string SyncDetail(string json)
        {
            var detailId = JsonSerializer.Deserialize<int>(json);

            var result = _purchaseHistoryService.SyncDetail(detailId);

            var response = JsonSerializer.Serialize<bool>(result);

            return response;
        }

        public string SyncCar(string json)
        {
            var carId = JsonSerializer.Deserialize<int>(json);

            var result = _purchaseHistoryService.SyncCar(carId);

            var response = JsonSerializer.Serialize<bool>(result);

            return response;
        }

        public string Delete(string json)
        {
            var id = JsonSerializer.Deserialize<int>(json);

            var result = _purchaseHistoryService.Delete(id);

            var response = JsonSerializer.Serialize<bool>(result);

            return response;
        }
    }
}

