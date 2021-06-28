namespace OnlineFoodWebsite.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUYENLIEU")]
    public partial class NGUYENLIEU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUYENLIEU()
        {
            CTNNLs = new HashSet<CTNNL>();
        }

        [Key]
        [StringLength(30)]
        public string MANL { get; set; }

        [StringLength(30)]
        public string TENNL { get; set; }
        [StringLength(50)]
        public string MOTA { get; set; }
        [StringLength(50)]
        public string HINHANH { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LASTUPDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTNNL> CTNNLs { get; set; }

        public decimal? temp { get; set; }
    }
}
