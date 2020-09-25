using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
            IEnumerable<ReimbursementVM> reimbursementVM = null;
            //var token = HttpContext.Session.GetString("JWToken");
            //http.DefaultRequestHeaders.Add("Authorization", token);
            var restTask = http.GetAsync("Manager");
            restTask.Wait();

            var result = restTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ReimbursementVM>>();
                readTask.Wait();
                reimbursementVM = readTask.Result;
            }
            return Json(reimbursementVM, new Newtonsoft.Json.JsonSerializerSettings());
        }
        public JsonResult Update(StatusVM statusVM, int id)
        {
            try
            {
                var json = JsonConvert.SerializeObject(statusVM);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //var token = HttpContext.Session.GetString("JWToken");
                //http.DefaultRequestHeaders.Add("Authorization", token);
                if (statusVM.StatusId != 0)
                {
                    var result = http.PutAsync("manager/" + id, byteContent).Result;
                    return Json(result);
                }

                return Json(404);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
