using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblCustomerTt
    {
        public long Id { get; set; }
        public string Ttstatus { get; set; }
        public long Customerid { get; set; }
        public string TtreferenceNo { get; set; }
        public string Year { get; set; }
        public long? SalemanId { get; set; }
        public long? ReceivedBankId { get; set; }
        public string BankReferenceNo { get; set; }
        public DateTime? Ttdate { get; set; }
        public string RemmiterName { get; set; }
        public long? RemmiterBankId { get; set; }
        public string RemmiterBankName { get; set; }
        public long? CurrencyId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AdvanceRecieved { get; set; }
        public decimal? BankCharges { get; set; }
        public decimal? ToatalAmount { get; set; }
        public string ComfirmBy { get; set; }
        public string Remarks { get; set; }
        public long? AccountantId { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public decimal? RefundAmount { get; set; }
        public decimal? RefundBankCharge { get; set; }
        public DateTime? RefundDate { get; set; }
        public string RefundRemarks { get; set; }
        public long? TransferttId { get; set; }
        public string TransferRemarks { get; set; }
        public string ReceviedRemarks { get; set; }
        public long? TransferAmount { get; set; }
        public decimal? TransferBankCharge { get; set; }
        public DateTime? TransferDate { get; set; }
        public decimal? ReceviedAmount { get; set; }
        public DateTime? ReceviedDate { get; set; }
    }
}
