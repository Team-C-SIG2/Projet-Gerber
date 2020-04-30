using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class AspNetRoleClaim
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(450)]
        public string RoleId { get; set; }
        [StringLength(255)]
        public string ClaimType { get; set; }
        [StringLength(255)]
        public string ClaimValue { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(AspNetRole.AspNetRoleClaims))]
        public virtual AspNetRole Role { get; set; }
    }
}
