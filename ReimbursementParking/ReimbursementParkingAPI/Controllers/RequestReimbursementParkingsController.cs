using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReimbursementParkingAPI.Context;
using ReimbursementParkingAPI.Models;
using System.IO;
using ReimbursementParkingAPI.Repositories;
using ReimbursementParkingAPI.ViewModels;

namespace ReimbursementParkingAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class RequestReimbursementParkingsController : ControllerBase
    {
        private readonly RequestReimbursementRepository _repo;
        public RequestReimbursementParkingsController(RequestReimbursementRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var reinmbursements = await _repo.GetById(id);
            return Ok(reinmbursements);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var del = await _repo.Delete(id);
            if (del > 0)
            {
                return Ok("Successfully Delete");
            }
            return BadRequest("Not Success");
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> CreateNewReimbursementRequest(string id, [FromForm]InsertReimbursementVM model)
        {
            var maxFileSize = 1048576;
            if (model.ReimbursementFile.ContentType != "application/pdf")
            {
                //return BadRequest("Uploaded File Must be PDF !");
            }
            if (model.ReimbursementFile.Length > maxFileSize)
            {
                return BadRequest("Uploaded File Maximum Size is 1MB !");
            }
            if (model.TotalPrice > 150000)
            {
                return BadRequest("Reimbursement Limit Is Capped At 150.000 !");
            }
            var result = await _repo.CreateNewRequest(id, model);
            if (result != null)
            {
                return BadRequest(result);
            }
            return Ok("Reimbursement Request Successfully Created !");
        }
    }
}

