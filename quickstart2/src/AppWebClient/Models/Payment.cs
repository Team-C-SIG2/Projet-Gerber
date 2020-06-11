using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Appreciations = new HashSet<Appreciation>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        [Column("Id_Order")]
        public int IdOrder { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime PaidDate { get; set; }
        [Column(TypeName = "money")]
        public decimal PriceTotal { get; set; }
        [Required]
        public string Details { get; set; }

        [ForeignKey(nameof(IdOrder))]
        [InverseProperty(nameof(Order.Payments))]
        public virtual Order IdOrderNavigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.Payments))]
        public virtual AspNetUser User { get; set; }
        [InverseProperty(nameof(Appreciation.IdPaymentNavigation))]
        public virtual ICollection<Appreciation> Appreciations { get; set; }
    }
}
