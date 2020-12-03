using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblTransportation
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long TypeId { get; set; }
        public decimal Price { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteStatus { get; set; }
        public long SourceId { get; set; }
        public string SourceType { get; set; }
        public long DesstinationId { get; set; }
        public string DestinationType { get; set; }
        public string SourceName { get; set; }
        public string DestinationName { get; set; }
    }
}
