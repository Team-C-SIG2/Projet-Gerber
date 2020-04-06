namespace ESBClientMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;

    [Table("CUSTOMERS")]
    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            ACCOUNTS = new HashSet<ACCOUNT>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(4)]
        [DisplayName("Acronyme")]
        public string ACRONYME { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Prénom")]
        public string FIRSTNAME { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Nom")]
        public string LASTNAME { get; set; }

        [Required]
        [StringLength(255)]
        public string ADDRESS { get; set; }

        [Required]
        [StringLength(4)]
        [DisplayName("Rue")]
        public string ZIP { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("NPA")]
        public string CITY { get; set; }

        [StringLength(13)]
        [DisplayName("Téléphone")]
        public string PHONE { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("NPA")]
        public string EMAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACCOUNT> ACCOUNTS { get; set; }
    }
}
