using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReimbursementParkingClient.ViewModels;

namespace ReimbursementParkingClient.Controllers
{
    public class DashboardController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://winarto-001-site1.dtempurl.com/api/")
        };
        public IActionResult Index()
        {
            if (!HttpContext.Session.IsAvailable)
            {
                return Redirect("/login");
            }
            if (HttpContext.Session.GetString("Id") == null)
            {
                return Redirect("/login");
            }
            return View();
        }

        [Route("profile")]
        public IActionResult Profile()
        {
            return View("~/Views/Dashboard/Profile.cshtml");
        }

        [Route("GetProfile")]
        public IActionResult GetProfile()
        {
            UserVM data = null;
            var id = HttpContext.Session.GetString("Id");
            client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWToken"));
            var resTask = client.GetAsync("users/" + id);
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                data = JsonConvert.DeserializeObject<UserVM>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            return Json(data);
        }

        [Route("updProfile")]
        public IActionResult UpdProfile(UserVM data)
        {
            var id = HttpContext.Session.GetString("Id");
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                if (data.Id == id)
                {
                    client.DefaultRequestHeaders.Add("Authorization", HttpContext.Session.GetString("JWToken"));
                    var result = client.PutAsync("users/" + id, byteContent);
                    result.Wait();
                    var resData = result.Result;

                    var responseData = resData.Content.ReadAsStringAsync().Result;

                  
                    HttpContext.Session.Remove("Name");
                    HttpContext.Session.SetString("Name", data.Name);
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
