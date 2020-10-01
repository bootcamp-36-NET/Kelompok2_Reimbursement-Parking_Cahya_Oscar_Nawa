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

        public HRDApprovalRepository(MyContext context) : base(context)
        {
            _context = context;
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
                    EmployeeId = q.EmployeeId,
                    PLATNumber = q.RequestDetail.PLATNumber,
                    TotalPrice = q.RequestDetail.TotalPrice,
                    VehicleOwner = q.RequestDetail.VechicleOwner,
                    ParkingAddress = q.RequestDetail.ParkingAddress,
                    ParkingName = q.RequestDetail.ParkingName,
                    PaymentType = q.RequestDetail.PaymentType,
                    RequestDate = q.RequestDate,
                    VeicleType = q.RequestDetail.VechicleType,
                    Content = q.Blob.Content,
                    StatusId = q.RequestReimbursementStatusEnumId,
                    ReimbursementStatus = q.RequestReimbursementStatusEnum.Status,
                    RejectReason = q.RejectReason
                })
                .ToListAsync();

            return data;
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
                    VeicleType = q.RequestDetail.VechicleType,
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
                    VeicleType = q.RequestDetail.VechicleType,
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

