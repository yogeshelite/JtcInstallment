using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblCustomerRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime RequestDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public long? SelectedCurrencyId { get; set; }
        public string StockNumber { get; set; }
        public decimal? CustomerOffer { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string Description { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Comment { get; set; }
        public string SoldStatus { get; set; }
        public long? UserTypeId { get; set; }
        public bool? TurnFlag { get; set; }
        public string Status { get; set; }
    }
}
