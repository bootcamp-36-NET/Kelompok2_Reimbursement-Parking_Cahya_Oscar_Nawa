using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReimbursementParkingAPI.ViewModels;

namespace ReimbursementParkingClient.Controllers
{
    public class ViewRequestController : Controller
    {

        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44322/api/")
        };

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult LoadRequest()
        {
            IEnumerable<ReimbursementVM> reimbursementVMs = null;

            var getId = HttpContext.Session.GetString("Id");

            var authToken = HttpContext.Session.GetString("JWToken");
            client.DefaultRequestHeaders.Add("Authorization", authToken);

            var resTask = client.GetAsync("RequestReimbursementParkings/" + getId);
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<ReimbursementVM>>();
                readTask.Wait();
                reimbursementVMs = readTask.Result;
            }
            else
            {
                reimbursementVMs = Enumerable.Empty<ReimbursementVM>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(reimbursementVMs);
        }

        public JsonResult LoadRequestReq(string id)
        {
            ReimbursementVM reimbursementVMs = null;

            var getId = HttpContext.Session.GetString("JWToken");
            client.DefaultRequestHeaders.Add("Authorization", getId);


            var resTask = client.GetAsync("ViewRequests/" + id);
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var getJson = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                reimbursementVMs = JsonConvert.DeserializeObject<ReimbursementVM>(getJson);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(reimbursementVMs);
        }

        public IActionResult Delete(int id)
        {
            var authToken = HttpContext.Session.GetString("JWToken");
            client.DefaultRequestHeaders.Add("Authorization", authToken);

            var result = client.DeleteAsync("RequestReimbursementParkings/" + id).Result;
            return Json(result);
        }
    }
}
