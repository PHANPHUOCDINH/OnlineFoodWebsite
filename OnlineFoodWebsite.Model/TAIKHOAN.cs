namespace OnlineFoodWebsite.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        public bool ROLE { get; set; }

        [Key]
        [StringLength(30)]
        public string TENTK { get; set; }

        [StringLength(20)]
        public string MK { get; set; }
    }
}
