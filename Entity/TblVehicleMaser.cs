using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblVehicleMaser
    {
        public long Id { get; set; }
        public long MakeId { get; set; }
        public long ModelId { get; set; }
        public long TypeId { get; set; }
        public long VariantId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Weight { get; set; }
        public decimal M3 { get; set; }
        public decimal AverageSellingPric { get; set; }
        public long CategoryMasterId { get; set; }
    }
}
