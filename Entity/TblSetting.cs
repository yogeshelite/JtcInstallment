using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblSetting
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public long UserId { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public virtual TblUserMaster User { get; set; }
    }
}
