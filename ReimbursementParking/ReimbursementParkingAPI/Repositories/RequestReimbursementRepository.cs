﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ReimbursementParkingAPI.Context;
using ReimbursementParkingAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Repositories
{
    public class RequestReimbursementRepository
    {
        private readonly MyContext _context;
        private readonly IConfiguration _configuration;
        private readonly SqlConnection con;

        public RequestReimbursementRepository(MyContext myContext, IConfiguration configuration)
        {
            _context = myContext;
            _configuration = configuration;
            con = new SqlConnection(_configuration["ConnectionStrings:ReimbursementParking"]);
        }

        public async Task<List<ReimbursementVM>> GetById(string id) {
            DynamicParameters param = new DynamicParameters();
            var procedureName = "SP_get_all_reimbursement_by_id";
            param.Add("@Id", id);

            var reimbursements = (await con.QueryAsync<ReimbursementVM>(procedureName, param, commandType: CommandType.StoredProcedure)).ToList();
            return reimbursements;
        }
    }
}