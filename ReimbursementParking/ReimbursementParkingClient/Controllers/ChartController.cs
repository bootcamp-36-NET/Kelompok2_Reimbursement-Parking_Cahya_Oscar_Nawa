using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReimbursementParkingAPI.ViewModels;

namespace ReimbursementParkingClient.Controllers
{
    public class ChartController : Controller
    {
        readonly HttpClient http = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44322/api/")
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadPie()
        {
            IEnumerable<PieChartVM> pie = null;

            var token = HttpContext.Session.GetString("JWToken");
            http.DefaultRequestHeaders.Add("Authorization", token);

            var resTask = http.GetAsync("charts/pie");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<PieChartVM>>();
                readTask.Wait();
                pie = readTask.Result;
            }
            else
            {
                pie = Enumerable.Empty<PieChartVM>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(pie);
        }

        public IActionResult LoadBar()
        {
            IEnumerable<ChartVM> bar = null;

            var token = HttpContext.Session.GetString("JWToken");
            http.DefaultRequestHeaders.Add("Authorization", token);

            var resTask = http.GetAsync("charts/bar");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<ChartVM>>();
                readTask.Wait();
                bar = readTask.Result;
            }
            else
            {
                bar = Enumerable.Empty<ChartVM>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(bar);
        }
    }
}
