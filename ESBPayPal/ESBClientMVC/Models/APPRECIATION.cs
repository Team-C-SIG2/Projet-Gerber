namespace ESBClientMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("APPRECIATIONS")]
    public partial class APPRECIATION
    {
        public int ID { get; set; }

        public int ID_LINEITEM { get; set; }

        public int ID_ORDER { get; set; }

        public int ID_PAYMENT { get; set; }

        [Required]
        [StringLength(20)]
        public string EVALUATION { get; set; }

        public virtual LINEITEM LINEITEM { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual PAYMENT PAYMENT { get; set; }
    }
}
