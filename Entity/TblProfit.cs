using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblProfit
    {
        public Guid Id { get; set; }
        public long Countryid { get; set; }
        public long Modelid { get; set; }
        public decimal Profit { get; set; }
        public decimal Concession { get; set; }
        public decimal Negotiable { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
