using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("ORDERS")]
    public partial class Order
    {
        public Order()
        {
            Appreciations = new HashSet<Appreciation>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ORDEREDDATE", TypeName = "datetime")]
        public DateTime Ordereddate { get; set; }
        [Column("SHIPPEDDATE", TypeName = "datetime")]
        public DateTime Shippeddate { get; set; }
        [Required]
        [Column("SHIPPINGADDRESS")]
        [StringLength(255)]
        public string Shippingaddress { get; set; }
        [Required]
        [Column("STATUS")]
        [StringLength(25)]
        public string Status { get; set; }
        [Column("TOTALPRICE", TypeName = "money")]
        public decimal Totalprice { get; set; }
        [Column("ID_ACCOUNT")]
        public int IdAccount { get; set; }

        [ForeignKey(nameof(IdAccount))]
        [InverseProperty(nameof(Account.Orders))]
        public virtual Account IdAccountNavigation { get; set; }
        [InverseProperty(nameof(Appreciation.IdOrderNavigation))]
        public virtual ICollection<Appreciation> Appreciations { get; set; }
    }
}
