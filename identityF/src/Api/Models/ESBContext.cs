using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ESBContext : DbContext
    {
        public ESBContext(DbContextOptions<ESBContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}
