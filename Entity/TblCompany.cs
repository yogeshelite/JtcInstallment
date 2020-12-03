using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblCompany
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string Emailid { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string CompanyType { get; set; }
        public string Facility { get; set; }
    }
}
