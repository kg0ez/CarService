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
            else if (query.Type == QueryType.Detail)
            {
                var nameMethod = JsonSerializer.Deserialize<QueryDetailType>(query.TypeAction);
                return methodService.Detail(nameMethod, query.Object);
            }
            else if (query.Type == QueryType.Basket)
            {
                var nameMethod = JsonSerializer.Deserialize<QueryBasketType>(query.TypeAction);
                return methodService.Basket(nameMethod, query.Object);
            }
            else if (query.Type == QueryType.Store)
            {
                var nameMethod = JsonSerializer.Deserialize<QueryStoreType>(query.TypeAction);
                return methodService.Store(nameMethod, query.Object);
            }
            else if (query.Type == QueryType.PurchaseHistory)
            {
                var nameMethod = JsonSerializer.Deserialize<QueryPurchaseHistoryType>(query.TypeAction);
                return methodService.History(nameMethod, query.Object);
            }

            throw new Exception("Type wasn`t found");
        }
    }
}

