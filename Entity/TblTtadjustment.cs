using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblTtadjustment
    {
        public long Id { get; set; }
        public string StockNumber { get; set; }
        public string TtrefNo { get; set; }
        public decimal? ActualAdjustedAmount { get; set; }
        public decimal? Adjustedamount { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
