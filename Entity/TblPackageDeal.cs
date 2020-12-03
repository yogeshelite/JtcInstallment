using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblPackageDeal
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CountryId { get; set; }
        public string IncludeCharges { get; set; }
        public string PackType { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
