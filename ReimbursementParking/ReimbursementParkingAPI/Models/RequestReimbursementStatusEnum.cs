using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Models
{
    [Table("tb_m_request-reimbursement-status-enum")]
    public class RequestReimbursementStatusEnum
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<RequestReimbursementParking> RequestReimbursementParkings { get; set; }
    }
}
