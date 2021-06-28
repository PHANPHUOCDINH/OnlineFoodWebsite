namespace OnlineFoodWebsite.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTNNL")]
    public partial class CTNNL
    {
        [Key]
        [StringLength(30)]
        public string MACTN { get; set; }

        [StringLength(30)]
        public string MANL { get; set; }

        [Column(TypeName = "money")]
        public decimal? CHIPHI { get; set; }

        public int? SOLUONG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYNHAP { get; set; }

        [StringLength(10)]
        public string DONVITINH { get; set; }
        [StringLength(30)]
        public string GHICHU { get; set; }
        public virtual NGUYENLIEU NGUYENLIEU { get; set; }
    }
}
