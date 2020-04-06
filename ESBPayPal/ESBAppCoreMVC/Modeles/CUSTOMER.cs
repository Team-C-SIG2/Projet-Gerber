namespace ESBAppCoreMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUSTOMERS")]
    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            // ACCOUNTS = new HashSet<ACCOUNT>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(4)]
        public string ACRONYME { get; set; }

        [Required]
        [StringLength(50)]
        public string FIRSTNAME { get; set; }

        [Required]
        [StringLength(100)]
        public string LASTNAME { get; set; }

        [Required]
        [StringLength(255)]
        public string ADDRESS { get; set; }

        [Required]
        [StringLength(4)]
        public string ZIP { get; set; }

        [Required]
        [StringLength(100)]
        public string CITY { get; set; }

        [StringLength(13)]
        public string PHONE { get; set; }

        [Required]
        [StringLength(255)]
        public string EMAIL { get; set; }

        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       // public virtual ICollection<ACCOUNT> ACCOUNTS { get; set; }
    }
}
