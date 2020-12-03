using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblVehicleAttributeLink
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }
        public long AttributeId { get; set; }
        public string Value { get; set; }
        public bool IsFeaturedAttribu { get; set; }
        public bool IsActive { get; set; }
        public long StockId { get; set; }
        public long AttributesId { get; set; }
    }
}
