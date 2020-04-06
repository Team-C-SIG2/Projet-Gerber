namespace ESBAppCoreMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RANKS")]
    public partial class RANK
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_BOOK { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_CATEGORIE { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_GENRE { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_FORMAT { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_LANGUAGE { get; set; }

        public virtual BOOK BOOK { get; set; }

        public virtual CATEGORy CATEGORy { get; set; }

        public virtual FORMAT FORMAT { get; set; }

        public virtual GENRE GENRE { get; set; }

        public virtual LANGUAGE LANGUAGE { get; set; }
    }
}
