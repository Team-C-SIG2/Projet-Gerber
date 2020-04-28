using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class Editor
    {

        public Editor()
        {
            Books = new HashSet<Book>();
        }


        [Key]
        public int Id { get; set; }


        [DisplayName("Editeur")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }


        [DisplayName("Pays")]
        [Required]
        [StringLength(3)]
        public string CountryCode { get; set; }

        [DisplayName("URL")]
        [Column("URL")]
        [StringLength(255)]
        public string Url { get; set; }


        [StringLength(255)]
        public string Email { get; set; }


        [DisplayName("Libre(s)")]
        [InverseProperty("IdEditorNavigation")]
        public virtual ICollection<Book> Books { get; set; }


    }// End Class 
}
