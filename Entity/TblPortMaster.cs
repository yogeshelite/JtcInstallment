using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace jtcinstallment.Api.Entity
{
    public partial class TblPortMaster
    {
        public long Id { get; set; }
        public string PortName { get; set; }
        public long CountryId { get; set; }
        public string TimeZone { get; set; }
        public DateTime RecordDate { get; set; }
        public long PortAgentId { get; set; }
        public long CountryMasterId { get; set; }
        public long VesselRouteId { get; set; }
        public long YardMaserYardl { get; set; }
        [NotMapped]
        public int[] AgentArray { get; set; }
    }
}
