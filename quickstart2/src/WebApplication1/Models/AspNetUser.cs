﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            Orders = new HashSet<Order>();
            Payments = new HashSet<APayment>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        [Key]
        [StringLength(450)]
        public string Id { get; set; }

        [DisplayName("Identifiant")]
        [Column("Id_Customer")]
        public int IdCustomer { get; set; }


        [DisplayName("Nom d'utilisateur")]
        [StringLength(256)]
        public string Username { get; set; }


        [StringLength(256)]
        public string NormalizedUsername { get; set; }


        [StringLength(256)]
        public string Email { get; set; }


        [StringLength(256)]
        public string NormalizedEmail { get; set; }


        public bool EmailConfirmed { get; set; }

        [DisplayName("Mot de passe")]
        [StringLength(255)]
        public string PasswordHash { get; set; }


        [StringLength(255)]
        public string SecurityStamp { get; set; }


        [StringLength(255)]
        public string ConcurrencyStamp { get; set; }


        [DisplayName("Téléphone")]
        [StringLength(255)]
        public string PhoneNumber { get; set; }


        public bool PhoneNumberConfirmed { get; set; }


        public bool TwoFactorEnabled { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime? LockoutEnd { get; set; }


        public bool LockoutEnabled { get; set; }


        public byte AccessFailedCount { get; set; }

        [DisplayName("Client")]
        [ForeignKey(nameof(IdCustomer))]
        [InverseProperty(nameof(Customer.AspNetUsers))]
        public virtual Customer IdCustomerNavigation { get; set; }


        [InverseProperty("User")]
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }


        [InverseProperty("User")]
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }


        [InverseProperty("User")]
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }


        [InverseProperty("User")]
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }


        [InverseProperty("User")]
        public virtual ICollection<Order> Orders { get; set; }


        [InverseProperty("User")]
        public virtual ICollection<APayment> Payments { get; set; }


        [InverseProperty("User")]
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }



    }
}
