using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblFindPerfectFit
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
