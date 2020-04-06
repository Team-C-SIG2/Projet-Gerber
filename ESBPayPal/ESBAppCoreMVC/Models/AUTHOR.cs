namespace ESBAppCoreMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AUTHORS")]
    public partial class AUTHOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AUTHOR()
        {
            BOOKS = new HashSet<BOOK>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string LASTNAME { get; set; }

        [Required]
        [StringLength(100)]
        public string FIRSTNAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOOK> BOOKS { get; set; }
    }
}
