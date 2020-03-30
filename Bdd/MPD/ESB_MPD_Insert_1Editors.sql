
-- USE (OPEN) DATABASE
USE [ESBookshop]
GO

-- UPDATE [dbo].[BOOKS] SET ID_EDITEUR = ABS(CHECKSUM(NewId())) % 11

-----------------------------------------------------------------------------
-- INSERT INTO TABLE EDITEURS 
-----------------------------------------------------------------------------

INSERT [dbo].[EDITEURS] ([NAME], [URL], [EMAIL], [COUNTRYCODE]) VALUES (N'Hachette', N'https://www.hachette.fr/', N'info@hachette.ch', N'FR')
INSERT [dbo].[EDITEURS] ([NAME], [URL], [EMAIL], [COUNTRYCODE]) VALUES (N'Centre suisse de services Formation CSFO', N'https://shop.sdbb.ch/', N' distribution@csfo.ch', N'CH')
INSERT [dbo].[EDITEURS] ([NAME], [URL], [EMAIL], [COUNTRYCODE]) VALUES (N'Editions ENI', N'https://www.editions-eni.fr/', N'info@eni.fr', N'FR')
INSERT [dbo].[EDITEURS] ([NAME], [URL], [EMAIL], [COUNTRYCODE]) VALUES (N'Accès Editions', N'http://www.acces-editions.com/', N'info@acces-editions.com', N'FR')
INSERT [dbo].[EDITEURS] ([NAME], [URL], [EMAIL], [COUNTRYCODE]) VALUES (N'Oxford University Press (OUP)', N'https://global.oup.com/', N'info@oup.com', N'UK')
INSERT [dbo].[EDITEURS] ([NAME], [URL], [EMAIL], [COUNTRYCODE]) VALUES (N'University of California Press (UC Press)', N'https://www.ucpress.edu/', N'info@uc-press.edu', N'USA')
INSERT [dbo].[EDITEURS] ([NAME], [URL], [EMAIL], [COUNTRYCODE]) VALUES (N'Der Audio Verlag (DAV)', N'https://www.der-audio-verlag.de/', N'info@dav.de', N'DE')
INSERT [dbo].[EDITEURS] ([NAME], [URL], [EMAIL], [COUNTRYCODE]) VALUES (N'BPX Edition', N'http://ww25.dallavecchia.com/', N'info@bpx-edition.de', N'DE')
INSERT [dbo].[EDITEURS] ([NAME], [URL], [EMAIL], [COUNTRYCODE]) VALUES (N'Editions Zoé', N'http://www.editionszoe.ch', N'info@editionszoe.ch', N'CH')
INSERT [dbo].[EDITEURS] ([NAME], [URL], [EMAIL], [COUNTRYCODE]) VALUES (N'Editions Médecine et Hygiène', N'https://www.medhyg.ch/', N'info@medhyg.ch', N'CH')
