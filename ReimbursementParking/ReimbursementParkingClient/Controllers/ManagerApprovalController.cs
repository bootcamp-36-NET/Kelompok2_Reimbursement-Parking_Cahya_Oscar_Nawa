using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReimbursementParkingAPI.Models;
using ReimbursementParkingAPI.ViewModels;

namespace ReimbursementParkingClient.Controllers
{
    public class ManagerApprovalController : Controller
    {
        readonly HttpClient http = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44322/api/")
        };
        readonly HttpClient auth = new HttpClient
        {
            BaseAddress = new Uri("http://winarto-001-site1.dtempurl.com/api/")
        };
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult LoadApprovalManager()
        {
            IEnumerable<StatusVM> reimbursementVM = null;
            //auth.DefaultRequestHeaders.Authorization =
            //    new AuthenticationHeaderValue("Bearer", 
            //    HttpContext.Session.GetString("JWToken"));
            //var token = HttpContext.Session.GetString("JWToken");
            //http.DefaultRequestHeaders.Add("Authorization", token);
            var restTask = http.GetAsync("ManagerApprovals/all");
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
            var restTask = http.GetAsync("ManagerApprovals/allApprove");
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
            var restTask = http.GetAsync("ManagerApprovals/reject");
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
        public ActionResult<ExpandoObject> ApproveRequest(int id, ApproveRejectVM approveVM)
        {
            //auth.DefaultRequestHeaders.Authorization =
            //    new AuthenticationHeaderValue("Bearer",
            //    HttpContext.Session.GetString("JWToken"));
            var authToken = HttpContext.Session.GetString("JWToken");
            auth.DefaultRequestHeaders.Add("Authorization", authToken);
            var resTaskUser = auth.GetAsync("Users/" + approveVM.EmployeeId);
            resTaskUser.Wait();

            var userResult = resTaskUser.Result;
            var responseUserData = userResult.Content.ReadAsAsync<GetUserVM>().Result;
            approveVM.Email = responseUserData.Email;

            string stringData = JsonConvert.SerializeObject(approveVM);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            var resTask = http.PutAsync("ManagerApprovals/approve/" + id, contentData);
            resTask.Wait();

            var result = resTask.Result;
            var responseData = result.Content.ReadAsStringAsync().Result;

            dynamic resultVM = new ExpandoObject();
            resultVM.Item1 = result;
            resultVM.Item2 = responseData;

            return Json(resultVM);
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
                    var result = http.PutAsync("ManagerApprovals/reject/" + Id, byteContent).Result;
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
            var resTask = http.GetAsync("ManagerApprovals/" + id);
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
        public ActionResult<ExpandoObject> DownloadFolder(int id)
        {
            Blob responseData = null;

            //var authToken = HttpContext.Session.GetString("JWToken");
            //client.DefaultRequestHeaders.Add("Authorization", authToken);

            var resTask = http.GetAsync("ManagerApprovals/GetFile/" + id);
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
