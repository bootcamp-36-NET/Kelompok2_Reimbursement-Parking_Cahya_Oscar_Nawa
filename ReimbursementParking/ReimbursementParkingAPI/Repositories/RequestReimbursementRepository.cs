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

        public int Delete(string id)
        {
            var sp = "SPDelete";
            param.Add("@id", id);
            var del = con.Execute(sp, param, commandType: CommandType.StoredProcedure);
            return del;
        }

        //public async Task<IEnumerable<RequestDetail>> Get()
        //{
        //    var SP = "SPShow";
        //    var show = await con.QueryAsync<RequestDetail>(SP, commandType: CommandType.StoredProcedure);
        //    return show;
        //}
    }
}
