namespace ESBClientMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;


    [Table("SHOPPINGCARTS")]
    public partial class SHOPPINGCART
    {
        // //////////////////////////////////////////////////////////////////
        // DATABSE PART
        // //////////////////////////////////////////////////////////////////

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SHOPPINGCART()
        {
            LINEITEMS = new HashSet<LINEITEM>();
        }

        [DisplayName("Panier")]
        public int ID { get; set; }

        [DisplayName("Date de création")]
        public DateTime CREATEDDATE { get; set; }

        [DisplayName("Numéro de Compte")]
        public int ID_ACCOUNT { get; set; }

        
        public virtual ACCOUNT ACCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<LINEITEM> LINEITEMS { get; set; }


    }// End clas 
}
