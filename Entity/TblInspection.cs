using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblInspection
    {
        public Guid Id { get; set; }
        public long Countryid { get; set; }
        public long ForCountry { get; set; }
    }
}
