using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class AspNetUserLogin
    {
        [Key]
        [StringLength(450)]
        public string LoginProvider { get; set; }
        [Key]
        [StringLength(450)]
        public string ProviderKey { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        [StringLength(255)]
        public string ProviderDisplayName { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.AspNetUserLogins))]
        public virtual AspNetUser User { get; set; }
    }
}
