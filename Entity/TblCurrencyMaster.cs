using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblCurrencyMaster
    {
        public TblCurrencyMaster()
        {
            TblCustomerDeal = new HashSet<TblCustomerDeal>();
            TblExchangeCurrency = new HashSet<TblExchangeCurrency>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal DollerExchangeValue { get; set; }
        public decimal YenExchangeValue { get; set; }
        public string CurrencyType { get; set; }
        public string Status { get; set; }
        public long? StockId { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteStatus { get; set; }
        public long? CountryId { get; set; }
        public decimal? KenyanShillingExchangeValue { get; set; }

        public virtual ICollection<TblCustomerDeal> TblCustomerDeal { get; set; }
        public virtual ICollection<TblExchangeCurrency> TblExchangeCurrency { get; set; }
    }
}
