using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{


    public partial class APayment
    {
        public APayment()
        {
            // Related Column 
            Appreciations = new HashSet<Appreciation>();
        }


        // ////////////////////////////////////////////////////
        // Column : Id (PK) 
        // ////////////////////////////////////////////////////

        [Key]
        public int Id { get; set; }


        // ////////////////////////////////////////////////////
        // Column : PaidDate 
        // ////////////////////////////////////////////////////
        [Column(TypeName = "datetime")]
        public DateTime PaidDate { get; set; }

        // ////////////////////////////////////////////////////
        // Column : PriceTotal 
        // ////////////////////////////////////////////////////

        [Column(TypeName = "money")]
        public decimal PriceTotal { get; set; }


        // ////////////////////////////////////////////////////
        // Column : Details 
        // ////////////////////////////////////////////////////
        [Required]
        [StringLength(255)]
        public string Details { get; set; }


        // ////////////////////////////////////////////////////
        // Column (FK) : UserId 
        // ////////////////////////////////////////////////////

        [Required]
        [StringLength(450)]
        public string UserId { get; set; }

        [DisplayName("Utilisateur")]
        [ForeignKey("UserId")]
        public virtual AspNetUser User { get; set; }


        // ####################################################
        // Related Column : Appreciations 
        // ####################################################

        [InverseProperty("IdPaymentNavigation")]
        public virtual ICollection<Appreciation> Appreciations { get; set; }


    }// End Class

}
