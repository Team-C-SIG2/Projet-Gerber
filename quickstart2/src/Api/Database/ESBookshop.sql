USE [master]
GO
/****** Object:  Database [ESBookshop]    Script Date: 06.04.2020 17:04:24 ******/
CREATE DATABASE [ESBookshop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ESBookshop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ESBookshop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ESBookshop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ESBookshop_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ESBookshop] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ESBookshop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ESBookshop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ESBookshop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ESBookshop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ESBookshop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ESBookshop] SET ARITHABORT OFF 
GO
ALTER DATABASE [ESBookshop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ESBookshop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ESBookshop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ESBookshop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ESBookshop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ESBookshop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ESBookshop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ESBookshop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ESBookshop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ESBookshop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ESBookshop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ESBookshop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ESBookshop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ESBookshop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ESBookshop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ESBookshop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ESBookshop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ESBookshop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ESBookshop] SET  MULTI_USER 
GO
ALTER DATABASE [ESBookshop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ESBookshop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ESBookshop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ESBookshop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ESBookshop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ESBookshop] SET QUERY_STORE = OFF
GO
USE [ESBookshop]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACCOUNTS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACCOUNTS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_CUTOMER] [int] NOT NULL,
	[PASSWORD] [varchar](15) NOT NULL,
	[LOGINNAME] [varchar](100) NOT NULL,
	[USERSTATE] [varchar](25) NOT NULL,
	[REGISTRATIONDATE] [datetime] NOT NULL,
	[ISCLOSED] [bit] NOT NULL,
	[BILLINGADDRESS] [char](255) NOT NULL,
	[TYPE] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ACCOUNTS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[APPRECIATIONS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[APPRECIATIONS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_LINEITEM] [int] NOT NULL,
	[ID_ORDER] [int] NOT NULL,
	[ID_PAYMENT] [int] NOT NULL,
	[EVALUATION] [varchar](20) NOT NULL,
 CONSTRAINT [PK_APPRECIATIONS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AUTHORS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUTHORS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LASTNAME] [varchar](100) NOT NULL,
	[FIRSTNAME] [varchar](100) NOT NULL,
 CONSTRAINT [PK_AUTHORS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BOOKS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BOOKS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_EDITEUR] [int] NOT NULL,
	[TITLE] [varchar](255) NOT NULL,
	[SUBTITLE] [varchar](128) NULL,
	[PRICE] [money] NOT NULL,
	[DATEPUBLICATION] [datetime] NOT NULL,
	[SUMMARY] [varchar](255) NOT NULL,
	[ISBN] [varchar](13) NOT NULL,
 CONSTRAINT [PK_BOOKS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORIES]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPTION] [char](100) NOT NULL,
 CONSTRAINT [PK_CATEGORIES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COWRITERS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COWRITERS](
	[ID_AUTHOR] [int] NOT NULL,
	[ID_BOOK] [int] NOT NULL,
 CONSTRAINT [PK_COWRITERS] PRIMARY KEY CLUSTERED 
(
	[ID_AUTHOR] ASC,
	[ID_BOOK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CUSTOMERS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMERS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ACRONYME] [varchar](4) NOT NULL,
	[FIRSTNAME] [varchar](50) NOT NULL,
	[LASTNAME] [varchar](100) NOT NULL,
	[ADDRESS] [varchar](255) NOT NULL,
	[ZIP] [varchar](4) NOT NULL,
	[CITY] [varchar](100) NOT NULL,
	[PHONE] [varchar](13) NULL,
	[EMAIL] [char](255) NOT NULL,
 CONSTRAINT [PK_CUSTOMERS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EDITEURS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EDITEURS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](128) NOT NULL,
	[URL] [varchar](128) NULL,
	[EMAIL] [varchar](255) NOT NULL,
	[COUNTRYCODE] [varchar](3) NOT NULL,
 CONSTRAINT [PK_EDITEURS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FORMATS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FORMATS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPTION] [varchar](50) NULL,
 CONSTRAINT [PK_FORMATS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GENRES]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GENRES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPTION] [varchar](100) NOT NULL,
 CONSTRAINT [PK_GENRES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LANGUAGES]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LANGUAGES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPTION] [varchar](20) NOT NULL,
	[CODE] [nchar](3) NOT NULL,
 CONSTRAINT [PK_LANGUAGES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LINEITEMS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LINEITEMS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_SHOPPINGCART] [int] NOT NULL,
	[ID_BOOK] [int] NOT NULL,
	[QUANTITY] [int] NOT NULL,
	[UNITPRICE] [money] NOT NULL,
	[ID_ORDER] [int] NOT NULL,
 CONSTRAINT [PK_LINEITEMS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ORDERS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ORDERS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ORDEREDDATE] [datetime] NOT NULL,
	[SHIPPEDDATE] [datetime] NOT NULL,
	[SHIPPINGADDRESS] [char](255) NOT NULL,
	[STATUS] [varchar](25) NOT NULL,
	[TOTALPRICE] [money] NOT NULL,
	[ID_ACCOUNT] [int] NOT NULL,
 CONSTRAINT [PK_ORDERS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAYMENTS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAYMENTS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PAIDDATE] [datetime] NOT NULL,
	[PRICETOTAL] [money] NOT NULL,
	[DETAILS] [char](255) NOT NULL,
	[ID_ACCOUNT] [int] NOT NULL,
 CONSTRAINT [PK_PAYMENTS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RANKS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RANKS](
	[ID_BOOK] [int] NOT NULL,
	[ID_CATEGORIE] [int] NOT NULL,
	[ID_GENRE] [int] NOT NULL,
	[ID_FORMAT] [int] NOT NULL,
	[ID_LANGUAGE] [int] NOT NULL,
 CONSTRAINT [PK_RANK] PRIMARY KEY CLUSTERED 
(
	[ID_BOOK] ASC,
	[ID_CATEGORIE] ASC,
	[ID_GENRE] ASC,
	[ID_FORMAT] ASC,
	[ID_LANGUAGE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SHOPPINGCARTS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SHOPPINGCARTS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CREATEDDATE] [datetime] NOT NULL,
	[ID_ACCOUNT] [int] NOT NULL,
 CONSTRAINT [PK_SHOPPINGCARTS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STOCKS]    Script Date: 06.04.2020 17:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STOCKS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_BOOK] [int] NOT NULL,
	[INITIALSTOCK] [smallint] NOT NULL,
	[CURRENTSTOCK] [smallint] NOT NULL,
	[DELIVERYDATE] [datetime] NOT NULL,
 CONSTRAINT [PK_STOCKS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[STOCKS] ADD  DEFAULT ((0)) FOR [INITIALSTOCK]
GO
ALTER TABLE [dbo].[ACCOUNTS]  WITH CHECK ADD  CONSTRAINT [FK_ACCOUNTS_CUSTOMERS] FOREIGN KEY([ID_CUTOMER])
REFERENCES [dbo].[CUSTOMERS] ([ID])
GO
ALTER TABLE [dbo].[ACCOUNTS] CHECK CONSTRAINT [FK_ACCOUNTS_CUSTOMERS]
GO
ALTER TABLE [dbo].[APPRECIATIONS]  WITH CHECK ADD  CONSTRAINT [FK_APPRECIATIONS_LINEITEMS] FOREIGN KEY([ID_LINEITEM])
REFERENCES [dbo].[LINEITEMS] ([ID])
GO
ALTER TABLE [dbo].[APPRECIATIONS] CHECK CONSTRAINT [FK_APPRECIATIONS_LINEITEMS]
GO
ALTER TABLE [dbo].[APPRECIATIONS]  WITH CHECK ADD  CONSTRAINT [FK_APPRECIATIONS_ORDERS] FOREIGN KEY([ID_ORDER])
REFERENCES [dbo].[ORDERS] ([ID])
GO
ALTER TABLE [dbo].[APPRECIATIONS] CHECK CONSTRAINT [FK_APPRECIATIONS_ORDERS]
GO
ALTER TABLE [dbo].[APPRECIATIONS]  WITH CHECK ADD  CONSTRAINT [FK_APPRECIATIONS_PAYMENTS] FOREIGN KEY([ID_PAYMENT])
REFERENCES [dbo].[PAYMENTS] ([ID])
GO
ALTER TABLE [dbo].[APPRECIATIONS] CHECK CONSTRAINT [FK_APPRECIATIONS_PAYMENTS]
GO
ALTER TABLE [dbo].[BOOKS]  WITH CHECK ADD  CONSTRAINT [FK_BOOKS_EDITEURS] FOREIGN KEY([ID_EDITEUR])
REFERENCES [dbo].[EDITEURS] ([ID])
GO
ALTER TABLE [dbo].[BOOKS] CHECK CONSTRAINT [FK_BOOKS_EDITEURS]
GO
ALTER TABLE [dbo].[COWRITERS]  WITH CHECK ADD  CONSTRAINT [FK_COWRITERS_AUTHORS] FOREIGN KEY([ID_AUTHOR])
REFERENCES [dbo].[AUTHORS] ([ID])
GO
ALTER TABLE [dbo].[COWRITERS] CHECK CONSTRAINT [FK_COWRITERS_AUTHORS]
GO
ALTER TABLE [dbo].[COWRITERS]  WITH CHECK ADD  CONSTRAINT [FK_COWRITERS_BOOKS] FOREIGN KEY([ID_BOOK])
REFERENCES [dbo].[BOOKS] ([ID])
GO
ALTER TABLE [dbo].[COWRITERS] CHECK CONSTRAINT [FK_COWRITERS_BOOKS]
GO
ALTER TABLE [dbo].[LINEITEMS]  WITH CHECK ADD  CONSTRAINT [FK_LINEITEMS_BOOKS] FOREIGN KEY([ID_BOOK])
REFERENCES [dbo].[BOOKS] ([ID])
GO
ALTER TABLE [dbo].[LINEITEMS] CHECK CONSTRAINT [FK_LINEITEMS_BOOKS]
GO
ALTER TABLE [dbo].[LINEITEMS]  WITH CHECK ADD  CONSTRAINT [FK_LINEITEMS_SHOPPINGCARTS] FOREIGN KEY([ID_SHOPPINGCART])
REFERENCES [dbo].[SHOPPINGCARTS] ([ID])
GO
ALTER TABLE [dbo].[LINEITEMS] CHECK CONSTRAINT [FK_LINEITEMS_SHOPPINGCARTS]
GO
ALTER TABLE [dbo].[ORDERS]  WITH CHECK ADD  CONSTRAINT [FK_ORDERS_ACCOUNTS] FOREIGN KEY([ID_ACCOUNT])
REFERENCES [dbo].[ACCOUNTS] ([ID])
GO
ALTER TABLE [dbo].[ORDERS] CHECK CONSTRAINT [FK_ORDERS_ACCOUNTS]
GO
ALTER TABLE [dbo].[PAYMENTS]  WITH CHECK ADD  CONSTRAINT [FK_PAYMENTS_ACCOUNTS] FOREIGN KEY([ID_ACCOUNT])
REFERENCES [dbo].[ACCOUNTS] ([ID])
GO
ALTER TABLE [dbo].[PAYMENTS] CHECK CONSTRAINT [FK_PAYMENTS_ACCOUNTS]
GO
ALTER TABLE [dbo].[RANKS]  WITH CHECK ADD  CONSTRAINT [FK_RANK_BOOKS] FOREIGN KEY([ID_BOOK])
REFERENCES [dbo].[BOOKS] ([ID])
GO
ALTER TABLE [dbo].[RANKS] CHECK CONSTRAINT [FK_RANK_BOOKS]
GO
ALTER TABLE [dbo].[RANKS]  WITH CHECK ADD  CONSTRAINT [FK_RANK_CATEGORIES] FOREIGN KEY([ID_CATEGORIE])
REFERENCES [dbo].[CATEGORIES] ([ID])
GO
ALTER TABLE [dbo].[RANKS] CHECK CONSTRAINT [FK_RANK_CATEGORIES]
GO
ALTER TABLE [dbo].[RANKS]  WITH CHECK ADD  CONSTRAINT [FK_RANK_FORMATS] FOREIGN KEY([ID_FORMAT])
REFERENCES [dbo].[FORMATS] ([ID])
GO
ALTER TABLE [dbo].[RANKS] CHECK CONSTRAINT [FK_RANK_FORMATS]
GO
ALTER TABLE [dbo].[RANKS]  WITH CHECK ADD  CONSTRAINT [FK_RANK_GENRES] FOREIGN KEY([ID_GENRE])
REFERENCES [dbo].[GENRES] ([ID])
GO
ALTER TABLE [dbo].[RANKS] CHECK CONSTRAINT [FK_RANK_GENRES]
GO
ALTER TABLE [dbo].[RANKS]  WITH CHECK ADD  CONSTRAINT [FK_RANK_LANGUAGES] FOREIGN KEY([ID_LANGUAGE])
REFERENCES [dbo].[LANGUAGES] ([ID])
GO
ALTER TABLE [dbo].[RANKS] CHECK CONSTRAINT [FK_RANK_LANGUAGES]
GO
ALTER TABLE [dbo].[SHOPPINGCARTS]  WITH CHECK ADD  CONSTRAINT [FK_SHOPPINGCARTS_ACCOUNTS] FOREIGN KEY([ID_ACCOUNT])
REFERENCES [dbo].[ACCOUNTS] ([ID])
GO
ALTER TABLE [dbo].[SHOPPINGCARTS] CHECK CONSTRAINT [FK_SHOPPINGCARTS_ACCOUNTS]
GO
ALTER TABLE [dbo].[STOCKS]  WITH CHECK ADD  CONSTRAINT [FK_STOCKS_BOOKS] FOREIGN KEY([ID_BOOK])
REFERENCES [dbo].[BOOKS] ([ID])
GO
ALTER TABLE [dbo].[STOCKS] CHECK CONSTRAINT [FK_STOCKS_BOOKS]
GO
USE [master]
GO
ALTER DATABASE [ESBookshop] SET  READ_WRITE 
GO
