using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebClient.ViewModel
{
    public partial class BookStock
    {
        public int IdBook { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Isbn { get; set; }
        public short currentStock { get; set; }
    }
}
