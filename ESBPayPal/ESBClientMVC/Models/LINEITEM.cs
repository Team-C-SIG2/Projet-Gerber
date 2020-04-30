namespace ESBClientMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;


    [Table("LINEITEMS")]
    public partial class LINEITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LINEITEM()
        {
            APPRECIATIONS = new HashSet<APPRECIATION>();
        }

        // Change column name to PersonId
        [DisplayName("Ligne")]
        public int ID { get; set; }

        [DisplayName("Panier")]
        public int ID_SHOPPINGCART { get; set; }

        [DisplayName("Livre")]
        public int ID_BOOK { get; set; }

        [DisplayName("Quantité")]
        public int QUANTITY { get; set; }


        // [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid Target Price; Maximum Two Decimal Points.")]
        // [PrecisionAndScale(6, 2, ErrorMessage = "Total Cost must not exceed $9999.99")]
        //  [Column(TypeName = "money")]

        [DisplayName("Prix unitaire")]
        [Column(TypeName = "money")]
        public decimal UNITPRICE { get; set; }

        [DisplayName("Commande")]
        public int ID_ORDER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPRECIATION> APPRECIATIONS { get; set; }

        public BOOK BOOK { get; set; }

        public virtual SHOPPINGCART SHOPPINGCART { get; set; }
    }
}
