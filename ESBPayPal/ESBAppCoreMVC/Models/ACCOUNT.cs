namespace ESBAppCoreMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNTS")]
    public partial class ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACCOUNT()
        {
            ORDERS = new HashSet<ORDER>();
            PAYMENTS = new HashSet<PAYMENT>();
            SHOPPINGCARTS = new HashSet<SHOPPINGCART>();
        }

        public int ID { get; set; }

        public int ID_CUTOMER { get; set; }

        [Required]
        [StringLength(15)]
        public string PASSWORD { get; set; }

        [Required]
        [StringLength(100)]
        public string LOGINNAME { get; set; }

        [Required]
        [StringLength(25)]
        public string USERSTATE { get; set; }

        public DateTime REGISTRATIONDATE { get; set; }

        public bool ISCLOSED { get; set; }

        [Required]
        [StringLength(255)]
        public string BILLINGADDRESS { get; set; }

        [Required]
        [StringLength(20)]
        public string TYPE { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYMENT> PAYMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHOPPINGCART> SHOPPINGCARTS { get; set; }
    }
}
