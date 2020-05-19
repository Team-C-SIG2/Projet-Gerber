using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class Stock
    {
        [Key]
        public int Id { get; set; }
        [Column("Id_Book")]
        public int IdBook { get; set; }
        public short InitialStock { get; set; }
        public short CurrentStock { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DeliveryDate { get; set; }

        [ForeignKey(nameof(IdBook))]
        [InverseProperty(nameof(Book.Stocks))]
        public virtual Book IdBookNavigation { get; set; }
    }
}
