using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServerAspNetIdentity.Models
{
    public partial class Rank
    {
        [Key]
        [Column("Id_Book")]
        public int IdBook { get; set; }
        [Key]
        [Column("Id_Categorie")]
        public int IdCategorie { get; set; }
        [Key]
        [Column("Id_Genre")]
        public int IdGenre { get; set; }
        [Key]
        [Column("Id_Format")]
        public int IdFormat { get; set; }
        [Key]
        [Column("Id_Language")]
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
