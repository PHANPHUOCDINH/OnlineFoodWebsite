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
        [Key]
        [StringLength(10)]
        public string MAMON { get; set; }

        [StringLength(30)]
        public string TENMON { get; set; }

        [StringLength(50)]
        public string MOTA { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIA { get; set; }

        public int? TINHTRANG { get; set; }

        [StringLength(10)]
        public string LOAIMON { get; set; }
    }
}
