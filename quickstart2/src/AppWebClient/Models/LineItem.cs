﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
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
        public int? IdShoppingcart { get; set; }
        [Column("Id_Wishlist")]
        public int? IdWishlist { get; set; }
        [Column("Id_Book")]
        public int IdBook { get; set; }
        [Display(Name = "Quantité")]
        public int Quantity { get; set; }
        [Display(Name = "Prix unitaire")]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        [Column("Id_Order")]
        public int? IdOrder { get; set; }
        [Display(Name = "Date de sélection")]
        [Column(TypeName = "datetime")]
        public DateTime InsertedDate { get; set; }

        [ForeignKey(nameof(IdBook))]
        [InverseProperty(nameof(Book.LineItems))]
        public virtual Book IdBookNavigation { get; set; }
        [ForeignKey(nameof(IdShoppingcart))]
        [InverseProperty(nameof(ShoppingCart.LineItems))]
        public virtual ShoppingCart IdShoppingcartNavigation { get; set; }
        [ForeignKey(nameof(IdWishlist))]
        [InverseProperty(nameof(Wishlist.LineItems))]
        public virtual Wishlist IdWishlistNavigation { get; set; }
        [InverseProperty(nameof(Appreciation.IdLineItemNavigation))]
        public virtual ICollection<Appreciation> Appreciations { get; set; }
    }
}
