using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblCustomerAccountHistory
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public decimal TotalAdjustedBalance { get; set; }
        public decimal TotalAdjustedAdvance { get; set; }
        public decimal TotalBalanceAmount { get; set; }
        public decimal TotalAdvanceAmount { get; set; }
        public decimal Currency { get; set; }
        public string AccountUpdateForInvoi { get; set; }
        public DateTime UpdateDate { get; set; }
        public string AccountUpdateReason { get; set; }
        public decimal RefundAmountUsd { get; set; }
        public decimal RefundAmountJpy { get; set; }
        public string TransferRemarks { get; set; }
        public long AccountantId { get; set; }
        public long CustomerMasterId { get; set; }
        public long UserMasterId { get; set; }
    }
}
