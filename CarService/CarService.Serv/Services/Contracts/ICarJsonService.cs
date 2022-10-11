using System;
namespace CarService.Serv.Services
{
    public interface ICarJsonService
    {
        string Get();
        string Get(int Id);
    }
}

