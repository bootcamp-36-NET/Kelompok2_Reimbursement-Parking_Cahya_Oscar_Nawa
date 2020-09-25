using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.Bases
{
    public interface BaseModel
    {
        int Id { get; set; }
        string RejectReason { get; set; }
        DateTimeOffset? HRDResponseTime { get; set; }
        DateTimeOffset? ManagerResponseTime { get; set; }
        int RequestReimbursementStatusEnumId { get; set; }
    }
}
