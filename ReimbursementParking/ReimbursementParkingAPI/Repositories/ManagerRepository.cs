using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ReimbursementParkingAPI.Context;
using ReimbursementParkingAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Repositories
{
    public class ManagerRepository
    {
        private readonly MyContext _context;
        private readonly IConfiguration _configuration;
        private readonly SqlConnection con;
        DynamicParameters param = new DynamicParameters();

        public ManagerRepository(MyContext myContext, IConfiguration configuration)
        {
            _context = myContext;
            _configuration = configuration;
            con = new SqlConnection(_configuration["ConnectionStrings:ReimbursementParking"]);
        }

        public async Task<IEnumerable<StatusVM>> GetStatus()
        {
            var procedureName = "SP_get_all_status";

            var reimbursements = (await con.QueryAsync<StatusVM>(procedureName, commandType: CommandType.StoredProcedure)).ToList();
            return reimbursements;
        }
        public int Update(int Id, StatusVM statusVM)
        {
            var procedureUpdate = "SP_update_status";
            var update = con.Execute(procedureUpdate, new { Id, statusVM.StatusId }, commandType: CommandType.StoredProcedure);
            return update;
        }
        public async Task<IEnumerable<StatusVM>> GetStatusApprovedByManager()
        {
            var procedureName = "SP_get_all_status_approvedByManager";
            var getAll = (await con.QueryAsync<StatusVM>(procedureName, commandType: CommandType.StoredProcedure)).ToList();
            return getAll;
        }
        public async Task<IEnumerable<StatusVM>> GetStatusRejectedByManager()
        {
            var procedureName = "SP_get_all_status_rejectedByManager";
            var getAll = (await con.QueryAsync<StatusVM>(procedureName, commandType: CommandType.StoredProcedure)).ToList();
            return getAll;
        }
        public async Task<StatusVM> Get(int Id)
        {
            var procedureById = "SP_retrieve_ManagerById";
            var getDivisionById = await con.QueryAsync<StatusVM>(procedureById, new { Id }, commandType: CommandType.StoredProcedure);
            return getDivisionById.FirstOrDefault();
        }
        public int UpdateReject(int Id, StatusVM statusVM)
        {
            var procedureUpdate = "SP_update_rejectReason";
            var update = con.Execute(procedureUpdate, new { Id, statusVM.RejectReason, statusVM.StatusId }, commandType: CommandType.StoredProcedure);
            return update;
        }
        
    }
}
