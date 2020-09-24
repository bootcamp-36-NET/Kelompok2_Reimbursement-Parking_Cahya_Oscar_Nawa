using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
            return View();
        }
        [Route("validate")]
        public IActionResult Validate(LoginViewModel loginVM)
        {
            if (loginVM.Email != null)
            {
                var jsonUserVM = JsonConvert.SerializeObject(loginVM);
                var buffer = System.Text.Encoding.UTF8.GetBytes(jsonUserVM);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var resTask = client.PostAsync("auths/login/", byteContent);
                resTask.Wait();
                var result = resTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync().Result;
                    if (data != "")
                    {
                        var handler = new JwtSecurityTokenHandler().ReadJwtToken(data);
                        var account = new LoginViewModel
                        {
                            Id = handler.Claims.Where(p => p.Type == "Id").Select(s => s.Value).FirstOrDefault(),
                            Email = handler.Claims.Where(p => p.Type == "Email").Select(s => s.Value).FirstOrDefault(),
                            Phone = handler.Claims.Where(p => p.Type == "Phone").Select(s => s.Value).FirstOrDefault(),
                            RoleName = handler.Claims.Where(p => p.Type == "RoleName").Select(s => s.Value).FirstOrDefault(),
                            Address = handler.Claims.Where(p => p.Type == "Address").Select(s => s.Value).FirstOrDefault(),
                            Name = handler.Claims.Where(p => p.Type == "Name").Select(s => s.Value).FirstOrDefault(),
                            Province = handler.Claims.Where(p => p.Type == "Province").Select(s => s.Value).FirstOrDefault(),
                            City = handler.Claims.Where(p => p.Type == "City").Select(s => s.Value).FirstOrDefault(),
                            SubDistrict = handler.Claims.Where(p => p.Type == "SubDistrict").Select(s => s.Value).FirstOrDefault(),
                            Village = handler.Claims.Where(p => p.Type == "Village").Select(s => s.Value).FirstOrDefault(),
                            ZipCode = handler.Claims.Where(p => p.Type == "ZipCode").Select(s => s.Value).FirstOrDefault(),

                        };

                        if (account.RoleName == "Admin" || account.RoleName == "Manager" || account.RoleName == "HRD" || account.RoleName == "Employee")
                        {
                            //    HttpContext.Session.SetString("Id", account.Id);
                            //    HttpContext.Session.SetString("Email", account.Email);
                            //    HttpContext.Session.SetString("Phone", account.Phone);
                            //    HttpContext.Session.SetString("RoleName", account.RoleName);
                            //    HttpContext.Session.SetString("Address", account.Address);
                            //    HttpContext.Session.SetString("Name", account.Name);
                            //    HttpContext.Session.SetString("Province", account.Province);
                            //    HttpContext.Session.SetString("City", account.City);
                            //    HttpContext.Session.SetString("SubDistrict", account.SubDistrict);
                            //    HttpContext.Session.SetString("Village", account.Village);
                            //    HttpContext.Session.SetString("ZipCode", account.ZipCode);
                            //HttpContext.Session.SetString("JWToken", "Bearer " + data);
                            if (account.RoleName == "Manager")
                            {
                                return Json(new { status = true, msg = "Login Successfully !" });
                            }
                            else if (account.RoleName == "HRD")
                            {
                                return Json(new { status = true, msg = "Login Successfully !" });
                            }
                            else
                            {
                                return Json(new { status = true, msg = "Login Successfully !" });
                            }
                        }
                        else
                        {
                            return Json(new { status = false, msg = "Please registration first." });
                        }
                    }
                    else
                    {
                        return Json(new { status = false, msg = "The data must be filled" });
                    }
                }
                else
                {
                    return Json(new { status = false, msg = "Something went wrong" });
                }
            }
            return Redirect("/login");

        }
    }
}
