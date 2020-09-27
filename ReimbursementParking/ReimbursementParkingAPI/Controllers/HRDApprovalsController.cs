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
using ReimbursementParkingAPI.ViewModels;

namespace ReimbursementParkingAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class HRDApprovalsController : BaseController<RequestReimbursementParking, HRDApprovalRepository>
    {
        private readonly HRDApprovalRepository _repo;

        public HRDApprovalsController(HRDApprovalRepository repository) : base(repository)
        {
            _repo = repository;
        }

        [HttpGet]
        [Route("approve/{id}")]
        public async Task<ActionResult> Approve(int id)
        {
            var reimbursementRequest = await _repo.GetById(id);
            reimbursementRequest.HRDResponseTime = DateTimeOffset.Now;
            reimbursementRequest.RequestReimbursementStatusEnumId = 2;
            var result = await _repo.Approve(reimbursementRequest);
            if (result < 0)
            {
                return BadRequest("Server Error !");
            }
            return Ok("Request Approved !");
        }

        [HttpPut]
        [Route("reject/{id}")]
        public async Task<ActionResult> Reject(int id, RejectVM rejectVM)
        {
            var reimbursementRequest = await _repo.GetById(id);
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
            return Ok("Request Rejected !");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRequestHRD()
        {
            var reimbursementRequests = await _repo.GetAll();
            return Ok(reimbursementRequests);
        }

    }
}
