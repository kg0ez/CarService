using System;
using System.Text.Json;
using CarService.Common.Enums;
using CarService.Common.ModelDto;
using static System.Reflection.Metadata.BlobBuilder;

namespace CarService.Serv.Services
{
    public class MethodService: IMethodService
    {
        private readonly ICarJsonService _carJsonService;
        private readonly IDetailJsonService _detailJsonService;
        private readonly IBasketJsonService _basketJsonService;
        private readonly IStoreJsonService _storeJsonService;
        private readonly IPurchaseHistoryJsonService _purchaseHistoryJsonService;


        public MethodService(ICarJsonService carJsonService, IDetailJsonService detailJsonService,
            IBasketJsonService basketJsonService, IStoreJsonService storeJsonService,
            IPurchaseHistoryJsonService purchaseHistoryJsonService)
        {
            _carJsonService = carJsonService;
            _detailJsonService = detailJsonService;
            _basketJsonService = basketJsonService;
            _storeJsonService = storeJsonService;
            _purchaseHistoryJsonService = purchaseHistoryJsonService;
        }

        public string Car(QueryCarType query, string obj)
        {
            if (query == QueryCarType.GetCars)
            {
                return _carJsonService.Get();
            }
            else if (query == QueryCarType.Get)
            {
                int carId = JsonSerializer.Deserialize<int>(obj);
                return _carJsonService.Get(carId);
            }
            throw new Exception("--");
        }
        public string Store(QueryStoreType query, string obj)
        {
            if (query == QueryStoreType.Get)
            {
                return _storeJsonService.Get();
            }
            throw new Exception("--");
        }

        public string Detail(QueryDetailType query, string obj)
        {
            if (query == QueryDetailType.GetDetails)
            {
                return _detailJsonService.Get();
            }
            else if (query == QueryDetailType.Get)
            {
                int carId = JsonSerializer.Deserialize<int>(obj);
                return _detailJsonService.Get(carId);
            }
            throw new Exception("--");
        }

        public string Basket(QueryBasketType query, string obj)
        {
            if (query == QueryBasketType.Get)
            {
                return _basketJsonService.Get();
            }
            else if (query == QueryBasketType.Add)
            {
                var bookId = JsonSerializer.Deserialize<int>(obj);
                return _basketJsonService.Add(bookId);
            }
            else if (query == QueryBasketType.Delete)
            {
                var id = JsonSerializer.Deserialize<int>(obj);
                return _basketJsonService.Delete(id);
            }
            else if (query == QueryBasketType.GetIdItem)
            {
                var id = JsonSerializer.Deserialize<int>(obj);
                return _basketJsonService.GetIdItem(id);
            }
            throw new Exception("--");
        }
        public string History(QueryPurchaseHistoryType query, string obj)
        {
            if (query == QueryPurchaseHistoryType.Get)
                return _purchaseHistoryJsonService.Get();

            else if (query == QueryPurchaseHistoryType.SyncDetail)
                return _purchaseHistoryJsonService.SyncDetail(obj);

            else if (query == QueryPurchaseHistoryType.SyncCar)
                return _purchaseHistoryJsonService.SyncCar(obj);

            else if (query == QueryPurchaseHistoryType.Delete)
                return _purchaseHistoryJsonService.Delete(obj);

            throw new Exception("History method wasn`t found");
        }
    }
}

