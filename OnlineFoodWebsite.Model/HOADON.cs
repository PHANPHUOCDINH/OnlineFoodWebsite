namespace OnlineFoodWebsite.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        [StringLength(10)]
        public string MAHD { get; set; }

        [StringLength(10)]
        public string MAKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYLAP { get; set; }

        [Column(TypeName = "money")]
        public decimal? THANHTIEN { get; set; }

        public int? GIAMGIA { get; set; }

        [StringLength(50)]
        public string GHICHU { get; set; }

        [StringLength(30)]
        public string TRANGTHAI { get; set; }
    }
}
