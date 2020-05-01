using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public partial class Appreciation
    {
        [Key]
        public int Id { get; set; }
        [Column("Id_LineItem")]
        public int IdLineItem { get; set; }
        [Column("Id_Order")]
        public int IdOrder { get; set; }
        [Column("Id_Payment")]
        public int IdPayment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EvaluationDate { get; set; }
        [Required]
        [StringLength(20)]
        public string Evaluation { get; set; }

        [ForeignKey(nameof(IdLineItem))]
        [InverseProperty(nameof(LineItem.Appreciations))]
        public virtual LineItem IdLineItemNavigation { get; set; }
        [ForeignKey(nameof(IdOrder))]
        [InverseProperty(nameof(Order.Appreciations))]
        public virtual Order IdOrderNavigation { get; set; }
        [ForeignKey(nameof(IdPayment))]
        [InverseProperty(nameof(Payment.Appreciations))]
        public virtual Payment IdPaymentNavigation { get; set; }
    }
}
