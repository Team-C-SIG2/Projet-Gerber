using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IdentityServerAspNetIdentity.ViewModels
{
    public class SMSVerification
    {
        [Phone]
        public string PhoneNumber { get; set; }

        [BindProperty, Required, Display(Name = "Code")]
        public string VerificationCode { get; set; }
    }
}
