using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblPortAgent
    {
        public long IdPa { get; set; }
        public long PortId { get; set; }
        public long AgentId { get; set; }
        public decimal Price { get; set; }
    }
}
