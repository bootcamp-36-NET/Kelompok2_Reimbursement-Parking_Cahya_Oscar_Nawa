using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Bases
{
    public interface BaseModel
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTimeOffset CreateDate { get; set; }
        DateTimeOffset ApproveDate { get; set; }
        string Reason { get; set; }
        string Role { get; set; }
    }
}
