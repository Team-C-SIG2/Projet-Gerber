using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class Editor
    {
        public Editor()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(3)]
        public string CountryCode { get; set; }
        [Column("URL")]
        [StringLength(255)]
        public string Url { get; set; }
        [StringLength(255)]
        public string Email { get; set; }

        [InverseProperty(nameof(Book.IdEditorNavigation))]
        public virtual ICollection<Book> Books { get; set; }
    }
}
