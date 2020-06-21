using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class Customer
    {
        public Customer()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(4)]
        public string Acronyme { get; set; }
        [Display(Name = "Prénom")]
        [StringLength(50)]
        public string Firstname { get; set; }
        [Display(Name = "Nom de famille")]
        [StringLength(100)]
        public string Lastname { get; set; }
        [Display(Name = "Adresse")]
        [StringLength(255)]
        public string Address { get; set; }
        [Display(Name = "Code postal")]
        [StringLength(4)]
        public string Zip { get; set; }
        [Display(Name = "Ville")]
        [StringLength(100)]
        public string City { get; set; }
        [Display(Name = "Adresse d'expédition")]
        [StringLength(255)]
        public string BillingAddress { get; set; }

        [InverseProperty(nameof(AspNetUser.IdCustomerNavigation))]
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
