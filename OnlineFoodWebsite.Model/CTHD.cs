namespace OnlineFoodWebsite.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        [StringLength(30)]
        public string MACTHD { get; set; }

        [StringLength(30)]
        public string MAMON { get; set; }

        [StringLength(30)]
        public string MAHD { get; set; }

        [StringLength(30)]
        public string GHICHU { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual MON MON { get; set; }
        public int? SOLUONG { get; set; }
    }
}
