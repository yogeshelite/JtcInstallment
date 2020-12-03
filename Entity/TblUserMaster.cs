using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblUserMaster
    {
        public TblUserMaster()
        {
            TblInvoice = new HashSet<TblInvoice>();
            TblSetting = new HashSet<TblSetting>();
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public long UserTypeId { get; set; }
        public string Email { get; set; }
        public long Moble { get; set; }
        public DateTime? RecordDate { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public long CustomerMasterL { get; set; }
        public DateTime? DeleteStatus { get; set; }
        public bool? TurnFlag { get; set; }

        public virtual ICollection<TblInvoice> TblInvoice { get; set; }
        public virtual ICollection<TblSetting> TblSetting { get; set; }
    }
}
