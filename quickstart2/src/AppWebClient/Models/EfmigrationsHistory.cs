using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    [Table("_EFMigrationsHistory")]
    public partial class EfmigrationsHistory
    {
        [Key]
        [StringLength(450)]
        public string MigrationId { get; set; }
        [Required]
        [StringLength(450)]
        public string ProductVersion { get; set; }
    }
}
