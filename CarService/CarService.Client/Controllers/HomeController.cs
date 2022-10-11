using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarService.Client.Models;

namespace CarService.Client.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
}

