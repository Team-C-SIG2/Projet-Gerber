namespace ESBClientMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ESBookshop : DbContext
    {
        public ESBookshop()
            : base("name=ESBookshop")
        {
        }

        // ////////////////////////////////////////////

        // ////////////////////////////////////////////

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.LOGINNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.USERSTATE)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.BILLINGADDRESS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.ORDERS)
                .WithRequired(e => e.ACCOUNT)
                .HasForeignKey(e => e.ID_ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.PAYMENTS)
                .WithRequired(e => e.ACCOUNT)
                .HasForeignKey(e => e.ID_ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ACCOUNT>()
                .HasMany(e => e.SHOPPINGCARTS)
                .WithRequired(e => e.ACCOUNT)
                .HasForeignKey(e => e.ID_ACCOUNT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<APPRECIATION>()
                .Property(e => e.EVALUATION)
                .IsUnicode(false);

            modelBuilder.Entity<AUTHOR>()
                .Property(e => e.LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<AUTHOR>()
                .Property(e => e.FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<AUTHOR>()
                .HasMany(e => e.BOOKS)
                .WithMany(e => e.AUTHORS)
                .Map(m => m.ToTable("COWRITERS").MapLeftKey("ID_AUTHOR").MapRightKey("ID_BOOK"));

            modelBuilder.Entity<BOOK>()
                .Property(e => e.TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.SUBTITLE)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.PRICE)
                .HasPrecision(19, 4);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.SUMMARY)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<BOOK>()
                .HasMany(e => e.LINEITEMS)
                .WithRequired(e => e.BOOK)
                .HasForeignKey(e => e.ID_BOOK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BOOK>()
                .HasMany(e => e.RANKS)
                .WithRequired(e => e.BOOK)
                .HasForeignKey(e => e.ID_BOOK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BOOK>()
                .HasMany(e => e.STOCKS)
                .WithRequired(e => e.BOOK)
                .HasForeignKey(e => e.ID_BOOK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CATEGORy>()
                .Property(e => e.DESCRIPTION)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORy>()
                .HasMany(e => e.RANKS)
                .WithRequired(e => e.CATEGORy)
                .HasForeignKey(e => e.ID_CATEGORIE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.ACRONYME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.ZIP)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.EMAIL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .HasMany(e => e.ACCOUNTS)
                .WithRequired(e => e.CUSTOMER)
                .HasForeignKey(e => e.ID_CUTOMER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EDITEUR>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EDITEUR>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<EDITEUR>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<EDITEUR>()
                .Property(e => e.COUNTRYCODE)
                .IsUnicode(false);

            modelBuilder.Entity<EDITEUR>()
                .HasMany(e => e.BOOKS)
                .WithRequired(e => e.EDITEUR)
                .HasForeignKey(e => e.ID_EDITEUR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FORMAT>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<FORMAT>()
                .HasMany(e => e.RANKS)
                .WithRequired(e => e.FORMAT)
                .HasForeignKey(e => e.ID_FORMAT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GENRE>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<GENRE>()
                .HasMany(e => e.RANKS)
                .WithRequired(e => e.GENRE)
                .HasForeignKey(e => e.ID_GENRE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LANGUAGE>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<LANGUAGE>()
                .Property(e => e.CODE)
                .IsFixedLength();

            modelBuilder.Entity<LANGUAGE>()
                .HasMany(e => e.RANKS)
                .WithRequired(e => e.LANGUAGE)
                .HasForeignKey(e => e.ID_LANGUAGE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LINEITEM>()
                .Property(e => e.UNITPRICE)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LINEITEM>()
                .HasMany(e => e.APPRECIATIONS)
                .WithRequired(e => e.LINEITEM)
                .HasForeignKey(e => e.ID_LINEITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.SHIPPINGADDRESS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<ORDER>()
                .Property(e => e.TOTALPRICE)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ORDER>()
                .HasMany(e => e.APPRECIATIONS)
                .WithRequired(e => e.ORDER)
                .HasForeignKey(e => e.ID_ORDER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAYMENT>()
                .Property(e => e.PRICETOTAL)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PAYMENT>()
                .Property(e => e.DETAILS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PAYMENT>()
                .HasMany(e => e.APPRECIATIONS)
                .WithRequired(e => e.PAYMENT)
                .HasForeignKey(e => e.ID_PAYMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SHOPPINGCART>()
                .HasMany(e => e.LINEITEMS)
                .WithRequired(e => e.SHOPPINGCART)
                .HasForeignKey(e => e.ID_SHOPPINGCART)
                .WillCascadeOnDelete(false);
        }
    }
}
