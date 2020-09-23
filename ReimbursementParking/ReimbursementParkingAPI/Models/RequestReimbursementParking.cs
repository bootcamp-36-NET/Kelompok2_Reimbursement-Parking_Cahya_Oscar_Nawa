using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Models
{
    [Table("tb_request-reimbursement-parking")]
    public class RequestReimbursementParking
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string RejectReason { get; set; }
        public DateTimeOffset RequestDate { get; set; }
        public DateTimeOffset HRDResponseTime { get; set; }
        public DateTimeOffset ManagerResponseTime { get; set; }

        public Blob Blob { get; set; }

        public RequestDetail RequestDetail { get; set; }

        public int RequestReimbursementStatusEnumId { get; set; }
        public RequestReimbursementStatusEnum RequestReimbursementStatusEnum { get; set; }
    }
}
