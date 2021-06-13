namespace OnlineFoodWebsite.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [Key]
        [StringLength(10)]
        public string MAKH { get; set; }

        [StringLength(30)]
        public string TENTK { get; set; }

        [StringLength(40)]
        public string HOTEN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYSINH { get; set; }

        [StringLength(50)]
        public string DIACHI { get; set; }

        public int? GIOITINH { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }
    }
}
