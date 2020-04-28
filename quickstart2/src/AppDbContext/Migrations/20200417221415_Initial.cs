using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppDbContext.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_EFMigrationsHistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    ProductVersion = table.Column<string>(unicode: false, maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EFMIGRATIONSHISTORY", x => x.MigrationId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    ConcurrencyStamp = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lastname = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Firstname = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(unicode: false, fixedLength: true, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acronyme = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    Firstname = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Address = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Zip = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    City = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Phone = table.Column<string>(unicode: false, maxLength: 13, nullable: true),
                    Email = table.Column<string>(unicode: false, fixedLength: true, maxLength: 255, nullable: false),
                    BillingAddress = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CountryCode = table.Column<string>(unicode: false, maxLength: 3, nullable: false),
                    URL = table.Column<string>(unicode: false, fixedLength: true, maxLength: 255, nullable: true),
                    Email = table.Column<string>(unicode: false, fixedLength: true, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Code = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    ClaimType = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    ClaimValue = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    Id_Customer = table.Column<int>(nullable: false),
                    Username = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    NormalizedUsername = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(unicode: false, maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    SecurityStamp = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    ConcurrencyStamp = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USERS_CUSTOMERS",
                        column: x => x.Id_Customer,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Editor = table.Column<int>(nullable: false),
                    Title = table.Column<string>(unicode: false, fixedLength: true, maxLength: 255, nullable: false),
                    Subtitle = table.Column<string>(unicode: false, maxLength: 128, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    DatePublication = table.Column<DateTime>(type: "datetime", nullable: true),
                    Summary = table.Column<string>(unicode: false, fixedLength: true, maxLength: 255, nullable: true),
                    ISBN = table.Column<string>(unicode: false, maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOOKS_EDITORS",
                        column: x => x.Id_Editor,
                        principalTable: "Editors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    ClaimType = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    ClaimValue = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    ProviderKey = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    UserId = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    ProviderDisplayName = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASPNETUSERLOGINS", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    RoleId = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    UserId = table.Column<string>(unicode: false, maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERROLES", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    LoginProvider = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    Value = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERTOKENS", x => new { x.LoginProvider, x.Name, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    OrderedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ShippingAddress = table.Column<string>(unicode: false, fixedLength: true, maxLength: 255, nullable: false),
                    Status = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORDERS_USERS",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaidDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PriceTotal = table.Column<decimal>(type: "money", nullable: false),
                    Details = table.Column<string>(unicode: false, fixedLength: true, maxLength: 255, nullable: false),
                    UserId = table.Column<string>(unicode: false, maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PAYMENTS_USERS",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(unicode: false, maxLength: 450, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SHOPPINGCARTS_USERS",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cowriters",
                columns: table => new
                {
                    Id_Author = table.Column<int>(nullable: false),
                    Id_Book = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COWRITERS", x => new { x.Id_Author, x.Id_Book });
                    table.ForeignKey(
                        name: "FK_COWRITERS_AUTHORS",
                        column: x => x.Id_Author,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COWRITERS_BOOKS",
                        column: x => x.Id_Book,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id_Book = table.Column<int>(nullable: false),
                    Id_Categorie = table.Column<int>(nullable: false),
                    Id_Genre = table.Column<int>(nullable: false),
                    Id_Format = table.Column<int>(nullable: false),
                    Id_Language = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RANKS", x => new { x.Id_Book, x.Id_Categorie, x.Id_Genre, x.Id_Format, x.Id_Language });
                    table.ForeignKey(
                        name: "FK_RANKS_BOOKS",
                        column: x => x.Id_Book,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RANKS_CATEGORIES",
                        column: x => x.Id_Categorie,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RANKS_FORMATS",
                        column: x => x.Id_Format,
                        principalTable: "Formats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RANKS_GENRES",
                        column: x => x.Id_Genre,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RANKS_LANGUAGES",
                        column: x => x.Id_Language,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Book = table.Column<int>(nullable: false),
                    InitialStock = table.Column<short>(nullable: false),
                    CurrentStock = table.Column<short>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_STOCKS_BOOKS",
                        column: x => x.Id_Book,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    Id_Shoppingcart = table.Column<int>(nullable: false),
                    Id_Book = table.Column<int>(nullable: false),
                    Id_Order = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LINEITEMS_BOOKS",
                        column: x => x.Id_Book,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LINEITEMS_SHOPPINGCARTS",
                        column: x => x.Id_Shoppingcart,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appreciations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Evaluation = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Id_LineItem = table.Column<int>(nullable: false),
                    Id_Order = table.Column<int>(nullable: false),
                    Id_Payment = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appreciations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_APPRECIATIONS_LINEITEMS",
                        column: x => x.Id_LineItem,
                        principalTable: "LineItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APPRECIATIONS_ORDERS",
                        column: x => x.Id_Order,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APPRECIATIONS_PAYMENTS",
                        column: x => x.Id_Payment,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appreciations_Id_LineItem",
                table: "Appreciations",
                column: "Id_LineItem");

            migrationBuilder.CreateIndex(
                name: "IX_Appreciations_Id_Order",
                table: "Appreciations",
                column: "Id_Order");

            migrationBuilder.CreateIndex(
                name: "IX_Appreciations_Id_Payment",
                table: "Appreciations",
                column: "Id_Payment");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Id_Customer",
                table: "AspNetUsers",
                column: "Id_Customer");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_UserId",
                table: "AspNetUserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Id_Editor",
                table: "Books",
                column: "Id_Editor");

            migrationBuilder.CreateIndex(
                name: "IX_Cowriters_Id_Book",
                table: "Cowriters",
                column: "Id_Book");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_Id_Book",
                table: "LineItems",
                column: "Id_Book");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_Id_Shoppingcart",
                table: "LineItems",
                column: "Id_Shoppingcart");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_Id_Categorie",
                table: "Ranks",
                column: "Id_Categorie");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_Id_Format",
                table: "Ranks",
                column: "Id_Format");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_Id_Genre",
                table: "Ranks",
                column: "Id_Genre");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_Id_Language",
                table: "Ranks",
                column: "Id_Language");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Id_Book",
                table: "Stocks",
                column: "Id_Book");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_EFMigrationsHistory");

            migrationBuilder.DropTable(
                name: "Appreciations");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cowriters");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Editors");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
