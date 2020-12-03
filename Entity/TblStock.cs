using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace jtcinstallment.Api.Entity
{
    public partial class TblStock
    {
        public long Id { get; set; }
        public long? StockId { get; set; }
        public string StockNumber { get; set; }
        public string Description { get; set; }
        public string ProductType { get; set; }
        public long? ProductId { get; set; }
        public long? SourcePort { get; set; }
        public long? DestinationPort { get; set; }
        public long? YardId { get; set; }
        public long? VesselId { get; set; }
        public DateTime? Eta { get; set; }
        public DateTime? Etd { get; set; }
        public long? AuctionId { get; set; }
        public string Etc { get; set; }
        public string AuctionGrade { get; set; }
        public DateTime? FirstRegistrationDate { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public string ChassisNumber { get; set; }
        public decimal? Mileage { get; set; }
        public decimal? FakeMileage { get; set; }
        public long? ColorId { get; set; }
        public string DefaultImage { get; set; }
        public string ExtraFeature { get; set; }
        public string OtherFeature { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? EntryDate { get; set; }
        public string AccountStatus { get; set; }
        public string Remark { get; set; }
        public long? CustomerId { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddress { get; set; }
        public string RangeofMilage { get; set; }
        public string NotifyParty { get; set; }
        public decimal? BuyingPrice { get; set; }
        public decimal? BuyingTax { get; set; }
        public decimal? RepairPrice { get; set; }
        public decimal? RepairTax { get; set; }
        public string Extracharges { get; set; }
        public decimal? ExtrachargesTax { get; set; }
        public decimal? Realisticcharges { get; set; }
        public decimal? RealisticchargesTax { get; set; }
        public decimal? CifPrice { get; set; }
        public decimal? CifTax { get; set; }
        public decimal? Cf { get; set; }
        public decimal? Cftax { get; set; }
        public decimal? Duty { get; set; }
        public decimal? DutyTax { get; set; }
        public decimal? MssLevy { get; set; }
        public decimal? MssLevyTax { get; set; }
        public decimal? DeliveryOrder { get; set; }
        public decimal? DeliveryOrderTax { get; set; }
        public decimal? PortCharges { get; set; }
        public decimal? PortChargesTax { get; set; }
        public decimal? AgentFess { get; set; }
        public decimal? AgentFessTax { get; set; }
        public decimal? RadiationCharges { get; set; }
        public decimal? RadiationTax { get; set; }
        public decimal? CEleven { get; set; }
        public decimal? CElevenTax { get; set; }
        public decimal? Expenses { get; set; }
        public decimal? ExpensesTax { get; set; }
        public decimal? LocalInspection { get; set; }
        public decimal? LocallnspectionTax { get; set; }
        public decimal? Warehouse { get; set; }
        public decimal? WarehouseTax { get; set; }
        public long? CurrencyId { get; set; }
        public string ExchangeRateYenDoller { get; set; }
        public decimal? ExchangeRateKesDoller { get; set; }
        public decimal? OfferPrice { get; set; }
        public string Location { get; set; }
        public string RegisterNo { get; set; }
        public string Model { get; set; }
        public string Clr { get; set; }
        public string Extras { get; set; }
        public string Cc { get; set; }
        public string Drive { get; set; }
        public string Fuel { get; set; }
        public decimal? TotalKes { get; set; }
        public decimal? GrandTotal { get; set; }
        public int? IsImport { get; set; }

        public virtual TblProduct Product { get; set; }

        [NotMapped]
        public object StockImportDetail { get; set; }
    }
}
