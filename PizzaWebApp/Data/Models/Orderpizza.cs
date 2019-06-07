using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Orderpizza
    {
        public int OrderId { get; set; }
        public int? LocationFid { get; set; }
        public int? UserFid { get; set; }
        public DateTime? Timecheck { get; set; }
        public DateTime? Timecheckdefault { get; set; }
    }
}
