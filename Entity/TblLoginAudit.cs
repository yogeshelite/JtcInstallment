using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblLoginAudit
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime LoginDate { get; set; }
        public string Ipaddress { get; set; }
        public bool IsSuccess { get; set; }
    }
}
