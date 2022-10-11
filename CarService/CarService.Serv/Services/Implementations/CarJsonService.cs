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
            var books = _carService.Get();

            var response = JsonSerializer.Serialize<List<CarDto>>(books);

            return response;
        }
    }
}

