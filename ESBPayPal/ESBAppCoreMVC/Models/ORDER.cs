namespace ESBAppCoreMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERS")]
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            APPRECIATIONS = new HashSet<APPRECIATION>();
        }

        public int ID { get; set; }

        public DateTime ORDEREDDATE { get; set; }

        public DateTime SHIPPEDDATE { get; set; }

        [Required]
        [StringLength(255)]
        public string SHIPPINGADDRESS { get; set; }

        [Required]
        [StringLength(25)]
        public string STATUS { get; set; }

        [Column(TypeName = "money")]
        public decimal TOTALPRICE { get; set; }

        public int ID_ACCOUNT { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPRECIATION> APPRECIATIONS { get; set; }
    }
}
