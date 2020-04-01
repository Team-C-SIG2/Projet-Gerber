using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("APPRECIATIONS")]
    public partial class Appreciation
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ID_LINEITEM")]
        public int IdLineitem { get; set; }
        [Column("ID_ORDER")]
        public int IdOrder { get; set; }
        [Column("ID_PAYMENT")]
        public int IdPayment { get; set; }
        [Required]
        [Column("EVALUATION")]
        [StringLength(20)]
        public string Evaluation { get; set; }

        [ForeignKey(nameof(IdLineitem))]
        [InverseProperty(nameof(Lineitem.Appreciations))]
        public virtual Lineitem IdLineitemNavigation { get; set; }
        [ForeignKey(nameof(IdOrder))]
        [InverseProperty(nameof(Order.Appreciations))]
        public virtual Order IdOrderNavigation { get; set; }
        [ForeignKey(nameof(IdPayment))]
        [InverseProperty(nameof(Payment.Appreciations))]
        public virtual Payment IdPaymentNavigation { get; set; }
    }
}
