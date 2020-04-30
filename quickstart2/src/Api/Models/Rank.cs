using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("RANKS")]
    public partial class Rank
    {
        [Key]
        [Column("ID_BOOK")]
        public int IdBook { get; set; }
        [Key]
        [Column("ID_CATEGORIE")]
        public int IdCategorie { get; set; }
        [Key]
        [Column("ID_GENRE")]
        public int IdGenre { get; set; }
        [Key]
        [Column("ID_FORMAT")]
        public int IdFormat { get; set; }
        [Key]
        [Column("ID_LANGUAGE")]
        public int IdLanguage { get; set; }

        [ForeignKey(nameof(IdBook))]
        [InverseProperty(nameof(Book.Ranks))]
        public virtual Book IdBookNavigation { get; set; }
        [ForeignKey(nameof(IdCategorie))]
        [InverseProperty(nameof(Category.Ranks))]
        public virtual Category IdCategorieNavigation { get; set; }
        [ForeignKey(nameof(IdFormat))]
        [InverseProperty(nameof(Format.Ranks))]
        public virtual Format IdFormatNavigation { get; set; }
        [ForeignKey(nameof(IdGenre))]
        [InverseProperty(nameof(Genre.Ranks))]
        public virtual Genre IdGenreNavigation { get; set; }
        [ForeignKey(nameof(IdLanguage))]
        [InverseProperty(nameof(Language.Ranks))]
        public virtual Language IdLanguageNavigation { get; set; }
    }
}
