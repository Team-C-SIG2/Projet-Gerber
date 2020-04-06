namespace ESBClientMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;


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
        [DisplayName("Mot de passe")]
        public string PASSWORD { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Nom d'utilisateur")]
        public string LOGINNAME { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("Etat")]
        public string USERSTATE { get; set; }

        [DisplayName("Date d'insription")]
        public DateTime REGISTRATIONDATE { get; set; }

        [DisplayName("Fermé?")]
        public bool ISCLOSED { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Adresse de facturation")]
        public string BILLINGADDRESS { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Type de compte")]
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
