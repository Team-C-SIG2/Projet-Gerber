using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebClient.ViewModel
{
    public class PdfViewModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime PaidDate { get; set; }
        public decimal PriceTotal { get; set; }
        public string Details { get; set; }
    }
}
