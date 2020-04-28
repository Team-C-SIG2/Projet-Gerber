using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDbContext.Models
{
    public partial class Order
    {
        public Order()
        {
            Appreciations = new HashSet<Appreciation>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(450)]
        public string UserId { get; set; }


        [DisplayName("Date de commande")]
        [Column(TypeName = "datetime")]
        public DateTime OrderedDate { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime ShippedDate { get; set; }


        [Required]
        [StringLength(255)]
        public string ShippingAddress { get; set; }


        [Required]
        [StringLength(25)]
        public string Status { get; set; }


        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }


        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.Orders))]
        public virtual AspNetUser User { get; set; }


        [InverseProperty("IdOrderNavigation")]
        public virtual ICollection<Appreciation> Appreciations { get; set; }


    }
}
