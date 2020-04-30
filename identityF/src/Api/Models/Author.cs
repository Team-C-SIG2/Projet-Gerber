using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("AUTHORS")]
    public partial class Author
    {
        public Author()
        {
            Cowriters = new HashSet<Cowriter>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("LASTNAME")]
        [StringLength(100)]
        public string Lastname { get; set; }
        [Required]
        [Column("FIRSTNAME")]
        [StringLength(100)]
        public string Firstname { get; set; }

        [InverseProperty(nameof(Cowriter.IdAuthorNavigation))]
        public virtual ICollection<Cowriter> Cowriters { get; set; }
    }
}
