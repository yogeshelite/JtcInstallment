using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblShipment
    {
        public long Id { get; set; }
        public DateTime ShipmentDate { get; set; }
        public long VesselId { get; set; }
        public string VoyageNo { get; set; }
        public string VesselType { get; set; }
        public string StockNumber { get; set; }
        public bool Inspection { get; set; }
        public DateTime? InspectionApplyDate { get; set; }
        public string InspectionStatus { get; set; }
        public DateTime? InspectionStatusDate { get; set; }
        public string InspectionCompany { get; set; }
        public bool? InspectionReApply { get; set; }
        public string ShippingAgent { get; set; }
        public string ShippingAgentCompany { get; set; }
        public bool? PackageDeal { get; set; }
        public decimal? InspectionCharges { get; set; }
        public decimal? ShippingCharges { get; set; }
        public decimal? HandlingCharges { get; set; }
        public decimal? VanningCharges { get; set; }
        public decimal? OtherCharges { get; set; }
        public decimal? Freight { get; set; }
        public decimal? SealCharges { get; set; }
        public decimal? Blcharges { get; set; }
        public string Status { get; set; }
        public DateTime? EtdDate { get; set; }
        public long? SourceCountryId { get; set; }
        public long? SourcePortId { get; set; }
        public long? SourceYardId { get; set; }
        public long? DestinationCountryId { get; set; }
        public long? DestinationPortId { get; set; }
        public long? DestinationYardId { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? EtaDate { get; set; }
        public long? Cfsid { get; set; }
    }
}
