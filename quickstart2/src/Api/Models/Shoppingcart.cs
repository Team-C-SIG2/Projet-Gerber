using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("SHOPPINGCARTS")]
    public partial class Shoppingcart
    {
        public Shoppingcart()
        {
            Lineitems = new HashSet<Lineitem>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CREATEDDATE", TypeName = "datetime")]
        public DateTime Createddate { get; set; }
        [Column("ID_ACCOUNT")]
        public int IdAccount { get; set; }

        [ForeignKey(nameof(IdAccount))]
        [InverseProperty(nameof(Account.Shoppingcarts))]
        public virtual Account IdAccountNavigation { get; set; }
        [InverseProperty(nameof(Lineitem.IdShoppingcartNavigation))]
        public virtual ICollection<Lineitem> Lineitems { get; set; }
    }
}
