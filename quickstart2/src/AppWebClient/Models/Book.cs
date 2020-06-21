using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class Book
    {
        public Book()
        {
            Cowriters = new HashSet<Cowriter>();
            LineItems = new HashSet<LineItem>();
            Ranks = new HashSet<Rank>();
            StockHistories = new HashSet<StockHistory>();
        }

        [Key]
        public int Id { get; set; }
        [Column("Id_Editor")]
        public int IdEditor { get; set; }
        [Required]
        [Display(Name = "Titre")]
        [StringLength(255)]
        public string Title { get; set; }
        [Display(Name = "Sous-titre")]
        [StringLength(128)]
        public string Subtitle { get; set; }
        [Display(Name = "Prix unitaire")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Display(Name = "Date de publication")]
        [Column(TypeName = "datetime")]
        public DateTime? DatePublication { get; set; }
        [Display(Name = "Résumé")]
        [StringLength(255)]
        public string Summary { get; set; }
        [Required]
        [Display(Name = "Code ISBN")]
        [Column("ISBN")]
        [StringLength(13)]
        public string Isbn { get; set; }
        public int Stock { get; set; }
        [Display(Name = "Stock initial")]
        public int StockInitial { get; set; }

        [ForeignKey(nameof(IdEditor))]
        [InverseProperty(nameof(Editor.Books))]
        public virtual Editor IdEditorNavigation { get; set; }
        [InverseProperty(nameof(Cowriter.IdBookNavigation))]
        public virtual ICollection<Cowriter> Cowriters { get; set; }
        [InverseProperty(nameof(LineItem.IdBookNavigation))]
        public virtual ICollection<LineItem> LineItems { get; set; }
        [InverseProperty(nameof(Rank.IdBookNavigation))]
        public virtual ICollection<Rank> Ranks { get; set; }
        [InverseProperty(nameof(StockHistory.IdBookNavigation))]
        public virtual ICollection<StockHistory> StockHistories { get; set; }
    }
}
