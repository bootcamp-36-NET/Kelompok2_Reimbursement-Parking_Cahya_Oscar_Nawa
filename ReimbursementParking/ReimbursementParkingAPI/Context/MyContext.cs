using Microsoft.EntityFrameworkCore;
using ReimbursementParkingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<RequestReimbursementStatusEnum> RequestReimbursementStatusEnums { get; set; }
        public DbSet<RequestReimbursementParking> RequestReimbursementParkings { get; set; }
        public DbSet<Blob> Blobs { get; set; }
        public DbSet<RequestDetail> RequestDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
