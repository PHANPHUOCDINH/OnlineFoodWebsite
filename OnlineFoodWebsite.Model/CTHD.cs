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
        [Column(Order = 0)]
        [StringLength(10)]
        public string MAHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MAKH { get; set; }

        [StringLength(10)]
        public string MAMON { get; set; }

        [StringLength(30)]
        public string GHICHU { get; set; }
    }
}
