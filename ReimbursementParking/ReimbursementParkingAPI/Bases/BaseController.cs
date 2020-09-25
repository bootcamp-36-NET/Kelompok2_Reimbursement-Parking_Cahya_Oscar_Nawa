using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReimbursementParkingAPI.Repositories.Interface;

namespace ReimbursementParkingAPI.Bases
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity : class
        where TRepository : IRepository<TEntity>
    {
        private readonly IRepository<TEntity> _repository;
        public BaseController(TRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetById(int id) => await _repository.GetById(id);

        [HttpGet]
        [Route("GetFile/{blobId}")]
        public async Task<ActionResult> GetFile(int blobId)
        {
            var data = await _repository.GetFile(blobId);
            if (data == null)
            {
                return BadRequest("File Corrupted !");
            }
            return Ok(data);
        }
    }
}
