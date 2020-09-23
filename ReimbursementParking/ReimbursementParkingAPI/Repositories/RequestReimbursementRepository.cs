using Dapper;
using Microsoft.Extensions.Configuration;
using ReimbursementParkingAPI.Context;
using ReimbursementParkingAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Repositories
{
    public class RequestReimbursementRepository
    {
        private readonly MyContext _context;
        private readonly IConfiguration _configuration;
        private readonly SqlConnection con;
        private readonly DynamicParameters param;

        public RequestReimbursementRepository(MyContext myContext, IConfiguration configuration, DynamicParameters parameters)
        {
            _context = myContext;
            _configuration = configuration;
            con = new SqlConnection(_configuration["ConnectionStrings:ReimbursementParking"]);
            param = parameters;
        }

        public async Task<List<ReimbursementVM>> GetById(string id) {
            var procedureName = "SPSelectDepartment";
            param.Add("@Id", id);

            var reimbursements = (await con.QueryAsync<ReimbursementVM>(procedureName, param, commandType: CommandType.StoredProcedure)).ToList();
            return reimbursements;
        }
    }
}
