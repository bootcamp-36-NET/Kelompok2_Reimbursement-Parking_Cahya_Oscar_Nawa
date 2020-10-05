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

        public async Task<List<StatusVM>> GetAll(string departmentName)
        {
            var data = await _context.RequestReimbursementParkings
                .Include("RequestDetail")
                .Include("Blob")
                .Where(q => q.RequestReimbursementStatusEnumId == 1 && q.RequestDetail.DepartmentName == departmentName)
                .Select(q => new StatusVM()
                {
                    Id = q.Id,
                    Periode = q.RequestDetail.Periode,
                    Name = q.RequestDetail.Name,
                    EmployeeId = q.EmployeeId,
                    PLATNumber = q.RequestDetail.PLATNumber,
                    TotalPrice = q.RequestDetail.TotalPrice,
                    VehicleOwner = q.RequestDetail.VechicleOwner,
                    ParkingAddress = q.RequestDetail.ParkingAddress,
                    ParkingName = q.RequestDetail.ParkingName,
                    PaymentType = q.RequestDetail.PaymentType,
                    RequestDate = q.RequestDate,
                    VehicleType = q.RequestDetail.VechicleType,
                    Content = q.Blob.Content,
                    StatusId = q.RequestReimbursementStatusEnumId,
                    ReimbursementStatus = q.RequestReimbursementStatusEnum.Status,
                    RejectReason = q.RejectReason
                })
                .ToListAsync();

            return data;
        }
        public async Task<List<StatusVM>> GetAllHistory(string departmentName)
        {
            var procedureName = "SP_get_all_hitory";
            param.Add("@DepartmentName", departmentName);

            var reimbursements = (await con.QueryAsync<StatusVM>(procedureName, param, commandType: CommandType.StoredProcedure)).ToList();
            return reimbursements;
        }
        public async Task<StatusVM> GetHistoryDetail(string id)
        {
            var procedureName = "SP_get_all_history_detail";
            param.Add("@Id", id);

            var reimbursements = (await con.QueryAsync<StatusVM>(procedureName, param, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            return reimbursements;
        }

        public async Task<List<StatusVM>> GetAllApprove(string departmentName)
        {
            var data = await _context.RequestReimbursementParkings
                .Include("RequestDetail")
                .Include("Blob")
                .Where(q => q.RequestReimbursementStatusEnumId == 2 && q.RequestDetail.DepartmentName == departmentName)
                .Select(q => new StatusVM()
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
                    VehicleType = q.RequestDetail.VechicleType,
                    Content = q.Blob.Content,
                    StatusId = q.RequestReimbursementStatusEnumId,
                    ReimbursementStatus = q.RequestReimbursementStatusEnum.Status,
                    RejectReason = q.RejectReason
                })
                .ToListAsync();

            return data;
        }
        public async Task<List<StatusVM>> GetAllReject(string departmentName)
        {
            var data = await _context.RequestReimbursementParkings
                .Include("RequestDetail")
                .Include("Blob")
                .Where(q => q.RequestReimbursementStatusEnumId == 4 && q.RequestDetail.DepartmentName == departmentName)
                .Select(q => new StatusVM()
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
                    VehicleType = q.RequestDetail.VechicleType,
                    Content = q.Blob.Content,
                    StatusId = q.RequestReimbursementStatusEnumId,
                    ReimbursementStatus = q.RequestReimbursementStatusEnum.Status,
                    RejectReason = q.RejectReason
                })
                .ToListAsync();

            return data;
        }
    }
}

