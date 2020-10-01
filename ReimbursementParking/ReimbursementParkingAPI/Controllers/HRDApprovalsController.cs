using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReimbursementParkingAPI.Bases;
using ReimbursementParkingAPI.Models;
using ReimbursementParkingAPI.Repositories;
using ReimbursementParkingAPI.Services;
using ReimbursementParkingAPI.ViewModels;

namespace ReimbursementParkingAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class HRDApprovalsController : BaseController<RequestReimbursementParking, HRDApprovalRepository>
    {
        private readonly HRDApprovalRepository _repo;
        private readonly SendEmailService _sendEmail;

        public HRDApprovalsController(HRDApprovalRepository repository,SendEmailService sendEmailService) : base(repository)
        {
            _repo = repository;
            _sendEmail = sendEmailService;
        }

        [HttpPut]
        [Route("approve")]
        public async Task<ActionResult> Approve(ApproveRejectVM approveVM)
        {
            var reimbursementRequest = await _repo.GetById(approveVM.Id);
            reimbursementRequest.HRDResponseTime = DateTimeOffset.Now;
            reimbursementRequest.RequestReimbursementStatusEnumId = 2;
            var result = await _repo.Approve(reimbursementRequest);
            if (result < 0)
            {
                return BadRequest("Server Error !");
            }

            var emailData = new SendEmailVM()
            {
                Email = approveVM.Email,
                Subject = "Reimbursement Status For Periode " + DateTimeOffset.Now.ToString("Y"),
                Body = "Your Reimbursement Request Has been Approved by HRD"
            };
            _sendEmail.SendEmail(emailData);

            return Ok("Request Approved !");
        }

        [HttpPut]
        [Route("reject")]
        public async Task<ActionResult> Reject(ApproveRejectVM rejectVM)
        {
            var reimbursementRequest = await _repo.GetById(rejectVM.Id);
            if (reimbursementRequest == null)
            {
                return BadRequest("Data Not Found !");
            }
            reimbursementRequest.HRDResponseTime = DateTimeOffset.Now;
            reimbursementRequest.RequestReimbursementStatusEnumId = 4;
            reimbursementRequest.RejectReason = rejectVM.RejectReason;
            var result = await _repo.Approve(reimbursementRequest);
            if (result < 0)
            {
                return BadRequest("Server Error !");
            }

            var emailData = new SendEmailVM()
            {
                Email = rejectVM.Email,
                Subject = "Reimbursement Status For Periode " + DateTimeOffset.Now.ToString("Y"),
                Body = "Your Reimbursement Request Has been Rejected by HRD"
            };
            _sendEmail.SendEmail(emailData);

            return Ok("Request Rejected !");
        }

        [HttpGet]
        [Route("all/{departmentName}")]
        public async Task<ActionResult> GetAllRequestHRD(string departmentName)
        {
            var reimbursementRequests = await _repo.GetAll(departmentName);
            return Ok(reimbursementRequests);
        }

        [HttpGet]
        [Route("allApprove/{departmentName}")]
        public async Task<ActionResult> GetAllApprovedByHRD(string departmentName)
        {
            var reimbursementRequests = await _repo.GetAllApprove(departmentName);
            return Ok(reimbursementRequests);
        }
        [HttpGet]
        [Route("allReject/{departmentName}")]
        public async Task<ActionResult> GetAllRejectedByHRD(string departmentName)
        {
            var reimbursementRequests = await _repo.GetAllReject(departmentName);
            return Ok(reimbursementRequests);
        }
    }
}
