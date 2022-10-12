using System;
namespace CarService.Serv.Services
{
    public interface IBasketJsonService
    {
        string Add(int detailId);
        string Delete(int id);
        string Get();
        string GetIdItem(int id);
    }
}

