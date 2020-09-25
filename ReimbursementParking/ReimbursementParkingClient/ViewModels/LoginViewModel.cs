using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingClient.ViewModels
{
    public class LoginViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string SubDistrict { get; set; }
        public string Village { get; set; }
        public string ZipCode { get; set; }
        public string Password { get; set; }
    }
}
