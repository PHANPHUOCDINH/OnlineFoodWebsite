namespace OnlineFoodWebsite.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [Key]
        [StringLength(30)]
        public string MANV { get; set; }

        [StringLength(40)]
        public string TENNV { get; set; }

        [StringLength(10)]
        public string TAIKHOAN { get; set; }

        [StringLength(50)]
        public string MATKHAU { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYSINH { get; set; }

        public int? GIOITINH { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        [StringLength(30)]
        public string CHUCVU { get; set; }

        [StringLength(60)]
        public string HINHANH { get; set; }

        public DateTime? LASTACTIVE { get; set; }
    }
}
