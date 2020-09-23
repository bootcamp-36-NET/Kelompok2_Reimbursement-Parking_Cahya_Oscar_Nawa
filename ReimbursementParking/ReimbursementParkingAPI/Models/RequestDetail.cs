using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Models
{
    [Table("tb_reimbursement-detail")]
    public class RequestDetail
    {
        [Key]
        public int Id { get; set; }
        public string PLATNumber { get; set; }
        public string VechicleType { get; set; }
        public string PaymentType { get; set; }
        public int TotalPrice { get; set; }
        public string VechicleOwner { get; set; }
        public string ParkingName { get; set; }
        public string ParkingAddress { get; set; }

        public RequestReimbursementParking RequestReimbursementParking { get; set; }
    }
}
