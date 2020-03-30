using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("LINEITEMS")]
    public partial class Lineitem
    {
        public Lineitem()
        {
            Appreciations = new HashSet<Appreciation>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ID_SHOPPINGCART")]
        public int IdShoppingcart { get; set; }
        [Column("ID_BOOK")]
        public int IdBook { get; set; }
        [Column("QUANTITY")]
        public int Quantity { get; set; }
        [Column("UNITPRICE", TypeName = "money")]
        public decimal Unitprice { get; set; }
        [Column("ID_ORDER")]
        public int IdOrder { get; set; }

        [ForeignKey(nameof(IdBook))]
        [InverseProperty(nameof(Book.Lineitems))]
        public virtual Book IdBookNavigation { get; set; }
        [ForeignKey(nameof(IdShoppingcart))]
        [InverseProperty(nameof(Shoppingcart.Lineitems))]
        public virtual Shoppingcart IdShoppingcartNavigation { get; set; }
        [InverseProperty(nameof(Appreciation.IdLineitemNavigation))]
        public virtual ICollection<Appreciation> Appreciations { get; set; }
    }
}
