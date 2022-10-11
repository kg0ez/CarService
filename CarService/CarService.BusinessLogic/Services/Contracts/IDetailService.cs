using System;
using CarService.Common.ModelDto;

namespace CarService.BusinessLogic.Services
{
    public interface IDetailService
    {
        void Sync();
        List<DetailDto> Get();
        DetailDto Get(int Id);
    }
}

