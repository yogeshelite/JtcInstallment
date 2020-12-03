using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblShippingAgentCharges
    {
        public long Id { get; set; }
        public long ShippingAgentId { get; set; }
        public bool? PackageDeal { get; set; }
        public long? ChargesCountryId { get; set; }
        public string Chargetype { get; set; }
        public decimal? InspectionCharges { get; set; }
        public decimal? ShippingCharges { get; set; }
        public decimal? HandlingCharges { get; set; }
        public decimal? VanningCharges { get; set; }
        public decimal? OtherCharges { get; set; }
        public decimal? Freight { get; set; }
        public decimal? SealCharges { get; set; }
        public decimal? Blcharges { get; set; }
        public long? SlabId { get; set; }
        public bool? DefaultFreightForCountry { get; set; }

        public virtual TblShippingAgent ShippingAgent { get; set; }
    }
}
