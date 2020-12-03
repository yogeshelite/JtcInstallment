using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblVariantMaster
    {
        public long Id { get; set; }
        public string VariantName { get; set; }
        public long VehicleMasterL { get; set; }
    }
}
