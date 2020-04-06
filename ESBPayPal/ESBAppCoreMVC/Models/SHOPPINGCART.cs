namespace ESBAppCoreMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SHOPPINGCARTS")]
    public partial class SHOPPINGCART
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SHOPPINGCART()
        {
            LINEITEMS = new HashSet<LINEITEM>();
        }

        public int ID { get; set; }

        public DateTime CREATEDDATE { get; set; }

        public int ID_ACCOUNT { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LINEITEM> LINEITEMS { get; set; }
    }
}
