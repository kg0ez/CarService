using System;
using CarService.Common.ModelDto;

namespace CarService.BusinessLogic.Services
{
    public interface IBasketService
    {
        bool Add(int detailId);
        bool Delete(int id);
        List<BasketDto> Get();
        int GetIdItem(int id);
    }
}

