using System;
namespace CarService.Serv.Services
{
    public interface IPurchaseHistoryJsonService
    {
        string Delete(string json);
        string SyncDetail(string json);
        string SyncCar(string json);
        string Get();
    }
}

