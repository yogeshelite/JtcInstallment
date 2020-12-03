using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblCategoryMaster
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string CategoryType { get; set; }
        public string Type { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public decimal? Profit { get; set; }
        public decimal? Concessions { get; set; }
        public long? CurrencyId { get; set; }
        public decimal? NegotiableAmount { get; set; }
        public string Discription { get; set; }
        public string BrandUrl { get; set; }
        public bool? MakerForoffer { get; set; }
    }
}
