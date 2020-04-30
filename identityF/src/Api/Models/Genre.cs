using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("GENRES")]
    public partial class Genre
    {
        public Genre()
        {
            Ranks = new HashSet<Rank>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(100)]
        public string Description { get; set; }

        [InverseProperty(nameof(Rank.IdGenreNavigation))]
        public virtual ICollection<Rank> Ranks { get; set; }
    }
}
