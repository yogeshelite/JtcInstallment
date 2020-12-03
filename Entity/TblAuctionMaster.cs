using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblAuctionMaster
    {
        public long Id { get; set; }
        public string AuctionName { get; set; }
        public long CountryId { get; set; }
        public string LocationName { get; set; }
    }
}
