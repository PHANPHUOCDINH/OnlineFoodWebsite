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
        [Key]
        [StringLength(10)]
        public string MANL { get; set; }

        [StringLength(30)]
        public string TENNL { get; set; }

        [StringLength(50)]
        public string MOTA { get; set; }

        [StringLength(30)]
        public string TINHTRANG { get; set; }
    }
}
