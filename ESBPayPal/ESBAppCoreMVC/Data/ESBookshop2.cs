using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ESBAppCoreMVC.Models;

namespace ESBAppCoreMVC.Data
{
    public class ESBookshop2: DbContext
    {
        public ESBookshop2(DbContextOptions<ESBookshop2> options)
            : base(options)
        {
        }

        // public DbSet<ESBAppCoreMVC.Models.CUSTOMER> CUSTOMER { get; set; }


        public virtual DbSet<ACCOUNT> ACCOUNTS { get; set; }
        public virtual DbSet<APPRECIATION> APPRECIATIONS { get; set; }
        public virtual DbSet<AUTHOR> AUTHORS { get; set; }
        public virtual DbSet<BOOK> BOOKS { get; set; }
        public virtual DbSet<CATEGORy> CATEGORIES { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERS { get; set; }
        public virtual DbSet<EDITEUR> EDITEURS { get; set; }
        public virtual DbSet<FORMAT> FORMATS { get; set; }
        public virtual DbSet<GENRE> GENRES { get; set; }
        public virtual DbSet<LANGUAGE> LANGUAGES { get; set; }
        public virtual DbSet<LINEITEM> LINEITEMS { get; set; }
        public virtual DbSet<ORDER> ORDERS { get; set; }
        public virtual DbSet<PAYMENT> PAYMENTS { get; set; }
        public virtual DbSet<RANK> RANKS { get; set; }
        public virtual DbSet<SHOPPINGCART> SHOPPINGCARTS { get; set; }
        public virtual DbSet<STOCK> STOCKS { get; set; }
    }
}
