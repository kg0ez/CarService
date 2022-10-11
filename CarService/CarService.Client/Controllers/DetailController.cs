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
    public class DetailController : Controller
    {
        public IActionResult Index()
        {
            var typeAction = QueryHandler<QueryDetailType>.QueryTypeSerialize(QueryDetailType.GetDetails);

            string json = QueryHandler<int>.Serialize(0, QueryType.Detail, typeAction);

            string answer = Connection.Client(json);

            var cars = JsonSerializer.Deserialize<List<DetailDto>>(answer);

            return View(cars);
        }

        public IActionResult AboutDetail(Nullable<int> id)
        {
            if (!id.HasValue)
                return NotFound();

            var typeAction = QueryHandler<QueryDetailType>.QueryTypeSerialize(QueryDetailType.Get);

            string json = QueryHandler<int>.Serialize((int)id, QueryType.Detail, typeAction);

            string answer = Connection.Client(json);

            var detail = JsonSerializer.Deserialize<DetailDto>(answer);

            if (detail != null)
                return View(detail);

            return NotFound();
        }
    }
}

