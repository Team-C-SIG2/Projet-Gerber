namespace ESBAppCoreMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LINEITEMS")]
    public partial class LINEITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LINEITEM()
        {
            APPRECIATIONS = new HashSet<APPRECIATION>();
        }

        public int ID { get; set; }

        public int ID_SHOPPINGCART { get; set; }

        public int ID_BOOK { get; set; }

        public int QUANTITY { get; set; }

        [Column(TypeName = "money")]
        public decimal UNITPRICE { get; set; }

        public int ID_ORDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPRECIATION> APPRECIATIONS { get; set; }

        public virtual BOOK BOOK { get; set; }

        public virtual SHOPPINGCART SHOPPINGCART { get; set; }
    }
}
