using System;
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
        [Required]
        [StringLength(4)]
        public string Acronyme { get; set; }
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(100)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        [Required]
        [StringLength(4)]
        public string Zip { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(13)]
        public string Phone { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string BillingAddress { get; set; }

        [InverseProperty("IdCustomerNavigation")]
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
