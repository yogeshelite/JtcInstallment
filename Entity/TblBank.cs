using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblBank
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool ForJtc { get; set; }
        public long? CountryId { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
