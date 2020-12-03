using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblFile
    {
        public long Id { get; set; }
        public string StockNumber { get; set; }
        public string DocName { get; set; }
        public string Url { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string DocType { get; set; }
        public bool? SendTocustomer { get; set; }
        public bool? DefaultImage { get; set; }
    }
}
