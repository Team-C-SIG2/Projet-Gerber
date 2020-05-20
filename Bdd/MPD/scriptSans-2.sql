USE [ESBookshop]
GO
/****** Object:  Table [dbo].[_EFMigrationsHistory]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[_EFMigrationsHistory](
	[MigrationId] [varchar](450) NOT NULL,
	[ProductVersion] [varchar](450) NOT NULL,
 CONSTRAINT [PK_EFMIGRATIONSHISTORY] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appreciations]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appreciations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_LineItem] [int] NOT NULL,
	[Id_Order] [int] NOT NULL,
	[Id_Payment] [int] NOT NULL,
	[EvaluationDate] [datetime] NOT NULL,
	[Evaluation] [varchar](20) NOT NULL,
 CONSTRAINT [PK_APPRECIATIONS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_ROLECLAIMS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [varchar](256) NULL,
	[NormalizedName] [varchar](256) NULL,
 CONSTRAINT [PK_ROLES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_USERCLAIMS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [varchar](450) NOT NULL,
	[ProviderKey] [varchar](450) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [text] NULL,
 CONSTRAINT [PK_ASPNETUSERLOGINS] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[RoleId] [nvarchar](450) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_USERROLES] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Id_Customer] [int] NOT NULL,
	[Username] [nvarchar](256) NULL,
	[NormalizedUsername] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_USERTOKENS] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[Name] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Lastname] [varchar](100) NOT NULL,
	[Firstname] [varchar](100) NOT NULL,
 CONSTRAINT [PK_AUTHORS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Editor] [int] NOT NULL,
	[Title] [char](255) NOT NULL,
	[Subtitle] [varchar](128) NULL,
	[Price] [money] NOT NULL,
	[DatePublication] [datetime] NULL,
	[Summary] [char](255) NULL,
	[ISBN] [varchar](13) NOT NULL,
	[Stock] [int] NOT NULL DEFAULT 0,
 CONSTRAINT [PK_BOOKS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [char](100) NOT NULL,
 CONSTRAINT [PK_CATEGORIES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cowriters]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cowriters](
	[Id_Author] [int] NOT NULL,
	[Id_Book] [int] NOT NULL,
 CONSTRAINT [PK_COWRITERS] PRIMARY KEY CLUSTERED 
(
	[Id_Author] ASC,
	[Id_Book] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Acronyme] [varchar](4) NULL,
	[Firstname] [varchar](50) NULL,
	[Lastname] [varchar](100) NULL,
	[Address] [varchar](255) NULL,
	[Zip] [varchar](4) NULL,
	[City] [varchar](100) NULL,
	[Phone] [varchar](13) NULL,
	[Email] [char](255) NULL,
	[BillingAddress] [varchar](255) NULL,
 CONSTRAINT [PK_CUSTOMERS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Editors]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Editors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[CountryCode] [varchar](3) NOT NULL,
	[URL] [char](255) NULL,
	[Email] [char](255) NULL,
 CONSTRAINT [PK_EDITORS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Formats]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_FORMATS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_GENRES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](20) NOT NULL,
	[Code] [nchar](3) NOT NULL,
 CONSTRAINT [PK_LANGUAGES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LineItems]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Shoppingcart] [int] NOT NULL,
	[Id_Book] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Id_Order] [int] NULL,
	[InsertedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_LINEITEMS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[OrderedDate] [datetime] NOT NULL,
	[ShippedDate] [datetime] NOT NULL,
	[ShippingAddress] [char](255) NOT NULL,
	[Status] [varchar](25) NOT NULL,
	[TotalPrice] [money] NOT NULL,
 CONSTRAINT [PK_ORDERS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[PaidDate] [datetime] NOT NULL,
	[PriceTotal] [money] NOT NULL,
	[Details] [char](255) NOT NULL,
 CONSTRAINT [PK_PAYMENTS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ranks]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ranks](
	[Id_Book] [int] NOT NULL,
	[Id_Categorie] [int] NOT NULL,
	[Id_Genre] [int] NOT NULL,
	[Id_Format] [int] NOT NULL,
	[Id_Language] [int] NOT NULL,
 CONSTRAINT [PK_RANKS] PRIMARY KEY CLUSTERED 
(
	[Id_Book] ASC,
	[Id_Categorie] ASC,
	[Id_Genre] ASC,
	[Id_Format] ASC,
	[Id_Language] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShoppingCarts]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCarts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_SHOPPINGCARTS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stocks]    Script Date: 18.05.2020 17:00:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stocks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Book] [int] NOT NULL,
	[InitialStock] [smallint] NOT NULL,
	[CurrentStock] [smallint] NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
 CONSTRAINT [PK_STOCKS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[_EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'MIGR-4EB586ACB9', N'V01')
INSERT [dbo].[_EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'MIGR-54349F3FC7', N'V01')
INSERT [dbo].[_EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'MIGR-F388F76BF2', N'V03')

INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'ID-32911D8393', N'CONCURRENCYSTAMP-F3F6E32662', N'Admin', N'ADMIN')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'ID-8F25D63E5C', N'CONCURRENCYSTAMP-6E31621404', N'Utilisateur', N'UTILISATEUR')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'ID-D41E97D28F', N'CONCURRENCYSTAMP-198B7AB0A3', N'Client', N'CLIENT')

SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (1, N'Bellier', N'Irène')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (2, N'Arnaud', N'Georges J.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (3, N'Austen', N'Jane')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (4, N'Ba', N'Mehdi')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (5, N'Ballard', N'J. G.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (6, N'Barjavel', N'René')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (7, N'Beagle', N'Peter S.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (8, N'Bory', N'Jean-Louis')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (9, N'Breton', N'Jean-François')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (10, N'Brite', N'Poppy Z.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (11, N'Bruit Zaidman', N'Louise')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (12, N'Campanella', N'Tommaso')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (13, N'Casanova', N'Giacomo')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (14, N'Cauvin', N'Patrick')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (15, N'Chase', N'James Hadley')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (16, N'Chédid', N'Andrée')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (17, N'Cherryh', N'Carolyn J.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (18, N'Chevillard', N'Thierry')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (19, N'Troyes', N'Chrétien de')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (20, N'Clarke', N'Arthur C.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (21, N'Colmont', N'Marie')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (22, N'Conan Doyle', N'Arthur')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (23, N'Dac', N'Pierre')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (24, N'Daeninckx', N'Didier')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (25, N'Dick', N'Philip Kindred')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (26, N'Dominique', N'A.-L.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (27, N'Edighoffer', N'Roland')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (28, N'Eliade', N'Mircea')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (29, N'Ellis', N'Bret Easton')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (30, N'Encel', N'Frédéric')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (31, N'Fajardie', N'Frédéric H.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (32, N'Findley', N'Timothy')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (33, N'Follet', N'Ken')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (34, N'Foulkes', N'Maït')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (35, N'Freud', N'Sigmund')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (36, N'Gallois', N'Anne')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (37, N'Giraudoux', N'Jean')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (38, N'Hartmann', N'Florence')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (39, N'Hobsbawm', N'Eric')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (40, N'Izzo', N'Jean-Claude')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (41, N'James', N'Phyllis Dorothy')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (42, N'Jarry', N'Alfred')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (43, N'Jonquet', N'Thierry')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (44, N'Jouguet', N'Pierre')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (45, N'Kafka', N'Franz')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (46, N'Keating', N'H. R. F.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (47, N'Khadra', N'Yasmina')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (48, N'Lang', N'Fritz')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (49, N'Le Bihan', N'Adrien')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (50, N'Le Breton', N'Auguste')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (51, N'Le Carré', N'John')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (52, N'Le Guin', N'Ursula')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (53, N'Le Texier', N'Robert')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (54, N'Leblanc', N'Maurice')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (55, N'Lecercle', N'Jean-Jacques')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (56, N'Lem', N'Stanislas')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (57, N'Leon', N'Donna')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (58, N'Levin', N'Ira')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (59, N'Ligou', N'D.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (60, N'Magnan', N'Pierre')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (61, N'Malaparte', N'Curzio')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (62, N'Meeks', N'Dimitri')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (63, N'Melnik', N'Constantin')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (64, N'Mérejovsky', N'Dmitri')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (65, N'Mestron', N'Hervé')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (66, N'Miller', N'Henry')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (67, N'Montaigne', N'Michel de')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (68, N'Moorcock', N'Michael')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (69, N'More', N'Thomas')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (70, N'Nivat', N'Anne')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (71, N'Njawé', N'Pius')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (72, N'Peyramaure', N'Michel')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (73, N'Plenel', N'Edwy')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (74, N'Poe', N'Edgar')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (75, N'Pohl', N'Frederick')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (76, N'Pouy', N'Jean-Bernard')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (77, N'Powers', N'Tim')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (78, N'Prada', N'Juan Manuel de la')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (79, N'Raimond', N'Jean-Bernard')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (80, N'Recueil', N'')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (81, N'Reed', N'John')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (82, N'Rice', N'Anne')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (83, N'Rimbaud', N'Edouard')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (84, N'Rivière', N'François')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (85, N'Roth', N'Philip')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (86, N'Rushdie', N'Salman')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (87, N'Sadoul', N'Jacques')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (88, N'Schopenhauer', N'Arthur')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (89, N'Sheckley', N'Robert')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (90, N'Shepard', N'Sam')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (91, N'Silverberg', N'Robert')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (92, N'Simmons', N'Dan')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (93, N'Siniac', N'Pierre')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (94, N'Sinoué', N'Gilbert')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (95, N'Sprague de Camp', N'L.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (96, N'Stoker', N'Bram')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (97, N'Tabachnik', N'Maud')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (98, N'Tocqueville', N'Alexis de')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (99, N'Twain', N'Mark')
GO
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (100, N'Van Vogt', N'Alfred E.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (101, N'Vance', N'Jack')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (102, N'Vercors', N'')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (103, N'Vernant', N'Jean-Pierre')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (104, N'Vernes', N'Henri')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (105, N'Verschave', N'François-Xavier')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (106, N'Villon', N'François')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (107, N'Vinci', N'Léonard de')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (108, N'Volkoff', N'Vladimir')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (109, N'Wells', N'Herbert George')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (110, N'Wilde', N'Oscar')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (111, N'Yung', N'Eric')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (112, N'Zelazny', N'Roger')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (113, N'Zeldin', N'Theodore')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (114, N'Hacquard', N'Georges')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (115, N'Dautry', N'J.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (116, N'Maisani', N'O.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (117, N'Aschero', N'Jean-Charles')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (118, N'Perrault', N'Gilles')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (119, N'Kuras', N'Benjamin')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (120, N'B.', N'Y.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (121, N'Gattégno', N'Jean-Pierre')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (122, N'Cazenave', N'Michel')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (123, N'Ligny', N'Jean-Marc')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (124, N'Nicole', N'Valérie')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (125, N'Block', N'Lawrence')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (126, N'Veyne', N'Paul')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (127, N'Leiber', N'Fritz')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (128, N'Arendt', N'Hannah')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (129, N'Orwell', N'George')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (130, N'Lorraine', N'Bérangère')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (131, N'Ray', N'Jean')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (132, N'Seurat', N'Michel')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (133, N'Louÿs', N'Pierre')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (134, N'Trump', N'Donald')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (135, N'Mahfouz', N'Naguib')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (136, N'Semprun', N'Jorge')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (137, N'Burnier', N'Michel-Antoine')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (138, N'Rambaud', N'Patrick')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (139, N'Dizdarevic', N'Zlatko')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (140, N'Spiegelman', N'Art')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (141, N'Meyer', N'Philippe')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (142, N'Desproges', N'Pierre')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (143, N'Saint-Laurent', N'Cécil')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (144, N'Sartre', N'Maurice')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (145, N'Pécherot', N'Patrick')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (146, N'Naipaul', N'V. S.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (147, N'Péan', N'Pierre')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (148, N'Cavanna', N'François')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (149, N'Pratt', N'Hugo')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (150, N'Kadaré', N'Ismail')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (151, N'Muñoz Molina', N'Antonio')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (152, N'Bradbury', N'Ray')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (153, N'Mitterrand', N'François')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (154, N'Marcelle', N'Pierre')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (155, N'Bourdieu', N'Pierre')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (156, N'Wul', N'Stefan')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (157, N'Hillerman', N'Tony')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (158, N'Lilius', N'Aleko')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (159, N'Tabet', N'Jade')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (160, N'Pélicier', N'Yves')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (161, N'Vessereau', N'André')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (162, N'Lentz', N'Serge')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (163, N'Chauchard', N'Paul')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (164, N'Wintrebert', N'Joëlle')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (165, N'Amiet', N'Pierre')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (166, N'Dillon', N'Myles')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (167, N'Chadwick', N'Nora K.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (168, N'Soublin', N'Jean')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (169, N'Pamuk', N'Orhan')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (170, N'Souaïdia', N'Habib')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (171, N'Lindskold', N'Jane')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (172, N'Subiela', N'Michel')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (173, N'Lovecraft', N'Howard Philip')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (174, N'Martin', N'George R. R.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (175, N'Hatzfeld', N'Jean')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (176, N'Bled', N'Bernard')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (177, N'Gaiman', N'Neil')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (178, N'Marchand', N'Paul M.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (179, N'Moore', N'Catherine L.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (180, N'Mahjoub', N'Jamal')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (181, N'Pynchon', N'Thomas')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (182, N'Milza', N'Pierre')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (183, N'Laroui', N'Abdallah')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (184, N'Vautrin', N'Jean')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (185, N'Anonyme', N'')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (186, N'Suard', N'Francois')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (187, N'Pauline Schmitt Pantel', N'Pauline')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (188, N'Couliano', N'Ioan P.')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (189, N'Raynal', N'Patrick')
INSERT [dbo].[Authors] ([Id], [Lastname], [Firstname]) VALUES (190, N'Arnaud', N'André')
SET IDENTITY_INSERT [dbo].[Authors] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (1, 6, N'L''ENA comme si vous y étiez                                                                                                                                                                                                                                    ', NULL, 6.4000, CAST(N'2032-09-07T00:00:00.000' AS DateTime), N'Résumé du livre : L''ENA comme si vous y étiez | Date de publication : Sep  7 2032 12:00AM                                                                                                                                                                      ', N'996269882')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (2, 3, N'Les moulins à nuages                                                                                                                                                                                                                                           ', NULL, 13.3000, CAST(N'2019-01-22T00:00:00.000' AS DateTime), N'Résumé du livre : Les moulins à nuages | Date de publication : Jan 22 2019 12:00AM                                                                                                                                                                             ', N'1189514814')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (3, 8, N'Orgueuil et préjugés                                                                                                                                                                                                                                           ', NULL, 15.2000, CAST(N'1912-01-17T00:00:00.000' AS DateTime), N'Résumé du livre : Orgueuil et préjugés | Date de publication : Jan 17 1912 12:00AM                                                                                                                                                                             ', N'552032787')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (4, 2, N'Rwanda :  un génocide français                                                                                                                                                                                                                                 ', NULL, 11.2000, CAST(N'1913-08-23T00:00:00.000' AS DateTime), N'Résumé du livre : Rwanda :  un génocide français | Date de publication : Aug 23 1913 12:00AM                                                                                                                                                                   ', N'50827272')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (5, 7, N'Cauchemar à quatre dimensions                                                                                                                                                                                                                                  ', NULL, 5.5000, CAST(N'1967-07-24T00:00:00.000' AS DateTime), N'Résumé du livre : Cauchemar à quatre dimensions | Date de publication : Jul 24 1967 12:00AM                                                                                                                                                                    ', N'778376164')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (6, 3, N'Béni soit l''atome                                                                                                                                                                                                                                              ', NULL, 8.7000, CAST(N'2075-06-02T00:00:00.000' AS DateTime), N'Résumé du livre : Béni soit l''atome | Date de publication : Jun  2 2075 12:00AM                                                                                                                                                                                ', N'915648917')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (7, 7, N'Le magicien de Karakosk                                                                                                                                                                                                                                        ', NULL, 22.0000, CAST(N'1969-04-03T00:00:00.000' AS DateTime), N'Résumé du livre : Le magicien de Karakosk | Date de publication : Apr  3 1969 12:00AM                                                                                                                                                                          ', N'939535517')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (8, 3, N'Contes de la fée verte                                                                                                                                                                                                                                         ', NULL, 20.0000, CAST(N'2037-12-02T00:00:00.000' AS DateTime), N'Résumé du livre : Contes de la fée verte | Date de publication : Dec  2 2037 12:00AM                                                                                                                                                                           ', N'307523807')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (9, 9, N'La religion grecque                                                                                                                                                                                                                                            ', NULL, 21.9000, CAST(N'1932-02-04T00:00:00.000' AS DateTime), N'Résumé du livre : La religion grecque | Date de publication : Feb  4 1932 12:00AM                                                                                                                                                                              ', N'1914294547')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (10, 9, N'La cité du Soleil                                                                                                                                                                                                                                              ', NULL, 24.5000, CAST(N'2009-08-09T00:00:00.000' AS DateTime), N'Résumé du livre : La cité du Soleil | Date de publication : Aug  9 2009 12:00AM                                                                                                                                                                                ', N'841659391')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (11, 7, N'Histoire de ma fuite des Plombs                                                                                                                                                                                                                                ', NULL, 12.0000, CAST(N'1932-10-02T00:00:00.000' AS DateTime), N'Résumé du livre : Histoire de ma fuite des Plombs | Date de publication : Oct  2 1932 12:00AM                                                                                                                                                                  ', N'1004762739')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (12, 8, N'Huit jours en été                                                                                                                                                                                                                                              ', NULL, 21.4000, CAST(N'2028-09-04T00:00:00.000' AS DateTime), N'Résumé du livre : Huit jours en été | Date de publication : Sep  4 2028 12:00AM                                                                                                                                                                                ', N'805487831')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (13, 7, N'Pourquoi pas nous ?                                                                                                                                                                                                                                            ', NULL, 6.1000, CAST(N'1994-12-19T00:00:00.000' AS DateTime), N'Résumé du livre : Pourquoi pas nous ? | Date de publication : Dec 19 1994 12:00AM                                                                                                                                                                              ', N'1551816149')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (14, 7, N'Le fin mot de l''histoire                                                                                                                                                                                                                                       ', NULL, 21.2000, CAST(N'2032-11-01T00:00:00.000' AS DateTime), N'Résumé du livre : Le fin mot de l''histoire | Date de publication : Nov  1 2032 12:00AM                                                                                                                                                                         ', N'1785050077')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (15, 3, N'L''autre                                                                                                                                                                                                                                                        ', NULL, 22.8000, CAST(N'1907-11-10T00:00:00.000' AS DateTime), N'Résumé du livre : L''autre | Date de publication : Nov 10 1907 12:00AM                                                                                                                                                                                          ', N'232255651')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (16, 7, N'Les étalombres                                                                                                                                                                                                                                                 ', NULL, 5.6000, CAST(N'1930-04-16T00:00:00.000' AS DateTime), N'Résumé du livre : Les étalombres | Date de publication : Apr 16 1930 12:00AM                                                                                                                                                                                   ', N'2130790079')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (17, 8, N'The bad leitmotiv                                                                                                                                                                                                                                              ', NULL, 14.6000, CAST(N'1909-07-08T00:00:00.000' AS DateTime), N'Résumé du livre : The bad leitmotiv | Date de publication : Jul  8 1909 12:00AM                                                                                                                                                                                ', N'926246966')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (18, 4, N'Romans de la Table Ronde                                                                                                                                                                                                                                       ', NULL, 11.4000, CAST(N'2057-06-17T00:00:00.000' AS DateTime), N'Résumé du livre : Romans de la Table Ronde | Date de publication : Jun 17 2057 12:00AM                                                                                                                                                                         ', N'1650915291')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (19, 1, N'Les fontaines du paradis                                                                                                                                                                                                                                       ', NULL, 8.3000, CAST(N'2010-08-20T00:00:00.000' AS DateTime), N'Résumé du livre : Les fontaines du paradis | Date de publication : Aug 20 2010 12:00AM                                                                                                                                                                         ', N'187082916')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (20, 1, N'Michka                                                                                                                                                                                                                                                         ', NULL, 22.1000, CAST(N'2006-11-20T00:00:00.000' AS DateTime), N'Résumé du livre : Michka | Date de publication : Nov 20 2006 12:00AM                                                                                                                                                                                           ', N'873807158')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (21, 9, N'Bons baisers de partout                                                                                                                                                                                                                                        ', NULL, 12.0000, CAST(N'1920-11-18T00:00:00.000' AS DateTime), N'Résumé du livre : Bons baisers de partout | Date de publication : Nov 18 1920 12:00AM                                                                                                                                                                          ', N'1520579215')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (22, 6, N'Autres lieux                                                                                                                                                                                                                                                   ', NULL, 13.3000, CAST(N'1978-05-26T00:00:00.000' AS DateTime), N'Résumé du livre : Autres lieux | Date de publication : May 26 1978 12:00AM                                                                                                                                                                                     ', N'1072486224')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (23, 5, N'Les figurants                                                                                                                                                                                                                                                  ', NULL, 5.5000, CAST(N'1969-06-11T00:00:00.000' AS DateTime), N'Résumé du livre : Les figurants | Date de publication : Jun 11 1969 12:00AM                                                                                                                                                                                    ', N'238913674')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (24, 1, N'Main Courante                                                                                                                                                                                                                                                  ', NULL, 22.6000, CAST(N'1952-08-30T00:00:00.000' AS DateTime), N'Résumé du livre : Main Courante | Date de publication : Aug 30 1952 12:00AM                                                                                                                                                                                    ', N'1712325861')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (25, 2, N'Zapping                                                                                                                                                                                                                                                        ', NULL, 11.5000, CAST(N'1929-01-24T00:00:00.000' AS DateTime), N'Résumé du livre : Zapping | Date de publication : Jan 24 1929 12:00AM                                                                                                                                                                                          ', N'1357829168')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (26, 4, N'Les braconniers du cosmos                                                                                                                                                                                                                                      ', NULL, 24.6000, CAST(N'2039-05-02T00:00:00.000' AS DateTime), N'Résumé du livre : Les braconniers du cosmos | Date de publication : May  2 2039 12:00AM                                                                                                                                                                        ', N'1460275297')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (27, 9, N'L''homme dont toutes les dents étaient exactement semblables                                                                                                                                                                                                    ', NULL, 23.8000, CAST(N'1986-04-02T00:00:00.000' AS DateTime), N'Résumé du livre : L''homme dont toutes les dents étaient exactement semblables | Date de publication : Apr  2 1986 12:00AM                                                                                                                                      ', N'259684775')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (28, 9, N'Le gorille se mange froid                                                                                                                                                                                                                                      ', NULL, 20.3000, CAST(N'1944-06-01T00:00:00.000' AS DateTime), N'Résumé du livre : Le gorille se mange froid | Date de publication : Jun  1 1944 12:00AM                                                                                                                                                                        ', N'1781821707')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (29, 6, N'Les Rose-Croix                                                                                                                                                                                                                                                 ', NULL, 24.8000, CAST(N'1964-01-14T00:00:00.000' AS DateTime), N'Résumé du livre : Les Rose-Croix | Date de publication : Jan 14 1964 12:00AM                                                                                                                                                                                   ', N'1280882929')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (30, 6, N'Initiation, rites, sociétés secrètes                                                                                                                                                                                                                           ', NULL, 18.5000, CAST(N'1979-07-20T00:00:00.000' AS DateTime), N'Résumé du livre : Initiation, rites, sociétés secrètes | Date de publication : Jul 20 1979 12:00AM                                                                                                                                                             ', N'1541322481')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (31, 7, N'Dictionnaire des religions                                                                                                                                                                                                                                     ', NULL, 13.1000, CAST(N'2006-06-25T00:00:00.000' AS DateTime), N'Résumé du livre : Dictionnaire des religions | Date de publication : Jun 25 2006 12:00AM                                                                                                                                                                       ', N'648909138')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (32, 3, N'Glamorama                                                                                                                                                                                                                                                      ', NULL, 5.1000, CAST(N'2015-06-15T00:00:00.000' AS DateTime), N'Résumé du livre : Glamorama | Date de publication : Jun 15 2015 12:00AM                                                                                                                                                                                        ', N'808000939')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (33, 6, N'L''art de la guerre par l''exemple                                                                                                                                                                                                                               ', NULL, 21.2000, CAST(N'1998-03-04T00:00:00.000' AS DateTime), N'Résumé du livre : L''art de la guerre par l''exemple | Date de publication : Mar  4 1998 12:00AM                                                                                                                                                                 ', N'1113765920')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (34, 3, N'Ciao, Bella, ciao !                                                                                                                                                                                                                                            ', NULL, 5.8000, CAST(N'1902-06-06T00:00:00.000' AS DateTime), N'Résumé du livre : Ciao, Bella, ciao ! | Date de publication : Jun  6 1902 12:00AM                                                                                                                                                                              ', N'225123230')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (35, 8, N'Les Hauts Vents                                                                                                                                                                                                                                                ', NULL, 20.5000, CAST(N'1902-07-17T00:00:00.000' AS DateTime), N'Résumé du livre : Les Hauts Vents | Date de publication : Jul 17 1902 12:00AM                                                                                                                                                                                  ', N'2059792596')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (36, 8, N'Guerres                                                                                                                                                                                                                                                        ', NULL, 20.2000, CAST(N'2042-04-06T00:00:00.000' AS DateTime), N'Résumé du livre : Guerres | Date de publication : Apr  6 2042 12:00AM                                                                                                                                                                                          ', N'1428615393')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (37, 5, N'Les lions du Panshir                                                                                                                                                                                                                                           ', NULL, 14.6000, CAST(N'2030-12-01T00:00:00.000' AS DateTime), N'Résumé du livre : Les lions du Panshir | Date de publication : Dec  1 2030 12:00AM                                                                                                                                                                             ', N'764826059')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (38, 9, N'Les saveurs du thé                                                                                                                                                                                                                                             ', NULL, 7.4000, CAST(N'1900-09-10T00:00:00.000' AS DateTime), N'Résumé du livre : Les saveurs du thé | Date de publication : Sep 10 1900 12:00AM                                                                                                                                                                               ', N'1006949935')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (39, 3, N'Cinq leçons sur la psychanalyse                                                                                                                                                                                                                                ', NULL, 8.3000, CAST(N'1931-01-29T00:00:00.000' AS DateTime), N'Résumé du livre : Cinq leçons sur la psychanalyse | Date de publication : Jan 29 1931 12:00AM                                                                                                                                                                  ', N'1495596008')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (40, 6, N'Aguigui Mouna                                                                                                                                                                                                                                                  ', NULL, 14.1000, CAST(N'1943-12-01T00:00:00.000' AS DateTime), N'Résumé du livre : Aguigui Mouna | Date de publication : Dec  1 1943 12:00AM                                                                                                                                                                                    ', N'857342241')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (41, 3, N'Intermezzo                                                                                                                                                                                                                                                     ', NULL, 20.9000, CAST(N'2076-12-18T00:00:00.000' AS DateTime), N'Résumé du livre : Intermezzo | Date de publication : Dec 18 2076 12:00AM                                                                                                                                                                                       ', N'2000200794')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (42, 6, N'Milosevic, la diagonale du fou                                                                                                                                                                                                                                 ', NULL, 17.2000, CAST(N'1908-05-29T00:00:00.000' AS DateTime), N'Résumé du livre : Milosevic, la diagonale du fou | Date de publication : May 29 1908 12:00AM                                                                                                                                                                   ', N'590828677')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (43, 1, N'L''historien engagé                                                                                                                                                                                                                                             ', NULL, 18.2000, CAST(N'2038-11-10T00:00:00.000' AS DateTime), N'Résumé du livre : L''historien engagé | Date de publication : Nov 10 2038 12:00AM                                                                                                                                                                               ', N'435342851')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (44, 8, N'Vivre fatigue                                                                                                                                                                                                                                                  ', NULL, 14.5000, CAST(N'1960-09-27T00:00:00.000' AS DateTime), N'Résumé du livre : Vivre fatigue | Date de publication : Sep 27 1960 12:00AM                                                                                                                                                                                    ', N'680365475')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (45, 8, N'Meurtre dans un fauteuil                                                                                                                                                                                                                                       ', NULL, 12.9000, CAST(N'2024-09-04T00:00:00.000' AS DateTime), N'Résumé du livre : Meurtre dans un fauteuil | Date de publication : Sep  4 2024 12:00AM                                                                                                                                                                         ', N'2138712448')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (46, 10, N'Une folie meurtrière                                                                                                                                                                                                                                           ', NULL, 16.3000, CAST(N'1940-10-09T00:00:00.000' AS DateTime), N'Résumé du livre : Une folie meurtrière | Date de publication : Oct  9 1940 12:00AM                                                                                                                                                                             ', N'1429480216')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (47, 2, N'Le pauvre nouveau est arrivé !                                                                                                                                                                                                                                 ', NULL, 14.7000, CAST(N'1921-07-30T00:00:00.000' AS DateTime), N'Résumé du livre : Le pauvre nouveau est arrivé ! | Date de publication : Jul 30 1921 12:00AM                                                                                                                                                                   ', N'35641180')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (48, 7, N'L''impérialisme macédonien et l''hellénisation de l''Orient                                                                                                                                                                                                       ', NULL, 15.3000, CAST(N'2003-04-27T00:00:00.000' AS DateTime), N'Résumé du livre : L''impérialisme macédonien et l''hellénisation de l''Orient | Date de publication : Apr 27 2003 12:00AM                                                                                                                                         ', N'549210362')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (49, 9, N'Le procès                                                                                                                                                                                                                                                      ', NULL, 7.7000, CAST(N'2055-04-14T00:00:00.000' AS DateTime), N'Résumé du livre : Le procès | Date de publication : Apr 14 2055 12:00AM                                                                                                                                                                                        ', N'1536135626')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (50, 7, N'Le shérif de Bombay                                                                                                                                                                                                                                            ', NULL, 7.5000, CAST(N'1986-09-12T00:00:00.000' AS DateTime), N'Résumé du livre : Le shérif de Bombay | Date de publication : Sep 12 1986 12:00AM                                                                                                                                                                              ', N'1359778196')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (51, 6, N'L''inspecteur Ghote en Californie                                                                                                                                                                                                                               ', NULL, 9.4000, CAST(N'2061-05-26T00:00:00.000' AS DateTime), N'Résumé du livre : L''inspecteur Ghote en Californie | Date de publication : May 26 2061 12:00AM                                                                                                                                                                 ', N'826284817')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (52, 1, N'Morituri                                                                                                                                                                                                                                                       ', NULL, 19.6000, CAST(N'2065-07-04T00:00:00.000' AS DateTime), N'Résumé du livre : Morituri | Date de publication : Jul  4 2065 12:00AM                                                                                                                                                                                         ', N'1484880463')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (53, 3, N'Auschwitz Graffiti                                                                                                                                                                                                                                             ', NULL, 21.1000, CAST(N'1959-07-07T00:00:00.000' AS DateTime), N'Résumé du livre : Auschwitz Graffiti | Date de publication : Jul  7 1959 12:00AM                                                                                                                                                                               ', N'314213583')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (54, 7, N'Bontemps et l''homme chat                                                                                                                                                                                                                                       ', NULL, 5.5000, CAST(N'1991-01-04T00:00:00.000' AS DateTime), N'Résumé du livre : Bontemps et l''homme chat | Date de publication : Jan  4 1991 12:00AM                                                                                                                                                                         ', N'1676537284')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (55, 10, N'Chandelles noires                                                                                                                                                                                                                                              ', NULL, 19.3000, CAST(N'1951-02-09T00:00:00.000' AS DateTime), N'Résumé du livre : Chandelles noires | Date de publication : Feb  9 1951 12:00AM                                                                                                                                                                                ', N'597310209')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (56, 1, N'livre d''or                                                                                                                                                                                                                                                     ', NULL, 15.3000, CAST(N'2021-07-31T00:00:00.000' AS DateTime), N'Résumé du livre : livre d''or | Date de publication : Jul 31 2021 12:00AM                                                                                                                                                                                       ', N'1259663047')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (57, 10, N'Le fol été du Fort Chabrol                                                                                                                                                                                                                                     ', NULL, 13.3000, CAST(N'1972-03-27T00:00:00.000' AS DateTime), N'Résumé du livre : Le fol été du Fort Chabrol | Date de publication : Mar 27 1972 12:00AM                                                                                                                                                                       ', N'43281866')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (58, 10, N'Le triangle d''or                                                                                                                                                                                                                                               ', NULL, 15.6000, CAST(N'1917-11-01T00:00:00.000' AS DateTime), N'Résumé du livre : Le triangle d''or | Date de publication : Nov  1 1917 12:00AM                                                                                                                                                                                 ', N'613359240')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (59, 8, N'Frankenstein: mythe et philosophie                                                                                                                                                                                                                             ', NULL, 13.4000, CAST(N'2046-06-21T00:00:00.000' AS DateTime), N'Résumé du livre : Frankenstein: mythe et philosophie | Date de publication : Jun 21 2046 12:00AM                                                                                                                                                               ', N'400399110')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (60, 9, N'Solaris                                                                                                                                                                                                                                                        ', NULL, 15.2000, CAST(N'1986-09-05T00:00:00.000' AS DateTime), N'Résumé du livre : Solaris | Date de publication : Sep  5 1986 12:00AM                                                                                                                                                                                          ', N'2078443693')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (61, 1, N'Mort à la Fenice                                                                                                                                                                                                                                               ', NULL, 10.7000, CAST(N'2036-02-03T00:00:00.000' AS DateTime), N'Résumé du livre : Mort à la Fenice | Date de publication : Feb  3 2036 12:00AM                                                                                                                                                                                 ', N'1580091138')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (62, 8, N'Un bonheur insoutenable                                                                                                                                                                                                                                        ', NULL, 23.1000, CAST(N'2078-03-08T00:00:00.000' AS DateTime), N'Résumé du livre : Un bonheur insoutenable | Date de publication : Mar  8 2078 12:00AM                                                                                                                                                                          ', N'1123438991')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (63, 5, N'Les îles britanniques en 1603                                                                                                                                                                                                                                  ', NULL, 18.4000, CAST(N'1999-10-04T00:00:00.000' AS DateTime), N'Résumé du livre : Les îles britanniques en 1603 | Date de publication : Oct  4 1999 12:00AM                                                                                                                                                                    ', N'1555012871')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (64, 7, N'Les Stuarts                                                                                                                                                                                                                                                    ', NULL, 17.9000, CAST(N'1931-11-14T00:00:00.000' AS DateTime), N'Résumé du livre : Les Stuarts | Date de publication : Nov 14 1931 12:00AM                                                                                                                                                                                      ', N'348651778')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (65, 7, N'Le sang des Atrides                                                                                                                                                                                                                                            ', NULL, 9.3000, CAST(N'2020-03-29T00:00:00.000' AS DateTime), N'Résumé du livre : Le sang des Atrides | Date de publication : Mar 29 2020 12:00AM                                                                                                                                                                              ', N'1370621879')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (66, 1, N'Le tombeau d''Hélios                                                                                                                                                                                                                                            ', NULL, 7.8000, CAST(N'1929-05-22T00:00:00.000' AS DateTime), N'Résumé du livre : Le tombeau d''Hélios | Date de publication : May 22 1929 12:00AM                                                                                                                                                                              ', N'1045513713')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (67, 5, N'La tête en fuite                                                                                                                                                                                                                                               ', NULL, 6.3000, CAST(N'1945-01-23T00:00:00.000' AS DateTime), N'Résumé du livre : La tête en fuite | Date de publication : Jan 23 1945 12:00AM                                                                                                                                                                                 ', N'868236938')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (68, 6, N'Les dieux égyptiens                                                                                                                                                                                                                                            ', NULL, 23.2000, CAST(N'2017-04-27T00:00:00.000' AS DateTime), N'Résumé du livre : Les dieux égyptiens | Date de publication : Apr 27 2017 12:00AM                                                                                                                                                                              ', N'1354314555')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (69, 5, N'Une affaire de trahison                                                                                                                                                                                                                                        ', NULL, 12.2000, CAST(N'2070-12-12T00:00:00.000' AS DateTime), N'Résumé du livre : Une affaire de trahison | Date de publication : Dec 12 2070 12:00AM                                                                                                                                                                          ', N'543300585')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (70, 3, N'Julien l''Apostat                                                                                                                                                                                                                                               ', NULL, 6.5000, CAST(N'1925-11-07T00:00:00.000' AS DateTime), N'Résumé du livre : Julien l''Apostat | Date de publication : Nov  7 1925 12:00AM                                                                                                                                                                                 ', N'1535297802')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (71, 1, N'Opus mortem                                                                                                                                                                                                                                                    ', NULL, 10.9000, CAST(N'1971-03-24T00:00:00.000' AS DateTime), N'Résumé du livre : Opus mortem | Date de publication : Mar 24 1971 12:00AM                                                                                                                                                                                      ', N'1934497129')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (72, 8, N'Lire aux cabinets                                                                                                                                                                                                                                              ', NULL, 10.0000, CAST(N'1949-07-25T00:00:00.000' AS DateTime), N'Résumé du livre : Lire aux cabinets | Date de publication : Jul 25 1949 12:00AM                                                                                                                                                                                ', N'191825679')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (73, 3, N'Des Cannibales                                                                                                                                                                                                                                                 ', NULL, 12.4000, CAST(N'2018-09-28T00:00:00.000' AS DateTime), N'Résumé du livre : Des Cannibales | Date de publication : Sep 28 2018 12:00AM                                                                                                                                                                                   ', N'1663503782')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (74, 5, N'La sorcière dormante                                                                                                                                                                                                                                           ', NULL, 7.1000, CAST(N'1940-12-08T00:00:00.000' AS DateTime), N'Résumé du livre : La sorcière dormante | Date de publication : Dec  8 1940 12:00AM                                                                                                                                                                             ', N'863927830')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (75, 3, N'Chienne de guerre                                                                                                                                                                                                                                              ', NULL, 20.0000, CAST(N'2058-01-12T00:00:00.000' AS DateTime), N'Résumé du livre : Chienne de guerre | Date de publication : Jan 12 2058 12:00AM                                                                                                                                                                                ', N'417036288')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (76, 3, N'Bloc-notes du bagnard                                                                                                                                                                                                                                          ', NULL, 15.2000, CAST(N'2050-02-05T00:00:00.000' AS DateTime), N'Résumé du livre : Bloc-notes du bagnard | Date de publication : Feb  5 2050 12:00AM                                                                                                                                                                            ', N'1474767792')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (77, 4, N'Les colosses de Carthage                                                                                                                                                                                                                                       ', NULL, 11.1000, CAST(N'2019-09-02T00:00:00.000' AS DateTime), N'Résumé du livre : Les colosses de Carthage | Date de publication : Sep  2 2019 12:00AM                                                                                                                                                                         ', N'1535606800')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (78, 10, N'Les portes de Gergovie                                                                                                                                                                                                                                         ', NULL, 24.9000, CAST(N'1941-06-11T00:00:00.000' AS DateTime), N'Résumé du livre : Les portes de Gergovie | Date de publication : Jun 11 1941 12:00AM                                                                                                                                                                           ', N'1010365963')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (79, 2, N'La part d''ombre                                                                                                                                                                                                                                                ', NULL, 6.3000, CAST(N'1905-04-11T00:00:00.000' AS DateTime), N'Résumé du livre : La part d''ombre | Date de publication : Apr 11 1905 12:00AM                                                                                                                                                                                  ', N'582776608')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (80, 8, N'Les lunettes                                                                                                                                                                                                                                                   ', NULL, 11.9000, CAST(N'1931-04-18T00:00:00.000' AS DateTime), N'Résumé du livre : Les lunettes | Date de publication : Apr 18 1931 12:00AM                                                                                                                                                                                     ', N'38696935')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (81, 9, N'Dialogue avec l''extraterrestre                                                                                                                                                                                                                                 ', NULL, 15.5000, CAST(N'2017-01-18T00:00:00.000' AS DateTime), N'Résumé du livre : Dialogue avec l''extraterrestre | Date de publication : Jan 18 2017 12:00AM                                                                                                                                                                   ', N'313790529')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (82, 3, N'Chasse à l''homme                                                                                                                                                                                                                                               ', NULL, 17.0000, CAST(N'2047-10-19T00:00:00.000' AS DateTime), N'Résumé du livre : Chasse à l''homme | Date de publication : Oct 19 2047 12:00AM                                                                                                                                                                                 ', N'359675578')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (83, 8, N'Poker d''âmes                                                                                                                                                                                                                                                   ', NULL, 13.4000, CAST(N'2057-03-01T00:00:00.000' AS DateTime), N'Résumé du livre : Poker d''âmes | Date de publication : Mar  1 2057 12:00AM                                                                                                                                                                                     ', N'792309093')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (84, 9, N'La Tempête                                                                                                                                                                                                                                                     ', NULL, 11.0000, CAST(N'2013-08-09T00:00:00.000' AS DateTime), N'Résumé du livre : La Tempête | Date de publication : Aug  9 2013 12:00AM                                                                                                                                                                                       ', N'1111670123')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (85, 3, N'La série des séries noires de l''été 1996                                                                                                                                                                                                                       ', NULL, 10.9000, CAST(N'1934-07-06T00:00:00.000' AS DateTime), N'Résumé du livre : La série des séries noires de l''été 1996 | Date de publication : Jul  6 1934 12:00AM                                                                                                                                                         ', N'1524182910')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (86, 6, N'Malheur aux tragiques                                                                                                                                                                                                                                          ', NULL, 20.2000, CAST(N'1908-09-07T00:00:00.000' AS DateTime), N'Résumé du livre : Malheur aux tragiques | Date de publication : Sep  7 1908 12:00AM                                                                                                                                                                            ', N'50207115')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (87, 7, N'Musées, des mondes énigmatiques                                                                                                                                                                                                                                ', NULL, 23.5000, CAST(N'1931-03-03T00:00:00.000' AS DateTime), N'Résumé du livre : Musées, des mondes énigmatiques | Date de publication : Mar  3 1931 12:00AM                                                                                                                                                                  ', N'517362897')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (88, 4, N'Penseurs grecs avant Socrate                                                                                                                                                                                                                                   ', NULL, 11.9000, CAST(N'1909-01-09T00:00:00.000' AS DateTime), N'Résumé du livre : Penseurs grecs avant Socrate | Date de publication : Jan  9 1909 12:00AM                                                                                                                                                                     ', N'1160066500')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (89, 1, N'Dix jours qui ébranlèrent le monde                                                                                                                                                                                                                             ', NULL, 24.0000, CAST(N'1956-12-05T00:00:00.000' AS DateTime), N'Résumé du livre : Dix jours qui ébranlèrent le monde | Date de publication : Dec  5 1956 12:00AM                                                                                                                                                               ', N'836067913')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (90, 7, N'Vittorio le vampire                                                                                                                                                                                                                                            ', NULL, 19.6000, CAST(N'2027-07-09T00:00:00.000' AS DateTime), N'Résumé du livre : Vittorio le vampire | Date de publication : Jul  9 2027 12:00AM                                                                                                                                                                              ', N'1657427117')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (91, 2, N'Doudou                                                                                                                                                                                                                                                         ', NULL, 20.7000, CAST(N'2001-10-19T00:00:00.000' AS DateTime), N'Résumé du livre : Doudou | Date de publication : Oct 19 2001 12:00AM                                                                                                                                                                                           ', N'974582001')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (92, 4, N'En enfer avec James Whale                                                                                                                                                                                                                                      ', NULL, 19.9000, CAST(N'1949-12-07T00:00:00.000' AS DateTime), N'Résumé du livre : En enfer avec James Whale | Date de publication : Dec  7 1949 12:00AM                                                                                                                                                                        ', N'1817784902')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (93, 4, N'Pastorale américaine                                                                                                                                                                                                                                           ', NULL, 12.7000, CAST(N'1998-11-01T00:00:00.000' AS DateTime), N'Résumé du livre : Pastorale américaine | Date de publication : Nov  1 1998 12:00AM                                                                                                                                                                             ', N'8819506')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (94, 10, N'Les versets sataniques                                                                                                                                                                                                                                         ', NULL, 18.5000, CAST(N'1909-11-29T00:00:00.000' AS DateTime), N'Résumé du livre : Les versets sataniques | Date de publication : Nov 29 1909 12:00AM                                                                                                                                                                           ', N'711549665')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (95, 6, N'Trois morts au soleil                                                                                                                                                                                                                                          ', NULL, 9.5000, CAST(N'2006-03-17T00:00:00.000' AS DateTime), N'Résumé du livre : Trois morts au soleil | Date de publication : Mar 17 2006 12:00AM                                                                                                                                                                            ', N'1264624317')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (96, 7, N'L''art d''avoir toujours raison                                                                                                                                                                                                                                  ', NULL, 7.2000, CAST(N'1998-01-28T00:00:00.000' AS DateTime), N'Résumé du livre : L''art d''avoir toujours raison | Date de publication : Jan 28 1998 12:00AM                                                                                                                                                                    ', N'1140988440')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (97, 4, N'Douces Illusions                                                                                                                                                                                                                                               ', NULL, 22.5000, CAST(N'1981-11-14T00:00:00.000' AS DateTime), N'Résumé du livre : Douces Illusions | Date de publication : Nov 14 1981 12:00AM                                                                                                                                                                                 ', N'468708732')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (98, 4, N'Les erreurs de Joenes                                                                                                                                                                                                                                          ', NULL, 6.0000, CAST(N'2024-09-14T00:00:00.000' AS DateTime), N'Résumé du livre : Les erreurs de Joenes | Date de publication : Sep 14 2024 12:00AM                                                                                                                                                                            ', N'1669474984')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (99, 4, N'Motel Chronicles / Lune faucon                                                                                                                                                                                                                                 ', NULL, 17.4000, CAST(N'1933-10-18T00:00:00.000' AS DateTime), N'Résumé du livre : Motel Chronicles / Lune faucon | Date de publication : Oct 18 1933 12:00AM                                                                                                                                                                   ', N'1781382560')
GO
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (100, 4, N'Le chemin de l''espace                                                                                                                                                                                                                                          ', NULL, 23.9000, CAST(N'1956-10-13T00:00:00.000' AS DateTime), N'Résumé du livre : Le chemin de l''espace | Date de publication : Oct 13 1956 12:00AM                                                                                                                                                                            ', N'2119682022')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (101, 1, N'Tom O''Bedlam                                                                                                                                                                                                                                                   ', NULL, 22.6000, CAST(N'2000-01-14T00:00:00.000' AS DateTime), N'Résumé du livre : Tom O''Bedlam | Date de publication : Jan 14 2000 12:00AM                                                                                                                                                                                     ', N'920434612')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (102, 9, N'Le conseiller                                                                                                                                                                                                                                                  ', NULL, 16.2000, CAST(N'2031-11-22T00:00:00.000' AS DateTime), N'Résumé du livre : Le conseiller | Date de publication : Nov 22 2031 12:00AM                                                                                                                                                                                    ', N'1409039074')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (103, 9, N'Démago Story                                                                                                                                                                                                                                                   ', NULL, 8.1000, CAST(N'2010-03-31T00:00:00.000' AS DateTime), N'Résumé du livre : Démago Story | Date de publication : Mar 31 2010 12:00AM                                                                                                                                                                                     ', N'1847309368')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (104, 8, N'Le dernier pharaon                                                                                                                                                                                                                                             ', NULL, 7.3000, CAST(N'1944-04-23T00:00:00.000' AS DateTime), N'Résumé du livre : Le dernier pharaon | Date de publication : Apr 23 1944 12:00AM                                                                                                                                                                               ', N'42108896')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (105, 8, N'A l''heure d''Iraz                                                                                                                                                                                                                                               ', NULL, 7.0000, CAST(N'2023-06-16T00:00:00.000' AS DateTime), N'Résumé du livre : A l''heure d''Iraz | Date de publication : Jun 16 2023 12:00AM                                                                                                                                                                                 ', N'1977681763')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (106, 4, N'Dracula                                                                                                                                                                                                                                                        ', NULL, 8.3000, CAST(N'1926-11-06T00:00:00.000' AS DateTime), N'Résumé du livre : Dracula | Date de publication : Nov  6 1926 12:00AM                                                                                                                                                                                          ', N'792448467')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (107, 7, N'Le sang de Venise                                                                                                                                                                                                                                              ', NULL, 15.7000, CAST(N'1957-01-31T00:00:00.000' AS DateTime), N'Résumé du livre : Le sang de Venise | Date de publication : Jan 31 1957 12:00AM                                                                                                                                                                                ', N'635110602')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (108, 8, N'Quinze jours dans le désert américain                                                                                                                                                                                                                          ', NULL, 8.4000, CAST(N'1903-07-18T00:00:00.000' AS DateTime), N'Résumé du livre : Quinze jours dans le désert américain | Date de publication : Jul 18 1903 12:00AM                                                                                                                                                            ', N'113578709')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (109, 5, N'Contes choisis                                                                                                                                                                                                                                                 ', NULL, 9.9000, CAST(N'1977-07-03T00:00:00.000' AS DateTime), N'Résumé du livre : Contes choisis | Date de publication : Jul  3 1977 12:00AM                                                                                                                                                                                   ', N'1454895251')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (110, 10, N'A l''assaut de l''invisible                                                                                                                                                                                                                                      ', NULL, 19.5000, CAST(N'1931-09-17T00:00:00.000' AS DateTime), N'Résumé du livre : A l''assaut de l''invisible | Date de publication : Sep 17 1931 12:00AM                                                                                                                                                                        ', N'1574312245')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (111, 1, N'La guerre contre le Rull                                                                                                                                                                                                                                       ', NULL, 11.0000, CAST(N'1972-08-24T00:00:00.000' AS DateTime), N'Résumé du livre : La guerre contre le Rull | Date de publication : Aug 24 1972 12:00AM                                                                                                                                                                         ', N'1716014989')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (112, 1, N'La machine ultime                                                                                                                                                                                                                                              ', NULL, 21.2000, CAST(N'1969-08-20T00:00:00.000' AS DateTime), N'Résumé du livre : La machine ultime | Date de publication : Aug 20 1969 12:00AM                                                                                                                                                                                ', N'855643625')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (113, 9, N'Le monde des A                                                                                                                                                                                                                                                 ', NULL, 8.2000, CAST(N'2024-12-01T00:00:00.000' AS DateTime), N'Résumé du livre : Le monde des A | Date de publication : Dec  1 2024 12:00AM                                                                                                                                                                                   ', N'49043174')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (114, 3, N'Le Silkie                                                                                                                                                                                                                                                      ', NULL, 12.3000, CAST(N'2026-01-16T00:00:00.000' AS DateTime), N'Résumé du livre : Le Silkie | Date de publication : Jan 16 2026 12:00AM                                                                                                                                                                                        ', N'1322614315')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (115, 7, N'L''empire de l''atome                                                                                                                                                                                                                                            ', NULL, 12.0000, CAST(N'1960-01-12T00:00:00.000' AS DateTime), N'Résumé du livre : L''empire de l''atome | Date de publication : Jan 12 1960 12:00AM                                                                                                                                                                              ', N'268912316')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (116, 5, N'Les joueurs du A                                                                                                                                                                                                                                               ', NULL, 18.0000, CAST(N'1969-01-02T00:00:00.000' AS DateTime), N'Résumé du livre : Les joueurs du A | Date de publication : Jan  2 1969 12:00AM                                                                                                                                                                                 ', N'592702234')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (117, 9, N'Escale dans les étoiles                                                                                                                                                                                                                                        ', NULL, 6.4000, CAST(N'1956-06-01T00:00:00.000' AS DateTime), N'Résumé du livre : Escale dans les étoiles | Date de publication : Jun  1 1956 12:00AM                                                                                                                                                                          ', N'1471241525')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (118, 6, N'Marune: Alastor 933                                                                                                                                                                                                                                            ', NULL, 20.0000, CAST(N'2058-04-10T00:00:00.000' AS DateTime), N'Résumé du livre : Marune: Alastor 933 | Date de publication : Apr 10 2058 12:00AM                                                                                                                                                                              ', N'190833408')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (119, 7, N'Trullion: Alastor 2262                                                                                                                                                                                                                                         ', NULL, 15.6000, CAST(N'1915-07-22T00:00:00.000' AS DateTime), N'Résumé du livre : Trullion: Alastor 2262 | Date de publication : Jul 22 1915 12:00AM                                                                                                                                                                           ', N'278518782')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (120, 8, N'Wyst: Alastor 1716                                                                                                                                                                                                                                             ', NULL, 13.3000, CAST(N'1974-05-08T00:00:00.000' AS DateTime), N'Résumé du livre : Wyst: Alastor 1716 | Date de publication : May  8 1974 12:00AM                                                                                                                                                                               ', N'1041739355')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (121, 6, N'Entre mythe et politique                                                                                                                                                                                                                                       ', NULL, 8.6000, CAST(N'1942-03-14T00:00:00.000' AS DateTime), N'Résumé du livre : Entre mythe et politique | Date de publication : Mar 14 1942 12:00AM                                                                                                                                                                         ', N'1311902270')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (122, 7, N'Les origines de la pensée grecque                                                                                                                                                                                                                              ', NULL, 13.8000, CAST(N'2013-05-26T00:00:00.000' AS DateTime), N'Résumé du livre : Les origines de la pensée grecque | Date de publication : May 26 2013 12:00AM                                                                                                                                                                ', N'1453523583')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (123, 6, N'Problèmes de la guerre en Grèce ancienne                                                                                                                                                                                                                       ', NULL, 18.5000, CAST(N'2025-06-28T00:00:00.000' AS DateTime), N'Résumé du livre : Problèmes de la guerre en Grèce ancienne | Date de publication : Jun 28 2025 12:00AM                                                                                                                                                         ', N'1124732218')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (124, 7, N'Problèmes de la guerre en Grèce ancienne                                                                                                                                                                                                                       ', NULL, 6.0000, CAST(N'2052-04-09T00:00:00.000' AS DateTime), N'Résumé du livre : Problèmes de la guerre en Grèce ancienne | Date de publication : Apr  9 2052 12:00AM                                                                                                                                                         ', N'316955819')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (125, 7, N'France-Afrique: le crime continue                                                                                                                                                                                                                              ', NULL, 24.7000, CAST(N'2004-09-18T00:00:00.000' AS DateTime), N'Résumé du livre : France-Afrique: le crime continue | Date de publication : Sep 18 2004 12:00AM                                                                                                                                                                ', N'119471934')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (126, 2, N'Le testament                                                                                                                                                                                                                                                   ', NULL, 10.0000, CAST(N'1999-08-03T00:00:00.000' AS DateTime), N'Résumé du livre : Le testament | Date de publication : Aug  3 1999 12:00AM                                                                                                                                                                                     ', N'335046926')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (127, 8, N'Prophéties facétieuses                                                                                                                                                                                                                                         ', NULL, 10.8000, CAST(N'2009-01-11T00:00:00.000' AS DateTime), N'Résumé du livre : Prophéties facétieuses | Date de publication : Jan 11 2009 12:00AM                                                                                                                                                                           ', N'1351042193')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (128, 10, N'Un cas de force mineure                                                                                                                                                                                                                                        ', NULL, 19.1000, CAST(N'1968-09-16T00:00:00.000' AS DateTime), N'Résumé du livre : Un cas de force mineure | Date de publication : Sep 16 1968 12:00AM                                                                                                                                                                          ', N'455560102')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (129, 10, N'Un homme juste                                                                                                                                                                                                                                                 ', NULL, 18.4000, CAST(N'2060-11-23T00:00:00.000' AS DateTime), N'Résumé du livre : Un homme juste | Date de publication : Nov 23 2060 12:00AM                                                                                                                                                                                   ', N'1473835731')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (130, 2, N'L''Homme Invisible                                                                                                                                                                                                                                              ', NULL, 9.4000, CAST(N'1911-02-15T00:00:00.000' AS DateTime), N'Résumé du livre : L''Homme Invisible | Date de publication : Feb 15 1911 12:00AM                                                                                                                                                                                ', N'1564895255')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (131, 5, N'La jeunesse est un art                                                                                                                                                                                                                                         ', NULL, 7.0000, CAST(N'1999-05-21T00:00:00.000' AS DateTime), N'Résumé du livre : La jeunesse est un art | Date de publication : May 21 1999 12:00AM                                                                                                                                                                           ', N'1266916270')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (132, 1, N'La tentation de l''ombre                                                                                                                                                                                                                                        ', NULL, 21.7000, CAST(N'1990-02-14T00:00:00.000' AS DateTime), N'Résumé du livre : La tentation de l''ombre | Date de publication : Feb 14 1990 12:00AM                                                                                                                                                                          ', N'1356289975')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (133, 10, N'La main d''Oberon                                                                                                                                                                                                                                               ', NULL, 22.7000, CAST(N'1998-10-04T00:00:00.000' AS DateTime), N'Résumé du livre : La main d''Oberon | Date de publication : Oct  4 1998 12:00AM                                                                                                                                                                                 ', N'1987304078')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (134, 5, N'La pierre des étoiles                                                                                                                                                                                                                                          ', NULL, 23.2000, CAST(N'1938-03-27T00:00:00.000' AS DateTime), N'Résumé du livre : La pierre des étoiles | Date de publication : Mar 27 1938 12:00AM                                                                                                                                                                            ', N'2125319429')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (135, 2, N'Le maître des ombres                                                                                                                                                                                                                                           ', NULL, 23.1000, CAST(N'2015-09-23T00:00:00.000' AS DateTime), N'Résumé du livre : Le maître des ombres | Date de publication : Sep 23 2015 12:00AM                                                                                                                                                                             ', N'1807862396')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (136, 10, N'Le sang d''Ambre                                                                                                                                                                                                                                                ', NULL, 21.2000, CAST(N'1994-05-28T00:00:00.000' AS DateTime), N'Résumé du livre : Le sang d''Ambre | Date de publication : May 28 1994 12:00AM                                                                                                                                                                                  ', N'1334757393')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (137, 4, N'Le signe de la licorne                                                                                                                                                                                                                                         ', NULL, 11.4000, CAST(N'1957-10-09T00:00:00.000' AS DateTime), N'Résumé du livre : Le signe de la licorne | Date de publication : Oct  9 1957 12:00AM                                                                                                                                                                           ', N'1470907680')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (138, 6, N'Les 9 princes d''Ambre                                                                                                                                                                                                                                          ', NULL, 8.4000, CAST(N'2056-05-09T00:00:00.000' AS DateTime), N'Résumé du livre : Les 9 princes d''Ambre | Date de publication : May  9 2056 12:00AM                                                                                                                                                                            ', N'1694546937')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (139, 6, N'Les cours du chaos                                                                                                                                                                                                                                             ', NULL, 23.2000, CAST(N'2016-08-07T00:00:00.000' AS DateTime), N'Résumé du livre : Les cours du chaos | Date de publication : Aug  7 2016 12:00AM                                                                                                                                                                               ', N'2085201155')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (140, 5, N'Les fusils d''Avalon                                                                                                                                                                                                                                            ', NULL, 5.5000, CAST(N'2029-03-13T00:00:00.000' AS DateTime), N'Résumé du livre : Les fusils d''Avalon | Date de publication : Mar 13 2029 12:00AM                                                                                                                                                                              ', N'1117268')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (141, 5, N'L''île des morts                                                                                                                                                                                                                                                ', NULL, 13.0000, CAST(N'1936-11-15T00:00:00.000' AS DateTime), N'Résumé du livre : L''île des morts | Date de publication : Nov 15 1936 12:00AM                                                                                                                                                                                  ', N'2037393660')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (142, 3, N'Repères sur la route                                                                                                                                                                                                                                           ', NULL, 23.5000, CAST(N'1963-12-08T00:00:00.000' AS DateTime), N'Résumé du livre : Repères sur la route | Date de publication : Dec  8 1963 12:00AM                                                                                                                                                                             ', N'1414531089')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (143, 3, N'Route 666                                                                                                                                                                                                                                                      ', NULL, 13.7000, CAST(N'2008-11-06T00:00:00.000' AS DateTime), N'Résumé du livre : Route 666 | Date de publication : Nov  6 2008 12:00AM                                                                                                                                                                                        ', N'850333231')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (144, 3, N'Royaumes d''ombre et de lumière                                                                                                                                                                                                                                 ', NULL, 12.8000, CAST(N'2039-10-30T00:00:00.000' AS DateTime), N'Résumé du livre : Royaumes d''ombre et de lumière | Date de publication : Oct 30 2039 12:00AM                                                                                                                                                                   ', N'1635784479')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (145, 9, N'Seigneur de lumière                                                                                                                                                                                                                                            ', NULL, 18.3000, CAST(N'1947-10-18T00:00:00.000' AS DateTime), N'Résumé du livre : Seigneur de lumière | Date de publication : Oct 18 1947 12:00AM                                                                                                                                                                              ', N'783481000')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (146, 3, N'Un pont de cendres                                                                                                                                                                                                                                             ', NULL, 7.9000, CAST(N'2020-01-18T00:00:00.000' AS DateTime), N'Résumé du livre : Un pont de cendres | Date de publication : Jan 18 2020 12:00AM                                                                                                                                                                               ', N'1331072687')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (147, 6, N'Une rose pour l''Ecclésiaste                                                                                                                                                                                                                                    ', NULL, 19.6000, CAST(N'2017-04-03T00:00:00.000' AS DateTime), N'Résumé du livre : Une rose pour l''Ecclésiaste | Date de publication : Apr  3 2017 12:00AM                                                                                                                                                                      ', N'1641226951')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (148, 8, N'De la conversation                                                                                                                                                                                                                                             ', NULL, 9.3000, CAST(N'1986-09-23T00:00:00.000' AS DateTime), N'Résumé du livre : De la conversation | Date de publication : Sep 23 1986 12:00AM                                                                                                                                                                               ', N'1594846907')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (149, 2, N'Guide romain antique                                                                                                                                                                                                                                           ', NULL, 23.0000, CAST(N'1975-10-04T00:00:00.000' AS DateTime), N'Résumé du livre : Guide romain antique | Date de publication : Oct  4 1975 12:00AM                                                                                                                                                                             ', N'1116172078')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (150, 3, N'Elric des Dragons                                                                                                                                                                                                                                              ', NULL, 22.0000, CAST(N'2027-10-26T00:00:00.000' AS DateTime), N'Résumé du livre : Elric des Dragons | Date de publication : Oct 26 2027 12:00AM                                                                                                                                                                                ', N'1954980659')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (151, 2, N'Le comte Airain                                                                                                                                                                                                                                                ', NULL, 16.0000, CAST(N'1964-02-12T00:00:00.000' AS DateTime), N'Résumé du livre : Le comte Airain | Date de publication : Feb 12 1964 12:00AM                                                                                                                                                                                  ', N'1905975787')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (152, 10, N'Le champion de Garathorn                                                                                                                                                                                                                                       ', NULL, 9.1000, CAST(N'2027-12-13T00:00:00.000' AS DateTime), N'Résumé du livre : Le champion de Garathorn | Date de publication : Dec 13 2027 12:00AM                                                                                                                                                                         ', N'1436113874')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (153, 8, N'Le dieu fou                                                                                                                                                                                                                                                    ', NULL, 12.7000, CAST(N'2077-05-21T00:00:00.000' AS DateTime), N'Résumé du livre : Le dieu fou | Date de publication : May 21 2077 12:00AM                                                                                                                                                                                      ', N'1762630836')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (154, 5, N'Elric le nécromancien                                                                                                                                                                                                                                          ', NULL, 11.1000, CAST(N'2075-12-25T00:00:00.000' AS DateTime), N'Résumé du livre : Elric le nécromancien | Date de publication : Dec 25 2075 12:00AM                                                                                                                                                                            ', N'1779329006')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (155, 9, N'La sorcière dormante                                                                                                                                                                                                                                           ', NULL, 12.4000, CAST(N'1938-07-13T00:00:00.000' AS DateTime), N'Résumé du livre : La sorcière dormante | Date de publication : Jul 13 1938 12:00AM                                                                                                                                                                             ', N'1057674436')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (156, 4, N'L''épée noire                                                                                                                                                                                                                                                   ', NULL, 23.9000, CAST(N'1998-09-12T00:00:00.000' AS DateTime), N'Résumé du livre : L''épée noire | Date de publication : Sep 12 1998 12:00AM                                                                                                                                                                                     ', N'1819113135')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (157, 3, N'Stormbringer                                                                                                                                                                                                                                                   ', NULL, 17.3000, CAST(N'2007-11-25T00:00:00.000' AS DateTime), N'Résumé du livre : Stormbringer | Date de publication : Nov 25 2007 12:00AM                                                                                                                                                                                     ', N'2137745010')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (158, 1, N'Le navigateur sur les mers du destin                                                                                                                                                                                                                           ', NULL, 9.7000, CAST(N'1920-08-05T00:00:00.000' AS DateTime), N'Résumé du livre : Le navigateur sur les mers du destin | Date de publication : Aug  5 1920 12:00AM                                                                                                                                                             ', N'1651577607')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (159, 5, N'La forteresse de la perle                                                                                                                                                                                                                                      ', NULL, 11.6000, CAST(N'1904-10-16T00:00:00.000' AS DateTime), N'Résumé du livre : La forteresse de la perle | Date de publication : Oct 16 1904 12:00AM                                                                                                                                                                        ', N'2044194431')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (160, 3, N'Deuil de veuf                                                                                                                                                                                                                                                  ', NULL, 24.1000, CAST(N'2055-07-04T00:00:00.000' AS DateTime), N'Résumé du livre : Deuil de veuf | Date de publication : Jul  4 2055 12:00AM                                                                                                                                                                                    ', N'556702056')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (161, 4, N'La quête de Tanelorn                                                                                                                                                                                                                                           ', NULL, 20.5000, CAST(N'2064-04-29T00:00:00.000' AS DateTime), N'Résumé du livre : La quête de Tanelorn | Date de publication : Apr 29 2064 12:00AM                                                                                                                                                                             ', N'1129234479')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (162, 10, N'L''épée de l''aurore                                                                                                                                                                                                                                             ', NULL, 5.5000, CAST(N'2001-09-14T00:00:00.000' AS DateTime), N'Résumé du livre : L''épée de l''aurore | Date de publication : Sep 14 2001 12:00AM                                                                                                                                                                               ', N'1331950529')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (163, 8, N'Le joyau noir                                                                                                                                                                                                                                                  ', NULL, 21.0000, CAST(N'2026-08-04T00:00:00.000' AS DateTime), N'Résumé du livre : Le joyau noir | Date de publication : Aug  4 2026 12:00AM                                                                                                                                                                                    ', N'974419667')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (164, 9, N'Le secret des runes                                                                                                                                                                                                                                            ', NULL, 23.6000, CAST(N'1933-01-07T00:00:00.000' AS DateTime), N'Résumé du livre : Le secret des runes | Date de publication : Jan  7 1933 12:00AM                                                                                                                                                                              ', N'2030381998')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (165, 9, N'Meurtres pour mémoire                                                                                                                                                                                                                                          ', NULL, 10.1000, CAST(N'1993-07-11T00:00:00.000' AS DateTime), N'Résumé du livre : Meurtres pour mémoire | Date de publication : Jul 11 1993 12:00AM                                                                                                                                                                            ', N'1340525187')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (166, 9, N'Le dossier 51                                                                                                                                                                                                                                                  ', NULL, 14.5000, CAST(N'2064-12-06T00:00:00.000' AS DateTime), N'Résumé du livre : Le dossier 51 | Date de publication : Dec  6 2064 12:00AM                                                                                                                                                                                    ', N'1128205830')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (167, 3, N'Le seigneur des airs                                                                                                                                                                                                                                           ', NULL, 17.4000, CAST(N'1958-10-13T00:00:00.000' AS DateTime), N'Résumé du livre : Le seigneur des airs | Date de publication : Oct 13 1958 12:00AM                                                                                                                                                                             ', N'976530045')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (168, 5, N'Le Léviathan des terres                                                                                                                                                                                                                                        ', NULL, 18.4000, CAST(N'1906-01-21T00:00:00.000' AS DateTime), N'Résumé du livre : Le Léviathan des terres | Date de publication : Jan 21 1906 12:00AM                                                                                                                                                                          ', N'971038261')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (169, 3, N'Le tsar d''acier                                                                                                                                                                                                                                                ', NULL, 14.8000, CAST(N'1923-12-14T00:00:00.000' AS DateTime), N'Résumé du livre : Le tsar d''acier | Date de publication : Dec 14 1923 12:00AM                                                                                                                                                                                  ', N'633914686')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (170, 6, N'Les guerriers d''argent                                                                                                                                                                                                                                         ', NULL, 20.6000, CAST(N'1972-11-19T00:00:00.000' AS DateTime), N'Résumé du livre : Les guerriers d''argent | Date de publication : Nov 19 1972 12:00AM                                                                                                                                                                           ', N'338122706')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (171, 2, N'Le dragon de l''épée                                                                                                                                                                                                                                            ', NULL, 16.0000, CAST(N'1913-11-28T00:00:00.000' AS DateTime), N'Résumé du livre : Le dragon de l''épée | Date de publication : Nov 28 1913 12:00AM                                                                                                                                                                              ', N'121491171')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (172, 7, N'La revanche de la Rose                                                                                                                                                                                                                                         ', NULL, 13.2000, CAST(N'2071-08-20T00:00:00.000' AS DateTime), N'Résumé du livre : La revanche de la Rose | Date de publication : Aug 20 2071 12:00AM                                                                                                                                                                           ', N'599222515')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (173, 3, N'Elric à la fin de temps                                                                                                                                                                                                                                        ', NULL, 13.3000, CAST(N'1997-09-08T00:00:00.000' AS DateTime), N'Résumé du livre : Elric à la fin de temps | Date de publication : Sep  8 1997 12:00AM                                                                                                                                                                          ', N'929355965')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (174, 10, N'Métro pour l''enfer                                                                                                                                                                                                                                             ', NULL, 24.8000, CAST(N'1927-03-23T00:00:00.000' AS DateTime), N'Résumé du livre : Métro pour l''enfer | Date de publication : Mar 23 1927 12:00AM                                                                                                                                                                               ', N'121514599')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (175, 10, N'De la religion                                                                                                                                                                                                                                                 ', NULL, 13.2000, CAST(N'1955-02-09T00:00:00.000' AS DateTime), N'Résumé du livre : De la religion | Date de publication : Feb  9 1955 12:00AM                                                                                                                                                                                   ', N'47744671')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (176, 2, N'Comme il a dit lui                                                                                                                                                                                                                                             ', NULL, 6.7000, CAST(N'2048-11-08T00:00:00.000' AS DateTime), N'Résumé du livre : Comme il a dit lui | Date de publication : Nov  8 2048 12:00AM                                                                                                                                                                               ', N'1767147067')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (177, 8, N'Encyclopédie des symboles                                                                                                                                                                                                                                      ', NULL, 19.3000, CAST(N'2013-06-11T00:00:00.000' AS DateTime), N'Résumé du livre : Encyclopédie des symboles | Date de publication : Jun 11 2013 12:00AM                                                                                                                                                                        ', N'491865786')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (178, 5, N'Jihad                                                                                                                                                                                                                                                          ', NULL, 5.1000, CAST(N'2029-07-28T00:00:00.000' AS DateTime), N'Résumé du livre : Jihad | Date de publication : Jul 28 2029 12:00AM                                                                                                                                                                                            ', N'166078132')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (179, 10, N'Planète d''exil                                                                                                                                                                                                                                                 ', NULL, 22.5000, CAST(N'1929-04-13T00:00:00.000' AS DateTime), N'Résumé du livre : Planète d''exil | Date de publication : Apr 13 1929 12:00AM                                                                                                                                                                                   ', N'612543995')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (180, 4, N'Single & Single                                                                                                                                                                                                                                                ', NULL, 12.3000, CAST(N'1994-07-28T00:00:00.000' AS DateTime), N'Résumé du livre : Single & Single | Date de publication : Jul 28 1994 12:00AM                                                                                                                                                                                  ', N'415254805')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (181, 8, N'Rhialto le Merveilleux                                                                                                                                                                                                                                         ', NULL, 9.2000, CAST(N'2041-08-05T00:00:00.000' AS DateTime), N'Résumé du livre : Rhialto le Merveilleux | Date de publication : Aug  5 2041 12:00AM                                                                                                                                                                           ', N'1551903419')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (182, 1, N'Un monde magique                                                                                                                                                                                                                                               ', NULL, 23.9000, CAST(N'2077-01-28T00:00:00.000' AS DateTime), N'Résumé du livre : Un monde magique | Date de publication : Jan 28 2077 12:00AM                                                                                                                                                                                 ', N'170168938')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (183, 6, N'Les lions sont lâchés                                                                                                                                                                                                                                          ', NULL, 7.1000, CAST(N'1938-04-16T00:00:00.000' AS DateTime), N'Résumé du livre : Les lions sont lâchés | Date de publication : Apr 16 1938 12:00AM                                                                                                                                                                            ', N'1512373106')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (184, 4, N'Le blues du libraire                                                                                                                                                                                                                                           ', NULL, 18.7000, CAST(N'1922-05-28T00:00:00.000' AS DateTime), N'Résumé du livre : Le blues du libraire | Date de publication : May 28 1922 12:00AM                                                                                                                                                                             ', N'1001424224')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (185, 8, N'Les Grecs ont-ils cru à leurs mythes ?                                                                                                                                                                                                                         ', NULL, 7.2000, CAST(N'2022-10-02T00:00:00.000' AS DateTime), N'Résumé du livre : Les Grecs ont-ils cru à leurs mythes ? | Date de publication : Oct  2 2022 12:00AM                                                                                                                                                           ', N'1216631240')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (186, 1, N'Eichmann à Jérusalem                                                                                                                                                                                                                                           ', NULL, 8.0000, CAST(N'2016-10-11T00:00:00.000' AS DateTime), N'Résumé du livre : Eichmann à Jérusalem | Date de publication : Oct 11 2016 12:00AM                                                                                                                                                                             ', N'2073183955')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (187, 6, N'Les monades urbaines                                                                                                                                                                                                                                           ', NULL, 10.6000, CAST(N'1931-04-04T00:00:00.000' AS DateTime), N'Résumé du livre : Les monades urbaines | Date de publication : Apr  4 1931 12:00AM                                                                                                                                                                             ', N'1613781137')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (188, 1, N'Chanur                                                                                                                                                                                                                                                         ', NULL, 23.8000, CAST(N'1970-09-07T00:00:00.000' AS DateTime), N'Résumé du livre : Chanur | Date de publication : Sep  7 1970 12:00AM                                                                                                                                                                                           ', N'1477446578')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (189, 10, N'L''épopée de Chanur                                                                                                                                                                                                                                             ', NULL, 22.2000, CAST(N'1950-06-15T00:00:00.000' AS DateTime), N'Résumé du livre : L''épopée de Chanur | Date de publication : Jun 15 1950 12:00AM                                                                                                                                                                               ', N'370049611')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (190, 6, N'Le retour de Chanur                                                                                                                                                                                                                                            ', NULL, 14.5000, CAST(N'1931-09-19T00:00:00.000' AS DateTime), N'Résumé du livre : Le retour de Chanur | Date de publication : Sep 19 1931 12:00AM                                                                                                                                                                              ', N'452717042')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (191, 2, N'Le der des ders                                                                                                                                                                                                                                                ', NULL, 21.3000, CAST(N'1967-10-23T00:00:00.000' AS DateTime), N'Résumé du livre : Le der des ders | Date de publication : Oct 23 1967 12:00AM                                                                                                                                                                                  ', N'148220635')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (192, 8, N'Les cieux découronnés                                                                                                                                                                                                                                          ', NULL, 20.6000, CAST(N'2055-10-03T00:00:00.000' AS DateTime), N'Résumé du livre : Les cieux découronnés | Date de publication : Oct  3 2055 12:00AM                                                                                                                                                                            ', N'51064826')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (193, 4, N'Hommage à la Catalogne                                                                                                                                                                                                                                         ', NULL, 24.2000, CAST(N'1991-11-24T00:00:00.000' AS DateTime), N'Résumé du livre : Hommage à la Catalogne | Date de publication : Nov 24 1991 12:00AM                                                                                                                                                                           ', N'1852629026')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (194, 4, N'Meurtres à Libération                                                                                                                                                                                                                                          ', NULL, 14.5000, CAST(N'1996-09-09T00:00:00.000' AS DateTime), N'Résumé du livre : Meurtres à Libération | Date de publication : Sep  9 1996 12:00AM                                                                                                                                                                            ', N'958461558')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (195, 3, N'Les contes du whisky                                                                                                                                                                                                                                           ', NULL, 14.9000, CAST(N'1908-02-05T00:00:00.000' AS DateTime), N'Résumé du livre : Les contes du whisky | Date de publication : Feb  5 1908 12:00AM                                                                                                                                                                             ', N'293801727')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (196, 4, N'Czechs and balances                                                                                                                                                                                                                                            ', NULL, 6.1000, CAST(N'2019-11-26T00:00:00.000' AS DateTime), N'Résumé du livre : Czechs and balances | Date de publication : Nov 26 2019 12:00AM                                                                                                                                                                              ', N'199839256')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (197, 1, N'Le périple de Baldassare                                                                                                                                                                                                                                       ', NULL, 20.7000, CAST(N'1939-06-09T00:00:00.000' AS DateTime), N'Résumé du livre : Le périple de Baldassare | Date de publication : Jun  9 1939 12:00AM                                                                                                                                                                         ', N'1196119477')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (198, 5, N'L''Etat de barbarie                                                                                                                                                                                                                                             ', NULL, 20.2000, CAST(N'1939-05-20T00:00:00.000' AS DateTime), N'Résumé du livre : L''Etat de barbarie | Date de publication : May 20 1939 12:00AM                                                                                                                                                                               ', N'1481073313')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (199, 7, N'Manuel de civilité pour les petites filles à l''usage des maisons d''éducation                                                                                                                                                                                   ', NULL, 14.2000, CAST(N'2000-05-25T00:00:00.000' AS DateTime), N'Résumé du livre : Manuel de civilité pour les petites filles à l''usage des maisons d''éducation | Date de publication : May 25 2000 12:00AM                                                                                                                     ', N'727464963')
GO
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (200, 4, N'L''Amérique d''abord                                                                                                                                                                                                                                             ', NULL, 5.4000, CAST(N'1994-02-26T00:00:00.000' AS DateTime), N'Résumé du livre : L''Amérique d''abord | Date de publication : Feb 26 1994 12:00AM                                                                                                                                                                               ', N'391978828')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (201, 6, N'Akhénaton le renégat                                                                                                                                                                                                                                           ', NULL, 19.6000, CAST(N'1987-02-24T00:00:00.000' AS DateTime), N'Résumé du livre : Akhénaton le renégat | Date de publication : Feb 24 1987 12:00AM                                                                                                                                                                             ', N'1158471424')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (202, 8, N'Netchaïev est de retour                                                                                                                                                                                                                                        ', NULL, 16.6000, CAST(N'1902-08-19T00:00:00.000' AS DateTime), N'Résumé du livre : Netchaïev est de retour | Date de publication : Aug 19 1902 12:00AM                                                                                                                                                                          ', N'860704506')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (203, 7, N'Le journalisme sans peine                                                                                                                                                                                                                                      ', NULL, 19.2000, CAST(N'1926-08-02T00:00:00.000' AS DateTime), N'Résumé du livre : Le journalisme sans peine | Date de publication : Aug  2 1926 12:00AM                                                                                                                                                                        ', N'1867187898')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (204, 4, N'Journal de guerre                                                                                                                                                                                                                                              ', NULL, 21.4000, CAST(N'1975-10-13T00:00:00.000' AS DateTime), N'Résumé du livre : Journal de guerre | Date de publication : Oct 13 1975 12:00AM                                                                                                                                                                                ', N'674334345')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (205, 4, N'Maus                                                                                                                                                                                                                                                           ', NULL, 24.4000, CAST(N'1954-01-02T00:00:00.000' AS DateTime), N'Résumé du livre : Maus | Date de publication : Jan  2 1954 12:00AM                                                                                                                                                                                             ', N'1940530731')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (206, 8, N'Maus II                                                                                                                                                                                                                                                        ', NULL, 12.9000, CAST(N'1956-01-26T00:00:00.000' AS DateTime), N'Résumé du livre : Maus II | Date de publication : Jan 26 1956 12:00AM                                                                                                                                                                                          ', N'621560042')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (207, 10, N'Paris la grande                                                                                                                                                                                                                                                ', NULL, 6.1000, CAST(N'1931-03-18T00:00:00.000' AS DateTime), N'Résumé du livre : Paris la grande | Date de publication : Mar 18 1931 12:00AM                                                                                                                                                                                  ', N'615886229')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (208, 2, N'A louer sans commission                                                                                                                                                                                                                                        ', NULL, 7.1000, CAST(N'2078-04-14T00:00:00.000' AS DateTime), N'Résumé du livre : A louer sans commission | Date de publication : Apr 14 2078 12:00AM                                                                                                                                                                          ', N'1406626772')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (209, 1, N'Le petit reporter                                                                                                                                                                                                                                              ', NULL, 12.1000, CAST(N'2016-10-23T00:00:00.000' AS DateTime), N'Résumé du livre : Le petit reporter | Date de publication : Oct 23 2016 12:00AM                                                                                                                                                                                ', N'296818068')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (210, 4, N'L''erreur                                                                                                                                                                                                                                                       ', NULL, 14.2000, CAST(N'1911-06-22T00:00:00.000' AS DateTime), N'Résumé du livre : L''erreur | Date de publication : Jun 22 1911 12:00AM                                                                                                                                                                                         ', N'436054237')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (211, 9, N'Gentil Faty !                                                                                                                                                                                                                                                  ', NULL, 10.0000, CAST(N'2022-08-30T00:00:00.000' AS DateTime), N'Résumé du livre : Gentil Faty ! | Date de publication : Aug 30 2022 12:00AM                                                                                                                                                                                    ', N'1671526155')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (212, 7, N'Frivolités d''un siècle d''or                                                                                                                                                                                                                                    ', NULL, 22.1000, CAST(N'1943-03-19T00:00:00.000' AS DateTime), N'Résumé du livre : Frivolités d''un siècle d''or | Date de publication : Mar 19 1943 12:00AM                                                                                                                                                                      ', N'805626327')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (213, 8, N'D''Alexandre à Zénobie                                                                                                                                                                                                                                          ', NULL, 15.8000, CAST(N'1917-12-11T00:00:00.000' AS DateTime), N'Résumé du livre : D''Alexandre à Zénobie | Date de publication : Dec 11 1917 12:00AM                                                                                                                                                                            ', N'783947492')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (214, 7, N'Le sorcier de Terremer                                                                                                                                                                                                                                         ', NULL, 7.8000, CAST(N'1949-08-11T00:00:00.000' AS DateTime), N'Résumé du livre : Le sorcier de Terremer | Date de publication : Aug 11 1949 12:00AM                                                                                                                                                                           ', N'1733609594')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (215, 5, N'La pierre de rêve                                                                                                                                                                                                                                              ', NULL, 6.7000, CAST(N'1974-02-14T00:00:00.000' AS DateTime), N'Résumé du livre : La pierre de rêve | Date de publication : Feb 14 1974 12:00AM                                                                                                                                                                                ', N'494808372')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (216, 1, N'A la courbe du fleuve                                                                                                                                                                                                                                          ', NULL, 19.5000, CAST(N'1930-03-10T00:00:00.000' AS DateTime), N'Résumé du livre : A la courbe du fleuve | Date de publication : Mar 10 1930 12:00AM                                                                                                                                                                            ', N'1336496818')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (217, 2, N'Empire du soleil                                                                                                                                                                                                                                               ', NULL, 17.7000, CAST(N'1963-07-11T00:00:00.000' AS DateTime), N'Résumé du livre : Empire du soleil | Date de publication : Jul 11 1963 12:00AM                                                                                                                                                                                 ', N'1670803465')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (218, 5, N'Manipulations africaines                                                                                                                                                                                                                                       ', NULL, 5.4000, CAST(N'1937-08-06T00:00:00.000' AS DateTime), N'Résumé du livre : Manipulations africaines | Date de publication : Aug  6 1937 12:00AM                                                                                                                                                                         ', N'458647835')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (219, 5, N'Dieu, Mozart, Le Pen et les autres...                                                                                                                                                                                                                          ', NULL, 8.7000, CAST(N'1906-07-30T00:00:00.000' AS DateTime), N'Résumé du livre : Dieu, Mozart, Le Pen et les autres... | Date de publication : Jul 30 1906 12:00AM                                                                                                                                                            ', N'311124818')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (220, 7, N'Cour des mystères                                                                                                                                                                                                                                              ', NULL, 22.4000, CAST(N'2017-11-28T00:00:00.000' AS DateTime), N'Résumé du livre : Cour des mystères | Date de publication : Nov 28 2017 12:00AM                                                                                                                                                                                ', N'581815057')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (221, 4, N'Trois chants funèbres pour le Kosovo                                                                                                                                                                                                                           ', NULL, 20.9000, CAST(N'2007-09-06T00:00:00.000' AS DateTime), N'Résumé du livre : Trois chants funèbres pour le Kosovo | Date de publication : Sep  6 2007 12:00AM                                                                                                                                                             ', N'1943425802')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (222, 8, N'Pleine lune                                                                                                                                                                                                                                                    ', NULL, 12.3000, CAST(N'2041-10-31T00:00:00.000' AS DateTime), N'Résumé du livre : Pleine lune | Date de publication : Oct 31 2041 12:00AM                                                                                                                                                                                      ', N'1639604391')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (223, 6, N'Crash !                                                                                                                                                                                                                                                        ', NULL, 7.1000, CAST(N'1930-08-29T00:00:00.000' AS DateTime), N'Résumé du livre : Crash ! | Date de publication : Aug 29 1930 12:00AM                                                                                                                                                                                          ', N'1760576123')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (224, 10, N'L''abeille et l''architecte                                                                                                                                                                                                                                      ', NULL, 9.1000, CAST(N'1998-04-16T00:00:00.000' AS DateTime), N'Résumé du livre : L''abeille et l''architecte | Date de publication : Apr 16 1998 12:00AM                                                                                                                                                                        ', N'277934507')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (225, 9, N'Conduite intérieure                                                                                                                                                                                                                                            ', NULL, 19.5000, CAST(N'1977-10-31T00:00:00.000' AS DateTime), N'Résumé du livre : Conduite intérieure | Date de publication : Oct 31 1977 12:00AM                                                                                                                                                                              ', N'187573887')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (226, 5, N'La compagnie des Glaces                                                                                                                                                                                                                                        ', NULL, 5.1000, CAST(N'1905-11-02T00:00:00.000' AS DateTime), N'Résumé du livre : La compagnie des Glaces | Date de publication : Nov  2 1905 12:00AM                                                                                                                                                                          ', N'1852149888')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (227, 10, N'Langage et pouvoir symbolique                                                                                                                                                                                                                                  ', NULL, 22.0000, CAST(N'1936-07-21T00:00:00.000' AS DateTime), N'Résumé du livre : Langage et pouvoir symbolique | Date de publication : Jul 21 1936 12:00AM                                                                                                                                                                    ', N'1027765836')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (228, 5, N'La guerre des pieuvres                                                                                                                                                                                                                                         ', NULL, 10.0000, CAST(N'2073-08-08T00:00:00.000' AS DateTime), N'Résumé du livre : La guerre des pieuvres | Date de publication : Aug  8 2073 12:00AM                                                                                                                                                                           ', N'886208337')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (229, 7, N'Oms en série                                                                                                                                                                                                                                                   ', NULL, 18.8000, CAST(N'2011-12-13T00:00:00.000' AS DateTime), N'Résumé du livre : Oms en série | Date de publication : Dec 13 2011 12:00AM                                                                                                                                                                                     ', N'1689348940')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (230, 10, N'Les clowns sacrés                                                                                                                                                                                                                                              ', NULL, 14.3000, CAST(N'1981-01-12T00:00:00.000' AS DateTime), N'Résumé du livre : Les clowns sacrés | Date de publication : Jan 12 1981 12:00AM                                                                                                                                                                                ', N'3742058')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (231, 9, N'Pirate en mer de Chine                                                                                                                                                                                                                                         ', NULL, 9.1000, CAST(N'1908-05-13T00:00:00.000' AS DateTime), N'Résumé du livre : Pirate en mer de Chine | Date de publication : May 13 1908 12:00AM                                                                                                                                                                           ', N'2040204578')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (232, 9, N'Blaireau se cache                                                                                                                                                                                                                                              ', NULL, 17.8000, CAST(N'2013-09-20T00:00:00.000' AS DateTime), N'Résumé du livre : Blaireau se cache | Date de publication : Sep 20 2013 12:00AM                                                                                                                                                                                ', N'2012275386')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (233, 5, N'La compagnie des Glaces                                                                                                                                                                                                                                        ', NULL, 24.7000, CAST(N'1917-01-06T00:00:00.000' AS DateTime), N'Résumé du livre : La compagnie des Glaces | Date de publication : Jan  6 1917 12:00AM                                                                                                                                                                          ', N'1282557201')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (234, 6, N'Histoire de la psychiatrie                                                                                                                                                                                                                                     ', NULL, 23.9000, CAST(N'1900-12-04T00:00:00.000' AS DateTime), N'Résumé du livre : Histoire de la psychiatrie | Date de publication : Dec  4 1900 12:00AM                                                                                                                                                                       ', N'935538961')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (235, 9, N'La statistique                                                                                                                                                                                                                                                 ', NULL, 8.8000, CAST(N'1977-05-12T00:00:00.000' AS DateTime), N'Résumé du livre : La statistique | Date de publication : May 12 1977 12:00AM                                                                                                                                                                                   ', N'604125788')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (236, 8, N'Les années sandwiches                                                                                                                                                                                                                                          ', NULL, 7.2000, CAST(N'2018-06-17T00:00:00.000' AS DateTime), N'Résumé du livre : Les années sandwiches | Date de publication : Jun 17 2018 12:00AM                                                                                                                                                                            ', N'1248958795')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (237, 9, N'Bunker-parano                                                                                                                                                                                                                                                  ', NULL, 24.7000, CAST(N'1974-09-04T00:00:00.000' AS DateTime), N'Résumé du livre : Bunker-parano | Date de publication : Sep  4 1974 12:00AM                                                                                                                                                                                    ', N'359031439')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (238, 7, N'Tehanu                                                                                                                                                                                                                                                         ', NULL, 17.1000, CAST(N'1954-05-13T00:00:00.000' AS DateTime), N'Résumé du livre : Tehanu | Date de publication : May 13 1954 12:00AM                                                                                                                                                                                           ', N'1677218098')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (239, 9, N'Le crépuscule des épées                                                                                                                                                                                                                                        ', NULL, 6.2000, CAST(N'1940-01-11T00:00:00.000' AS DateTime), N'Résumé du livre : Le crépuscule des épées | Date de publication : Jan 11 1940 12:00AM                                                                                                                                                                          ', N'2079227933')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (240, 10, N'La compagnie des Glaces                                                                                                                                                                                                                                        ', NULL, 15.0000, CAST(N'2000-02-07T00:00:00.000' AS DateTime), N'Résumé du livre : La compagnie des Glaces | Date de publication : Feb  7 2000 12:00AM                                                                                                                                                                          ', N'180534288')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (241, 1, N'La chimie du cerveau                                                                                                                                                                                                                                           ', NULL, 11.6000, CAST(N'2036-09-18T00:00:00.000' AS DateTime), N'Résumé du livre : La chimie du cerveau | Date de publication : Sep 18 2036 12:00AM                                                                                                                                                                             ', N'628319736')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (242, 9, N'Le créateur chimérique                                                                                                                                                                                                                                         ', NULL, 7.7000, CAST(N'2024-01-02T00:00:00.000' AS DateTime), N'Résumé du livre : Le créateur chimérique | Date de publication : Jan  2 2024 12:00AM                                                                                                                                                                           ', N'1662532167')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (243, 7, N'Temps fort                                                                                                                                                                                                                                                     ', NULL, 18.9000, CAST(N'2054-11-06T00:00:00.000' AS DateTime), N'Résumé du livre : Temps fort | Date de publication : Nov  6 2054 12:00AM                                                                                                                                                                                       ', N'83741865')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (244, 1, N'Sodome et Gomorrhe                                                                                                                                                                                                                                             ', NULL, 6.4000, CAST(N'2051-03-23T00:00:00.000' AS DateTime), N'Résumé du livre : Sodome et Gomorrhe | Date de publication : Mar 23 2051 12:00AM                                                                                                                                                                               ', N'1538171406')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (245, 7, N'Le monde englouti                                                                                                                                                                                                                                              ', NULL, 10.3000, CAST(N'1925-09-14T00:00:00.000' AS DateTime), N'Résumé du livre : Le monde englouti | Date de publication : Sep 14 1925 12:00AM                                                                                                                                                                                ', N'1129016129')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (246, 5, N'Eternité société anonyme                                                                                                                                                                                                                                       ', NULL, 21.1000, CAST(N'1975-01-01T00:00:00.000' AS DateTime), N'Résumé du livre : Eternité société anonyme | Date de publication : Jan  1 1975 12:00AM                                                                                                                                                                         ', N'916660841')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (247, 1, N'Les royaumes celtiques                                                                                                                                                                                                                                         ', NULL, 18.5000, CAST(N'1917-09-04T00:00:00.000' AS DateTime), N'Résumé du livre : Les royaumes celtiques | Date de publication : Sep  4 1917 12:00AM                                                                                                                                                                           ', N'175532178')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (248, 1, N'Le second regard                                                                                                                                                                                                                                               ', NULL, 24.0000, CAST(N'2068-01-11T00:00:00.000' AS DateTime), N'Résumé du livre : Le second regard | Date de publication : Jan 11 2068 12:00AM                                                                                                                                                                                 ', N'693003271')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (249, 4, N'Mon nom est rouge                                                                                                                                                                                                                                              ', NULL, 19.8000, CAST(N'2072-07-21T00:00:00.000' AS DateTime), N'Résumé du livre : Mon nom est rouge | Date de publication : Jul 21 2072 12:00AM                                                                                                                                                                                ', N'900771742')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (250, 9, N'La sale guerre                                                                                                                                                                                                                                                 ', NULL, 22.0000, CAST(N'2003-11-03T00:00:00.000' AS DateTime), N'Résumé du livre : La sale guerre | Date de publication : Nov  3 2003 12:00AM                                                                                                                                                                                   ', N'1897493207')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (251, 3, N'Lord Démon                                                                                                                                                                                                                                                     ', NULL, 5.6000, CAST(N'1936-12-14T00:00:00.000' AS DateTime), N'Résumé du livre : Lord Démon | Date de publication : Dec 14 1936 12:00AM                                                                                                                                                                                       ', N'1838887549')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (252, 5, N'La messe noire des innocents                                                                                                                                                                                                                                   ', NULL, 17.2000, CAST(N'1914-09-18T00:00:00.000' AS DateTime), N'Résumé du livre : La messe noire des innocents | Date de publication : Sep 18 1914 12:00AM                                                                                                                                                                     ', N'314615477')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (253, 3, N'Le tire-bouchon du Bon Dieu                                                                                                                                                                                                                                    ', NULL, 24.0000, CAST(N'2004-09-21T00:00:00.000' AS DateTime), N'Résumé du livre : Le tire-bouchon du Bon Dieu | Date de publication : Sep 21 2004 12:00AM                                                                                                                                                                      ', N'511798583')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (254, 10, N'Le seigneur des araignées                                                                                                                                                                                                                                      ', NULL, 23.4000, CAST(N'2036-04-01T00:00:00.000' AS DateTime), N'Résumé du livre : Le seigneur des araignées | Date de publication : Apr  1 2036 12:00AM                                                                                                                                                                        ', N'1909889838')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (255, 6, N'La cité de la bête                                                                                                                                                                                                                                             ', NULL, 20.0000, CAST(N'2029-04-08T00:00:00.000' AS DateTime), N'Résumé du livre : La cité de la bête | Date de publication : Apr  8 2029 12:00AM                                                                                                                                                                               ', N'1703277994')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (256, 1, N'L''ultime rivage                                                                                                                                                                                                                                                ', NULL, 24.8000, CAST(N'2044-03-10T00:00:00.000' AS DateTime), N'Résumé du livre : L''ultime rivage | Date de publication : Mar 10 2044 12:00AM                                                                                                                                                                                  ', N'220828000')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (257, 3, N'Les tombeaux d''Atuan                                                                                                                                                                                                                                           ', NULL, 19.1000, CAST(N'1905-11-27T00:00:00.000' AS DateTime), N'Résumé du livre : Les tombeaux d''Atuan | Date de publication : Nov 27 1905 12:00AM                                                                                                                                                                             ', N'567330835')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (258, 7, N'Le cavalier Chaos                                                                                                                                                                                                                                              ', NULL, 16.2000, CAST(N'1970-07-23T00:00:00.000' AS DateTime), N'Résumé du livre : Le cavalier Chaos | Date de publication : Jul 23 1970 12:00AM                                                                                                                                                                                ', N'22833284')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (259, 9, N'Le sang du monde                                                                                                                                                                                                                                               ', NULL, 18.7000, CAST(N'1987-11-14T00:00:00.000' AS DateTime), N'Résumé du livre : Le sang du monde | Date de publication : Nov 14 1987 12:00AM                                                                                                                                                                                 ', N'420823251')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (260, 3, N'Les rails d''incertitude                                                                                                                                                                                                                                        ', NULL, 20.1000, CAST(N'1985-06-30T00:00:00.000' AS DateTime), N'Résumé du livre : Les rails d''incertitude | Date de publication : Jun 30 1985 12:00AM                                                                                                                                                                          ', N'1989411868')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (261, 7, N'L''agonie de la lumière                                                                                                                                                                                                                                         ', NULL, 11.6000, CAST(N'1964-10-28T00:00:00.000' AS DateTime), N'Résumé du livre : L''agonie de la lumière | Date de publication : Oct 28 1964 12:00AM                                                                                                                                                                           ', N'1233068199')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (262, 6, N'Le palais du déviant                                                                                                                                                                                                                                           ', NULL, 14.8000, CAST(N'2000-08-12T00:00:00.000' AS DateTime), N'Résumé du livre : Le palais du déviant | Date de publication : Aug 12 2000 12:00AM                                                                                                                                                                             ', N'1360813182')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (263, 6, N'Carnets de campagne                                                                                                                                                                                                                                            ', NULL, 23.1000, CAST(N'1913-08-30T00:00:00.000' AS DateTime), N'Résumé du livre : Carnets de campagne | Date de publication : Aug 30 1913 12:00AM                                                                                                                                                                              ', N'234682731')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (264, 4, N'Stardust                                                                                                                                                                                                                                                       ', NULL, 7.2000, CAST(N'1938-12-25T00:00:00.000' AS DateTime), N'Résumé du livre : Stardust | Date de publication : Dec 25 1938 12:00AM                                                                                                                                                                                         ', N'1670305487')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (265, 9, N'Sympathie pour le diable                                                                                                                                                                                                                                       ', NULL, 21.4000, CAST(N'2047-08-21T00:00:00.000' AS DateTime), N'Résumé du livre : Sympathie pour le diable | Date de publication : Aug 21 2047 12:00AM                                                                                                                                                                         ', N'720144770')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (266, 9, N'Shambleau                                                                                                                                                                                                                                                      ', NULL, 20.6000, CAST(N'2011-08-04T00:00:00.000' AS DateTime), N'Résumé du livre : Shambleau | Date de publication : Aug  4 2011 12:00AM                                                                                                                                                                                        ', N'2113389452')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (267, 8, N'Vineland                                                                                                                                                                                                                                                       ', NULL, 22.8000, CAST(N'2060-04-05T00:00:00.000' AS DateTime), N'Résumé du livre : Vineland | Date de publication : Apr  5 2060 12:00AM                                                                                                                                                                                         ', N'187288525')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (268, 4, N'Vienne la nuit                                                                                                                                                                                                                                                 ', NULL, 7.4000, CAST(N'1944-12-17T00:00:00.000' AS DateTime), N'Résumé du livre : Vienne la nuit | Date de publication : Dec 17 1944 12:00AM                                                                                                                                                                                   ', N'302749998')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (269, 1, N'Islam et histoire                                                                                                                                                                                                                                              ', NULL, 11.4000, CAST(N'2034-10-04T00:00:00.000' AS DateTime), N'Résumé du livre : Islam et histoire | Date de publication : Oct  4 2034 12:00AM                                                                                                                                                                                ', N'577814735')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (270, 5, N'Date d''expiration                                                                                                                                                                                                                                              ', NULL, 20.9000, CAST(N'2057-01-01T00:00:00.000' AS DateTime), N'Résumé du livre : Date d''expiration | Date de publication : Jan  1 2057 12:00AM                                                                                                                                                                                ', N'1265860206')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (271, 3, N'Histoire de Huon de Bordeaux et Aubéron roi de féerie                                                                                                                                                                                                          ', NULL, 18.6000, CAST(N'1995-03-26T00:00:00.000' AS DateTime), N'Résumé du livre : Histoire de Huon de Bordeaux et Aubéron roi de féerie | Date de publication : Mar 26 1995 12:00AM                                                                                                                                            ', N'538976810')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (272, 6, N'Le temps meurtrier                                                                                                                                                                                                                                             ', NULL, 12.2000, CAST(N'2039-07-28T00:00:00.000' AS DateTime), N'Résumé du livre : Le temps meurtrier | Date de publication : Jul 28 2039 12:00AM                                                                                                                                                                               ', N'946608534')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (273, 3, N'Les illuminés                                                                                                                                                                                                                                                  ', NULL, 20.2000, CAST(N'2056-09-06T00:00:00.000' AS DateTime), N'Résumé du livre : Les illuminés | Date de publication : Sep  6 2056 12:00AM                                                                                                                                                                                    ', N'1428625625')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (274, 3, N'Pierres de sang                                                                                                                                                                                                                                                ', NULL, 0.0000, CAST(N'1943-08-06T00:00:00.000' AS DateTime), N'Résumé du livre : Pierres de sang | Date de publication : Aug  6 1943 12:00AM                                                                                                                                                                                  ', N'377257295')
INSERT [dbo].[Books] ([Id], [Id_Editor], [Title], [Subtitle], [Price], [DatePublication], [Summary], [ISBN]) VALUES (275, 9, N'La religion grecque                                                                                                                                                                                                                                            ', NULL, 21.9000, CAST(N'2036-08-14T00:00:00.000' AS DateTime), N'Résumé du livre : La religion grecque | Date de publication : Aug 14 2036 12:00AM                                                                                                                                                                              ', N'2020878939')
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Description]) VALUES (1, N'Art                                                                                                 ')
INSERT [dbo].[Categories] ([Id], [Description]) VALUES (2, N'Bande dessinée                                                                                      ')
INSERT [dbo].[Categories] ([Id], [Description]) VALUES (3, N'Cuisine                                                                                             ')
INSERT [dbo].[Categories] ([Id], [Description]) VALUES (4, N'Roman                                                                                               ')
INSERT [dbo].[Categories] ([Id], [Description]) VALUES (5, N'Sciences                                                                                            ')
INSERT [dbo].[Categories] ([Id], [Description]) VALUES (6, N'Sciences Humaines                                                                                   ')
INSERT [dbo].[Categories] ([Id], [Description]) VALUES (7, N'Littérature                                                                                         ')
INSERT [dbo].[Categories] ([Id], [Description]) VALUES (8, N'Gestion                                                                                             ')
INSERT [dbo].[Categories] ([Id], [Description]) VALUES (9, N'High-tech                                                                                           ')
INSERT [dbo].[Categories] ([Id], [Description]) VALUES (10, N'Sport                                                                                               ')
INSERT [dbo].[Categories] ([Id], [Description]) VALUES (11, N'Langues                                                                                             ')
SET IDENTITY_INSERT [dbo].[Categories] OFF
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (1, 3)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (2, 159)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (6, 48)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (6, 71)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (8, 94)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (8, 142)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (8, 196)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (10, 105)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (11, 230)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (12, 29)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (12, 46)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (13, 11)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (13, 47)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (13, 134)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (14, 66)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (15, 246)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (16, 240)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (17, 42)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (18, 6)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (18, 147)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (18, 218)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (19, 194)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (20, 19)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (20, 94)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (21, 55)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (21, 113)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (21, 117)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (23, 28)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (24, 50)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (24, 70)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (24, 83)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (24, 128)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (27, 216)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (28, 217)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (31, 57)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (32, 127)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (33, 66)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (33, 156)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (35, 143)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (36, 52)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (37, 53)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (38, 83)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (38, 193)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (39, 22)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (39, 34)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (40, 35)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (41, 148)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (41, 237)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (43, 16)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (43, 150)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (44, 99)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (44, 110)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (44, 226)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (45, 1)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (45, 17)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (45, 82)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (45, 107)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (45, 156)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (46, 33)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (46, 110)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (46, 244)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (46, 246)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (48, 107)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (49, 96)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (50, 134)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (50, 233)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (52, 93)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (52, 160)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (53, 37)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (53, 80)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (55, 98)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (55, 106)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (56, 53)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (56, 107)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (56, 108)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (56, 235)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (59, 25)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (59, 189)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (60, 6)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (60, 22)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (62, 19)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (62, 240)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (64, 122)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (65, 104)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (65, 144)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (69, 80)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (69, 97)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (70, 117)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (70, 249)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (71, 45)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (71, 75)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (71, 245)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (72, 94)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (74, 16)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (75, 3)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (75, 137)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (75, 150)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (76, 155)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (78, 21)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (78, 85)
GO
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (80, 110)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (80, 189)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (81, 17)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (81, 89)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (84, 75)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (84, 95)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (85, 125)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (87, 112)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (89, 33)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (90, 25)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (90, 116)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (90, 228)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (91, 206)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (92, 160)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (93, 88)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (94, 201)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (94, 224)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (94, 227)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (96, 158)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (96, 193)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (96, 223)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (97, 3)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (97, 6)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (97, 32)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (98, 15)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (99, 211)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (99, 231)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (99, 235)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (102, 49)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (103, 151)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (106, 17)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (106, 248)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (107, 31)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (107, 50)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (108, 63)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (108, 154)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (109, 59)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (111, 27)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (112, 64)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (112, 224)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (113, 226)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (114, 66)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (114, 100)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (114, 140)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (114, 187)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (128, 1)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (131, 144)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (132, 5)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (132, 148)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (132, 197)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (135, 74)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (135, 91)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (137, 157)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (137, 246)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (140, 15)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (141, 38)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (141, 96)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (143, 76)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (143, 197)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (143, 204)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (144, 197)
INSERT [dbo].[Cowriters] ([Id_Author], [Id_Book]) VALUES (145, 200)
SET IDENTITY_INSERT [dbo].[Editors] ON 

INSERT [dbo].[Editors] ([Id], [Name], [CountryCode], [URL], [Email]) VALUES (1, N'Hachette', N'FR', N'https://www.hachette.fr/                                                                                                                                                                                                                                       ', N'info@hachette.ch                                                                                                                                                                                                                                               ')
INSERT [dbo].[Editors] ([Id], [Name], [CountryCode], [URL], [Email]) VALUES (2, N'Centre suisse de services Formation CSFO', N'CH', N'https://shop.sdbb.ch/                                                                                                                                                                                                                                          ', N' distribution@csfo.ch                                                                                                                                                                                                                                          ')
INSERT [dbo].[Editors] ([Id], [Name], [CountryCode], [URL], [Email]) VALUES (3, N'Editions ENI', N'FR', N'https://www.editions-eni.fr/                                                                                                                                                                                                                                   ', N'info@eni.fr                                                                                                                                                                                                                                                    ')
INSERT [dbo].[Editors] ([Id], [Name], [CountryCode], [URL], [Email]) VALUES (4, N'Accès Editions', N'FR', N'http://www.acces-editions.com/                                                                                                                                                                                                                                 ', N'info@acces-editions.com                                                                                                                                                                                                                                        ')
INSERT [dbo].[Editors] ([Id], [Name], [CountryCode], [URL], [Email]) VALUES (5, N'Oxford University Press (OUP)', N'UK', N'https://global.oup.com/                                                                                                                                                                                                                                        ', N'info@oup.com                                                                                                                                                                                                                                                   ')
INSERT [dbo].[Editors] ([Id], [Name], [CountryCode], [URL], [Email]) VALUES (6, N'University of California Press (UC Press)', N'USA', N'https://www.ucpress.edu/                                                                                                                                                                                                                                       ', N'info@uc-press.edu                                                                                                                                                                                                                                              ')
INSERT [dbo].[Editors] ([Id], [Name], [CountryCode], [URL], [Email]) VALUES (7, N'Der Audio Verlag (DAV)', N'DE', N'https://www.der-audio-verlag.de/                                                                                                                                                                                                                               ', N'info@dav.de                                                                                                                                                                                                                                                    ')
INSERT [dbo].[Editors] ([Id], [Name], [CountryCode], [URL], [Email]) VALUES (8, N'BPX Edition', N'DE', N'http://ww25.dallavecchia.com/                                                                                                                                                                                                                                  ', N'info@bpx-edition.de                                                                                                                                                                                                                                            ')
INSERT [dbo].[Editors] ([Id], [Name], [CountryCode], [URL], [Email]) VALUES (9, N'Editions Zoé', N'CH', N'http://www.editionszoe.ch                                                                                                                                                                                                                                      ', N'info@editionszoe.ch                                                                                                                                                                                                                                            ')
INSERT [dbo].[Editors] ([Id], [Name], [CountryCode], [URL], [Email]) VALUES (10, N'Editions Médecine et Hygiène', N'CH', N'https://www.medhyg.ch/                                                                                                                                                                                                                                         ', N'info@medhyg.ch                                                                                                                                                                                                                                                 ')
SET IDENTITY_INSERT [dbo].[Editors] OFF
SET IDENTITY_INSERT [dbo].[Formats] ON 

INSERT [dbo].[Formats] ([Id], [Description]) VALUES (1, N'Papier')
INSERT [dbo].[Formats] ([Id], [Description]) VALUES (2, N'Ebook')
INSERT [dbo].[Formats] ([Id], [Description]) VALUES (3, N'Audiobook')
INSERT [dbo].[Formats] ([Id], [Description]) VALUES (4, N'PDF')
INSERT [dbo].[Formats] ([Id], [Description]) VALUES (5, N'TXT')
SET IDENTITY_INSERT [dbo].[Formats] OFF
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Description]) VALUES (1, N'Antique')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (2, N'Contemporaine')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (3, N'Gothique')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (4, N'Moderne')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (5, N'Asie')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (6, N'Europe')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (7, N'Afrique')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (8, N'Comédie')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (9, N'Thriller')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (10, N'Action')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (11, N'Fantasy')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (12, N'fantastique')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (13, N'Biographie')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (14, N'Polar')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (15, N'Roman')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (16, N'Informatique')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (17, N'Gestion d''entreprise')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (18, N'Algèbre')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (19, N'Trigonométrie')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (20, N'Programmation Orientée objet (POO)')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (21, N'Informatique en nuage (Cloud)')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (22, N'Bases de données relationnelles')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (23, N'Big data')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (24, N'Anglais')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (25, N'Allemand')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (26, N'Statistiques')
INSERT [dbo].[Genres] ([Id], [Description]) VALUES (27, N'Italien')
SET IDENTITY_INSERT [dbo].[Genres] OFF
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([Id], [Description], [Code]) VALUES (1, N'Français', N'FRA')
INSERT [dbo].[Languages] ([Id], [Description], [Code]) VALUES (2, N'Anglais', N'ANG')
INSERT [dbo].[Languages] ([Id], [Description], [Code]) VALUES (3, N'Allemand', N'ALL')
INSERT [dbo].[Languages] ([Id], [Description], [Code]) VALUES (4, N'Espagnol', N'ESP')
INSERT [dbo].[Languages] ([Id], [Description], [Code]) VALUES (5, N'Italien', N'ITA')
SET IDENTITY_INSERT [dbo].[Languages] OFF

INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (1, 9, 6, 5, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (3, 3, 12, 4, 4)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (3, 5, 11, 4, 4)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (3, 7, 1, 1, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (3, 8, 13, 3, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (4, 3, 11, 3, 4)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (4, 6, 4, 3, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (5, 8, 23, 4, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (6, 2, 12, 3, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (6, 5, 16, 4, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (6, 9, 22, 4, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (7, 6, 24, 2, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (11, 9, 18, 1, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (12, 6, 12, 3, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (13, 3, 7, 2, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (13, 4, 13, 1, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (13, 7, 6, 1, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (20, 9, 10, 3, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (21, 2, 19, 3, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (22, 1, 23, 2, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (23, 2, 17, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (25, 6, 21, 3, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (27, 5, 10, 2, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (32, 1, 11, 2, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (33, 9, 1, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (33, 9, 18, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (37, 7, 7, 2, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (38, 7, 2, 1, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (46, 9, 14, 2, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (48, 6, 9, 2, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (48, 8, 1, 3, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (50, 5, 13, 2, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (52, 5, 14, 1, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (53, 9, 3, 3, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (55, 4, 6, 3, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (55, 5, 24, 2, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (56, 10, 27, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (67, 7, 11, 1, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (68, 2, 17, 2, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (74, 3, 17, 2, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (77, 6, 23, 3, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (78, 5, 5, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (78, 7, 11, 1, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (78, 9, 15, 1, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (80, 9, 15, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (82, 1, 2, 2, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (85, 2, 14, 3, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (85, 9, 12, 3, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (86, 5, 11, 3, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (86, 9, 8, 2, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (87, 5, 20, 1, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (87, 5, 24, 3, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (88, 5, 16, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (88, 8, 13, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (89, 3, 12, 4, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (89, 9, 18, 1, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (90, 9, 20, 3, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (91, 3, 13, 2, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (96, 7, 10, 2, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (97, 5, 22, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (99, 3, 5, 3, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (100, 2, 12, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (100, 3, 10, 3, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (100, 9, 12, 2, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (101, 5, 5, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (104, 7, 14, 2, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (105, 5, 15, 1, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (110, 1, 22, 2, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (110, 5, 11, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (111, 5, 3, 2, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (112, 4, 20, 1, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (113, 1, 5, 2, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (113, 8, 14, 2, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (120, 1, 6, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (121, 8, 15, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (125, 8, 23, 4, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (127, 2, 16, 2, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (127, 11, 22, 5, 4)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (133, 5, 24, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (133, 7, 19, 3, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (133, 8, 13, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (133, 9, 1, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (133, 9, 6, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (134, 9, 6, 5, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (135, 6, 17, 3, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (139, 3, 7, 1, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (140, 10, 13, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (141, 8, 7, 1, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (141, 9, 24, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (143, 1, 8, 2, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (143, 3, 20, 2, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (144, 5, 5, 1, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (145, 7, 14, 1, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (146, 4, 12, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (150, 8, 12, 3, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (151, 10, 5, 1, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (153, 11, 21, 5, 4)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (154, 2, 18, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (154, 6, 21, 5, 4)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (155, 1, 17, 2, 3)
GO
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (156, 7, 22, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (156, 8, 23, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (156, 8, 26, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (156, 10, 25, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (160, 1, 19, 2, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (187, 4, 5, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (189, 9, 3, 2, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (190, 4, 24, 1, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (190, 6, 7, 3, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (190, 10, 17, 3, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (190, 10, 20, 3, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (192, 5, 21, 1, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (193, 2, 3, 2, 2)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (197, 4, 7, 1, 1)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (199, 2, 17, 1, 3)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (216, 9, 22, 4, 5)
INSERT [dbo].[Ranks] ([Id_Book], [Id_Categorie], [Id_Genre], [Id_Format], [Id_Language]) VALUES (223, 8, 13, 3, 5)
SET IDENTITY_INSERT [dbo].[Stocks] ON 

INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (1, 46, 317, 267, CAST(N'2018-10-11T17:27:44.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (2, 27, 372, 322, CAST(N'2018-03-25T17:31:56.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (3, 29, 85, 55, CAST(N'2018-05-06T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (4, 43, 374, 324, CAST(N'2017-05-06T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (5, 71, 361, 311, CAST(N'2017-05-21T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (6, 38, 233, 183, CAST(N'2020-02-02T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (7, 216, 366, 316, CAST(N'2017-08-30T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (8, 195, 193, 143, CAST(N'2017-11-07T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (9, 203, 449, 399, CAST(N'2019-10-28T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (10, 200, 171, 121, CAST(N'2017-04-14T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (11, 114, 220, 170, CAST(N'2018-05-08T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (12, 120, 355, 305, CAST(N'2017-12-31T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (13, 130, 292, 242, CAST(N'2019-06-06T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (14, 114, 213, 163, CAST(N'2018-05-20T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (15, 1, 50, 25, CAST(N'2019-07-21T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (16, 45, 234, 184, CAST(N'2018-06-29T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (17, 44, 385, 335, CAST(N'2019-05-24T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (18, 45, 240, 190, CAST(N'2019-07-20T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (19, 243, 468, 418, CAST(N'2018-02-07T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (20, 128, 416, 366, CAST(N'2017-04-20T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (21, 31, 181, 131, CAST(N'2019-01-10T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (22, 91, 457, 407, CAST(N'2019-11-21T17:43:28.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (23, 42, 405, 355, CAST(N'2019-05-30T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (24, 37, 467, 417, CAST(N'2020-03-16T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (25, 217, 227, 177, CAST(N'2019-11-13T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (26, 59, 291, 241, CAST(N'2018-07-25T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (27, 67, 34, 31, CAST(N'2017-06-05T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (28, 28, 279, 229, CAST(N'2017-09-19T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (29, 156, 42, 17, CAST(N'2019-07-04T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (30, 204, 182, 132, CAST(N'2017-07-08T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (31, 191, 288, 238, CAST(N'2019-11-17T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (32, 237, 30, 27, CAST(N'2018-03-08T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (33, 100, 475, 425, CAST(N'2018-12-02T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (34, 26, 122, 92, CAST(N'2018-02-15T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (35, 5, 20, 17, CAST(N'2018-04-23T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (36, 3, 346, 296, CAST(N'2019-05-08T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (37, 145, 406, 356, CAST(N'2018-11-13T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (38, 242, 293, 243, CAST(N'2018-11-22T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (39, 121, 455, 405, CAST(N'2019-12-16T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (40, 69, 22, 19, CAST(N'2019-09-25T17:47:13.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (41, 209, 496, 446, CAST(N'2018-02-03T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (42, 31, 489, 439, CAST(N'2019-11-28T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (43, 55, 33, 30, CAST(N'2019-07-23T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (44, 122, 325, 275, CAST(N'2017-12-05T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (45, 100, 140, 110, CAST(N'2018-05-05T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (46, 199, 169, 119, CAST(N'2017-07-09T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (47, 115, 29, 26, CAST(N'2017-06-04T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (48, 197, 217, 167, CAST(N'2018-07-14T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (49, 197, 292, 242, CAST(N'2019-05-25T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (50, 3, 388, 338, CAST(N'2018-12-05T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (51, 221, 119, 89, CAST(N'2020-02-12T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (52, 200, 497, 447, CAST(N'2017-10-29T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (53, 40, 432, 382, CAST(N'2018-04-21T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (54, 134, 333, 283, CAST(N'2020-03-05T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (55, 30, 489, 439, CAST(N'2017-04-26T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (56, 54, 137, 107, CAST(N'2019-10-01T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (57, 3, 142, 112, CAST(N'2020-02-04T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (58, 40, 167, 117, CAST(N'2019-06-08T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (59, 31, 67, 42, CAST(N'2019-10-09T17:48:25.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (60, 245, 24, 21, CAST(N'2019-09-19T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (61, 225, 409, 359, CAST(N'2019-07-15T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (62, 20, 386, 336, CAST(N'2017-11-04T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (63, 122, 364, 314, CAST(N'2019-12-06T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (64, 142, 460, 410, CAST(N'2018-09-19T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (65, 220, 133, 103, CAST(N'2018-06-28T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (66, 235, 399, 349, CAST(N'2017-05-07T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (67, 135, 379, 329, CAST(N'2017-12-14T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (68, 8, 414, 364, CAST(N'2018-05-25T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (69, 102, 205, 155, CAST(N'2017-04-11T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (70, 243, 177, 127, CAST(N'2018-12-18T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (71, 19, 166, 116, CAST(N'2017-08-13T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (72, 115, 388, 338, CAST(N'2018-10-01T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (73, 60, 318, 268, CAST(N'2018-06-19T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (74, 242, 352, 302, CAST(N'2017-05-01T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (75, 32, 335, 285, CAST(N'2018-02-20T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (76, 192, 270, 220, CAST(N'2018-07-30T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (77, 33, 351, 301, CAST(N'2018-05-26T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (78, 65, 184, 134, CAST(N'2019-05-21T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (79, 239, 476, 426, CAST(N'2019-12-03T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (80, 129, 383, 333, CAST(N'2018-09-04T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (81, 12, 448, 398, CAST(N'2018-06-06T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (82, 32, 154, 104, CAST(N'2019-02-25T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (83, 235, 404, 354, CAST(N'2020-01-05T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (84, 14, 91, 61, CAST(N'2019-03-10T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (85, 232, 463, 413, CAST(N'2017-09-25T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (86, 196, 253, 203, CAST(N'2017-08-21T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (87, 243, 30, 27, CAST(N'2018-06-18T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (88, 134, 174, 124, CAST(N'2017-11-09T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (89, 139, 325, 275, CAST(N'2020-02-08T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (90, 124, 369, 319, CAST(N'2017-09-24T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (91, 151, 262, 212, CAST(N'2017-07-28T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (92, 73, 312, 262, CAST(N'2019-03-29T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (93, 21, 122, 92, CAST(N'2019-10-29T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (94, 104, 104, 74, CAST(N'2017-12-05T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (95, 1, 165, 115, CAST(N'2019-10-09T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (96, 160, 141, 111, CAST(N'2020-01-21T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (97, 160, 52, 27, CAST(N'2019-01-11T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (98, 30, 114, 84, CAST(N'2020-02-10T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (99, 117, 320, 270, CAST(N'2019-01-10T17:59:49.000' AS DateTime))
GO
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (100, 153, 375, 325, CAST(N'2017-05-24T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (101, 82, 314, 264, CAST(N'2018-06-02T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (102, 64, 173, 123, CAST(N'2019-08-26T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (103, 199, 449, 399, CAST(N'2017-10-18T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (104, 226, 433, 383, CAST(N'2019-04-08T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (105, 94, 66, 41, CAST(N'2018-05-02T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (106, 211, 153, 103, CAST(N'2017-10-02T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (107, 59, 478, 428, CAST(N'2017-10-07T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (108, 87, 80, 50, CAST(N'2018-02-10T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (109, 56, 94, 64, CAST(N'2020-02-29T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (110, 73, 328, 278, CAST(N'2018-01-19T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (111, 73, 330, 280, CAST(N'2019-01-18T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (112, 124, 459, 409, CAST(N'2019-02-03T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (113, 102, 449, 399, CAST(N'2018-09-19T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (114, 125, 449, 399, CAST(N'2018-06-06T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (115, 93, 283, 233, CAST(N'2019-10-27T17:59:49.000' AS DateTime))
INSERT [dbo].[Stocks] ([Id], [Id_Book], [InitialStock], [CurrentStock], [DeliveryDate]) VALUES (116, 105, 496, 446, CAST(N'2017-11-05T17:59:49.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Stocks] OFF
ALTER TABLE [dbo].[Stocks] ADD  DEFAULT ((0)) FOR [InitialStock]
GO
ALTER TABLE [dbo].[Appreciations]  WITH CHECK ADD  CONSTRAINT [FK_APPRECIATIONS_LINEITEMS] FOREIGN KEY([Id_LineItem])
REFERENCES [dbo].[LineItems] ([Id])
GO
ALTER TABLE [dbo].[Appreciations] CHECK CONSTRAINT [FK_APPRECIATIONS_LINEITEMS]
GO
ALTER TABLE [dbo].[Appreciations]  WITH CHECK ADD  CONSTRAINT [FK_APPRECIATIONS_ORDERS] FOREIGN KEY([Id_Order])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[Appreciations] CHECK CONSTRAINT [FK_APPRECIATIONS_ORDERS]
GO
ALTER TABLE [dbo].[Appreciations]  WITH CHECK ADD  CONSTRAINT [FK_APPRECIATIONS_PAYMENTS] FOREIGN KEY([Id_Payment])
REFERENCES [dbo].[Payments] ([Id])
GO
ALTER TABLE [dbo].[Appreciations] CHECK CONSTRAINT [FK_APPRECIATIONS_PAYMENTS]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Roles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_UserLogins_Users_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_USERS_CUSTOMERS] FOREIGN KEY([Id_Customer])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_USERS_CUSTOMERS]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_UserTokens_Users_UserId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_BOOKS_EDITORS] FOREIGN KEY([Id_Editor])
REFERENCES [dbo].[Editors] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_BOOKS_EDITORS]
GO
ALTER TABLE [dbo].[Cowriters]  WITH CHECK ADD  CONSTRAINT [FK_COWRITERS_AUTHORS] FOREIGN KEY([Id_Author])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[Cowriters] CHECK CONSTRAINT [FK_COWRITERS_AUTHORS]
GO
ALTER TABLE [dbo].[Cowriters]  WITH CHECK ADD  CONSTRAINT [FK_COWRITERS_BOOKS] FOREIGN KEY([Id_Book])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[Cowriters] CHECK CONSTRAINT [FK_COWRITERS_BOOKS]
GO
ALTER TABLE [dbo].[LineItems]  WITH CHECK ADD  CONSTRAINT [FK_LINEITEMS_BOOKS] FOREIGN KEY([Id_Book])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[LineItems] CHECK CONSTRAINT [FK_LINEITEMS_BOOKS]
GO
ALTER TABLE [dbo].[LineItems]  WITH CHECK ADD  CONSTRAINT [FK_LINEITEMS_SHOPPINGCARTS] FOREIGN KEY([Id_Shoppingcart])
REFERENCES [dbo].[ShoppingCarts] ([Id])
GO
ALTER TABLE [dbo].[LineItems] CHECK CONSTRAINT [FK_LINEITEMS_SHOPPINGCARTS]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_ORDERS_USERS] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_ORDERS_USERS]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_PAYMENTS_USERS] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_PAYMENTS_USERS]
GO
ALTER TABLE [dbo].[Ranks]  WITH CHECK ADD  CONSTRAINT [FK_RANKS_BOOKS] FOREIGN KEY([Id_Book])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[Ranks] CHECK CONSTRAINT [FK_RANKS_BOOKS]
GO
ALTER TABLE [dbo].[Ranks]  WITH CHECK ADD  CONSTRAINT [FK_RANKS_CATEGORIES] FOREIGN KEY([Id_Categorie])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Ranks] CHECK CONSTRAINT [FK_RANKS_CATEGORIES]
GO
ALTER TABLE [dbo].[Ranks]  WITH CHECK ADD  CONSTRAINT [FK_RANKS_FORMATS] FOREIGN KEY([Id_Format])
REFERENCES [dbo].[Formats] ([Id])
GO
ALTER TABLE [dbo].[Ranks] CHECK CONSTRAINT [FK_RANKS_FORMATS]
GO
ALTER TABLE [dbo].[Ranks]  WITH CHECK ADD  CONSTRAINT [FK_RANKS_GENRES] FOREIGN KEY([Id_Genre])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[Ranks] CHECK CONSTRAINT [FK_RANKS_GENRES]
GO
ALTER TABLE [dbo].[Ranks]  WITH CHECK ADD  CONSTRAINT [FK_RANKS_LANGUAGES] FOREIGN KEY([Id_Language])
REFERENCES [dbo].[Languages] ([Id])
GO
ALTER TABLE [dbo].[Ranks] CHECK CONSTRAINT [FK_RANKS_LANGUAGES]
GO
ALTER TABLE [dbo].[ShoppingCarts]  WITH CHECK ADD  CONSTRAINT [FK_SHOPPINGCARTS_USERS] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ShoppingCarts] CHECK CONSTRAINT [FK_SHOPPINGCARTS_USERS]
GO
ALTER TABLE [dbo].[Stocks]  WITH CHECK ADD  CONSTRAINT [FK_STOCKS_BOOKS] FOREIGN KEY([Id_Book])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[Stocks] CHECK CONSTRAINT [FK_STOCKS_BOOKS]
GO
