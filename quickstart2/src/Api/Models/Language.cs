using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("LANGUAGES")]
    public partial class Language
    {
        public Language()
        {
            Ranks = new HashSet<Rank>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(20)]
        public string Description { get; set; }
        [Required]
        [Column("CODE")]
        [StringLength(3)]
        public string Code { get; set; }

        [InverseProperty(nameof(Rank.IdLanguageNavigation))]
        public virtual ICollection<Rank> Ranks { get; set; }
    }
}
