using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblInvoiceAdjustmentAudit
    {
        public long AuditId { get; set; }
        public long InvoiceId { get; set; }
        public decimal AdjustFromAdvance { get; set; }
        public decimal AdjustFromBalance { get; set; }
        public decimal TotalAdjustAmount { get; set; }
        public decimal YenExchangeValue { get; set; }
        public string Currency { get; set; }
        public long CustomerId { get; set; }
        public DateTime UpdateDate { get; set; }
        public long UpdatedByUserId { get; set; }
        public long UserMasterId { get; set; }
    }
}
