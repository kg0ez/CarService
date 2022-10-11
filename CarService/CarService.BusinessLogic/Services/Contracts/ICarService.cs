using System;
using CarService.Common.ModelDto;

namespace CarService.BusinessLogic.Services
{
    public interface ICarService
    {
        void Sync();
        List<CarDto> Get();
        CarDto Get(int Id);
    }
}

