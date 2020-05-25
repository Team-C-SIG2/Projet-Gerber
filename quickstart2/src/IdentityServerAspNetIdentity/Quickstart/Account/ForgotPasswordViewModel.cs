using System.ComponentModel.DataAnnotations;

namespace IdentityServerAspNetIdentity.Quickstart.Account.UI
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
