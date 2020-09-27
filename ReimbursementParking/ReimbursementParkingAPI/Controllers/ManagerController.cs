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
        [Route("requestHRD")]
        public async Task<IEnumerable<StatusVM>> GetStatus()
        {
            return await _repo.GetStatus();
        }

        [HttpPut("{Id}")]
        public ActionResult Update(int Id, StatusVM entity)
        {
            _repo.Update(Id, entity);
            return Ok("Data has been updated");
        }
        [HttpGet("approve")]
        public async Task<IEnumerable<StatusVM>> GetStatusApprovedByManager()
        {
            return await _repo.GetStatusApprovedByManager();
        }
        [HttpGet("reject")]
        public async Task<IEnumerable<StatusVM>> GetStatusRejectedByManager()
        {
            return await _repo.GetStatusRejectedByManager();
        }
        public async Task<StatusVM> Get(int Id)
        {
            return await _repo.Get(Id);
        }
        [HttpPut("rejectReason/{Id}")]
        public ActionResult UpdateReject(int Id, StatusVM entity)
        {
            _repo.UpdateReject(Id, entity);
            return Ok("Data has been updated");
        }
    }
}
