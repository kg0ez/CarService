using System;
namespace CarService.Serv.Services
{
    public interface IDetailJsonService
    {
        string Get();
        string Get(int Id);
    }
}

