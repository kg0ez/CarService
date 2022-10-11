using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarService.Client.Models;
using CarService.Client.Handlers;
using CarService.Common.Enums;
using Microsoft.AspNetCore.Connections;
using System.Text.Json;
using CarService.Client.ClientConnection;
using CarService.Common.ModelDto;

namespace CarService.Client.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddBusket(Nullable<int> id)
    {
        if (!id.HasValue)
            return NotFound();

        var typeAction = QueryHandler<QueryBasketType>.QueryTypeSerialize(QueryBasketType.Add);

        string json = QueryHandler<int>.Serialize((int)id, QueryType.Basket, typeAction);

        string answer = Connection.Client(json);

        var isAdded = JsonSerializer.Deserialize<bool>(answer);

        if (!isAdded)
            return NotFound();
        return RedirectPermanent("~/Car/Index");
        //return RedirectToAction("~/Car/Index");
    }

    public IActionResult Basket()
    {
        var typeAction = QueryHandler<QueryBasketType>.QueryTypeSerialize(QueryBasketType.Get);

        string json = QueryHandler<int>.Serialize(0, QueryType.Basket, typeAction);

        string answer = Connection.Client(json);

        var basket = JsonSerializer.Deserialize<List<BasketDto>>(answer);

        return View(basket);
    }

    [HttpPost]
    public IActionResult DeleteBusket(Nullable<int> id)
    {
        if (!id.HasValue)
            return NotFound();

        var typeAction = QueryHandler<QueryBasketType>.QueryTypeSerialize(QueryBasketType.Delete);

        string json = QueryHandler<int>.Serialize((int)id, QueryType.Basket, typeAction);

        string answer = Connection.Client(json);

        var isDeleted = JsonSerializer.Deserialize<bool>(answer);

        if (!isDeleted)
            return NotFound();

        return RedirectToAction("Basket");
    }
}

