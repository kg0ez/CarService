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

        public MethodService(ICarJsonService carJsonService)
        {
            _carJsonService = carJsonService;
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
    }
}

