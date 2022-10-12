using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CarService.Client.ClientConnection;
using CarService.Client.Handlers;
using CarService.Common.Enums;
using CarService.Common.ModelDto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarService.Client.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            var typeAction = QueryHandler<QueryStoreType>.QueryTypeSerialize(QueryStoreType.Get);

            string json = QueryHandler<int>.Serialize(0, QueryType.Store, typeAction);

            string answer = Connection.Client(json);

            var store = JsonSerializer.Deserialize<StoreDto>(answer);

            return View(store);
        }
    }
}

