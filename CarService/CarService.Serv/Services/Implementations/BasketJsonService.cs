using System;
using CarService.BusinessLogic.Services;
using CarService.Common.ModelDto;
using System.Text.Json;

namespace CarService.Serv.Services
{
    public class BasketJsonService: IBasketJsonService
    {
        private readonly IBasketService _basketService;

        public BasketJsonService(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public string Add(int detailId)
        {
            var answer = _basketService.Add(detailId);

            var response = JsonSerializer.Serialize<bool>(answer);

            return response;
        }

        public string Delete(int id)
        {
            var answer = _basketService.Delete(id);

            var response = JsonSerializer.Serialize<bool>(answer);

            return response;
        }

        public string Get()
        {
            var details = _basketService.Get();

            var response = JsonSerializer.Serialize<List<BasketDto>>(details);

            return response;
        }
    }
}

