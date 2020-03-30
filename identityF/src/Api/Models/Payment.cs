using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("PAYMENTS")]
    public partial class Payment
    {
        public Payment()
        {
            Appreciations = new HashSet<Appreciation>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("PAIDDATE", TypeName = "datetime")]
        public DateTime Paiddate { get; set; }
        [Column("PRICETOTAL", TypeName = "money")]
        public decimal Pricetotal { get; set; }
        [Required]
        [Column("DETAILS")]
        [StringLength(255)]
        public string Details { get; set; }
        [Column("ID_ACCOUNT")]
        public int IdAccount { get; set; }

        [ForeignKey(nameof(IdAccount))]
        [InverseProperty(nameof(Account.Payments))]
        public virtual Account IdAccountNavigation { get; set; }
        [InverseProperty(nameof(Appreciation.IdPaymentNavigation))]
        public virtual ICollection<Appreciation> Appreciations { get; set; }
    }
}
