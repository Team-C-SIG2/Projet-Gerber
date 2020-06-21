using System.ComponentModel.DataAnnotations;

namespace AppWebClient.ViewModel
{
    public partial class UserProfilViewModel
    {
        public int Id { get; set; }
        public string Acronyme { get; set; }
        [Display(Name = "Prénom")]
        public string Firstname { get; set; }
        [Display(Name = "Nom de famille")]
        public string Lastname { get; set; }
        [Display(Name = "Adresse")]
        public string Address { get; set; }
        [Display(Name = "Code postal")]
        public string Zip { get; set; }
        [Display(Name = "Ville")]
        public string City { get; set; }
        [Display(Name = "Adresse de facturation")]
        public string BillingAddress { get; set; }
        [Display(Name = "Adresse mail")]
        public string Email { get; set; }
        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; }
    }
}
