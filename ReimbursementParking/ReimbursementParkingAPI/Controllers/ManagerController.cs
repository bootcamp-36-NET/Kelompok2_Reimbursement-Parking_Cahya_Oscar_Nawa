using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReimbursementParkingAPI.Repositories;
using ReimbursementParkingAPI.ViewModels;

namespace ReimbursementParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ManagerRepository _repo;
        public ManagerController(ManagerRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ReimbursementVM>> GetStatus()
        {
            return await _repo.GetStatus();
        }

        //[HttpPut("{Id}")]
        //public IHttpActionResult Put(int id, StatusVM statusVM)
        //{
        //    _repo.Update(id, divisionVM);
        //    return Ok("Data has been updated");
        //}
    }
}
