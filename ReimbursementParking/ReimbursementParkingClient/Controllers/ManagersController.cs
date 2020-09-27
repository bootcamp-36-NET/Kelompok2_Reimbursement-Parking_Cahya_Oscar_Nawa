using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReimbursementParkingAPI.ViewModels;

namespace ReimbursementParkingClient.Controllers
{
    public class ManagersController : Controller
    {
        readonly HttpClient http = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44322/api/")
        };
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult LoadApprovalManager()
        {
            IEnumerable<StatusVM> reimbursementVM = null;
            //var token = HttpContext.Session.GetString("JWToken");
            //http.DefaultRequestHeaders.Add("Authorization", token);
            var restTask = http.GetAsync("Manager/requestHRD");
            restTask.Wait();

            var result = restTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<StatusVM>>();
                readTask.Wait();
                reimbursementVM = readTask.Result;
            }
            return Json(reimbursementVM);
        }
        public JsonResult LoadApprovedByManager()
        {
            IEnumerable<StatusVM> reimbursementVM = null;
            //var token = HttpContext.Session.GetString("JWToken");
            //http.DefaultRequestHeaders.Add("Authorization", token);
            var restTask = http.GetAsync("Manager/approve");
            restTask.Wait();

            var result = restTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<StatusVM>>();
                readTask.Wait();
                reimbursementVM = readTask.Result;
            }
            return Json(reimbursementVM);
        }
        public JsonResult LoadRejectedByManager()
        {
            IEnumerable<StatusVM> reimbursementVM = null;
            //var token = HttpContext.Session.GetString("JWToken");
            //http.DefaultRequestHeaders.Add("Authorization", token);
            var restTask = http.GetAsync("Manager/reject");
            restTask.Wait();

            var result = restTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<StatusVM>>();
                readTask.Wait();
                reimbursementVM = readTask.Result;
            }
            return Json(reimbursementVM);
        }
        public JsonResult Update(StatusVM statusVM, int Id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(statusVM);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //var token = HttpContext.Session.GetString("JWToken");
                //http.DefaultRequestHeaders.Add("Authorization", token);
                if (Id > 0)
                {
                    var result = http.PutAsync("manager/" + Id, byteContent).Result;
                    return Json(result);
                }

                return Json(404);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult UpdateReject(StatusVM statusVM, int Id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(statusVM);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //var token = HttpContext.Session.GetString("JWToken");
                //http.DefaultRequestHeaders.Add("authorization", token);
                if (Id > 0)
                {
                    var result = http.PutAsync("manager/rejectReason/" + Id, byteContent).Result;
                    return Json(result);
                }

                return Json(404);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult GetById(int id)
        {
            StatusVM divisionVMs = null;
            var resTask = http.GetAsync("manager/" + id);
            resTask.Wait();
            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var getJson = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                divisionVMs = JsonConvert.DeserializeObject<StatusVM>(getJson);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }

            return Json(divisionVMs);
        }

    }
}
