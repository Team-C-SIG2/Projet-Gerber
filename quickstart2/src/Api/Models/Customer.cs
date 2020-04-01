using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("CUSTOMERS")]
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("ACRONYME")]
        [StringLength(4)]
        public string Acronyme { get; set; }
        [Required]
        [Column("FIRSTNAME")]
        [StringLength(50)]
        public string Firstname { get; set; }
        [Required]
        [Column("LASTNAME")]
        [StringLength(100)]
        public string Lastname { get; set; }
        [Required]
        [Column("ADDRESS")]
        [StringLength(255)]
        public string Address { get; set; }
        [Required]
        [Column("ZIP")]
        [StringLength(4)]
        public string Zip { get; set; }
        [Required]
        [Column("CITY")]
        [StringLength(100)]
        public string City { get; set; }
        [Column("PHONE")]
        [StringLength(13)]
        public string Phone { get; set; }
        [Required]
        [Column("EMAIL")]
        [StringLength(255)]
        public string Email { get; set; }

        [InverseProperty(nameof(Account.IdCutomerNavigation))]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
