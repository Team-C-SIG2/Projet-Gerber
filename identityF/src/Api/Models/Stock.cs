using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("STOCKS")]
    public partial class Stock
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ID_BOOK")]
        public int IdBook { get; set; }
        [Column("INITIALSTOCK")]
        public short Initialstock { get; set; }
        [Column("CURRENTSTOCK")]
        public short Currentstock { get; set; }
        [Column("DELIVERYDATE", TypeName = "datetime")]
        public DateTime Deliverydate { get; set; }

        [ForeignKey(nameof(IdBook))]
        [InverseProperty(nameof(Book.Stocks))]
        public virtual Book IdBookNavigation { get; set; }
    }
}
