using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblCustomerDeal
    {
        public Guid Id { get; set; }
        public long CustomerId { get; set; }
        public string ChargesType { get; set; }
        public string VesselType { get; set; }
        public decimal? InspectionCharges { get; set; }
        public decimal? ShippingCharges { get; set; }
        public decimal? HandlingCharges { get; set; }
        public decimal? VanningCharges { get; set; }
        public decimal? OtherCharges { get; set; }
        public decimal? Freight { get; set; }
        public decimal? SealCharges { get; set; }
        public decimal? Blcharges { get; set; }
        public decimal? MiscellaneouseCharges { get; set; }
        public long? SlabId { get; set; }
        public string DealType { get; set; }
        public string DealName { get; set; }
        public long? CarTypeId { get; set; }
        public int? NoofCar { get; set; }
        public long CountryId { get; set; }
        public long CurrencyId { get; set; }
        public decimal? SizeFrom { get; set; }
        public decimal? SizeTo { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? DealStartDate { get; set; }
        public DateTime? DealEndDate { get; set; }
        public DateTime? PaymentDeadLineDate { get; set; }
        public decimal? PriceRangeFrom { get; set; }
        public decimal? PriceRangeTo { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? ProfitAmount { get; set; }
        public int? NumberOfContainer { get; set; }
        public string Comment { get; set; }

        public virtual TblCountryMaster Country { get; set; }
        public virtual TblCurrencyMaster Currency { get; set; }
        public virtual TblCustomerMaster Customer { get; set; }
    }
}
