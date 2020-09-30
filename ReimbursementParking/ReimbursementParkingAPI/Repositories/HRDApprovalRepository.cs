using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReimbursementParkingAPI.Context;
using ReimbursementParkingAPI.Models;
using ReimbursementParkingAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Repositories
{
    public class HRDApprovalRepository : GeneralRepository<RequestReimbursementParking, MyContext>
    {
        private readonly MyContext _context;
        private readonly IConfiguration _configuration;
        private readonly SqlConnection con;
        DynamicParameters param = new DynamicParameters();

        public HRDApprovalRepository(MyContext context, IConfiguration configuration) : base(context)
        {
            _context = context;
            _configuration = configuration;
            con = new SqlConnection(_configuration["ConnectionStrings:ReimbursementParking"]);
        }

        public async Task<List<ApprovalViewModel>> GetAll()
        {
            var data = await _context.RequestReimbursementParkings
                .Include("RequestDetail")
                .Include("Blob")
                .Where(q=> q.RequestReimbursementStatusEnumId == 1)
                .Select(q=> new ApprovalViewModel()
                {
                    Id = q.Id,
                    EmployeeId = q.EmployeeId,
                    PLATNumber = q.RequestDetail.PLATNumber,
                    TotalPrice = q.RequestDetail.TotalPrice,
                    VehicleOwner = q.RequestDetail.VechicleOwner,
                    ParkingAddress = q.RequestDetail.ParkingAddress,
                    ParkingName = q.RequestDetail.ParkingName,
                    PaymentType = q.RequestDetail.PaymentType,
                    RequestDate = q.RequestDate,
                    VehicleType = q.RequestDetail.VechicleType
                })
                .ToListAsync();

            return data;
        }

        public async Task<IEnumerable<StatusVM>> GetStatusApprovedByManager()
        {
            var procedureName = "SP_get_all_status_approved_by_HRD";
            var getAll = (await con.QueryAsync<StatusVM>(procedureName, commandType: CommandType.StoredProcedure)).ToList();
            return getAll;
        }
        public async Task<IEnumerable<StatusVM>> GetStatusRejectedByManager()
        {
            var procedureName = "SP_get_all_status_rejected_by_HRD";
            var getAll = (await con.QueryAsync<StatusVM>(procedureName, commandType: CommandType.StoredProcedure)).ToList();
            return getAll;
        }
    }
}
