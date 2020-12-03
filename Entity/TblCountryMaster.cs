using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblCountryMaster
    {
        public TblCountryMaster()
        {
            TblCustomerDeal = new HashSet<TblCustomerDeal>();
        }

        public long Id { get; set; }
        public string CountryName { get; set; }
        public bool? Active { get; set; }
        public string CountryCode { get; set; }
        public string DialingCode { get; set; }
        public string CurrencyCode { get; set; }
        public string Symbols { get; set; }
        public bool? InspectionRequired { get; set; }
        public string InspectionCompanyId { get; set; }
        public decimal? DefaultInspectionFee { get; set; }
        public decimal? DefaultAuctionFee { get; set; }
        public decimal? DefaultRecycleFee { get; set; }
        public decimal? DefaultRepairFee { get; set; }
        public decimal? DefaultTransportationFee { get; set; }
        public decimal? DefaultInspectionValidInMonth { get; set; }
        public decimal? DefaultTax { get; set; }
        public decimal? DefaultCif { get; set; }

        public virtual ICollection<TblCustomerDeal> TblCustomerDeal { get; set; }
    }
}
