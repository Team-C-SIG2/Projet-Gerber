using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServerAspNetIdentity.Models
{
    public partial class Category
    {
        public Category()
        {
            Ranks = new HashSet<Rank>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [InverseProperty(nameof(Rank.IdCategorieNavigation))]
        public virtual ICollection<Rank> Ranks { get; set; }
    }
}
