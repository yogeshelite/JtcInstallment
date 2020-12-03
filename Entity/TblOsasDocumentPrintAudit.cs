using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblOsasDocumentPrintAudit
    {
        public long Id { get; set; }
        public long PortId { get; set; }
        public long VesselId { get; set; }
        public string VoyageNumber { get; set; }
        public long CustomerId { get; set; }
        public long VehicleId { get; set; }
        public string DocumentPrintA { get; set; }
        public DateTime PrintDate { get; set; }
        public long PrintByUserId { get; set; }
        public int PortMasterId { get; set; }
        public long VesselMasterid { get; set; }
    }
}
