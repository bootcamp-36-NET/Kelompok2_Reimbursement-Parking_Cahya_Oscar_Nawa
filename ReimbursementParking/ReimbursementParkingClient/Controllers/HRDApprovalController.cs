﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReimbursementParkingAPI.Models;
using ReimbursementParkingAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;

namespace ReimbursementParkingClient.Controllers
{
    public class HRDApprovalController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44322/api/")
        };

        readonly HttpClient userClient = new HttpClient
        {
            BaseAddress = new Uri("http://winarto-001-site1.dtempurl.com/api/")
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllRequestHRD()
        {
            IEnumerable<StatusVM> reimbursementRequest = null;

            var authToken = HttpContext.Session.GetString("JWToken");
            client.DefaultRequestHeaders.Add("Authorization", authToken);

            var departmentName = HttpContext.Session.GetString("DepartmentName");

            var resTask = client.GetAsync("HRDApprovals/all/" + departmentName);
            resTask.Wait();

            var result = resTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<StatusVM>>();
                readTask.Wait();
                reimbursementRequest = readTask.Result;
            }

            return Json(reimbursementRequest);
        }

        public ActionResult<ExpandoObject> ApproveRequest(ApproveRejectVM approveVM)
        {
            var authToken = HttpContext.Session.GetString("JWToken");

            userClient.DefaultRequestHeaders.Add("Authorization", authToken);
            var resTaskUser = userClient.GetAsync("reimburs/" + approveVM.EmployeeId);
            resTaskUser.Wait();

            var userResult = resTaskUser.Result;
            var responseUserData = userResult.Content.ReadAsAsync<GetUserVM>().Result;
            approveVM.Email = responseUserData.Email;

            string stringData = JsonConvert.SerializeObject(approveVM);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Add("Authorization", authToken);
            var resTask = client.PutAsync("HRDApprovals/approve", contentData);
            resTask.Wait();

            var result = resTask.Result;
            var responseData = result.Content.ReadAsStringAsync().Result;

            dynamic resultVM = new ExpandoObject();
            resultVM.Item1 = result;
            resultVM.Item2 = responseData;

            return Json(resultVM);
        }

        public ActionResult<ExpandoObject> RejectRequest(ApproveRejectVM rejectVM)
        {
            var authToken = HttpContext.Session.GetString("JWToken");

            userClient.DefaultRequestHeaders.Add("Authorization", authToken);
            var resTaskUser = userClient.GetAsync("reimburs/" + rejectVM.EmployeeId);
            resTaskUser.Wait();

            var userResult = resTaskUser.Result;
            var responseUserData = userResult.Content.ReadAsAsync<GetUserVM>().Result;
            rejectVM.Email = responseUserData.Email;


            string stringData = JsonConvert.SerializeObject(rejectVM);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Add("Authorization", authToken);
            var resTask = client.PutAsync("HRDApprovals/reject", contentData);
            resTask.Wait();

            var result = resTask.Result;
            var responseData = result.Content.ReadAsStringAsync().Result;

            dynamic resultVM = new ExpandoObject();
            resultVM.Item1 = result;
            resultVM.Item2 = responseData;

            return Json(resultVM);
        }

        public ActionResult<ExpandoObject> DownloadFolder(string id)
        {
            Blob responseData = null;

            var authToken = HttpContext.Session.GetString("JWToken");
            client.DefaultRequestHeaders.Add("Authorization", authToken);

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

        [HttpGet("{Id}")]
        public JsonResult GetReimbursementById(string Id)
        {
            IEnumerable<StatusVM> reimbursementVM = null;

            var token = HttpContext.Session.GetString("JWToken");
            client.DefaultRequestHeaders.Add("Authorization", token);

            var restTask = client.GetAsync("HRDApprovals/history/detail/" + Id);
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

        public JsonResult GetAllHitoryHRD()
        {
            IEnumerable<StatusVM> reimbursementVM = null;

            var token = HttpContext.Session.GetString("JWToken");
            client.DefaultRequestHeaders.Add("Authorization", token);

            var departmentName = HttpContext.Session.GetString("DepartmentName");

            var restTask = client.GetAsync("HRDApprovals/history/" + departmentName);
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

        public JsonResult GetApprovedByHRD()
        {
            IEnumerable<StatusVM> reimbursementVM = null;

            var token = HttpContext.Session.GetString("JWToken");
            client.DefaultRequestHeaders.Add("Authorization", token);

            var departmentName = HttpContext.Session.GetString("DepartmentName");

            var restTask = client.GetAsync("HRDApprovals/allApprove/" + departmentName);
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
        public JsonResult GetRejectedByHRD()
        {
            IEnumerable<StatusVM> reimbursementVM = null;

            var token = HttpContext.Session.GetString("JWToken");
            client.DefaultRequestHeaders.Add("Authorization", token);

            var departmentName = HttpContext.Session.GetString("DepartmentName");

            var restTask = client.GetAsync("HRDApprovals/allReject/" + departmentName);
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

    }
}
