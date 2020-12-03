using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblSaleMaster
    {
        public long Id { get; set; }
        public string SaleReferenceNo { get; set; }
        public Guid ReferenceGuid { get; set; }
        public long? UserId { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string Status { get; set; }
    }
}
