using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Book
    {
        public int ID { get; set; }

        public int ID_Editeur { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatePublication { get; set; }

        public string Summary { get; set; }

        public string ISBN { get; set; }
    }
}
