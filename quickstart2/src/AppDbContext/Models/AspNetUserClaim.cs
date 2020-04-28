using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDbContext.Models
{
    public partial class AspNetUserClaim
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        [StringLength(255)]
        public string ClaimType { get; set; }
        [StringLength(255)]
        public string ClaimValue { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.AspNetUserClaims))]
        public virtual AspNetUser User { get; set; }
    }
}
