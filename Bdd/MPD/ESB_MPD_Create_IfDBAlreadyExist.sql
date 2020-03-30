/*

-- CODE SI BDD ESBookshop EXISTE DEJA

 ----------------------------------------------------------------------------
             Génération d'une base de données pour
                        SQL Server 2005
                       (26/3/2020 16:58:21)
 ----------------------------------------------------------------------------
     Nom de la base : ESBookshop
     Projet : Accueil WinDesign V17
     Auteur : Halide Baytar
     Date de dernière modification : 26/3/2020 16:57:41
 ----------------------------------------------------------------------------
*/

-----------------------------------------------------------------------------
-- MANAGE DATABASE
-----------------------------------------------------------------------------

-- USE (OPEN) DATABASE
USE ESBookshop
GO


-----------------------------------------------------------------------------
-- DROP CONSTRAINTS 
-----------------------------------------------------------------------------

--_________________________________________________________
-- ALTER TABLE APPRECIATIONS
--_________________________________________________________

-- FK_APPRECIATIONS_LINEITEMS
ALTER TABLE APPRECIATIONS   
DROP CONSTRAINT FK_APPRECIATIONS_LINEITEMS;   
GO 


-- FK_APPRECIATIONS_ORDERS
ALTER TABLE APPRECIATIONS   
DROP CONSTRAINT FK_APPRECIATIONS_ORDERS;   
GO 


-- FK_APPRECIATIONS_PAYMENTS
ALTER TABLE APPRECIATIONS   
DROP CONSTRAINT FK_APPRECIATIONS_PAYMENTS;   
GO 

--_________________________________________________________
-- ALTER TABLE LINEITEMS
--_________________________________________________________

-- FK_LINEITEMS_SHOPPINGCARTS
ALTER TABLE LINEITEMS   
DROP CONSTRAINT FK_LINEITEMS_SHOPPINGCARTS;   
GO 


-- FK_LINEITEMS_BOOKS
ALTER TABLE LINEITEMS   
DROP CONSTRAINT FK_LINEITEMS_BOOKS;   
GO 


--_________________________________________________________
-- ALTER TABLE PAYMENTS
--_________________________________________________________

-- FK_PAYMENTS_ACCOUNTS
ALTER TABLE PAYMENTS   
DROP CONSTRAINT FK_PAYMENTS_ACCOUNTS;   
GO 


--_________________________________________________________
-- ALTER TABLE ORDERS
--_________________________________________________________

-- FK_ORDERS_ACCOUNTS
ALTER TABLE dbo.ORDERS   
DROP CONSTRAINT FK_ORDERS_ACCOUNTS;   
GO 

--_________________________________________________________
-- ALTER TABLE ACCOUNTS
--_________________________________________________________

-- FK_ACCOUNTS_CUSTOMERS
ALTER TABLE dbo.ACCOUNTS   
DROP CONSTRAINT FK_ACCOUNTS_CUSTOMERS;   
GO 

--_________________________________________________________

-- ALTER TABLE SHOPPINGCARTS
--_________________________________________________________

-- FK_SHOPPINGCARTS_ACCOUNTS
ALTER TABLE dbo.SHOPPINGCARTS   
DROP CONSTRAINT FK_SHOPPINGCARTS_ACCOUNTS;   
GO 


--_________________________________________________________
-- ALTER TABLE STOCKS
--_________________________________________________________
-- FK_STOCKS_BOOKS
ALTER TABLE dbo.STOCKS   
DROP CONSTRAINT FK_STOCKS_BOOKS;   
GO 

--_________________________________________________________
-- ALTER TABLE BOOKS
--_________________________________________________________

-- FK_BOOKS_EDITIONS
ALTER TABLE dbo.BOOKS   
DROP CONSTRAINT FK_BOOKS_EDITEURS;   
GO 


--_________________________________________________________
-- ALTER TABLE COWRITERS
--_________________________________________________________

-- FK_COWRITERS_AUTHORS
ALTER TABLE dbo.COWRITERS   
DROP CONSTRAINT FK_COWRITERS_AUTHORS;   
GO 

-- FK_COWRITERS_BOOKS
ALTER TABLE dbo.COWRITERS   
DROP CONSTRAINT FK_COWRITERS_BOOKS;   
GO 

--_________________________________________________________
-- ALTER TABLE RANKS
--_________________________________________________________

-- FK_RANK_BOOKS
ALTER TABLE dbo.RANKS   
DROP CONSTRAINT FK_RANK_BOOKS;   
GO 

-- FK_RANK_CATEGORIES
ALTER TABLE dbo.RANKS   
DROP CONSTRAINT FK_RANK_CATEGORIES;   
GO 

-- FK_RANK_GENRES
ALTER TABLE dbo.RANKS   
DROP CONSTRAINT FK_RANK_GENRES;   
GO 

-- FK_RANK_FORMATS
ALTER TABLE dbo.RANKS   
DROP CONSTRAINT FK_RANK_FORMATS;   
GO 

-- FK_RANK_LANGUAGES
ALTER TABLE dbo.RANKS   
DROP CONSTRAINT FK_RANK_LANGUAGES;   
GO 

-----------------------------------------------------------------------------
-- DROP TABLES
-----------------------------------------------------------------------------

-- TABLE APPRECIATIONS
DROP TABLE [dbo].[APPRECIATIONS]
GO

-- TABLE CUSTOMERS
DROP TABLE [dbo].[CUSTOMERS]
GO

-- TABLE FORMATS
DROP TABLE [dbo].[FORMATS]
GO

-- TABLE LINEITEMS
DROP TABLE [dbo].[LINEITEMS]
GO

-- TABLE PAYMENTS
DROP TABLE [dbo].[PAYMENTS]
GO

-- TABLE ORDERS
DROP TABLE [dbo].[ORDERS]
GO

-- TABLE ACCOUNTS
DROP TABLE [dbo].[ACCOUNTS]
GO

-- TABLE LANGUAGES
DROP TABLE [dbo].[LANGUAGES]
GO

-- TABLE SHOPPINGCARTS
DROP TABLE [dbo].[SHOPPINGCARTS]
GO

-- TABLE CATEGORIES
DROP TABLE [dbo].[CATEGORIES]
GO

-- TABLE STOCKS
DROP TABLE [dbo].[STOCKS]
GO

-- TABLE GENRES
DROP TABLE [dbo].[GENRES]
GO

-- TABLE AUTHORS
DROP TABLE [dbo].[AUTHORS]
GO

-- EDITIONS
DROP TABLE [dbo].[EDITEURS]
GO

-- BOOKS
DROP TABLE [dbo].[BOOKS]
GO

-- TABLE COWRITERS
DROP TABLE [dbo].[COWRITERS]
GO

-- TABLE RANKS
DROP TABLE [dbo].[RANKS]
GO


/* -----------------------------------------------------------------------------
      TABLE : APPRECIATIONS
----------------------------------------------------------------------------- */

create table APPRECIATIONS
  (
     ID int IDENTITY(1,1),
     ID_LINEITEM int  not null  ,
     ID_ORDER int  not null  ,
     ID_PAYMENT int  not null  ,
     EVALUATION varchar(20)  not null  
     ,
     constraint PK_APPRECIATIONS primary key (ID)
  ) 
go



/*      INDEX DE APPRECIATIONS      */



/* -----------------------------------------------------------------------------
      TABLE : CUSTOMERS
----------------------------------------------------------------------------- */

/*

DROP TABLE [dbo].[CUSTOMERS]
GO

*/ 

create table CUSTOMERS
  (
     ID int IDENTITY(1,1),
     ACRONYME varchar(4)  not null  ,
     FIRSTNAME varchar(50)  not null  ,
     LASTNAME varchar(100)  not null  ,
     ADDRESS varchar(255)  not null  ,
	 ZIP varchar(4)  not null  ,
	 CITY varchar(100)  not null  ,	 
     PHONE varchar(13)  null  ,
     EMAIL char(255)  not null  ,
     constraint PK_CUSTOMERS primary key (ID) ,
  ) 
go



-- UPDATE Customers SET email = CONCAT(CONCAT(firstname, '.'), CONCAT(lastname, '@email.com'));
-- UPDATE Customers SET ACRONYME = CONCAT(SUBSTRING( UPPER(FIRSTNAME), 1 , 2), SUBSTRING ( UPPER(LASTNAME), 1 , 2)); 


/* -----------------------------------------------------------------------------
      TABLE : FORMATS
----------------------------------------------------------------------------- */

create table FORMATS
  (
     ID int IDENTITY(1,1),
     DESCRIPTION varchar(50)  null  
     ,
     constraint PK_FORMATS primary key (ID)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : LINEITEMS
----------------------------------------------------------------------------- */

create table LINEITEMS
  (
     ID int IDENTITY(1,1),
     ID_SHOPPINGCART int  not null  ,
     ID_BOOK int  not null  ,
     QUANTITY int  not null  ,
     UNITPRICE money  not null  ,
     ID_ORDER int  not null  
     ,
     constraint PK_LINEITEMS primary key (ID)
  ) 
go



/*      INDEX DE LINEITEMS      */



/* -----------------------------------------------------------------------------
      TABLE : PAYMENTS
----------------------------------------------------------------------------- */

create table PAYMENTS
  (
     ID int IDENTITY(1,1),
     PAIDDATE datetime  not null  ,
     PRICETOTAL money  not null  ,
     DETAILS char(255)  not null  ,
     ID_ACCOUNT int  not null  
     ,
     constraint PK_PAYMENTS primary key (ID)
  ) 
go



/*      INDEX DE PAYMENTS      */


/* -----------------------------------------------------------------------------
      TABLE : ORDERS
----------------------------------------------------------------------------- */

create table ORDERS
  (
     ID int IDENTITY(1,1),
     ORDEREDDATE datetime  not null  ,
     SHIPPEDDATE datetime  not null  ,
     SHIPPINGADDRESS char(255)  not null  ,
     STATUS varchar(25)  not null  ,
     TOTALPRICE money  not null  ,
     ID_ACCOUNT int  not null  
     ,
     constraint PK_ORDERS primary key (ID)
  ) 
go

/*      INDEX DE ORDERS      */


/* -----------------------------------------------------------------------------
      TABLE : ACCOUNTS
----------------------------------------------------------------------------- */

create table ACCOUNTS
  (
     ID int IDENTITY(1,1),
     ID_CUTOMER int  not null  ,
     PASSWORD varchar(15)  not null  ,
     LOGINNAME varchar(100)  not null  ,
     USERSTATE varchar(25)  not null  ,
     REGISTRATIONDATE datetime  not null  ,
     ISCLOSED bit  not null  ,
     BILLINGADDRESS char(255)  not null  ,
     TYPE varchar(20)  not null  
     ,
     constraint PK_ACCOUNTS primary key (ID)
  ) 
go

/*      INDEX DE ACCOUNTS      */


/* -----------------------------------------------------------------------------
      TABLE : LANGUAGES
----------------------------------------------------------------------------- */

create table LANGUAGES
  (
     ID int IDENTITY(1,1),
     DESCRIPTION varchar(20)  not null  ,
     CODE nchar(3)  not null  
     ,
     constraint PK_LANGUAGES primary key (ID)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : SHOPPINGCARTS
----------------------------------------------------------------------------- */

create table SHOPPINGCARTS
  (
     ID int IDENTITY(1,1),
     CREATEDDATE datetime  not null  ,
     ID_ACCOUNT int  not null  
     ,
     constraint PK_SHOPPINGCARTS primary key (ID)
  ) 
go


/* -----------------------------------------------------------------------------
      TABLE : CATEGORIES
----------------------------------------------------------------------------- */

create table CATEGORIES
  (
     ID int IDENTITY(1,1),
     DESCRIPTION char(100)  not null  
     ,
     constraint PK_CATEGORIES primary key (ID)
  ) 
go



/* -----------------------------------------------------------------------------
      TABLE : STOCKS
----------------------------------------------------------------------------- */

create table STOCKS
  (
     ID int IDENTITY(1,1),
     ID_BOOK int  not null  ,
     INITIALSTOCK smallint  not null 
      DEFAULT 0 ,
     CURRENTSTOCK smallint  not null  ,
     DELIVERYDATE datetime  not null  
     ,
     constraint PK_STOCKS primary key (ID)
  ) 
go



/*      INDEX DE STOCKS      */



/* -----------------------------------------------------------------------------
      TABLE : GENRES
----------------------------------------------------------------------------- */

create table GENRES
  (
     ID int IDENTITY(1,1),
     DESCRIPTION varchar(100)  not null  
     ,
     constraint PK_GENRES primary key (ID)
  ) 
go


/* -----------------------------------------------------------------------------
      TABLE : AUTHORS
----------------------------------------------------------------------------- */

create table AUTHORS
  (
     ID int IDENTITY(1,1),
     LASTNAME varchar(100)  not null  ,
     FIRSTNAME varchar(100)  not null  
     ,
     constraint PK_AUTHORS primary key (ID)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : EDITEURS
----------------------------------------------------------------------------- */

create table EDITEURS
  (
     ID int IDENTITY(1,1),
     NAME varchar(128)  not null  ,
     URL varchar(128)  null  ,
     EMAIL varchar(255)  not null  ,
     COUNTRYCODE varchar(3)  not null  
     ,
     constraint PK_EDITEURS primary key (ID)
  ) 
go

/* -----------------------------------------------------------------------------
      TABLE : BOOKS
----------------------------------------------------------------------------- */

--  ISBN varchar(13) not  null  
create table BOOKS
  (
     ID int IDENTITY(1,1),
     ID_EDITEUR int  not null  ,
     TITLE varchar(255)  not null  ,
     SUBTITLE varchar(128)  null  ,
     PRICE money  not null  ,
     DATEPUBLICATION datetime not null  ,
     SUMMARY varchar(255) not null  ,
     ISBN varchar(13) not null  -- ISBN AS CONVERT(BIGINT,RAND()*10000000000000) 
     ,
     constraint PK_BOOKS primary key (ID)
  ) 
go



/*      INDEX DE BOOKS      */



/* -----------------------------------------------------------------------------
      TABLE : COWRITERS
----------------------------------------------------------------------------- */

create table COWRITERS
  (
     ID_AUTHOR int  not null  ,
     ID_BOOK int  not null  
     ,
     constraint PK_COWRITERS primary key (ID_AUTHOR, ID_BOOK)
  ) 
go



/*      INDEX DE COWRITERS      */



/* -----------------------------------------------------------------------------
      TABLE : RANKS
----------------------------------------------------------------------------- */

create table RANKS
  (
     ID_BOOK int  not null  ,
     ID_CATEGORIE int  not null  ,
     ID_GENRE int  not null  ,
     ID_FORMAT int  not null  ,
     ID_LANGUAGE int  not null  
     ,
     constraint PK_RANK primary key (ID_BOOK, ID_CATEGORIE, ID_GENRE, ID_FORMAT, ID_LANGUAGE)
  ) 
go



/*      INDEX DE RANKS      */




/* -----------------------------------------------------------------------------
							-- REFERENCES SUR LES TABLES
----------------------------------------------------------------------------- */

--_________________________________________________________
-- ALTER TABLE APPRECIATIONS
--_________________________________________________________

-- FK_APPRECIATIONS_LINEITEMS
alter table APPRECIATIONS 
     add constraint FK_APPRECIATIONS_LINEITEMS foreign key (ID_LINEITEM) 
               references LINEITEMS (ID)
go

-- FK_APPRECIATIONS_ORDERS
alter table APPRECIATIONS 
     add constraint FK_APPRECIATIONS_ORDERS foreign key (ID_ORDER) 
               references ORDERS (ID)
go

-- FK_APPRECIATIONS_PAYMENTS
alter table APPRECIATIONS 
     add constraint FK_APPRECIATIONS_PAYMENTS foreign key (ID_PAYMENT) 
               references PAYMENTS (ID)
go

--_________________________________________________________
-- ALTER TABLE LINEITEMS
--_________________________________________________________

-- FK_LINEITEMS_SHOPPINGCARTS
alter table LINEITEMS 
     add constraint FK_LINEITEMS_SHOPPINGCARTS foreign key (ID_SHOPPINGCART) 
               references SHOPPINGCARTS (ID)
go

-- FK_LINEITEMS_BOOKS
alter table LINEITEMS 
     add constraint FK_LINEITEMS_BOOKS foreign key (ID_BOOK) 
               references BOOKS (ID)
go


--_________________________________________________________

-- ALTER TABLE PAYMENTS
--_________________________________________________________

-- FK_PAYMENTS_ACCOUNTS
alter table PAYMENTS 
     add constraint FK_PAYMENTS_ACCOUNTS foreign key (ID_ACCOUNT) 
               references ACCOUNTS (ID)
go


--_________________________________________________________

-- ALTER TABLE ORDERS
--_________________________________________________________

-- FK_ORDERS_ACCOUNTS
alter table ORDERS 
     add constraint FK_ORDERS_ACCOUNTS foreign key (ID_ACCOUNT) 
               references ACCOUNTS (ID)
go

--_________________________________________________________

-- ALTER TABLE ACCOUNTS
--_________________________________________________________

-- FK_ACCOUNTS_CUSTOMERS
alter table ACCOUNTS 
     add constraint FK_ACCOUNTS_CUSTOMERS foreign key (ID_CUTOMER) 
               references CUSTOMERS (ID)
go


--_________________________________________________________

-- ALTER TABLE SHOPPINGCARTS
--_________________________________________________________

-- FK_SHOPPINGCARTS_ACCOUNTS
alter table SHOPPINGCARTS 
     add constraint FK_SHOPPINGCARTS_ACCOUNTS foreign key (ID_ACCOUNT) 
               references ACCOUNTS (ID)
go


--_________________________________________________________

-- ALTER TABLE STOCKS
--_________________________________________________________

-- FK_STOCKS_BOOKS
alter table STOCKS
     add constraint FK_STOCKS_BOOKS foreign key (ID_BOOK) 
               references BOOKS (ID)
go

--_________________________________________________________

-- ALTER TABLE BOOKS
--_________________________________________________________

-- FK_BOOKS_EDITEURS
alter table BOOKS 
     add constraint FK_BOOKS_EDITEURS foreign key (ID_EDITEUR) 
               references EDITEURS(ID)
go


--_________________________________________________________

-- ALTER TABLE COWRITERS
--_________________________________________________________


-- FK_COWRITERS_AUTHORS
alter table COWRITERS 
     add constraint FK_COWRITERS_AUTHORS foreign key (ID_AUTHOR) 
               references AUTHORS (ID)
go

-- FK_COWRITERS_BOOKS
alter table COWRITERS 
     add constraint FK_COWRITERS_BOOKS foreign key (ID_BOOK) 
               references BOOKS (ID)
go

--_________________________________________________________
-- ALTER TABLE RANKS
--_________________________________________________________

-- FK_RANK_BOOKS
alter table RANKS
     add constraint FK_RANK_BOOKS foreign key (ID_BOOK) 
               references BOOKS (ID)
go

-- FK_RANK_CATEGORIES
alter table RANKS 
     add constraint FK_RANK_CATEGORIES foreign key (ID_CATEGORIE) 
               references CATEGORIES (ID)
go

-- FK_RANK_GENRES
alter table RANKS 
     add constraint FK_RANK_GENRES foreign key (ID_GENRE) 
               references GENRES (ID)
go

-- FK_RANK_FORMATS
alter table RANKS 
     add constraint FK_RANK_FORMATS foreign key (ID_FORMAT) 
               references FORMATS (ID)
go

-- FK_RANK_LANGUAGES
alter table RANKS 
     add constraint FK_RANK_LANGUAGES foreign key (ID_LANGUAGE) 
               references LANGUAGES (ID)
go




/*
 -----------------------------------------------------------------------------
               FIN DE GENERATION
 -----------------------------------------------------------------------------
*/