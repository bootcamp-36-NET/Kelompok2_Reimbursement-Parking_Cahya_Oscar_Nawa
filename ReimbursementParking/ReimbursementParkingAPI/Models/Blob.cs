using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Models
{
    [Table("tb_blob")]
    public class Blob
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public RequestReimbursementParking RequestReimbursementParking { get; set; }
    }
}
