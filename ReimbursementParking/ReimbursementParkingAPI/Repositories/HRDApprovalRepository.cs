using Microsoft.EntityFrameworkCore;
using ReimbursementParkingAPI.Context;
using ReimbursementParkingAPI.Models;
using ReimbursementParkingAPI.ViewModels;
using System;
using System.Collections.Generic;
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
    }
}
