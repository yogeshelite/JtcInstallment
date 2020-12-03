using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblRegister
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RegisterType { get; set; }
        public bool AppStatus { get; set; }
        public string MobileNo { get; set; }
        public string CustomerCode { get; set; }
        public string Otp { get; set; }
        public DateTime? RecordStatus { get; set; }
        public DateTime? UpdateStatus { get; set; }
        public DateTime? DeleteStatus { get; set; }
    }
}
