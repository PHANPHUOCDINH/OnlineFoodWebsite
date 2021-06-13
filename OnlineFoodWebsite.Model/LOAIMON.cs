namespace OnlineFoodWebsite.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIMON")]
    public partial class LOAIMON
    {
        [Key]
        [StringLength(10)]
        public string MALOAI { get; set; }

        [StringLength(20)]
        public string TENLOAI { get; set; }
    }
}
