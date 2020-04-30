namespace AppDbContext.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;
    using System.Text.Json.Serialization;

    [Table("Appreciations")]
    public partial class Appreciation
    {

        // ////////////////////////////////////////////////////
        // Column : Id (PK) 
        // ////////////////////////////////////////////////////
        [Key]
        public int Id { get; set; }


        // ////////////////////////////////////////////////////
        // Column : Evaluation 
        // ////////////////////////////////////////////////////

        [Required]
        [StringLength(20)]
        public string Evaluation { get; set; }


        // ////////////////////////////////////////////////////
        // Column (FK) : Id_LineItem 
        // ////////////////////////////////////////////////////

        [Column("Id_LineItem")]
        public int IdLineItem { get; set; }

        [DisplayName("Article")]
        [JsonIgnore]
        [ForeignKey(nameof(IdLineItem))]
        [InverseProperty(nameof(LineItem.Appreciations))]
        public virtual LineItem IdLineItemNavigation { get; set; }


        // ////////////////////////////////////////////////////
        // Column (FK) : Id_Order 
        // ////////////////////////////////////////////////////
        [Column("Id_Order")]
        public int IdOrder { get; set; }


        [DisplayName("Commande")]
        [ForeignKey(nameof(IdOrder))]
        [InverseProperty(nameof(Order.Appreciations))]
        public virtual Order IdOrderNavigation { get; set; }


        // ////////////////////////////////////////////////////
        // Column (FK) : Id_Payment 
        // ////////////////////////////////////////////////////
        [Column("Id_Payment")]
        public int IdPayment { get; set; }

        [DisplayName("No paiement")]
        [JsonIgnore]
        [ForeignKey(nameof(IdPayment))]
        [InverseProperty(nameof(Payment.Appreciations))]
        public virtual Payment IdPaymentNavigation { get; set; }





    }// End Class
}






