
-- USE (OPEN) DATABASE
USE [ESBookshop]
GO

-----------------------------------------------------------------------------
-- INSERT INTO TABLE GENRES 
-----------------------------------------------------------------------------


INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Antique')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Contemporaine')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Gothique')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Moderne')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Asie')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Europe')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Afrique')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Comédie')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Thriller')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Action')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Fantasy')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'fantastique')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Biographie')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Polar')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Roman')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Informatique')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Gestion d''entreprise')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Algèbre')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Trigonométrie')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Programmation Orientée objet (POO)')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Informatique en nuage (Cloud)')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Bases de données relationnelles')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Big data')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Anglais')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Allemand')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Statistiques')
INSERT [dbo].[GENRES] ([DESCRIPTION]) VALUES (N'Italien')


-----------------------------------------------------------------------------
-- INSERT INTO TABLE LANGUAGES 
-----------------------------------------------------------------------------

INSERT [dbo].[LANGUAGES] ([DESCRIPTION], [CODE]) VALUES (N'Français', N'FRA')
INSERT [dbo].[LANGUAGES] ([DESCRIPTION], [CODE]) VALUES (N'Anglais', N'ANG')
INSERT [dbo].[LANGUAGES] ([DESCRIPTION], [CODE]) VALUES (N'Allemand', N'ALL')
INSERT [dbo].[LANGUAGES] ([DESCRIPTION], [CODE]) VALUES (N'Espagnol', N'ESP')
INSERT [dbo].[LANGUAGES] ([DESCRIPTION], [CODE]) VALUES (N'Italien', N'ITA')

-----------------------------------------------------------------------------
-- INSERT INTO TABLE CATEGORIES 
-----------------------------------------------------------------------------

INSERT [dbo].[CATEGORIES] ([DESCRIPTION]) VALUES (N'Art')
INSERT [dbo].[CATEGORIES] ([DESCRIPTION]) VALUES (N'Bande dessinée')
INSERT [dbo].[CATEGORIES] ([DESCRIPTION]) VALUES (N'Cuisine')
INSERT [dbo].[CATEGORIES] ([DESCRIPTION]) VALUES (N'Roman')
INSERT [dbo].[CATEGORIES] ([DESCRIPTION]) VALUES (N'Sciences')
INSERT [dbo].[CATEGORIES] ([DESCRIPTION]) VALUES (N'Sciences Humaines')
INSERT [dbo].[CATEGORIES] ([DESCRIPTION]) VALUES (N'Littérature')
INSERT [dbo].[CATEGORIES] ([DESCRIPTION]) VALUES (N'Gestion ')
INSERT [dbo].[CATEGORIES] ([DESCRIPTION]) VALUES (N'High-tech')
INSERT [dbo].[CATEGORIES] ([DESCRIPTION]) VALUES (N'Sport')
INSERT [dbo].[CATEGORIES] ([DESCRIPTION]) VALUES (N'Langues')

-----------------------------------------------------------------------------
-- INSERT INTO TABLE FORMATS 
-----------------------------------------------------------------------------

INSERT [dbo].[FORMATS] ([DESCRIPTION]) VALUES (N'Papier')
INSERT [dbo].[FORMATS] ([DESCRIPTION]) VALUES (N'Ebook')
INSERT [dbo].[FORMATS] ([DESCRIPTION]) VALUES (N'Audiobook')
INSERT [dbo].[FORMATS] ([DESCRIPTION]) VALUES (N'PDF')
INSERT [dbo].[FORMATS] ([DESCRIPTION]) VALUES (N'TXT')





