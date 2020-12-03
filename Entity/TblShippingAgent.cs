using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblShippingAgent
    {
        public TblShippingAgent()
        {
            TblShippingAgentCharges = new HashSet<TblShippingAgentCharges>();
        }

        public long Id { get; set; }
        public long? CountryId { get; set; }
        public string ShippingAgentName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public virtual ICollection<TblShippingAgentCharges> TblShippingAgentCharges { get; set; }
    }
}
