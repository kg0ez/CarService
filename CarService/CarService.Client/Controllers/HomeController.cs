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
    public IActionResult HistoryPayment()
    {
        var typeAction = QueryHandler<QueryPurchaseHistoryType>.QueryTypeSerialize(QueryPurchaseHistoryType.Get);

        string json = QueryHandler<int>.Serialize(0, QueryType.PurchaseHistory, typeAction);

        string answer = Connection.Client(json);

        var history = JsonSerializer.Deserialize<List<PurchaseHistoryDto>>(answer);
        //List<PurchaseHistoryDto> ph = new List<PurchaseHistoryDto> {
        //    new PurchaseHistoryDto { Img = "cars/01.jpeg", Name = "bmw", Price = 2133, PurchaseTime = DateTime.Now }};
        return View(Enumerable.Reverse(history).ToList());
    }

    [HttpPost]
    public IActionResult Trash(int historyId)
    {
        var typeAction = QueryHandler<QueryPurchaseHistoryType>.QueryTypeSerialize(QueryPurchaseHistoryType.Delete);

        string json = QueryHandler<int>.Serialize(historyId, QueryType.PurchaseHistory, typeAction);

        string answer = Connection.Client(json);

        var history = JsonSerializer.Deserialize<bool>(answer);

        return RedirectToActionPermanent("HistoryPaymentPage", "Home");
    }

    [HttpPost]
    public IActionResult BuyDetail(Nullable<int> id)
    {
        if (!id.HasValue)
            return NotFound();

        var typeAction = QueryHandler<QueryPurchaseHistoryType>.QueryTypeSerialize(QueryPurchaseHistoryType.SyncDetail);

        string json = QueryHandler<int>.Serialize((int)id, QueryType.PurchaseHistory, typeAction);

        string answer = Connection.Client(json);

        var historyPayment = JsonSerializer.Deserialize<bool>(answer);

        return RedirectPermanent("~/Detail/Index");
    }

    [HttpPost]
    public IActionResult BuyCar(Nullable<int> id)
    {
        if (!id.HasValue)
            return NotFound();

        var typeAction = QueryHandler<QueryPurchaseHistoryType>.QueryTypeSerialize(QueryPurchaseHistoryType.SyncCar);

        string json = QueryHandler<int>.Serialize((int)id, QueryType.PurchaseHistory, typeAction);

        string answer = Connection.Client(json);

        var historyPayment = JsonSerializer.Deserialize<bool>(answer);

        return RedirectPermanent("~/Car/Index");
    }
}


