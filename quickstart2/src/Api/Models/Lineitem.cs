using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public partial class LineItem
    {
        public LineItem()
        {
            Appreciations = new HashSet<Appreciation>();
        }

        [Key]
        public int Id { get; set; }
        [Column("Id_Shoppingcart")]
        public int IdShoppingcart { get; set; }
        [Column("Id_Book")]
        public int IdBook { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        [Column("Id_Order")]
        public int? IdOrder { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime InsertedDate { get; set; }

        [ForeignKey(nameof(IdBook))]
        [InverseProperty(nameof(Book.LineItems))]
        public virtual Book IdBookNavigation { get; set; }
        [ForeignKey(nameof(IdShoppingcart))]
        [InverseProperty(nameof(ShoppingCart.LineItems))]
        public virtual ShoppingCart IdShoppingcartNavigation { get; set; }
        [InverseProperty(nameof(Appreciation.IdLineItemNavigation))]
        public virtual ICollection<Appreciation> Appreciations { get; set; }
    }
}
