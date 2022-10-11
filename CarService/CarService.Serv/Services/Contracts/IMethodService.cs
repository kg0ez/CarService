using System;
using CarService.Common.Enums;

namespace CarService.Serv.Services
{
    public interface IMethodService
    {
        string Car(QueryCarType query, string obj);
    }
}

