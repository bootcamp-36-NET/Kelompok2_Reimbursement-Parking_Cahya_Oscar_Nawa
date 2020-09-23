using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReimbursementParkingAPI.Repositories;

namespace ReimbursementParkingAPI.Controllers
{
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
    }
}
