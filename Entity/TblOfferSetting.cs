using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblOfferSetting
    {
        public long Id { get; set; }
        public string OfferHeader { get; set; }
        public string OfferSubHeader { get; set; }
        public string LStatus { get; set; }
    }
}
