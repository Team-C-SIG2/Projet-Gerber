namespace ESBClientMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EDITEURS")]
    public partial class EDITEUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EDITEUR()
        {
            BOOKS = new HashSet<BOOK>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string NAME { get; set; }

        [StringLength(128)]
        public string URL { get; set; }

        [Required]
        [StringLength(255)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(3)]
        public string COUNTRYCODE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BOOK> BOOKS { get; set; }
    }
}
