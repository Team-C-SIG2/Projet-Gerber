using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class LineItem
    {

        public LineItem()
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
        // Column : Quantity 
        // ////////////////////////////////////////////////////

        public int Quantity { get; set; }

        // ////////////////////////////////////////////////////
        // Column : UnitPrice 
        // ////////////////////////////////////////////////////

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        // ////////////////////////////////////////////////////
        // Column : InsertedDate 
        // ////////////////////////////////////////////////////

        [DisplayName("Date d'insertion")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime")]
        public DateTime? InsertedDate { get; set; }


        // ////////////////////////////////////////////////////
        // Column (FK) : Id_Shoppingcart 
        // ////////////////////////////////////////////////////

        [Column("Id_Shoppingcart")]
        public int IdShoppingcart { get; set; }


        [DisplayName("Panier")]
        [ForeignKey("Id_Shoppingcart")]
        public virtual ShoppingCart IdShoppingcartNavigation { get; set; }


        // ////////////////////////////////////////////////////
        // Column (FK) : Id_Book 
        // ////////////////////////////////////////////////////

        [Column("Id_Book")]
        public int IdBook { get; set; }


        [DisplayName("Article")]
        [ForeignKey("Id_Book")]
        public virtual Book IdBookNavigation { get; set; }


        // ////////////////////////////////////////////////////
        // Column (FK) : Id_Order 
        // ////////////////////////////////////////////////////

        [Column("Id_Order")]
        public int? IdOrder { get; set; }


        [DisplayName("Commande")]
        [ForeignKey("Id_Order")]
        public virtual Order IdOrderNavigation { get; set; }


        // ####################################################
        // Related Column : Appreciations 
        // ####################################################

        [InverseProperty("IdLineItemNavigation")]
        public virtual ICollection<Appreciation> Appreciations { get; set; }



    }
}
