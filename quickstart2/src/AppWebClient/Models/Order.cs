using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class Order
    {

        public Order()
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
        // Column : OrderedDate 
        // ////////////////////////////////////////////////////


        [DisplayName("Date de commande")]
        [Column(TypeName = "datetime")]

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime OrderedDate { get; set; }

        // ////////////////////////////////////////////////////
        // Column : ShippedDate 
        // ////////////////////////////////////////////////////

        [Column(TypeName = "datetime")]
        public DateTime ShippedDate { get; set; }

        // ////////////////////////////////////////////////////
        // Column : ShippingAddress 
        // ////////////////////////////////////////////////////

        [Required]
        [StringLength(255)]
        public string ShippingAddress { get; set; }

        // ////////////////////////////////////////////////////
        // Column : Status 
        // ////////////////////////////////////////////////////

        [Required]
        [StringLength(25)]
        public string Status { get; set; }

        // ////////////////////////////////////////////////////
        // Column : TotalPrice 
        // ////////////////////////////////////////////////////

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }


        // ////////////////////////////////////////////////////
        // Column (FK) : UserId 
        // ////////////////////////////////////////////////////

        [Required]
        [StringLength(450)]
        [DisplayName("Utilisateur")]
        public string UserId { get; set; }

        [DisplayName("Utilisateur")]
        [ForeignKey("UserId")]
        public virtual AspNetUser User { get; set; }


        // ####################################################
        // Related Column : Appreciations 
        // ####################################################

        [InverseProperty("IdOrderNavigation")]
        public virtual ICollection<Appreciation> Appreciations { get; set; }


    }// End Class
}
