namespace OnlineFoodWebsite.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MON")]
    public partial class MON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MON()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(30)]
        public string MAMON { get; set; }

        [StringLength(30)]
        public string TENMON { get; set; }

        [StringLength(30)]
        public string MALOAI { get; set; }

        [StringLength(50)]
        public string MOTA { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIA { get; set; }

        [StringLength(20)]
        public string TINHTRANG { get; set; }

        [StringLength(50)]
        public string HINHANH { get; set; }

        [StringLength(10)]
        public string DONVITINH { get; set; }

        public int? SOLUONGBAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual LOAIMON LOAIMON { get; set; }

        public int? temp { get; set; }
    }
}
