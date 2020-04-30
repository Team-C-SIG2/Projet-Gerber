using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appreciation> Appreciations { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Cowriter> Cowriters { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Editor> Editors { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }
        public virtual DbSet<Format> Formats { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<APayment> Payments { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ESBookshop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Appreciation 
            modelBuilder.Entity<Appreciation>(entity =>
            {
                entity.Property(e => e.Evaluation).IsUnicode(false);

                entity.HasOne(d => d.IdLineItemNavigation)
                    .WithMany(p => p.Appreciations)
                    .HasForeignKey(d => d.IdLineItem)
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


            // AspNetRoleClaim
            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.ClaimType).IsUnicode(false);

                entity.Property(e => e.ClaimValue).IsUnicode(false);

                entity.Property(e => e.RoleId).IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RoleClaims_Roles_RoleId");
            });


            // AspNetRole

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.ConcurrencyStamp).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.NormalizedName).IsUnicode(false);
            });


            // AspNetUserClaim
            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.ClaimType).IsUnicode(false);

                entity.Property(e => e.ClaimValue).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserClaims_Users_UserId");
            });


            // AspNetUserLogin

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PK_ASPNETUSERLOGINS");

                entity.Property(e => e.LoginProvider).IsUnicode(false);

                entity.Property(e => e.ProviderKey).IsUnicode(false);

                entity.Property(e => e.ProviderDisplayName).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserLogins_Users_UserId");
            });


            // AspNetUserRole

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId })
                    .HasName("PK_USERROLES");

                entity.Property(e => e.RoleId).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRoles_Roles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRoles_Users_UserId");
            });


            // AspNetUserToken
            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.Name, e.UserId })
                    .HasName("PK_USERTOKENS");

                entity.Property(e => e.LoginProvider).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.Property(e => e.Value).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserTokens_Users_UserId");
            });


            // AspNetUser
            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Id).IsUnicode(false);

                entity.Property(e => e.ConcurrencyStamp).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.NormalizedEmail).IsUnicode(false);

                entity.Property(e => e.NormalizedUsername).IsUnicode(false);

                entity.Property(e => e.PasswordHash).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.SecurityStamp).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERS_CUSTOMERS");
            });


            // Author
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);
            });


            // Book
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Isbn).IsUnicode(false);

                entity.Property(e => e.Subtitle).IsUnicode(false);

                entity.Property(e => e.Summary)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdEditorNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdEditor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOOKS_EDITORS");
            });


            // Categorie
            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .IsFixedLength();
            });


            // Cowriter
            modelBuilder.Entity<Cowriter>(entity =>
            {
                entity.HasKey(e => new { e.IdAuthor, e.IdBook })
                    .HasName("PK_COWRITERS");

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


            // Customer

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Acronyme).IsUnicode(false);

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.BillingAddress).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Zip).IsUnicode(false);
            });


            // Editor
            modelBuilder.Entity<Editor>(entity =>
            {
                entity.Property(e => e.CountryCode).IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsUnicode(false)
                    .IsFixedLength();
            });


            // EfmigrationsHistory
            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PK_EFMIGRATIONSHISTORY");

                entity.Property(e => e.MigrationId).IsUnicode(false);

                entity.Property(e => e.ProductVersion).IsUnicode(false);
            });



            // Format
            modelBuilder.Entity<Format>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });


            // Genre
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });



            // Language
            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Code).IsFixedLength();

                entity.Property(e => e.Description).IsUnicode(false);
            });


            // LineItem
            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LINEITEMS_BOOKS");

                entity.HasOne(d => d.IdShoppingcartNavigation)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.IdShoppingcart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LINEITEMS_SHOPPINGCARTS");
            });


            // Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.ShippingAddress)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERS_USERS");
            });


            // Payment
            modelBuilder.Entity<APayment>(entity =>
            {
                entity.Property(e => e.Details)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMENTS_USERS");
            });


            // Rank
            modelBuilder.Entity<Rank>(entity =>
            {
                entity.HasKey(e => new { e.IdBook, e.IdCategorie, e.IdGenre, e.IdFormat, e.IdLanguage })
                    .HasName("PK_RANKS");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.Ranks)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RANKS_BOOKS");

                entity.HasOne(d => d.IdCategorieNavigation)
                    .WithMany(p => p.Ranks)
                    .HasForeignKey(d => d.IdCategorie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RANKS_CATEGORIES");

                entity.HasOne(d => d.IdFormatNavigation)
                    .WithMany(p => p.Ranks)
                    .HasForeignKey(d => d.IdFormat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RANKS_FORMATS");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.Ranks)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RANKS_GENRES");

                entity.HasOne(d => d.IdLanguageNavigation)
                    .WithMany(p => p.Ranks)
                    .HasForeignKey(d => d.IdLanguage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RANKS_LANGUAGES");
            });



            // ShoppingCart
            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SHOPPINGCARTS_USERS");
            });



            // Stock
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
