using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Newtonsoft.Json;
using ReimbursementParkingClient.ViewModels;

namespace ReimbursementParkingClient.Controllers
{
    public class MainController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://winarto-001-site1.dtempurl.com/api/")
        };

        public IActionResult Index()
        {
            return View();
        }
        [Route("login")]
        public IActionResult Login()
        {
            if (HttpContext.Session.IsAvailable)
            {
                if (HttpContext.Session.GetString("Id") != null)
                {
                    return Redirect("~/Views/Layout/_Login.cshtml");
                }
            }
            return View();
        }

        [Route("login-validate")]
        public ActionResult<ExpandoObject> Login(LoginViewModel loginVM)
        {
            dynamic resultVM = new ExpandoObject();
            string stringData = JsonConvert.SerializeObject(loginVM);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            
            var resTask = client.PostAsync("reimburs/login", contentData);
            resTask.Wait();
            var result = resTask.Result;
            var responseData = result.Content.ReadAsStringAsync().Result;
            resultVM.Item1 = result;
            resultVM.Item2 = responseData;

            if (result.IsSuccessStatusCode)
            {
                var token = new JwtSecurityToken(jwtEncodedString: responseData);
                var authToken = "Bearer " + responseData;
                var isVerified = token.Claims.First(c => c.Type == "VerifyCode").Value;

                HttpContext.Session.SetString("Id", token.Claims.First(c => c.Type == "Id").Value);
                HttpContext.Session.SetString("RoleName", token.Claims.First(c => c.Type == "RoleName").Value);
                HttpContext.Session.SetString("Name", token.Claims.First(c => c.Type == "Name").Value);
                HttpContext.Session.SetString("Email", token.Claims.First(c => c.Type == "Email").Value);
                HttpContext.Session.SetString("VerifyCode", token.Claims.First(c => c.Type == "VerifyCode").Value);
                HttpContext.Session.SetString("DepartmentName", token.Claims.First(c => c.Type == "DepartmentName").Value);
                HttpContext.Session.SetString("JWToken", authToken);

                resultVM.Item3 = isVerified;

                return Json(resultVM);
            }

            resultVM.Item3 = "";

            return Json(resultVM);
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/login");
        }
    }
}
