using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblInspectionCompanyFee
    {
        public Guid Id { get; set; }
        public Guid Inspectonid { get; set; }
        public long Companyid { get; set; }
        public bool IsRequired { get; set; }
        public decimal? InspectionFee { get; set; }
    }
}
