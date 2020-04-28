using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class Book
    {
        public Book()
        {
            Cowriters = new HashSet<Cowriter>();
            LineItems = new HashSet<LineItem>();
            Ranks = new HashSet<Rank>();
            Stocks = new HashSet<Stock>();
        }


        [Key]
        public int Id { get; set; }


        [DisplayName("Editeur")]
        [Column("Id_Editor")]
        public int IdEditor { get; set; }


        [DisplayName("Titre")]
        [Required]
        [StringLength(255)]
        public string Title { get; set; }



        [DisplayName("Sous-titre ")]
        [StringLength(128)]
        public string Subtitle { get; set; }


        [DisplayName("Prix (CHF)")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }


        [DisplayName("Date de publication")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime")]
        public DateTime? DatePublication { get; set; }


        [DisplayName("Résumé")]
        [StringLength(255)]
        public string Summary { get; set; }


        [DisplayName("ISBN")]
        [Required]
        [Column("ISBN")]
        [StringLength(13)]
        public string Isbn { get; set; }


        [DisplayName("Editeur")]
        [ForeignKey(nameof(IdEditor))]
        [InverseProperty(nameof(Editor.Books))]
        public virtual Editor IdEditorNavigation { get; set; }



        [DisplayName("Auteur(s)")]
        [InverseProperty("IdBookNavigation")]
        public virtual ICollection<Cowriter> Cowriters { get; set; }


        [InverseProperty("IdBookNavigation")]
        public virtual ICollection<LineItem> LineItems { get; set; }


        [DisplayName("Categorie(s)")]
        [InverseProperty("IdBookNavigation")]
        public virtual ICollection<Rank> Ranks { get; set; }


        [DisplayName("Stock")]
        [InverseProperty("IdBookNavigation")]
        public virtual ICollection<Stock> Stocks { get; set; }


    }// End Class 
}
