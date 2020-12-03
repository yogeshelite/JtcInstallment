using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblVesselRoute
    {
        public long Id { get; set; }
        public long PortId { get; set; }
        public long VesselMasterId { get; set; }
        public string Type { get; set; }
        public DateTime? LastPuttingdate { get; set; }
    }
}
