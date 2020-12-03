using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblWishlist
    {
        public long Id { get; set; }
        public string CustomerEmail { get; set; }
        public string StockNumber { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
