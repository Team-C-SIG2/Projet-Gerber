namespace ESBAppCoreMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STOCKS")]
    public partial class STOCK
    {
        public int ID { get; set; }

        public int ID_BOOK { get; set; }

        public short INITIALSTOCK { get; set; }

        public short CURRENTSTOCK { get; set; }

        public DateTime DELIVERYDATE { get; set; }

        public virtual BOOK BOOK { get; set; }
    }
}
