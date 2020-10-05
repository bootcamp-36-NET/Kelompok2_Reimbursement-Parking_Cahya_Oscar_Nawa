using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.ViewModels
{
    public class ApproveRejectVM
    {
        public string EmployeeId { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string RejectReason { get; set; }
    }
}
