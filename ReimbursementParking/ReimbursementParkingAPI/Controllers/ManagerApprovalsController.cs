using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class ManagerApprovalsController : BaseController<RequestReimbursementParking, ManagerApprovalRepository>
    {
        private readonly ManagerApprovalRepository _repo;
        private readonly SendEmailService _sendEmail;

        public ManagerApprovalsController(ManagerApprovalRepository repository, SendEmailService sendEmailService) : base(repository)
        {
            _repo = repository;
            _sendEmail = sendEmailService;
        }

        [HttpPut]
        [Route("approve/{id}")]
        public async Task<ActionResult> Approve(int Id, ApproveRejectVM approveVM)
        {
            var reimbursementRequest = await _repo.GetById(Id);
            reimbursementRequest.ManagerResponseTime = DateTimeOffset.Now;
            reimbursementRequest.RequestReimbursementStatusEnumId = 3;
            var result = await _repo.Approve(reimbursementRequest);
            if (result < 0)
            {
                return BadRequest("Server Error !");
            }
            var emailData = new SendEmailVM()
            {
                Email = approveVM.Email,
                Subject = "Reimbursement Status For Periode " + DateTimeOffset.Now.ToString("Y"),
                Body = "Your Reimbursement Request Has been Approved by Manager"
            };
            _sendEmail.SendEmail(emailData);
            return Ok("Request Approved !");
        }

        [HttpPut]
        [Route("reject/{id}")]
        public async Task<ActionResult> Reject(int id, ApproveRejectVM rejectVM)
        {
            var reimbursementRequest = await _repo.GetById(id);
            if (reimbursementRequest == null)
            {
                return BadRequest("Data Not Found !");
            }
            reimbursementRequest.ManagerResponseTime = DateTimeOffset.Now;
            reimbursementRequest.RequestReimbursementStatusEnumId = 5;
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
                Body = "Your Reimbursement Request Has been Rejected by Manager"
            };
            _sendEmail.SendEmail(emailData);

            return Ok("Request Rejected !");
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetAllRequestManager()
        {
            var reimbursementRequests = await _repo.GetAll();
            return Ok(reimbursementRequests);
        }
        [HttpGet]
        [Route("allApprove")]
        public async Task<ActionResult> GetAllApprovedByManager()
        {
            var reimbursementRequests = await _repo.GetAllApprove();
            return Ok(reimbursementRequests);
        }
        [HttpGet]
        [Route("reject")]
        public async Task<ActionResult> GetAllRejectedByManager()
        {
            var reimbursementRequests = await _repo.GetAllReject();
            return Ok(reimbursementRequests);
        }

    }
}
