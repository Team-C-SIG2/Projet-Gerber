namespace ESBClientMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PAYMENTS")]
    public partial class PAYMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAYMENT()
        {
            APPRECIATIONS = new HashSet<APPRECIATION>();
        }

        public int ID { get; set; }

        public DateTime PAIDDATE { get; set; }

        [Column(TypeName = "money")]
        public decimal PRICETOTAL { get; set; }

        [Required]
        [StringLength(255)]
        public string DETAILS { get; set; }

        public int ID_ACCOUNT { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPRECIATION> APPRECIATIONS { get; set; }
    }
}
