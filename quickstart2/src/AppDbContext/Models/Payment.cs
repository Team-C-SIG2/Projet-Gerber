using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDbContext.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Appreciations = new HashSet<Appreciation>();
        }

        [Key]
        public int Id { get; set; }





        [Column(TypeName = "datetime")]
        public DateTime PaidDate { get; set; }


        [Column(TypeName = "money")]
        public decimal PriceTotal { get; set; }


        [Required]
        [StringLength(255)]
        public string Details { get; set; }



        [Required]
        [StringLength(450)]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.Payments))]
        public virtual AspNetUser User { get; set; }




        [InverseProperty("IdPaymentNavigation")]
        public virtual ICollection<Appreciation> Appreciations { get; set; }



    }
}
