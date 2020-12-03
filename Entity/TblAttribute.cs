using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblAttribute
    {
        public long Id { get; set; }
        public string Attribute { get; set; }
        public string Type { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string Name { get; set; }
    }
}
