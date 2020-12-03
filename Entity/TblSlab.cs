using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblSlab
    {
        public long Id { get; set; }
        public string SlabFrom { get; set; }
        public string SlabTo { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string SlabSign { get; set; }
    }
}
