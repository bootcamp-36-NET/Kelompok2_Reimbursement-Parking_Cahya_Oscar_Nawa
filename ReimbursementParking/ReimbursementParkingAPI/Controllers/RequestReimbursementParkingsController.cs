using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReimbursementParkingAPI.Repositories;
using ReimbursementParkingAPI.ViewModels;

namespace ReimbursementParkingAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
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

        [HttpPost("{id}")]
        public async Task<ActionResult> CreateNewReimbursementRequest(string id, [FromForm]InsertReimbursementVM model)
        {
            var maxFileSize = 4194304;
            if (model.ReimbursementFile.ContentType != "application/zip")
            {
                return BadRequest("Uploaded File Must be Zip !");
            }
            if (model.ReimbursementFile.Length > maxFileSize)
            {
                return BadRequest("Uploaded File Maximum Size is 4MB !");
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
