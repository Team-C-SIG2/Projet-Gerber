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

        public virtual DbSet<Appreciation> Appreciations { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cowriter> Cowriters { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Editor> Editors { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }
        public virtual DbSet<Format> Formats { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ESBookshop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.NormalizedName).IsUnicode(false);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RoleClaims_Roles_RoleId");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USERS_CUSTOMERS");
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserClaims_Users_UserId");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PK_ASPNETUSERLOGINS");

                entity.Property(e => e.LoginProvider).IsUnicode(false);

                entity.Property(e => e.ProviderKey).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserLogins_Users_UserId");
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId })
                    .HasName("PK_USERROLES");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRoles_Roles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRoles_Users_UserId");
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.Name, e.UserId })
                    .HasName("PK_USERTOKENS");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserTokens_Users_UserId");
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

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

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

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Acronyme).IsUnicode(false);

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.BillingAddress).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.Zip).IsUnicode(false);
            });

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

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PK_EFMIGRATIONSHISTORY");

                entity.Property(e => e.MigrationId).IsUnicode(false);

                entity.Property(e => e.ProductVersion).IsUnicode(false);
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
                    .HasConstraintName("FK_LINEITEMS_SHOPPINGCARTS");

                entity.HasOne(d => d.IdWishlistNavigation)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.IdWishlist)
                    .HasConstraintName("FK_LINEITEMS_WISHLISTS");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.ShippingAddress)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERS_USERS");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Details)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAYMENTS_USERS");
            });

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

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SHOPPINGCARTS_USERS");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WISHLISTS_USERS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
