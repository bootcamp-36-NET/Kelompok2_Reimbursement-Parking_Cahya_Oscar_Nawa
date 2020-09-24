﻿using System;
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
                            RoleName = handler.Claims.Where(p => p.Type == "RoleName").Select(s => s.Value).FirstOrDefault(),
                            Name = handler.Claims.Where(p => p.Type == "Name").Select(s => s.Value).FirstOrDefault()

                        };

                        if (account.RoleName == "Admin" || account.RoleName == "Manager" || account.RoleName == "HRD" || account.RoleName == "Employee")
                        {
                            HttpContext.Session.SetString("Id", account.Id);
                            HttpContext.Session.SetString("RoleName", account.RoleName);
                            HttpContext.Session.SetString("Name", account.Name);
                            HttpContext.Session.SetString("JWToken", "Bearer " + data);
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
        [Route("login-validate")]
        public IActionResult Login(LoginViewModel loginVM)
        {
            string stringData = JsonConvert.SerializeObject(loginVM);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            var resTask = client.PostAsync("auths/login/", contentData);

            var result = resTask.Result;
            var responseData = result.Content.ReadAsStringAsync().Result;

            if (result.IsSuccessStatusCode)
            {
                var token = new JwtSecurityToken(jwtEncodedString: responseData);
                var authToken = "Bearer " + responseData;
                var isVerified = token.Claims.First(c => c.Type == "VerifyCode").Value;

                HttpContext.Session.SetString("Id", token.Claims.First(c => c.Type == "Id").Value);
                HttpContext.Session.SetString("RoleName", token.Claims.First(c => c.Type == "RoleName").Value);
                HttpContext.Session.SetString("Name", token.Claims.First(c => c.Type == "Name").Value);
                HttpContext.Session.SetString("VerifyCode", token.Claims.First(c => c.Type == "VerifyCode").Value);
                HttpContext.Session.SetString("JWToken", authToken);

                return Json((result, responseData), new Newtonsoft.Json.JsonSerializerSettings());
            }
            return Json((result, responseData), new Newtonsoft.Json.JsonSerializerSettings());
        }
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/login");
        }
    }
}
