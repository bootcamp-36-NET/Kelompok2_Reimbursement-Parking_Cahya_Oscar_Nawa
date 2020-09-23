using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Models
{
    [Table("tb_plat-number")]
    public class RequestDetail
    {
        public int Id { get; set; }
        public string PlatNumber { get; set; }
        public string VechicleType { get; set; }
        public string PaymentType { get; set; }
        public int TotalPrice { get; set; }
        public string VechicleOwner { get; set; }
        public string ParkingName { get; set; }
        public string ParkingAddress { get; set; }

        public int RequestReimbursementParkingId { get; set; }
        public RequestReimbursementParking RequestReimbursementParking { get; set; }
    }
}
