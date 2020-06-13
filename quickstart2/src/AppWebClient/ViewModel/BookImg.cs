using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace AppWebClient.ViewModel
{
    public class BookImg
    {
        public int IdEditor { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public decimal Price { get; set; }
        public DateTime? DatePublication { get; set; }
        public string Summary { get; set; }
        public string Isbn { get; set; }
        public string authorName { get; set; }
        public int? category { get; set; }
        public ICollection<IFormFile> Images { get; set; }
    }
}
