﻿using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblInvoiceHistory
    {
        public long Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string StockNumber { get; set; }
        public long? CustomerId { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? SalePrice { get; set; }
        public string Status { get; set; }
        public DateTime? CancelDate { get; set; }
        public string PaymentStatus { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal? BalanceAmount { get; set; }
        public decimal? Fobprice { get; set; }
        public decimal? Cifprice { get; set; }
        public DateTime? EntryDate { get; set; }
        public long? Sno { get; set; }
        public long? UserId { get; set; }
        public DateTime? ReserveDate { get; set; }
        public Guid? ReferenceGuid { get; set; }
        public string Type { get; set; }
        public long? CountryId { get; set; }
        public long? CurrencyId { get; set; }
        public string Comment { get; set; }
        public int? CancelFrom { get; set; }
        public long? AccountantId { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddress { get; set; }
        public bool? IsOriginalConsigne { get; set; }
        public string SaleComment { get; set; }
        public string NotifyParty { get; set; }
        public string PlaceofDischarge { get; set; }
        public string Cfs { get; set; }
        public string AccountantComment { get; set; }
    }
}
