using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblYardLocation
    {
        public long Id { get; set; }
        public long YardId { get; set; }
        public string LocationDiscription { get; set; }
        public long CountryId { get; set; }
    }
}
