using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebClient.ViewModel
{
    public class BookReviews
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public int Note { get; set; }
        public DateTime Date { get; set; }
        public bool Signale { get; set; }
    }
}
