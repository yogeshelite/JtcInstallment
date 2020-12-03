using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblExtraCharge
    {
        public Guid Id { get; set; }
        public string StockNumber { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
    }
}
