using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{

    // [Serializable]
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            LineItems = new HashSet<LineItem>();
        }



        [Key]
        public int Id { get; set; }



        [DisplayName("Utilisateur")]
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }



        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date création")]
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }


        [DisplayName("Utilisateur")]
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.ShoppingCarts))]
        public virtual AspNetUser User { get; set; }


        [InverseProperty("IdShoppingcartNavigation")]
        public virtual ICollection<LineItem> LineItems { get; set; }


    }// End Class 
}
