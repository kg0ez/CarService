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
}

