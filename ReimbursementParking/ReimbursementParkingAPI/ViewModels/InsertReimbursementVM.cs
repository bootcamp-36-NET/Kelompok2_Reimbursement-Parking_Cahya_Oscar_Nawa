using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.ViewModels
{
    public class InsertReimbursementVM
    {
        public string EmployeeId { get; set; }
        public byte[] Content { get; set; }
        public IFormFile ReimbursementFile { get; set; }
        public string Name { get; set; }
        public string Periode { get; set; }
        public string PLATNumber { get; set; }
        public string VehicleType { get; set; }
        public string PaymentType { get; set; }
        public int TotalPrice { get; set; }
        public string VehicleOwner { get; set; }
        public string ParkingName { get; set; }
        public string ParkingAddress { get; set; }
        public string DepartmentName { get; set; }
    }
}
