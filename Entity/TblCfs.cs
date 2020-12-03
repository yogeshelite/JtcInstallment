using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblCfs
    {
        public long Id { get; set; }
        public string VoyageNo { get; set; }
        public string Cfsname { get; set; }
        public int Capacity { get; set; }
        public decimal? Frieght { get; set; }
        public int? Size { get; set; }
        public bool? FullStatus { get; set; }
        public string ContainerNumber { get; set; }
        public int? ProductCount { get; set; }
        public DateTime? DeleteStatus { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
