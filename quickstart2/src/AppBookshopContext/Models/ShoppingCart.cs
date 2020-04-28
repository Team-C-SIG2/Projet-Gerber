using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBookshopContext.Models
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            LineItems = new HashSet<LineItem>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.ShoppingCarts))]
        public virtual AspNetUser User { get; set; }
        [InverseProperty("IdShoppingcartNavigation")]
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
