using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblExchangeCurrency
    {
        public long Id { get; set; }
        public long CurrencyId { get; set; }
        public DateTime UpdateDate { get; set; }
        public decimal UsdexchangeRate { get; set; }
        public decimal YenexchangeRate { get; set; }

        public virtual TblCurrencyMaster Currency { get; set; }
    }
}
