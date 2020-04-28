using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            Ranks = new HashSet<Rank>();
        }



        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(100)]
        public string Description { get; set; }



        [InverseProperty("IdCategorieNavigation")]
        public virtual ICollection<Rank> Ranks { get; set; }


    }
}
