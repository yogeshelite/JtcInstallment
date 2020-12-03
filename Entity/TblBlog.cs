using System;
using System.Collections.Generic;

namespace jtcinstallment.Api.Entity
{
    public partial class TblBlog
    {
        public int Id { get; set; }
        public string Discription { get; set; }
        public string Imageurl { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public DateTime? RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
