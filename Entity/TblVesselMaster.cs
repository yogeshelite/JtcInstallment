using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace jtcinstallment.Api.Entity
{
    public partial class TblVesselMaster
    {
        public long Id { get; set; }
        public long? VesselNameId { get; set; }
        public string VoyageNo { get; set; }
        public string VesselType { get; set; }
        public bool? IsPackageDeal { get; set; }
        public int? NoOfContainer { get; set; }
        public string YardId { get; set; }
        public string ShippingAgentid { get; set; }
        public long? SourceCountryId { get; set; }
        public long? DestinationCountryId { get; set; }
        public DateTime? Etddate { get; set; }
        public DateTime? LastConsigneDate { get; set; }
        public DateTime? LastCfsdate { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        [NotMapped]
        public object VesselRouteDetail { get; set; }
    }
}
