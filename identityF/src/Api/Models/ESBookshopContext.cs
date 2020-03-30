using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.Models
{
    public partial class ESBookshopContext : DbContext
    {
        public ESBookshopContext()
        {
        }

        public ESBookshopContext(DbContextOptions<ESBookshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Appreciation> Appreciations { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cowriter> Cowriters { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Editeur> Editeurs { get; set; }
        public virtual DbSet<Format> Formats { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Lineitem> Lineitems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<Shoppingcart> Shoppingcarts { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Billingaddress)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Loginname).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.Userstate).IsUnicode(false);

                entity.HasOne(d => d.IdCutomerNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.IdCutomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTS_CUSTOMERS");
            });

            modelBuilder.Entity<Appreciation>(entity =>
            {
                entity.Property(e => e.Evaluation).IsUnicode(false);

                entity.HasOne(d => d.IdLineitemNavigation)
                    .WithMany(p => p.Appreciations)
                    .HasForeignKey(d => d.IdLineitem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPRECIATIONS_LINEITEMS");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Appreciations)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPRECIATIONS_ORDERS");

                entity.HasOne(d => d.IdPaymentNavigation)
                    .WithMany(p => p.Appreciations)
                    .HasForeignKey(d => d.IdPayment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPRECIATIONS_PAYMENTS");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Isbn).IsUnicode(false);

                entity.Property(e => e.Subtitle).IsUnicode(false);

                entity.Property(e => e.Summary).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.IdEditeurNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdEditeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOOKS_EDITEURS");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Cowriter>(entity =>
            {
                entity.HasKey(e => new { e.IdAuthor, e.IdBook });

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Cowriters)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COWRITERS_AUTHORS");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.Cowriters)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COWRITERS_BOOKS");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Acronyme).IsUnicode(false);

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Zip).IsUnicode(false);
            });

            modelBuilder.Entity<Editeur>(entity =>
            {
                entity.Property(e => e.Countrycode).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Url).IsUnicode(false);
            });

            modelBuilder.Entity<Format>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Code).IsFixedLength();

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Lineitem>(entity =>
            {
                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.Lineitems)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LINEITEMS_BOOKS");

                entity.HasOne(d => d.IdShoppingcartNavigation)
                    .WithMany(p => p.Lineitems)
                    .HasForeignKey(d => d.IdShoppingcart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LINEITEMS_SHOPPINGCARTS");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Shippingaddress)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERS_ACCOUNTS");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Details)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMENTS_ACCOUNTS");
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.HasKey(e => new { e.IdBook, e.IdCategorie, e.IdGenre, e.IdFormat, e.IdLanguage })
                    .HasName("PK_RANK");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.Ranks)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RANK_BOOKS");

                entity.HasOne(d => d.IdCategorieNavigation)
                    .WithMany(p => p.Ranks)
                    .HasForeignKey(d => d.IdCategorie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RANK_CATEGORIES");

                entity.HasOne(d => d.IdFormatNavigation)
                    .WithMany(p => p.Ranks)
                    .HasForeignKey(d => d.IdFormat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RANK_FORMATS");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.Ranks)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RANK_GENRES");

                entity.HasOne(d => d.IdLanguageNavigation)
                    .WithMany(p => p.Ranks)
                    .HasForeignKey(d => d.IdLanguage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RANK_LANGUAGES");
            });

            modelBuilder.Entity<Shoppingcart>(entity =>
            {
                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Shoppingcarts)
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SHOPPINGCARTS_ACCOUNTS");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STOCKS_BOOKS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
