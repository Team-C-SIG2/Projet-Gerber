using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public partial class Wishlist
    {
        public Wishlist()
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
        [InverseProperty(nameof(AspNetUser.Wishlists))]
        public virtual AspNetUser User { get; set; }
        [InverseProperty(nameof(LineItem.IdWishlistNavigation))]
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
