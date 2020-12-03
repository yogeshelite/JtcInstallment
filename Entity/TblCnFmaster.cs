using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblCnFmaster
    {
        public long Id { get; set; }
        public long CountryId { get; set; }
        public long PortId { get; set; }
        public decimal Freight { get; set; }
        public decimal InspectionCharges { get; set; }
        public decimal ShippingCharges { get; set; }
        public decimal RepairCost { get; set; }
        public decimal MiscCharges { get; set; }
        public decimal FreightExchangeRate { get; set; }
        public string Description { get; set; }
        public DateTime RecordDate { get; set; }
        public int PortMasterId { get; set; }
        public long CouteryMasterId { get; set; }
    }
}
