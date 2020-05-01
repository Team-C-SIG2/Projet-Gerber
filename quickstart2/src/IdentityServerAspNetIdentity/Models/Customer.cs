using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServerAspNetIdentity.Models
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
        [StringLength(50)]
        public string Firstname { get; set; }
        [StringLength(100)]
        public string Lastname { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(4)]
        public string Zip { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(13)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string BillingAddress { get; set; }

        [InverseProperty(nameof(AspNetUser.IdCustomerNavigation))]
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
