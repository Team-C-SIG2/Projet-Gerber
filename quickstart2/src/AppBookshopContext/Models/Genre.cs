using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBookshopContext.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Ranks = new HashSet<Rank>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [InverseProperty("IdGenreNavigation")]
        public virtual ICollection<Rank> Ranks { get; set; }
    }
}
