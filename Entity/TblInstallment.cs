using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace jtcinstallment.Api.Entity
{
    public partial class TblInstallment
    {
        public long Id { get; set; }
        public string StockNumber { get; set; }
        public long? CustomerId { get; set; }
        public long? SalemanId { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? DownPayment { get; set; }
        public int? TimeDurationYears { get; set; }
        public int? TotalInstallment { get; set; }
        public decimal? TaxPer { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? FinalAmount { get; set; }
        public decimal? InstallAmount { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string Installmentmode { get; set; }
        public int? Day { get; set; }
        [NotMapped]
        public string PaymentMode { get; set; }
    }
}
