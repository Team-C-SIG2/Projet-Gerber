using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    [Table("StockHistory")]
    public partial class StockHistory
    {
        [Key]
        public int Id { get; set; }
        [Column("Id_Book")]
        public int IdBook { get; set; }
        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime TransactionDate { get; set; }
        public int TransactionStock { get; set; }
        public int TransactionType { get; set; }

        [ForeignKey(nameof(IdBook))]
        [InverseProperty(nameof(Book.StockHistories))]
        public virtual Book IdBookNavigation { get; set; }
    }
}
