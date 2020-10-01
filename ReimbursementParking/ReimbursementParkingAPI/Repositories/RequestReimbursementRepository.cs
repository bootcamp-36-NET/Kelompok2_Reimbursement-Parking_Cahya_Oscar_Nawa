using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReimbursementParkingAPI.Context;
using ReimbursementParkingAPI.Models;
using ReimbursementParkingAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Repositories
{
    public class RequestReimbursementRepository
    {
        private readonly MyContext _context;
        private readonly IConfiguration _configuration;
        private readonly SqlConnection con;
        DynamicParameters param = new DynamicParameters();

        public RequestReimbursementRepository(MyContext myContext, IConfiguration configuration)
        {
            _context = myContext;
            _configuration = configuration;
            con = new SqlConnection(_configuration["ConnectionStrings:ReimbursementParking"]);
        }

        public async Task<List<ReimbursementVM>> GetById(string id)
        {
            var procedureName = "SP_get_all_reimbursement_by_id";
            param.Add("@Id", id);

            var reimbursements = (await con.QueryAsync<ReimbursementVM>(procedureName, param, commandType: CommandType.StoredProcedure)).ToList();
            return reimbursements;
        }

        public async Task<int> Delete(string id)
        {
            var sp = "SPDelete";
            param.Add("@id", id);
            var del = await con.ExecuteAsync(sp, param, commandType: CommandType.StoredProcedure);
            return del;
        }

        //public async Task<IEnumerable<RequestDetail>> Get()
        //{
        //    var SP = "SPShow";
        //    var show = await con.QueryAsync<RequestDetail>(SP, commandType: CommandType.StoredProcedure);
        //    return show;
        //}

        public async Task<string> CreateNewRequest(string id, InsertReimbursementVM model)
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var isExistInMonth = await _context.RequestReimbursementParkings
                .Where(Q => Q.RequestDate >= startDate && (Q.RequestReimbursementStatusEnumId < 4) && Q.EmployeeId == id).AnyAsync();
            if (isExistInMonth)
            {
                return "Can Only Request Once Per Month  !";
            }

            RequestReimbursementParking reimbursement = new RequestReimbursementParking()
            {
                EmployeeId = id,
                RequestDate = DateTimeOffset.Now,
                RequestReimbursementStatusEnumId = 1
            };
            _context.RequestReimbursementParkings.Add(reimbursement);
            await _context.SaveChangesAsync();

            var fileContent = new byte[0];
            using (var ms = new MemoryStream())
            {
                await model.ReimbursementFile.CopyToAsync(ms);

                fileContent = ms.ToArray();
            }

            Models.Blob blob = new Models.Blob()
            {
                Id = reimbursement.Id,
                Content = fileContent,
                CreatedAt = DateTimeOffset.Now,
                Name = id + " - " + model.Name,
                ContentType = model.ReimbursementFile.ContentType
            };

            RequestDetail requestDetail = new RequestDetail()
            {
                Id = reimbursement.Id,
                TotalPrice = model.TotalPrice,
                ParkingName = model.ParkingName,
                PLATNumber = model.PLATNumber.ToUpper(),
                ParkingAddress = model.ParkingAddress,
                VechicleOwner = model.VehicleOwner,
                VechicleType = model.VehicleType,
                PaymentType = model.PaymentType,
                DepartmentName = model.DepartmentName

            };

             _context.Blobs.Add(blob);
             _context.RequestDetails.Add(requestDetail);

            var result = await _context.SaveChangesAsync();
            if (result < 0)
            {
                return "Server Error !";
            }
            return null;
        }
    }
}
