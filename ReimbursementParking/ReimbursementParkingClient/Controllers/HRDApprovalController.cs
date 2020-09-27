using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public IActionResult GetAllRequestHRD()
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

        public ActionResult<ExpandoObject> ApproveRequest(int id)
        {
            //var authToken = HttpContext.Session.GetString("JWToken");
            //client.DefaultRequestHeaders.Add("Authorization", authToken);

            var resTask = client.GetAsync("HRDApprovals/approve/" + id);
            resTask.Wait();

            var result = resTask.Result;
            var responseData = result.Content.ReadAsStringAsync().Result;

            dynamic resultVM = new ExpandoObject();
            resultVM.Item1 = result;
            resultVM.Item2 = responseData;

            return Json(resultVM);
        }

        public ActionResult<ExpandoObject> RejectRequest(RejectVM rejectVM)
        {
            //var authToken = HttpContext.Session.GetString("JWToken");
            //client.DefaultRequestHeaders.Add("Authorization", authToken);

            string stringData = JsonConvert.SerializeObject(rejectVM);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            var resTask = client.PutAsync("HRDApprovals/reject/" + rejectVM.RequestId, contentData);
            resTask.Wait();

            var result = resTask.Result;
            var responseData = result.Content.ReadAsStringAsync().Result;

            dynamic resultVM = new ExpandoObject();
            resultVM.Item1 = result;
            resultVM.Item2 = responseData;

            return Json(resultVM);
        }

        public ActionResult<ExpandoObject> DownloadFolder(int id)
        {
            Blob responseData = null;

            //var authToken = HttpContext.Session.GetString("JWToken");
            //client.DefaultRequestHeaders.Add("Authorization", authToken);

            var resTask = client.GetAsync("HRDApprovals/GetFile/" + id);
            resTask.Wait();
            var result = resTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Blob>();
                readTask.Wait();
                responseData = readTask.Result;
            }

            dynamic resultVM = new ExpandoObject();
            resultVM.Item1 = result;
            resultVM.Item2 = responseData;

            return Json(resultVM);
        }
    }
}
