using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblCustomerMaster
    {
        public TblCustomerMaster()
        {
            TblCustomerDeal = new HashSet<TblCustomerDeal>();
            TblInvoice = new HashSet<TblInvoice>();
        }

        public long Id { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string EmailId { get; set; }
        public DateTime? RecordDate { get; set; }
        public long? UserId { get; set; }
        public string Password { get; set; }
        public string TypeOfCustomer { get; set; }
        public string Comments { get; set; }
        public bool? Active { get; set; }
        public long? InvoiceAdjustmentAuditAudit { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Mobileno { get; set; }
        public long? CountryId { get; set; }
        public string Country { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteStatus { get; set; }
        public long? UserTypeId { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddress { get; set; }
        public string CustomerCode { get; set; }
        public string LastName { get; set; }
        public string Imageurl { get; set; }

        public virtual ICollection<TblCustomerDeal> TblCustomerDeal { get; set; }
        public virtual ICollection<TblInvoice> TblInvoice { get; set; }
    }
}
