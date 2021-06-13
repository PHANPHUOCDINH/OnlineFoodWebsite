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
        [StringLength(10)]
        public string MANV { get; set; }

        [StringLength(30)]
        public string TENTK { get; set; }

        [StringLength(40)]
        public string HOTEN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYSINH { get; set; }

        public int? GIOITINH { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }
    }
}
