using System;
using System.Text.Json;
using CarService.BusinessLogic.Services;
using CarService.Common.ModelDto;

namespace CarService.Serv.Services
{
    public class CarJsonService: ICarJsonService
    {
        private readonly ICarService _carService;

        public CarJsonService(ICarService carService)
        {
            _carService = carService;
        }

        public string Get()
        {
            var cars = _carService.Get();

            var response = JsonSerializer.Serialize<List<CarDto>>(cars);

            return response;
        }
        public string Get(int Id)
        {
            var cars = _carService.Get(Id);

            var response = JsonSerializer.Serialize<CarDto>(cars);

            return response;
        }
    }
}

