using System;
using CarService.Common.Enums;

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
            throw new Exception("--");
        }
    }
}

