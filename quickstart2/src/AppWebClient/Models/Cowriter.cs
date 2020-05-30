using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class Cowriter
    {
        [Key]
        [Column("Id_Author")]
        public int IdAuthor { get; set; }
        [Key]
        [Column("Id_Book")]
        public int IdBook { get; set; }

        [ForeignKey(nameof(IdAuthor))]
        [InverseProperty(nameof(Author.Cowriters))]
        public virtual Author IdAuthorNavigation { get; set; }
        [ForeignKey(nameof(IdBook))]
        [InverseProperty(nameof(Book.Cowriters))]
        public virtual Book IdBookNavigation { get; set; }
    }
}
