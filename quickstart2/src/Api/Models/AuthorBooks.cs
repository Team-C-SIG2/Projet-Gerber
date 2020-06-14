using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class AuthorBooks
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string EditorName { get; set; }
        public string EditorUrl { get; set; }
        public string EditorEmail { get; set; }
    }
}
