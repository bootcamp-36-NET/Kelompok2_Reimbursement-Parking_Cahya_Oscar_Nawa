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
    public class RequestReimbursementParkingController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44322/api/")
        };

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult LoadInitialCreateData()
        {
            InsertReimbursementVM model = new InsertReimbursementVM();
            model.EmployeeId = HttpContext.Session.GetString("Id");
            model.Name = HttpContext.Session.GetString("Name");

            return Json(model);
        }

        public ActionResult<ExpandoObject> CreateReimbursement([FromForm] InsertReimbursementVM model)
        { 
            var multiContent = new MultipartFormDataContent();
            var file = model.ReimbursementFile;
            if (file != null)
            {
                var fileStreamContent = new StreamContent(file.OpenReadStream());
                multiContent.Add(fileStreamContent, "ReimbursementFile", file.FileName);
            }
            multiContent.Add(new StringContent(model.EmployeeId.ToString()), "EmployeeId");
            multiContent.Add(new StringContent(model.Name.ToString()), "Name");
            multiContent.Add(new StringContent(model.ParkingAddress.ToString()), "ParkingAddress");
            multiContent.Add(new StringContent(model.ParkingName.ToString()), "ParkingName");
            multiContent.Add(new StringContent(model.PaymentType.ToString()), "PaymentType");
            multiContent.Add(new StringContent(model.PLATNumber.ToString()), "PLATNumber");
            multiContent.Add(new StringContent(model.TotalPrice.ToString()), "TotalPrice");
            multiContent.Add(new StringContent(model.VehicleType.ToString()), "VehicleType");
            multiContent.Add(new StringContent(model.VehicleOwner.ToString()), "VehicleOwner");

            //var authToken = HttpContext.Session.GetString("JWToken");
            //client.DefaultRequestHeaders.Add("Authorization", authToken);

            var resTask = client.PostAsync("RequestReimbursementParkings/" + model.EmployeeId, multiContent);
            resTask.Wait();

            var result = resTask.Result;

            var responseData = result.Content.ReadAsStringAsync().Result;

            return Json((result, responseData), new Newtonsoft.Json.JsonSerializerSettings());
        }

        public ActionResult LoadRequest()
        {
            IEnumerable<ReimbursementVM> reimbursementVMs = null;
            var getId = HttpContext.Session.GetString("id");
            var resTask = client.GetAsync("RequestReimbursementParkings/ " + getId);
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

        public IActionResult Delete(string id)
        {
            //client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("token"));
            var result = client.DeleteAsync("" + id).Result;
            return Json(result);
        }
    }
}
