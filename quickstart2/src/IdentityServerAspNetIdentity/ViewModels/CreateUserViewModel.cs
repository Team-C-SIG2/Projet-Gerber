namespace IdentityServerAspNetIdentity.ViewModels
{
    public class CreateUserViewModel
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }

    }
}
