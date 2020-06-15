using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("StockHistory")]
    public partial class StockHistory
    {
        [Key]
        public int Id { get; set; }
        [Column("Id_Book")]
        public int IdBook { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TransactionDate { get; set; }
        public int TransactionStock { get; set; }

        [ForeignKey(nameof(IdBook))]
        [InverseProperty(nameof(Book.StockHistories))]
        public virtual Book IdBookNavigation { get; set; }
    }
}
