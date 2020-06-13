using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public partial class AspNetUserRole
    {
        [Key]
        public string RoleId { get; set; }
        [Key]
        public string UserId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(AspNetRole.AspNetUserRoles))]
        public virtual AspNetRole Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.AspNetUserRoles))]
        public virtual AspNetUser User { get; set; }
    }
}
