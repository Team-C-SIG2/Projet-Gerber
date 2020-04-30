namespace ESBClientMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;


    [Table("BOOKS")]
    public partial class BOOK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOOK()
        {
            LINEITEMS = new HashSet<LINEITEM>();
            RANKS = new HashSet<RANK>();
            STOCKS = new HashSet<STOCK>();
            AUTHORS = new HashSet<AUTHOR>();
        }

        public int ID { get; set; }

        public int ID_EDITEUR { get; set; }

        [DisplayName("Titre")]
        [Required]
        [StringLength(255)]
        public string TITLE { get; set; }

        [DisplayName("Sous titre")]
        [StringLength(128)]
        public string SUBTITLE { get; set; }

        [DisplayName("Prix")]
        [Column(TypeName = "money")]
        public decimal PRICE { get; set; }

        [DisplayName("Date de publication")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DATEPUBLICATION { get; set; }


        [Required]
        [StringLength(255)]
        [DisplayName("Résumé")]
        public string SUMMARY { get; set; }

        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }

        public virtual EDITEUR EDITEUR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LINEITEM> LINEITEMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RANK> RANKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCK> STOCKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTHOR> AUTHORS { get; set; }
    }
}
