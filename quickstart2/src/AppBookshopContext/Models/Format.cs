﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppBookshopContext.Models
{
    public partial class Format
    {
        public Format()
        {
            Ranks = new HashSet<Rank>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("IdFormatNavigation")]
        public virtual ICollection<Rank> Ranks { get; set; }
    }
}