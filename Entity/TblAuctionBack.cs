using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblAuctionBack
    {
        public Guid Id { get; set; }
        public long CompanyId { get; set; }
        public string StockNumber { get; set; }
        public string SourceTypeAuctionOrYard { get; set; }
        public long SourceId { get; set; }
        public string DestinationTypeAuctionOrYard { get; set; }
        public long DestinationId { get; set; }
        public long TypeId { get; set; }
        public decimal Price { get; set; }
        public long StockId { get; set; }
        public long? TranspotationId { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public long? CurrencyId { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? AuctionFee { get; set; }
        public decimal? MiscellaneousCharges { get; set; }
        public string Comment { get; set; }
    }
}
