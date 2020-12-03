using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblAgentMaster
    {
        public long Id { get; set; }
        public string AgentName { get; set; }
        public string ContactPerson { get; set; }
        public string AgentAddress { get; set; }
        public string Fax { get; set; }
        public string Phone { get; set; }
        public long Telephone { get; set; }
        public string Email { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteStatus { get; set; }
        public long? CompanyId { get; set; }
    }
}
