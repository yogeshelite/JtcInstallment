using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace jtcinstallment.Api.Entity
{
    public partial class TblYard
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int NumberOfFreeDay { get; set; }
        public string AgentId { get; set; }
        public string PortId { get; set; }
        public decimal? HandlingChages { get; set; }
        public decimal? RadiationCharges { get; set; }
        public decimal? GodownCharges { get; set; }
        public decimal? OtherCharges { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        [NotMapped]
        public long CountryId { get; set; }
        [NotMapped]
        public string LocationDescription { get; set; }
    }
}
