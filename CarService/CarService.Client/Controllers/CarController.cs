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


namespace CarService.Client.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            var typeAction = QueryHandler<QueryCarType>.QueryTypeSerialize(QueryCarType.GetCars);

            string json = QueryHandler<int>.Serialize(0, QueryType.Car, typeAction);

            string answer = Connection.Client(json);

            var books = JsonSerializer.Deserialize<List<CarDto>>(answer);

            return View(books);
        }
    }
}

