using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementParkingAPI.ViewModels
{
    public class ChartVM
    {
        public DateTimeOffset? ManagerResponseTime { get; set; }
        public int total { get; set; }
    }

    public class PieChartVM
    {
        public string VechicleType { get; set; }
        public int total { get; set; }
    }
}
