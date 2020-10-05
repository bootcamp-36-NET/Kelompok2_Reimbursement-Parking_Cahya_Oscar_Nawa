using ReimbursementParkingAPI.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Models
{
    [Table("tb_m_request_reimbursement_status_enum")]
    public class RequestReimbursementStatusEnum
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public ICollection<RequestReimbursementParking> RequestReimbursementParkings { get; set; }
    }
}
