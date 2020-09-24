using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPut("{Id}")]
        public ActionResult Update(int Id, StatusVM entity)
        {
            _repo.Update(Id, entity);
            return Ok("Data has been updated");
        }
    }
}
