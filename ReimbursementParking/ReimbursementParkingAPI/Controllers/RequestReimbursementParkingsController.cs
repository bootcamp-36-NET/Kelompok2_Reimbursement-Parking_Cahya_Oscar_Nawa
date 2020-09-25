using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReimbursementParkingAPI.Context;
using ReimbursementParkingAPI.Models;
using ReimbursementParkingAPI.Repositories;
using ReimbursementParkingAPI.ViewModels;

namespace ReimbursementParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestReimbursementParkingsController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly RequestReimbursementRepository _repo;
        public RequestReimbursementParkingsController(MyContext myContext, RequestReimbursementRepository repo)
        {
            _context = myContext;
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var reinmbursements = await _repo.GetById(id);
            return Ok(reinmbursements);
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    var getData = _context.RequestReimbursementParkings.Where(x => x.EmployeeId == id && x.RequestReimbursementStatusEnumId == 1);
        //    if (getData == null)
        //    {
        //        return BadRequest("Not Successfully");
        //    }

        //    _context.RequestReimbursementParkings.Remove((RequestReimbursementParking)getData);
        //    _context.SaveChanges();
        //    return Ok(new { msg = "Successfully Delete" });
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var del = _repo.Delete(id);
            if (del > 0)
            {
                return Ok("Successfully Delete");
            }
            return BadRequest("Not Success");
        }
    }
}

