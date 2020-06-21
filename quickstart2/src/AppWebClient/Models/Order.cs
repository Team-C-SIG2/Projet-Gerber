using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class Order
    {
        public Order()
        {
            Appreciations = new HashSet<Appreciation>();
            Payments = new HashSet<Payment>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        [Display(Name = "Date de commande")]
        [Column(TypeName = "datetime")]
        public DateTime OrderedDate { get; set; }
        [Display(Name = "Date d'expédition")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Column(TypeName = "datetime")]
        public DateTime ShippedDate { get; set; }
        [Required]
        [Display(Name = "Adresse d'expédition")]
        [StringLength(255)]
        public string ShippingAddress { get; set; }
        [Required]
        [Display(Name = "Statut")]
        [StringLength(25)]
        public string Status { get; set; }
        [Display(Name = "Prix total")]
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.Orders))]
        public virtual AspNetUser User { get; set; }
        [InverseProperty(nameof(Appreciation.IdOrderNavigation))]
        public virtual ICollection<Appreciation> Appreciations { get; set; }
        [InverseProperty(nameof(Payment.IdOrderNavigation))]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
