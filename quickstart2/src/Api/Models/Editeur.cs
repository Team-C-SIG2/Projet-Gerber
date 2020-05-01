using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("EDITEURS")]
    public partial class Editeur
    {
        public Editeur()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(128)]
        public string Name { get; set; }
        [Column("URL")]
        [StringLength(128)]
        public string Url { get; set; }
        [Required]
        [Column("EMAIL")]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [Column("COUNTRYCODE")]
        [StringLength(3)]
        public string Countrycode { get; set; }

        [InverseProperty(nameof(Book.IdEditorNavigation))]
        public virtual ICollection<Book> Books { get; set; }
    }
}
