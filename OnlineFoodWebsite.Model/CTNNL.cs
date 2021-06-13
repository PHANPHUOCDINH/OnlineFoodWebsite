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
        [StringLength(10)]
        public string MACTN { get; set; }

        [StringLength(10)]
        public string MANL { get; set; }

        public int? SOLUONG { get; set; }

        [StringLength(10)]
        public string DONVI { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NGAYNHAP { get; set; }
    }
}
