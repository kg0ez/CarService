using System;
using CarService.Serv.Services;
using System.Text.Json;
using CarService.Common.Serv;
using CarService.Common.Enums;

namespace CarService.Serv.Handler
{
    public static class QueryHandler
    {
        public static string SearchType(
            ServerQuery query,
            IMethodService methodService)
        {

            if (query.Type == QueryType.Car)
            {
                var nameMethod = JsonSerializer.Deserialize<QueryCarType>(query.TypeAction);
                return methodService.Car(nameMethod, query.Object);
            }
            

            throw new Exception("Type wasn`t found");
        }
    }
}

