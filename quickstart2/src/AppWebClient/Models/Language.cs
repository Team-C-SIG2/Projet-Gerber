using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class Language
    {
        public Language()
        {
            Ranks = new HashSet<Rank>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Description { get; set; }
        [Required]
        [StringLength(3)]
        public string Code { get; set; }

        [InverseProperty(nameof(Rank.IdLanguageNavigation))]
        public virtual ICollection<Rank> Ranks { get; set; }
    }
}
