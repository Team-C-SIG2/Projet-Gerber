﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    [Table("ACCOUNTS")]
    public partial class Account
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ID_CUTOMER")]
        public int IdCutomer { get; set; }
        [Required]
        [Column("PASSWORD")]
        [StringLength(15)]
        public string Password { get; set; }
        [Required]
        [Column("LOGINNAME")]
        [StringLength(100)]
        public string Loginname { get; set; }
        [Required]
        [Column("USERSTATE")]
        [StringLength(25)]
        public string Userstate { get; set; }
        [Column("REGISTRATIONDATE", TypeName = "datetime")]
        public DateTime Registrationdate { get; set; }
        [Column("ISCLOSED")]
        public bool Isclosed { get; set; }
        [Required]
        [Column("BILLINGADDRESS")]
        [StringLength(255)]
        public string Billingaddress { get; set; }
        [Required]
        [Column("TYPE")]
        [StringLength(20)]
        public string Type { get; set; }
    }
}