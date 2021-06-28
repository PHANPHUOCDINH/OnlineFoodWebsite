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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(40)]
        public string MAHD { get; set; }

        [StringLength(40)]
        public string MAKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYLAP { get; set; }

        [Column(TypeName = "money")]
        public decimal? TONGTIEN { get; set; }

        public int? GIAMGIA { get; set; }

        [StringLength(50)]
        public string GHICHU { get; set; }

        [StringLength(30)]
        public string TRANGTHAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
        [StringLength(50)]
        public string PHANHOI { get; set; }

        [StringLength(50)]
        public string GHICHUKHACH { get; set; }

        public decimal? temp { get; set; }
    }
}
