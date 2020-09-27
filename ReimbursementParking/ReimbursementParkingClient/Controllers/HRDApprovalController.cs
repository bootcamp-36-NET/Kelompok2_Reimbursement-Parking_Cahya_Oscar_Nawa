using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReimbursementParkingAPI.Models;
using ReimbursementParkingAPI.ViewModels;

namespace ReimbursementParkingClient.Controllers
{
    public class HRDApprovalController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44322/api/")
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllRequestHRD()
        {
            IEnumerable<ApprovalViewModel> reimbursementRequest = null;

            //var authToken = HttpContext.Session.GetString("JWToken");
            //client.DefaultRequestHeaders.Add("Authorization", authToken);

            var resTask = client.GetAsync("HRDApprovals");
            resTask.Wait();

            var result = resTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ApprovalViewModel>>();
                readTask.Wait();
                reimbursementRequest = readTask.Result;
            }

            return Json(reimbursementRequest);
        }

        public ActionResult ApproveRequest(int id)
        {
            //var authToken = HttpContext.Session.GetString("JWToken");
            //client.DefaultRequestHeaders.Add("Authorization", authToken);

            var resTask = client.GetAsync("HRDApprovals/approve/" + id);
            resTask.Wait();

            var result = resTask.Result;
            var responseData = result.Content.ReadAsStringAsync().Result;

            return Json((result, responseData), new Newtonsoft.Json.JsonSerializerSettings());
        }

        public ActionResult RejectRequest(int id, string reason)
        {
            //var authToken = HttpContext.Session.GetString("JWToken");
            //client.DefaultRequestHeaders.Add("Authorization", authToken);
            var contentData = new StringContent(reason, System.Text.Encoding.UTF8, "application/json");

            var resTask = client.PutAsync("HRDApprovals/reject/" + id, contentData);
            resTask.Wait();

            var result = resTask.Result;
            var responseData = result.Content.ReadAsStringAsync().Result;

            return Json((result, responseData), new Newtonsoft.Json.JsonSerializerSettings());
        }

        public ActionResult DownloadFolder(int id)
        {
            Blob responseData = null;

            //var authToken = HttpContext.Session.GetString("JWToken");
            //client.DefaultRequestHeaders.Add("Authorization", authToken);

            var resTask = client.GetAsync("HRDApprovals/reject/" + id);
            resTask.Wait();
            var result = resTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Blob>();
                readTask.Wait();
                responseData = readTask.Result;
            }

            return Json((result, responseData), new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
