namespace OnlineFoodWebsite.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ARTICLE")]
    public partial class ARTICLE
    {
        [StringLength(10)]
        public string ArticleId { get; set; }

        [StringLength(60)]
        public string ArticleTitle { get; set; }

        public string ArticleDes { get; set; }

        [StringLength(128)]
        public string ArticleImg { get; set; }

        public DateTime? ArticleDate { get; set; }
    }
}
