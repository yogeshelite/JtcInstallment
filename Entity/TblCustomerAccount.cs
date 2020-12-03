using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblCustomerAccount
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public decimal TotalDepositAmountUsd { get; set; }
        public decimal TotalDepositBalanceUsd { get; set; }
        public decimal TotalDepositAdvanceUsd { get; set; }
        public decimal TotalAdjustedAmountUsd { get; set; }
        public decimal TotalAdjustedBalanceUsd { get; set; }
        public decimal TotalAdjustedAdvanceUsd { get; set; }
        public decimal TotalDepositAmountJpy { get; set; }
        public decimal TotalDepositBalanceJpy { get; set; }
        public decimal TotalDepositAdvanceJpy { get; set; }
        public decimal TotalAdjustedAmountJpy { get; set; }
        public decimal TotalAdjustedBalanceJpy { get; set; }
        public decimal TotalAdjustedAdvanceJpy { get; set; }
        public decimal RefundAmountUsd { get; set; }
        public decimal AdvanceAmountUsd { get; set; }
        public decimal BalanceAmountUsd { get; set; }
        public decimal RefundAmountJpy { get; set; }
        public decimal AdvanceAmountJpy { get; set; }
        public decimal BalanceAmountJpy { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string AccountUpdateStatus { get; set; }
        public decimal TransferAmountUsd { get; set; }
        public decimal TransferAmountJpy { get; set; }
        public string TransferRemarks { get; set; }
        public long AccountantId { get; set; }
        public long CustomerMasterId { get; set; }
        public long UserMasterId { get; set; }
    }
}
