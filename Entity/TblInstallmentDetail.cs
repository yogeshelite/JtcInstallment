using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblInstallmentDetail
    {
        public long Id { get; set; }
        public long? InstallmentId { get; set; }
        public DateTime? InstallmentDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string PaymentStatus { get; set; }
        public string ReffNo { get; set; }
        public string PaymentBy { get; set; }
        public decimal? TaxPer { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? FinalAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public DateTime? InstallmentGivenDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? Status { get; set; }
    }
}
