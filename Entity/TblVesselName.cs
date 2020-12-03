using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblVesselName
    {
        public long Id { get; set; }
        public string VesselName { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
