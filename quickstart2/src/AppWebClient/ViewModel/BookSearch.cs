﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebClient.ViewModel
{
    public class BookSearch
    {
        public int? IdEditor { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public DateTime? DatePublicationFrom { get; set; }
        public DateTime? DatePublicationTo { get; set; }
        public string Summary { get; set; }
        public string Isbn { get; set; }
        public string authorName { get; set; }
        public string category { get; set; }
    }
}
