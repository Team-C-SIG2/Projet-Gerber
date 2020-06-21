using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.Models
{
    public partial class Review
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        public int Note { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        public bool Signale { get; set; }
    }
}
