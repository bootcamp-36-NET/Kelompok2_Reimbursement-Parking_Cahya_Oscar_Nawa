using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReimbursementParkingAPI.Context;
using ReimbursementParkingAPI.ViewModels;

namespace ReimbursementParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly MyContext _context;
        public ChartsController(MyContext myContext)
        {
            _context = myContext;
        }
        // GET api/values
        [HttpGet]
        [Route("pie")]
        public async Task<List<PieChartVM>> GetPie()
        {
            var data1 = await _context.RequestReimbursementParkings.Include("RequestDetail")
                           .Where(x => x.RequestReimbursementStatusEnumId == 3)
                           .GroupBy(q => q.RequestDetail.VechicleType)
                            .Select(q => new PieChartVM
                            {
                                VechicleType = q.Key,
                                total = q.Count()
                            }).ToListAsync();

            return data1;
        }

        [HttpGet]
        [Route("bar")]
        public async Task<List<ChartVM>> GetBar()
        {
            var data2 = await _context.RequestReimbursementParkings.Include("RequestDetail")
                           .Where(x => x.RequestReimbursementStatusEnumId == 3)
                           .GroupBy(q => q.ManagerResponseTime)
                           .Select(q => new ChartVM
                           {
                               ManagerResponseTime = q.Key,
                               total = q.Count()
                           }).ToListAsync();
            return data2;
        }
    }
}
