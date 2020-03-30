using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("BOOKS")]
    public partial class Book
    {
        public Book()
        {
            Cowriters = new HashSet<Cowriter>();
            Lineitems = new HashSet<Lineitem>();
            Ranks = new HashSet<Rank>();
            Stocks = new HashSet<Stock>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ID_EDITEUR")]
        public int IdEditeur { get; set; }
        [Required]
        [Column("TITLE")]
        [StringLength(255)]
        public string Title { get; set; }
        [Column("SUBTITLE")]
        [StringLength(128)]
        public string Subtitle { get; set; }
        [Column("PRICE", TypeName = "money")]
        public decimal Price { get; set; }
        [Column("DATEPUBLICATION", TypeName = "datetime")]
        public DateTime Datepublication { get; set; }
        [Required]
        [Column("SUMMARY")]
        [StringLength(255)]
        public string Summary { get; set; }
        [Required]
        [Column("ISBN")]
        [StringLength(13)]
        public string Isbn { get; set; }

        [ForeignKey(nameof(IdEditeur))]
        [InverseProperty(nameof(Editeur.Books))]
        public virtual Editeur IdEditeurNavigation { get; set; }
        [InverseProperty(nameof(Cowriter.IdBookNavigation))]
        public virtual ICollection<Cowriter> Cowriters { get; set; }
        [InverseProperty(nameof(Lineitem.IdBookNavigation))]
        public virtual ICollection<Lineitem> Lineitems { get; set; }
        [InverseProperty(nameof(Rank.IdBookNavigation))]
        public virtual ICollection<Rank> Ranks { get; set; }
        [InverseProperty(nameof(Stock.IdBookNavigation))]
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
