using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblStock = new HashSet<TblStock>();
        }

        public long Id { get; set; }
        public string ProductType { get; set; }
        public string Discription { get; set; }
        public long MakerId { get; set; }
        public long ModelId { get; set; }
        public long Typeid { get; set; }
        public long VariantId { get; set; }
        public string ChassisType { get; set; }
        public int? NoOfSeats { get; set; }
        public int? NoOfDoors { get; set; }
        public string Drive { get; set; }
        public string Fuel { get; set; }
        public string Hours { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string EngineCc { get; set; }

        public virtual ICollection<TblStock> TblStock { get; set; }
    }
}
