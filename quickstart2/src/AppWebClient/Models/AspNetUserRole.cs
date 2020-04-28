using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class AspNetUserRole
    {
        [Key]
        [StringLength(450)]
        public string RoleId { get; set; }
        [Key]
        [StringLength(450)]
        public string UserId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(AspNetRole.AspNetUserRoles))]
        public virtual AspNetRole Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.AspNetUserRoles))]
        public virtual AspNetUser User { get; set; }
    }
}
