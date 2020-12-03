using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblYardCharge
    {
        public long Id { get; set; }
        public long YardId { get; set; }
        public string ChargesDiscription { get; set; }
        public string ProductType { get; set; }
        public string SlabType { get; set; }
        public long SlabTypeId { get; set; }
        public decimal Fee { get; set; }
        public long PortId { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public decimal? ShippingCharge { get; set; }
        public decimal? VanningCharge { get; set; }
        public decimal? ParkingFee { get; set; }
    }
}
