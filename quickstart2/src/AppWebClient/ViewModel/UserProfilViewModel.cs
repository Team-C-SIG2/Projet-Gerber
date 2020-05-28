using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.ViewModel
{
    public partial class UserProfilViewModel
    {
        public int Id { get; set; }
        public string Acronyme { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string BillingAddress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
