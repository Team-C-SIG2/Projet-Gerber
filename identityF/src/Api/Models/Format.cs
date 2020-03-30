using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("FORMATS")]
    public partial class Format
    {
        public Format()
        {
            Ranks = new HashSet<Rank>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty(nameof(Rank.IdFormatNavigation))]
        public virtual ICollection<Rank> Ranks { get; set; }
    }
}
