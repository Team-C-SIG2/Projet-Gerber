USE [ESBookshop]
GO

/* 
-- GENERATION INITIALE DES DONNEES 

INSERT INTO [dbo].[SHOPPINGCARTS]([ID],[CREATEDDATE],[ID_ACCOUNT])
VALUES(17, DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 1095) * -1, getdate())  , ABS(CHECKSUM(NewId())) % 25 )
GO

 */ 


-- INSERT INTO TABLE SHOPPINGCARTS

INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2018-02-21T22:07:49.000' AS DateTime), 1)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2017-05-22T22:07:49.000' AS DateTime), 11)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2019-02-05T22:07:49.000' AS DateTime), 19)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2019-06-15T22:07:49.000' AS DateTime), 9)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2018-04-30T22:07:49.000' AS DateTime), 19)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2018-08-25T22:07:49.000' AS DateTime), 14)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2017-07-17T22:07:49.000' AS DateTime), 16)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2019-10-06T22:07:49.000' AS DateTime), 9)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2018-07-20T22:07:49.000' AS DateTime), 15)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2018-07-01T22:07:49.000' AS DateTime), 13)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2018-06-18T22:07:49.000' AS DateTime), 23)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2018-07-29T22:07:49.000' AS DateTime), 7)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2018-09-03T22:07:49.000' AS DateTime), 13)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2018-05-26T22:07:49.000' AS DateTime), 1)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2018-08-18T22:07:49.000' AS DateTime), 19)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2019-08-21T22:07:49.000' AS DateTime), 16)
INSERT [dbo].[SHOPPINGCARTS] ([CREATEDDATE], [ID_ACCOUNT]) VALUES (CAST(N'2017-10-04T22:08:34.000' AS DateTime), 23)