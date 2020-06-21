using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class Author
    {
        public Author()
        {
            Cowriters = new HashSet<Cowriter>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nom de famille")]
        [StringLength(100)]
        public string Lastname { get; set; }
        [Required]
        [Display(Name = "Prénom")]
        [StringLength(100)]
        public string Firstname { get; set; }

        [InverseProperty(nameof(Cowriter.IdAuthorNavigation))]
        public virtual ICollection<Cowriter> Cowriters { get; set; }
    }
}
