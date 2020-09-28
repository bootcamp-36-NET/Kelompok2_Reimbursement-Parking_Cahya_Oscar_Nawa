using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingClient.ViewModels
{
    public class ApproveRejectVM
    {
        public string EmployeeId { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string RejectReason { get; set; }
    }
}
