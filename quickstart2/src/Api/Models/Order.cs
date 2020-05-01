using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
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
        [InverseProperty(nameof(Appreciation.IdOrderNavigation))]
        public virtual ICollection<Appreciation> Appreciations { get; set; }
    }
}
