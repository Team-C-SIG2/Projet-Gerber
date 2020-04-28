using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class AspNetUserToken
    {
        [Key]
        [StringLength(450)]
        public string UserId { get; set; }
        [Key]
        [StringLength(450)]
        public string LoginProvider { get; set; }
        [Key]
        [StringLength(450)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Value { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.AspNetUserTokens))]
        public virtual AspNetUser User { get; set; }
    }
}
