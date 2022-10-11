using System;
using System.Text.Json;
using CarService.BusinessLogic.Services;
using CarService.Common.ModelDto;

namespace CarService.Serv.Services
{
    public class DetailJsonService: IDetailJsonService
    {
        private readonly IDetailService _detailService;

        public DetailJsonService(IDetailService detailService)
        {
            _detailService = detailService;
        }

        public string Get()
        {
            var details = _detailService.Get();

            var response = JsonSerializer.Serialize<List<DetailDto>>(details);

            return response;
        }

        public string Get(int Id)
        {
            var detail = _detailService.Get(Id);

            var response = JsonSerializer.Serialize<DetailDto>(detail);

            return response;
        }
    }
}

