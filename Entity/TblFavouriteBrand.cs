using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblFavouriteBrand
    {
        public long Id { get; set; }
        public string Favouritebrand { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string Comment { get; set; }
    }
}
