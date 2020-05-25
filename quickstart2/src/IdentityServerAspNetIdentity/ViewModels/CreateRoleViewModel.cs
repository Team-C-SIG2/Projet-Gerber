using System.ComponentModel.DataAnnotations;

namespace IdentityServerAspNetIdentity.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
