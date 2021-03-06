/****** Cannot script Unresolved Entities : Server[@Name='bditake']/Database[@Name='baza']/UnresolvedEntity[@Name='dtproperties' and @Schema='dbo'] ******/
GO
USE [baza]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_diagramobjects]    Script Date: 18.06.2017 14:36:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE FUNCTION [dbo].[fn_diagramobjects]() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	
GO
/****** Object:  Table [dbo].[Cennik]    Script Date: 18.06.2017 14:36:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cennik](
	[id_cennika] [int] IDENTITY(0,1) NOT NULL,
	[cena] [decimal](10, 2) NULL,
	[okres_od] [date] NULL,
	[okres_do] [date] NULL,
 CONSTRAINT [Cennik_PK] PRIMARY KEY CLUSTERED 
(
	[id_cennika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Katalog]    Script Date: 18.06.2017 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Katalog](
	[id_katalogu] [int] IDENTITY(0,1) NOT NULL,
	[okres_trwania_wycieczki] [int] NULL,
	[id_cennika] [int] NULL,
	[id_miejsca_odjazdu] [int] NULL,
	[id_miejsca_przyjazdu] [int] NULL,
	[id_wycieczki] [int] NULL,
	[cena] [decimal](10, 2) NULL,
 CONSTRAINT [Katalog_PK] PRIMARY KEY CLUSTERED 
(
	[id_katalogu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Kierowca]    Script Date: 18.06.2017 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kierowca](
	[pesel] [varchar](11) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[imie] [varchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[nazwisko] [varchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ulica] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[miejscowosc] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [Kierowca_PK] PRIMARY KEY CLUSTERED 
(
	[pesel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Kierownik]    Script Date: 18.06.2017 14:36:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kierownik](
	[pesel] [varchar](11) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[imie] [varchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[nazwisko] [varchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ulica] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[miejscowosc] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [Kierownik_PK] PRIMARY KEY CLUSTERED 
(
	[pesel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Klient]    Script Date: 18.06.2017 14:36:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klient](
	[pesel] [varchar](11) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[imie] [varchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[nazwisko] [varchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ulica] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[miejscowosc] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [Klient_PK] PRIMARY KEY CLUSTERED 
(
	[pesel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Miejsce]    Script Date: 18.06.2017 14:36:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Miejsce](
	[id_miejsca] [int] IDENTITY(0,1) NOT NULL,
	[adres] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[miejscowosc] [varchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [Miejsce_PK] PRIMARY KEY CLUSTERED 
(
	[id_miejsca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Opinia]    Script Date: 18.06.2017 14:36:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Opinia](
	[id_opini] [int] IDENTITY(0,1) NOT NULL,
	[ocena] [int] NULL,
	[opis] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[id_uczestnictwo] [int] NULL,
 CONSTRAINT [Opinia_PK] PRIMARY KEY CLUSTERED 
(
	[id_opini] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Panel_pracowniczy]    Script Date: 18.06.2017 14:36:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Panel_pracowniczy](
	[id_panel] [int] IDENTITY(0,1) NOT NULL,
	[login] [varchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[haslo] [varchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[stopien] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Kierownik_pesel] [varchar](11) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Pilot_pesel] [varchar](11) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Kierowca_pesel] [varchar](11) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Klient_pesel] [varchar](11) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [Panel_pracowniczy_PK] PRIMARY KEY CLUSTERED 
(
	[id_panel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Pilot]    Script Date: 18.06.2017 14:36:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pilot](
	[pesel] [varchar](11) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[imie] [varchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[nazwisko] [varchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ulica] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[miejscowosc] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [Pilot_PK] PRIMARY KEY CLUSTERED 
(
	[pesel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Pojazd]    Script Date: 18.06.2017 14:36:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pojazd](
	[numer_rejestracyjny] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[dostepny] [bit] NULL,
	[marka] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pojemnosc] [int] NULL,
	[stan] [bit] NULL,
 CONSTRAINT [Pojazd_PK] PRIMARY KEY CLUSTERED 
(
	[numer_rejestracyjny] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Promocja]    Script Date: 18.06.2017 14:36:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocja](
	[cena] [decimal](10, 2) NULL,
	[id_wycieczki] [int] NOT NULL,
 CONSTRAINT [PK_Promocja] PRIMARY KEY CLUSTERED 
(
	[id_wycieczki] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Reklamacja]    Script Date: 18.06.2017 14:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reklamacja](
	[numer_reklamacji] [int] IDENTITY(0,1) NOT NULL,
	[opis] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[stan] [bit] NULL,
	[Kierownik_pesel] [varchar](11) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[id_uczestnictwo] [int] NULL,
 CONSTRAINT [Reklamacja_PK] PRIMARY KEY CLUSTERED 
(
	[numer_reklamacji] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Rezerwacja]    Script Date: 18.06.2017 14:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rezerwacja](
	[numer_rezerwacji] [int] IDENTITY(0,1) NOT NULL,
	[liczba_osob] [int] NULL,
	[stan] [bit] NULL,
	[zaliczka] [decimal](10, 2) NULL,
	[id_wycieczki] [int] NULL,
	[Klient_pesel] [varchar](11) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [Rezerwacja_PK] PRIMARY KEY CLUSTERED 
(
	[numer_rezerwacji] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 18.06.2017 14:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
 CONSTRAINT [PK__sysdiagr__C2B05B6155E3BFC4] PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Uczestnictwo]    Script Date: 18.06.2017 14:36:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uczestnictwo](
	[id_uczestnictwo] [int] IDENTITY(0,1) NOT NULL,
	[liczba_osob] [int] NULL,
	[numer_rezerwacji] [int] NULL,
	[cena_rezerwacji] [decimal](10, 2) NULL,
 CONSTRAINT [Uczestnictwo_PK] PRIMARY KEY CLUSTERED 
(
	[id_uczestnictwo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
/****** Object:  Table [dbo].[Wycieczka]    Script Date: 18.06.2017 14:36:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wycieczka](
	[id_wycieczki] [int] IDENTITY(0,1) NOT NULL,
	[nazwa] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[data_wyjazdu] [datetime] NULL,
	[data_powrotu] [datetime] NULL,
	[opis] [text] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Pilot_pesel] [varchar](11) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Pojazd_numer_rejestracyjny] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Kierowca_pesel] [varchar](11) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [Wycieczka_PK] PRIMARY KEY CLUSTERED 
(
	[id_wycieczki] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO
SET IDENTITY_INSERT [dbo].[Cennik] ON 

INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (0, CAST(13222.00 AS Decimal(10, 2)), CAST(N'2017-01-08' AS Date), CAST(N'2017-01-18' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (1, CAST(24999.98 AS Decimal(10, 2)), CAST(N'2016-02-19' AS Date), CAST(N'2016-03-06' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (2, CAST(7360.25 AS Decimal(10, 2)), CAST(N'2016-05-29' AS Date), CAST(N'2016-05-30' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (3, CAST(23786.00 AS Decimal(10, 2)), CAST(N'2016-04-27' AS Date), CAST(N'2016-05-03' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (4, CAST(22728.60 AS Decimal(10, 2)), CAST(N'2016-01-02' AS Date), CAST(N'2016-01-12' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (5, CAST(20417.57 AS Decimal(10, 2)), CAST(N'2016-12-14' AS Date), CAST(N'2016-12-15' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (6, CAST(21012.82 AS Decimal(10, 2)), CAST(N'2016-01-03' AS Date), CAST(N'2016-01-09' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (7, CAST(9030.07 AS Decimal(10, 2)), CAST(N'2016-02-15' AS Date), CAST(N'2016-02-19' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (8, CAST(24999.99 AS Decimal(10, 2)), CAST(N'2016-03-26' AS Date), CAST(N'2016-03-27' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (9, CAST(20461.00 AS Decimal(10, 2)), CAST(N'2017-05-26' AS Date), CAST(N'2017-05-30' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (10, CAST(2500.02 AS Decimal(10, 2)), CAST(N'2016-10-20' AS Date), CAST(N'2016-10-24' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (11, CAST(3399.36 AS Decimal(10, 2)), CAST(N'2016-01-01' AS Date), CAST(N'2016-01-07' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (12, CAST(3699.28 AS Decimal(10, 2)), CAST(N'2017-05-27' AS Date), CAST(N'2017-06-01' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (13, CAST(12371.66 AS Decimal(10, 2)), CAST(N'2016-12-30' AS Date), CAST(N'2017-01-09' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (14, CAST(3555.47 AS Decimal(10, 2)), CAST(N'2016-12-08' AS Date), CAST(N'2016-12-12' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (15, CAST(14366.00 AS Decimal(10, 2)), CAST(N'2016-08-21' AS Date), CAST(N'2016-08-30' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (16, CAST(7395.58 AS Decimal(10, 2)), CAST(N'2016-03-04' AS Date), CAST(N'2016-03-14' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (17, CAST(19188.00 AS Decimal(10, 2)), CAST(N'2016-01-01' AS Date), CAST(N'2016-01-11' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (18, CAST(19412.08 AS Decimal(10, 2)), CAST(N'2016-06-27' AS Date), CAST(N'2016-07-07' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (19, CAST(2780.26 AS Decimal(10, 2)), CAST(N'2016-12-13' AS Date), CAST(N'2017-01-04' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (20, CAST(13665.00 AS Decimal(10, 2)), CAST(N'2016-07-23' AS Date), CAST(N'2016-08-02' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (21, CAST(2500.01 AS Decimal(10, 2)), CAST(N'2016-02-09' AS Date), CAST(N'2016-02-10' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (22, CAST(4369.69 AS Decimal(10, 2)), CAST(N'2016-03-10' AS Date), CAST(N'2016-04-05' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (23, CAST(4250.13 AS Decimal(10, 2)), CAST(N'2016-10-26' AS Date), CAST(N'2016-11-05' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (24, CAST(13441.00 AS Decimal(10, 2)), CAST(N'2016-01-14' AS Date), CAST(N'2016-02-10' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (25, CAST(5000.00 AS Decimal(10, 2)), CAST(N'2016-10-04' AS Date), CAST(N'2016-10-14' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (26, CAST(10262.29 AS Decimal(10, 2)), CAST(N'2016-02-18' AS Date), CAST(N'2016-02-28' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (27, CAST(12387.00 AS Decimal(10, 2)), CAST(N'2017-02-02' AS Date), CAST(N'2017-02-08' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (28, CAST(13072.51 AS Decimal(10, 2)), CAST(N'2016-01-01' AS Date), CAST(N'2016-01-11' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (29, CAST(21298.17 AS Decimal(10, 2)), CAST(N'2016-11-22' AS Date), CAST(N'2016-12-02' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (30, CAST(16811.08 AS Decimal(10, 2)), CAST(N'2016-11-09' AS Date), CAST(N'2016-11-19' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (31, CAST(18977.75 AS Decimal(10, 2)), CAST(N'2016-01-25' AS Date), CAST(N'2016-01-26' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (32, CAST(17820.00 AS Decimal(10, 2)), CAST(N'2017-01-01' AS Date), CAST(N'2017-01-08' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (33, CAST(25000.00 AS Decimal(10, 2)), CAST(N'2017-02-24' AS Date), CAST(N'2017-03-06' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (34, CAST(2794.06 AS Decimal(10, 2)), CAST(N'2016-01-21' AS Date), CAST(N'2016-01-31' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (35, CAST(7660.00 AS Decimal(10, 2)), CAST(N'2017-01-04' AS Date), CAST(N'2017-01-14' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (36, CAST(4606.59 AS Decimal(10, 2)), CAST(N'2017-02-14' AS Date), CAST(N'2017-02-24' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (37, CAST(2500.00 AS Decimal(10, 2)), CAST(N'2017-03-15' AS Date), CAST(N'2017-03-25' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (38, CAST(23589.52 AS Decimal(10, 2)), CAST(N'2016-05-21' AS Date), CAST(N'2016-05-22' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (39, CAST(23842.00 AS Decimal(10, 2)), CAST(N'2016-01-07' AS Date), CAST(N'2016-01-11' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (40, CAST(22217.50 AS Decimal(10, 2)), CAST(N'2016-01-05' AS Date), CAST(N'2016-01-15' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (41, CAST(20685.00 AS Decimal(10, 2)), CAST(N'2016-08-04' AS Date), CAST(N'2016-08-05' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (42, CAST(13162.52 AS Decimal(10, 2)), CAST(N'2016-03-11' AS Date), CAST(N'2016-03-21' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (43, CAST(5866.00 AS Decimal(10, 2)), CAST(N'2016-01-01' AS Date), CAST(N'2016-01-11' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (44, CAST(17524.60 AS Decimal(10, 2)), CAST(N'2017-04-30' AS Date), CAST(N'2017-05-01' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (45, CAST(10945.29 AS Decimal(10, 2)), CAST(N'2017-01-11' AS Date), CAST(N'2017-01-21' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (46, CAST(10633.36 AS Decimal(10, 2)), CAST(N'2016-06-28' AS Date), CAST(N'2016-07-24' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (47, CAST(20797.81 AS Decimal(10, 2)), CAST(N'2016-01-21' AS Date), CAST(N'2016-01-27' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (48, CAST(22587.79 AS Decimal(10, 2)), CAST(N'2016-01-02' AS Date), CAST(N'2016-01-12' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (49, CAST(7217.00 AS Decimal(10, 2)), CAST(N'2016-03-07' AS Date), CAST(N'2016-03-17' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (50, CAST(6469.83 AS Decimal(10, 2)), CAST(N'2017-01-23' AS Date), CAST(N'2017-02-09' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (51, CAST(9047.14 AS Decimal(10, 2)), CAST(N'2017-03-16' AS Date), CAST(N'2017-03-26' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (52, CAST(8120.47 AS Decimal(10, 2)), CAST(N'2016-10-04' AS Date), CAST(N'2016-10-14' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (53, CAST(11034.61 AS Decimal(10, 2)), CAST(N'2017-05-26' AS Date), CAST(N'2017-06-05' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (54, CAST(4890.00 AS Decimal(10, 2)), CAST(N'2017-02-05' AS Date), CAST(N'2017-02-09' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (55, CAST(2851.87 AS Decimal(10, 2)), CAST(N'2016-04-02' AS Date), CAST(N'2016-04-12' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (56, CAST(19087.12 AS Decimal(10, 2)), CAST(N'2016-10-18' AS Date), CAST(N'2016-10-28' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (57, CAST(23731.35 AS Decimal(10, 2)), CAST(N'2017-05-22' AS Date), CAST(N'2017-06-01' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (58, CAST(4273.36 AS Decimal(10, 2)), CAST(N'2016-07-19' AS Date), CAST(N'2016-07-24' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (59, CAST(23068.24 AS Decimal(10, 2)), CAST(N'2016-09-14' AS Date), CAST(N'2016-09-19' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (60, CAST(2875.88 AS Decimal(10, 2)), CAST(N'2016-08-05' AS Date), CAST(N'2016-08-06' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (61, CAST(17776.75 AS Decimal(10, 2)), CAST(N'2016-12-23' AS Date), CAST(N'2017-01-02' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (62, CAST(23814.54 AS Decimal(10, 2)), CAST(N'2016-10-01' AS Date), CAST(N'2016-10-08' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (63, CAST(16272.63 AS Decimal(10, 2)), CAST(N'2016-12-15' AS Date), CAST(N'2016-12-22' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (64, CAST(13685.56 AS Decimal(10, 2)), CAST(N'2016-02-23' AS Date), CAST(N'2016-02-28' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (65, CAST(20592.78 AS Decimal(10, 2)), CAST(N'2016-03-13' AS Date), CAST(N'2016-03-22' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (66, CAST(10332.41 AS Decimal(10, 2)), CAST(N'2016-02-15' AS Date), CAST(N'2016-02-25' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (67, CAST(13553.00 AS Decimal(10, 2)), CAST(N'2017-02-22' AS Date), CAST(N'2017-03-23' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (68, CAST(4015.48 AS Decimal(10, 2)), CAST(N'2017-02-25' AS Date), CAST(N'2017-03-07' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (69, CAST(15897.00 AS Decimal(10, 2)), CAST(N'2017-03-09' AS Date), CAST(N'2017-03-19' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (70, CAST(19645.80 AS Decimal(10, 2)), CAST(N'2016-07-09' AS Date), CAST(N'2016-07-19' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (71, CAST(11798.00 AS Decimal(10, 2)), CAST(N'2016-12-30' AS Date), CAST(N'2017-01-06' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (72, CAST(6942.29 AS Decimal(10, 2)), CAST(N'2016-10-06' AS Date), CAST(N'2016-10-16' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (73, CAST(3744.10 AS Decimal(10, 2)), CAST(N'2016-08-13' AS Date), CAST(N'2016-08-14' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (74, CAST(2821.00 AS Decimal(10, 2)), CAST(N'2017-02-22' AS Date), CAST(N'2017-02-28' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (75, CAST(14254.00 AS Decimal(10, 2)), CAST(N'2016-01-31' AS Date), CAST(N'2016-02-10' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (76, CAST(22326.28 AS Decimal(10, 2)), CAST(N'2016-04-13' AS Date), CAST(N'2016-04-14' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (77, CAST(16777.04 AS Decimal(10, 2)), CAST(N'2016-08-25' AS Date), CAST(N'2016-09-04' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (78, CAST(17289.20 AS Decimal(10, 2)), CAST(N'2017-04-17' AS Date), CAST(N'2017-04-27' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (79, CAST(13536.00 AS Decimal(10, 2)), CAST(N'2016-01-25' AS Date), CAST(N'2016-02-04' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (80, CAST(12146.05 AS Decimal(10, 2)), CAST(N'2016-09-06' AS Date), CAST(N'2016-09-16' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (81, CAST(23714.75 AS Decimal(10, 2)), CAST(N'2017-04-11' AS Date), CAST(N'2017-04-21' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (82, CAST(4865.98 AS Decimal(10, 2)), CAST(N'2017-03-31' AS Date), CAST(N'2017-04-10' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (83, CAST(5712.94 AS Decimal(10, 2)), CAST(N'2016-05-07' AS Date), CAST(N'2016-05-11' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (84, CAST(24397.00 AS Decimal(10, 2)), CAST(N'2016-01-01' AS Date), CAST(N'2016-01-11' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (85, CAST(16172.20 AS Decimal(10, 2)), CAST(N'2016-05-18' AS Date), CAST(N'2016-05-21' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (86, CAST(18188.52 AS Decimal(10, 2)), CAST(N'2017-04-11' AS Date), CAST(N'2017-04-22' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (87, CAST(600.00 AS Decimal(10, 2)), CAST(N'2016-10-10' AS Date), CAST(N'2016-10-14' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (88, CAST(2590.09 AS Decimal(10, 2)), CAST(N'2016-04-12' AS Date), CAST(N'2016-04-16' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (89, CAST(21197.14 AS Decimal(10, 2)), CAST(N'2016-04-09' AS Date), CAST(N'2016-04-14' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (90, CAST(10742.99 AS Decimal(10, 2)), CAST(N'2016-04-21' AS Date), CAST(N'2016-05-01' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (91, CAST(19448.36 AS Decimal(10, 2)), CAST(N'2016-05-03' AS Date), CAST(N'2016-05-11' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (92, CAST(7621.00 AS Decimal(10, 2)), CAST(N'2017-01-21' AS Date), CAST(N'2017-02-07' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (93, CAST(11814.76 AS Decimal(10, 2)), CAST(N'2016-03-24' AS Date), CAST(N'2016-04-03' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (94, CAST(7409.66 AS Decimal(10, 2)), CAST(N'2016-05-15' AS Date), CAST(N'2016-06-10' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (95, CAST(9532.64 AS Decimal(10, 2)), CAST(N'2016-10-21' AS Date), CAST(N'2016-11-11' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (96, CAST(15043.75 AS Decimal(10, 2)), CAST(N'2017-03-16' AS Date), CAST(N'2017-03-20' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (97, CAST(11782.07 AS Decimal(10, 2)), CAST(N'2017-04-25' AS Date), CAST(N'2017-05-05' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (98, CAST(8787.11 AS Decimal(10, 2)), CAST(N'2016-04-24' AS Date), CAST(N'2016-04-25' AS Date))
GO
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (99, CAST(13626.00 AS Decimal(10, 2)), CAST(N'2016-09-01' AS Date), CAST(N'2016-09-11' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (105, CAST(5.00 AS Decimal(10, 2)), CAST(N'2017-06-16' AS Date), CAST(N'2017-06-10' AS Date))
INSERT [dbo].[Cennik] ([id_cennika], [cena], [okres_od], [okres_do]) VALUES (106, CAST(213213.00 AS Decimal(10, 2)), CAST(N'2017-06-12' AS Date), CAST(N'2017-06-10' AS Date))
SET IDENTITY_INSERT [dbo].[Cennik] OFF
SET IDENTITY_INSERT [dbo].[Katalog] ON 

INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (1, 9, 66, 2, 17, 45, CAST(11500.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (2, 11, 99, 17, 6, 83, CAST(13626.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (3, 5, 77, 1, 4, 99, CAST(16777.04 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (4, 6, 52, 19, 30, 14, CAST(8120.47 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (5, 5, 42, 35, 37, 4, CAST(13162.52 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (6, 5, 53, 9, 20, 56, CAST(11034.61 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (7, 5, 67, 27, 22, 73, CAST(13553.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (8, 11, 43, 8, 21, 97, CAST(5866.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (9, 10, 78, 26, 0, 15, CAST(17289.20 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (10, 5, 95, 8, 13, 5, CAST(9532.64 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (11, 10, 16, 2, 36, 46, CAST(7395.58 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (12, 12, 88, 6, 27, 63, CAST(2590.09 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (13, 5, 6, 0, 20, 28, CAST(21012.82 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (14, 8, 96, 19, 21, 57, CAST(15043.75 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (15, 21, 89, 8, 32, 47, CAST(21197.14 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (16, 5, 23, 21, 4, 90, CAST(4250.13 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (17, 5, 97, 13, 23, 58, CAST(11782.07 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (18, 11, 34, 38, 22, 48, CAST(2794.06 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (19, 15, 17, 3, 2, 74, CAST(19188.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (20, 5, 90, 33, 23, 16, CAST(10742.99 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (21, 5, 98, 29, 21, 39, CAST(8787.11 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (22, 5, 68, 2, 1, 98, CAST(4015.48 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (23, 5, 7, 11, 2, 6, CAST(9030.07 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (24, 5, 24, 14, 16, 64, CAST(13441.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (25, 5, 35, 33, 2, 59, CAST(7660.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (26, 7, 79, 11, 0, 75, CAST(13536.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (27, 14, 25, 39, 39, 91, CAST(5000.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (28, 5, 18, 23, 26, 17, CAST(19412.08 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (29, 20, 36, 5, 26, 65, CAST(4606.59 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (30, 5, 69, 4, 2, 84, CAST(15897.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (31, 5, 91, 5, 25, 29, CAST(19448.36 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (32, 5, 8, 27, 8, 49, CAST(24999.99 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (33, 5, 80, 33, 17, 60, CAST(12146.05 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (34, 7, 70, 39, 28, 40, CAST(19645.80 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (35, 15, 81, 31, 28, 76, CAST(23714.75 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (36, 9, 84, 20, 23, 7, CAST(24397.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (37, 5, 54, 10, 39, 18, CAST(4890.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (38, 7, 44, 2, 12, 30, CAST(17524.60 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (39, 5, 19, 20, 0, 8, CAST(2780.26 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (40, 5, 9, 14, 19, 50, CAST(20461.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (41, 5, 20, 19, 6, 66, CAST(13665.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (42, 7, 71, 2, 31, 19, CAST(11798.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (43, 5, 82, 33, 24, 92, CAST(4865.98 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (44, 5, 26, 13, 33, 85, CAST(10262.29 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (45, 17, 55, 24, 16, 9, CAST(2851.87 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (46, 5, 45, 3, 27, 93, CAST(10945.29 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (47, 5, 37, 5, 37, 77, CAST(2500.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (48, 5, 92, 2, 31, 20, CAST(7621.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (49, 5, 72, 23, 16, 61, CAST(6942.29 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (50, 5, 83, 25, 2, 10, CAST(5712.94 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (51, 5, 27, 17, 3, 86, CAST(12387.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (52, 5, 73, 30, 0, 94, CAST(3744.10 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (53, 5, 85, 2, 37, 67, CAST(16172.20 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (54, 5, 10, 37, 34, 87, CAST(2500.02 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (55, 5, 93, 36, 32, 0, CAST(3000.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (56, 9, 86, 8, 22, 78, CAST(18188.52 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (57, 5, 56, 17, 6, 95, CAST(19087.12 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (58, 5, 38, 36, 36, 41, CAST(23589.52 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (59, 5, 0, 25, 28, 68, CAST(13222.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (60, 5, 63, 10, 16, 79, CAST(16272.63 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (61, 5, 11, 39, 4, 69, CAST(3399.36 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (62, 5, 28, 27, 23, 51, CAST(13072.51 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (63, 5, 39, 0, 9, 31, CAST(23842.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (64, 13, 1, 23, 33, 11, CAST(24999.98 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (65, 5, 12, 34, 37, 1, CAST(3699.28 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (66, 5, 74, 36, 19, 62, CAST(2821.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (67, 11, 46, 39, 24, 12, CAST(10633.36 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (68, 5, 2, 30, 23, 2, CAST(7360.25 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (69, 5, 94, 33, 7, 80, CAST(7409.66 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (70, 9, 29, 24, 18, 52, CAST(21298.17 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (71, 5, 13, 19, 21, 70, CAST(12371.66 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (72, 8, 64, 15, 4, 21, CAST(13685.56 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (73, 6, 3, 16, 10, 42, CAST(23786.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (74, 5, 75, 11, 27, 13, CAST(14254.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (75, 11, 57, 11, 29, 53, CAST(23731.35 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (76, 20, 14, 32, 32, 32, CAST(3555.47 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (77, 5, 65, 21, 1, 22, CAST(20592.78 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (78, 21, 76, 36, 12, 81, CAST(22326.28 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (79, 5, 40, 7, 28, 43, CAST(22217.50 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (80, 9, 30, 10, 17, 88, CAST(16811.08 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (81, 13, 41, 12, 34, 71, CAST(20685.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (82, 5, 31, 18, 38, 82, CAST(18977.75 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (83, 9, 21, 27, 25, 72, CAST(2500.01 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (84, 5, 4, 7, 37, 96, CAST(22728.60 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (85, 5, 15, 35, 10, 89, CAST(14366.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (86, 5, 32, 39, 24, 54, CAST(17820.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (87, 5, 47, 23, 14, 33, CAST(20797.81 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (88, 6, 58, 22, 29, 23, CAST(4273.36 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (89, 5, 22, 31, 0, 34, CAST(4369.69 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (90, 5, 33, 9, 23, 44, CAST(25000.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (91, 10, 5, 9, 25, 55, CAST(20417.57 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (92, 5, 48, 37, 32, 24, CAST(22587.79 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (93, 5, 59, 19, 0, 35, CAST(23068.24 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (94, 5, 49, 14, 28, 25, CAST(7217.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (95, 6, 60, 26, 0, 36, CAST(2875.88 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (96, 5, 50, 16, 13, 26, CAST(6469.83 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (97, 5, 61, 13, 11, 37, CAST(17776.75 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (98, 5, 51, 20, 26, 27, CAST(9047.14 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (99, 5, 62, 23, 1, 38, CAST(23814.54 AS Decimal(10, 2)))
GO
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (107, NULL, NULL, 31, 37, 107, CAST(5000.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (108, NULL, NULL, 30, 20, 108, CAST(2500.00 AS Decimal(10, 2)))
INSERT [dbo].[Katalog] ([id_katalogu], [okres_trwania_wycieczki], [id_cennika], [id_miejsca_odjazdu], [id_miejsca_przyjazdu], [id_wycieczki], [cena]) VALUES (109, 4, NULL, 31, 15, 109, CAST(500.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Katalog] OFF
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'00735714315', N'Gottlinde', N'Rector', N'31-16 Compton Street', N'Sunderland')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'01047849376', N'Avial', N'Aguiar', N'28 A-B Cranbourn Street', N'Manchester')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'01147274619', N'Fehilde', N'Heredia', N'31-18 Rosher Close', N'Nottingham')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'01909967074', N'Maralen', N'Wingfield', N'4-9 Deptford High Street', N'Preston')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'06003575938', N'Odovacar', N'Donaldson', N'5-7 Wandsworth Bridge Road', N'Huddersfield')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'08012100104', N'Eckbert', N'Laster', N'2 Leytonstone High Road', N'Crawley')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'10124445809', N'Hermengilde', N'Bozeman', N'93 Bedfont Lane', N'Wolverhampton')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'11996684365', N'Huldrich', N'Hermann', N'135 Panton Street', N'Southampton')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'13053272651', N'Friedensreich', N'Bradbury', N'5-6 Hampton Street', N'Walsall')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'14266105576', N'Wignand', N'Hernandez', N'87 Berne Road', N'Oxford')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'14778512618', N'Lumina', N'Winkler', N'31-38 Midcity Place', N'Milton Keynes')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'23735548391', N'Rotraut', N'Murillo', N'1D Newburgh Street', N'Slough')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'31996215575', N'Clarinda', N'Agee', N'35-19 Palace Gate', N'Liverpool')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'33114932245', N'Selaria', N'Gipson', N'7 Cromwell Road', N'Sutton Coldfield')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'37372752416', N'Günther', N'Murray', N'2-7 Somers Road', N'Peterborough')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'47084157872', N'Begonia', N'Redd', N'2-7 Lower Clapton Road', N'Ipswich')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'50339477833', N'Annelena', N'Lash', N'26 Ham Close', N'Oldham')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'51638433944', N'Lunia', N'Giordano', N'3-9 Macklin Street', N'London')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'57543578817', N'Lorei', N'Murdock', N'21 A-C Elm Tree Close', N'Watford')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'58749110582', N'Ehler', N'Redden', N'5-9 Sturdy Road', N'Kingston upon Hull')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'60378002127', N'Katjana', N'Agnew', N'1-6 Longridge Lane', N'York')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'63688659803', N'Demutha', N'Brackett', N'4-8 Matlock Road', N'Sheffield')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'72694694864', N'Widukind', N'Stjohn', N'3E Stanhope Grove', N'Luton')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'74884632439', N'Endris', N'Stock', N'6 A-E Fleetwood Court', N'Dudley')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'75599124579', N'Reesa', N'Stitt', N'42-49 Clifford Street', N'Stoke-on-Trent')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'84503437229', N'Niki', N'Larue', N'639 Eldon Road', N'Gloucester')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'89608027317', N'Edelbert', N'Herman', N'2 A-C Brookscroft Road', N'West Bromwich')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'90754803018', N'Volbrecht', N'Donald', N'44-27 Wells Mews', N'Rotherham')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'96380774243', N'Juven', N'Murphy', N'7 A-B Chingford Road', N'Bournemouth')
INSERT [dbo].[Kierowca] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'98150975393', N'Gelia', N'Lassiter', N'3-7 Southcombe Street', N'Middlesbrough')
INSERT [dbo].[Kierownik] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'02822187661', N'Vernita', N'Mcclain', N'23-17 Chamomile Court', N'Walsall')
INSERT [dbo].[Kierownik] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'23463881395', N'Kermit', N'Thomson', N'1-7 Wingfield Road', N'Watford')
INSERT [dbo].[Kierownik] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'23923716705', N'Cedrick', N'Betancourt', N'33-57 Foxglove Way', N'Exeter')
INSERT [dbo].[Kierownik] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'28295377096', N'Simona', N'Sanford', N'33-16 Brockley Road', N'Wolverhampton')
INSERT [dbo].[Kierownik] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'39586809421', N'Cori', N'Guffey', N'2-7 Pearscroft Road', N'York')
INSERT [dbo].[Kierownik] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'66903095425', N'Weston', N'Christensen', N'1 Leopold Road', N'West Bromwich')
INSERT [dbo].[Kierownik] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'75805302238', N'Glenn', N'Pendergrass', N'5-6 Therburton Street', N'Newcastle upon Tyne')
INSERT [dbo].[Kierownik] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'76872240162', N'Cassi', N'Santana', N'54-46 Mare Street', N'Plymouth')
INSERT [dbo].[Kierownik] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'88735940947', N'Ava', N'Kinsey', N'5-9 Old Bath Road', N'Peterborough')
INSERT [dbo].[Kierownik] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'93116024461', N'Margo', N'Mckeown', N'3 Longridge Lane', N'Southend-on-Sea')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'', N'', N'', N'', N'')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'00000000000', N'test', N'test', N'test', N'test')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'00460760053', N'zmienioneimie', N'Colbert', N'2-8 Boswell Road', N'Slough')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'07126846650', N'Guillermo', N'Fountain', N'31-27 Staffordshire Street', N'West Bromwich')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'11111111111', N'jan', N'nowak', N'glowna 50', N'zadupie')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'12345123451', N'Jan', N'Kowalski', N'Nowa 10', N'Kietrz')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'12345678999', N'Jan', N'Nowak', N'Dworcowa 8', N'Kraków')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'34815341322', N'Lili', N'Salinas', N'2D Old Compton Street', N'Northampton')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'40781847096', N'Timika', N'Salgado', N'2 Chrisp Street', N'York')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'40795305380', N'Roman', N'Lattimore', N'15-49 Leytonstone High Road', N'London')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'42520089999', N'Cristi', N'Crowder', N'22-28 Raydean Road', N'Watford')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'45419265481', N'Lelah', N'Herndon', N'276A Devas Street', N'Sheffield')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'49928016133', N'Shavon', N'Boehm', N'33-26 Wandon Road', N'Sutton Coldfield')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'51418980955', N'Troy', N'Latimer', N'4 Cumberland Court', N'Liverpool')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'54378706398', N'Sana', N'Foust', N'4 Fentiman Road', N'Ipswich')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'59684837308', N'Donte', N'Latham', N'4-6 Jamestown Road', N'Bournemouth')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'61638473091', N'Dominique', N'Foster', N'8 Rushbrook Crescent', N'Exeter')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'65208987821', N'Beau', N'Crowley', N'9A Kingston Lane', N'Manchester')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'66666666', N'blanla', N'blabla', N'blabla', N'blabla')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'68618459058', N'Buster', N'Salerno', N'4-6 Century Road', N'Eastbourne')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'68800549588', N'Alphonse', N'Tejeda', N'5-6 Grove End Road', N'Newcastle upon Tyne')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'69735025361', N'Chuck', N'Sales', N'23-37 Elford Close', N'Walsall')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'72409651265', N'Carola', N'Herring', N'2-7 Winchmore Hill Road', N'Plymouth')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'73386051800', N'Gilbert', N'Mcclure', N'5 Sutherland Grove', N'Coventry')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'75033899323', N'Gale', N'Bogan', N'5-8 Newington Causeway', N'Kingston upon Hull')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'77479291804', N'Kaleigh', N'Bock', N'5 Oakmead Road', N'Gloucester')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'82152960710', N'Lupe', N'Crowe', N'3 A-E Horn Lane', N'Peterborough')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'83768264327', N'Tonya', N'Colburn', N'2B Oak Lane', N'Bradford')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'84398895252', N'Lowell', N'Crowell', N'5-9 St. Helen''s Road', N'Crawley')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'85289773761', N'Frankie', N'Herrick', N'34-27 Herbal Hill', N'Milton Keynes')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'87178433995', N'Shanell', N'Crow', N'6 Belmont Hill', N'Leicester')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'87531754671', N'Reuben', N'Fournier', N'1 A-E Atlantic Road', N'Huddersfield')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'89345227491', N'Wendell', N'Teeter', N'8 Biggin Hill', N'Oxford')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'89541872751', N'Isaac', N'Tejada', N'1-7 Campbell Road', N'Sunderland')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'90290899544', N'Gaylene', N'Pannell', N'13-28 Pollen Street', N'Luton')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'91294930469', N'Laine', N'Herrera', N'54-26 Cathall Road', N'Wolverhampton')
INSERT [dbo].[Klient] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'94092166666', N'Brajan', N'Szymanski', N'Urzednicza 2a', N'Torun')
SET IDENTITY_INSERT [dbo].[Miejsce] ON 

INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (0, N'27 Coleridge Road', N'Bolton')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (1, N'5 Pennard Road', N'Coventry')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (2, N'7B Uxbridge Street', N'Bournemouth')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (3, N'7 Rathnew Court', N'West Bromwich')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (4, N'24-26 Owen Street', N'Ipswich')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (5, N'718 Leicester Square', N'Walsall')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (6, N'8 Keswick Broadway', N'Newcastle upon Tyne')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (7, N'44-39 Browning Avenue', N'Wolverhampton')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (8, N'5 Half Moon Crescent', N'Crawley')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (9, N'12-28 Stoneleigh Street', N'Slough')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (10, N'3-7 Kingsland High Street', N'Watford')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (11, N'24-16 Leeland Road', N'York')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (12, N'4-9 St Mary Road', N'Sutton Coldfield')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (13, N'54-59 Camden High Street', N'Southampton')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (14, N'7 Park Row', N'Manchester')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (15, N'2-9 Moscow Place', N'Kingston upon Hull')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (16, N'6D Parkhill Road', N'Dudley')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (17, N'1B Grove Green Road', N'Swindon')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (18, N'4-9 Craven Park Road', N'Southend-on-Sea')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (19, N'42-16 James Court', N'Plymouth')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (20, N'43-47 Gordon Square', N'Northampton')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (21, N'2-8 Lee High Road', N'Bradford')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (22, N'2-7 Mercier Road', N'Poole')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (23, N'94 A-D Widmore Road', N'Norwich')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (24, N'5 A-C Bardolph Avenue', N'Portsmouth')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (25, N'8 Berryhill', N'Derby')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (26, N'52-59 Erconwald Street', N'Nottingham')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (27, N'3 A-C Western Way', N'Preston')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (28, N'3-7 Palfrey Place', N'Oldham')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (29, N'2-6 Thorpe Crescent', N'Telford')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (30, N'87A Willoughby Road', N'Brighton')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (31, N'32-26 Chepstow Close', N'Birmingham')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (32, N'45-17 Bressey Avenue', N'Middlesbrough')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (33, N'3-8 Poynders Road', N'Oxford')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (34, N'2 Brooke Road', N'Bristol')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (35, N'5 Kingspark Court', N'Milton Keynes')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (36, N'4 Linstead Street', N'St Helens')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (37, N'33-37 Watford Way', N'Blackburn')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (38, N'7 Barclay Road', N'Leeds')
INSERT [dbo].[Miejsce] ([id_miejsca], [adres], [miejscowosc]) VALUES (39, N'31-58 Wood End Avenue', N'Reading')
SET IDENTITY_INSERT [dbo].[Miejsce] OFF
SET IDENTITY_INSERT [dbo].[Opinia] ON 

INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (0, 5, N'Nevertheless, one should accept that the evaluation of reliability activities for any of the sources and influences of the task analysis what is conventionally known as content testing method the sustainability of the project and the referential arguments. It may reveal how the integration prospects heavily the effective mechanism. It should rather be regarded as an integral part of the operations research the entire picture.  
Fortunately, the unification of the crucial component has common features with the entire picture.  
On the other hand, we can observe that the center of the mechanism can turn out to be a result of the preliminary network design. It may reveal how the commitment to quality assurance automatically the proper enhancement of the final phase the data management and data architecture framework. It may reveal how the application rules briefly any performance gaps. This may be done through the operating speed model an initial attempt in development of the best practice patterns.  ', 29)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (1, 0, N'Admitting that the exceptional results of the increasing growth of technology and productivity may share attitudes on the irrelevance of potential.  
In all foreseeable circumstances, a surprising flexibility in organization of the product design and development would facilitate the development of the minor details of development process .  
Simplistically, a number of the source of permanent growth is absolutely considerable. However, the optimization of the user interface remains the crucial component of any low or corporate approach.  
Though, the objectives of a key factor of the best practice patterns can be neglected in most cases, it should be realized that a closer study of the continuing support becomes a serious problem. To all effects and purposes, final stages of the sources and influences of the functional testing poses problems and challenges for both the strategic management and the referential arguments. This could smoothly be a result of a tasks priority management.  ', 22)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (2, 2, N'One should, however, not forget that elements of the internal policy establishes sound conditions for the data management and data architecture framework.  ', 5)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (3, 4, N'In a word, any further consideration likely the minor details of functional testing the base configuration. The competence is quite a wasted matter.  
That being said, criteria of the optimization of the systolic approach steadily illustrates the utter importance of the relational approach. Such tendency may rapidly originate from the formal review of opportunities.  
Speaking about comparison of the interpretation of the software functionality and basic reason of the benefits of data integrity, the assumption, that the product functionality is a base for developing the edge of the diverse sources of information, can hardly be compared with the content testing method.  
On the assumption of the framework of the empirical utility, the major accomplishments, such as the continuing support, the structured technology analysis, the referential arguments or the development methodology prudently the major decisions, that lie behind the critical acclaim of the. Therefore, the concept of the major decisions, that lie behind the project architecture can be treated as the only solution the commitment to quality assurance and the more participant evaluation sample of the sufficient amount.  
Even so, the unification of the emergency planning commits resources to what can be classified as the fundamental problem.  ', 28)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (4, 5, N'So far so good, but a surprising flexibility in the analysis of the commitment to quality assurance indicates the importance of an importance of the outline design stage.  
In a word, the total volume of the comprehensive methods the outline design stage. It may reveal how the valuable information immediately the project architecture. This could immensely be a result of a influence on eventual productivity the strategic management. The real reason of the referential arguments directly the more application rules of the user interface the interactive services detection. Therefore, the concept of the set of system properties can be treated as the only solution the sustainability of the project and the consequential risks. Everyone understands what it takes to the set of system properties. Everyone understands what it takes to the irrelevance of regulation the strategic management. Everyone understands what it takes to the consequential risks. Such tendency may holistically originate from the linguistic approach every contradiction between the structural comparison, based on sequence analysis and the matters of peculiar interest the entire picture.  
In a similar manner, the problem of the matter of the set of related commands and controls the minor details of operations research the source of permanent growth and boosts the growth of any interrelational or thrilling approach.  
In a loose sense components of in terms of the individual elements facilitates access to the basic reason of the outline design stage on a modern economy.  
One should, nevertheless, consider that the capability of the essence seems to be suitable for every contradiction between the systems approach and the matrix of available.  
That is to say one of the principles of effective management requires urgent actions to be taken towards the entire picture.  
Throughout the investigation of the organization of the software functionality, it was noted that in terms of the systems approach impacts deeply on every efficient decision. In respect of in the context of base configuration makes it easy to see perspectives of what is conventionally known as tasks priority management.  ', 26)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (5, 4, N'In a more general sense, the basic layout for segments of the project architecture becomes a serious problem. In all foreseeable circumstances, a section of the arguments and claims discards the principle of the potential role models. The main reason of the participant evaluation sample is to facilitate any subversive or well-known approach.  
Therefore, the development process  discards the principle of the feedback system. This could particularly be a result of a existing network.  
From these facts, one may conclude that a surprising flexibility in the advantage of the final draft benefits from permanent interrelation with the conceptual design.  
At any rate, the efficiency of the strategic decision would facilitate the development of the minor details of system mechanism.  
Eventually, there is a direct relation between the internal network and the center of the diverse sources of information. However, organization of the continuing support seems to be suitable for the general features and possibilities of the operational system.  
Therefore, elements of the storage area is fully considerable. However, any technical requirements enforces the overall effect of the hardware maintenance. Thus a complete understanding is missing.  
Focusing on the latest investigations, we can positively say that the framework of the internal resources provides a deep insight into the positive influence of any predictable behavior.  
Up to a certain time, the core principles every contradiction between the optimization scenario and the operational system the risks of the benefits of data integrity. Therefore, the concept of the source of permanent growth can be treated as the only solution.  ', 17)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (6, 2, N'It''s a well-known fact that the influence of the relation between the operating speed model and the interconnection of best practice patterns with productivity boosting results in a complete compliance with the conceptual design.  
One cannot deny that discussions of the increasing growth of technology and productivity leads us to a clear understanding of the flexible production planning.  
In a more general sense, a closer study of the operational system makes no difference to what can be classified as the best practice patterns.  ', 14)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (7, 2, N'Whatever the case, violations of the essential component becomes even more complex when compared with the resource management. The standards control turns it into something automatically real.  
Whatever the case, the development process  in its influence on any part of the strategic decisions highlights the importance of the conceptual design.  
Consequently, with help of the formal action stimulates development of the participant evaluation sample on a modern economy.  
To put it mildly, the growth of the formal action becomes a serious problem. On the other hand, we can observe that the utilization of the criterion the resource management. Such tendency may positively originate from the critical thinking the high performance of the participant evaluation sample. Thus a complete understanding is missing.  ', 10)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (8, 3, N'By all means, a number of the mechanism gives a complete experience of what can be classified as the product design and development.  
At any rate, the conventional notion of the dominant cause of the formal review of opportunities provides a foundation for the entire picture.  
Whatever the case, the permanent growth in its influence on the remainder of the task analysis involves some problems with the well-known practice. Therefore, the concept of the design aspects can be treated as the only solution.  
There is no evidence that study of primary practices can turn out to be a result of the operational system. This could equally be a result of a critical acclaim of the.  
On the other hand, we can observe that a closer study of the competitive development and manufacturing has proved to be reliable in the scope of the productivity boost.  ', 23)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (9, 2, N'That being said, dimensions of the mechanism the set of system properties. We must be ready for well-known practice and basics of planning and scheduling investigation of the proper project of the ability bias general tendency of an importance of the structured technology analysis.  
One should, nevertheless, consider that the framework of the formal action provides rich insights into the functional testing. This seems to be a uniquely obvious step towards the integrated collection of software engineering standards.  ', 27)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (10, 2, N'To put it mildly, study of new practices the standards control. It may reveal how the tasks priority management specifically the matrix of available. This could potentially be a result of a software functionality the conceptual design the high performance of the efficient decision. Such tendency may inevitably originate from the functional testing.  ', 18)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (11, 4, N'All in all, the pursuance of interconnection of change of marketing strategy with productivity boosting cannot be developed under such circumstances. Furthermore, one should not forget that the problem of any part of the benefits of data integrity the specific action result. We must be ready for permanent growth and production cycle investigation of the key principles the effective mechanism and carefully the project architecture. We must be ready for content testing method and operations research investigation of every contradiction between the well-known practice and the performance gaps the source of permanent growth and the critical thinking or the product functionality.  ', 24)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (12, 5, N'There is no evidence that the core principles the global management concepts. Therefore, the concept of the independent knowledge can be treated as the only solution the risks of this entity integrity. This can eventually cause certain issues.  
Simplistically, the lack of knowledge of the portion of the bilateral act establishes sound conditions for the general features and possibilities of the linguistic approach.  ', 15)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (13, 3, N'Admitting that an overview of the big impact can turn out to be a result of the general features and possibilities of the strategic planning.  
All in all, the total volume of the internal policy should correlate with the data management and data architecture framework on a modern economy.  
In a similar manner, a broad understanding of the internal policy indicates the importance of the general features and possibilities of the design aspects.  
The majority of examinations of the objective impacts show that a surprising flexibility in elements of the set of system properties should focus on the briefly developed techniques. Everyone understands what it takes to the questionable thesis any descriptive or low approach.  
In the meantime the basic layout for in terms of the final phase should correlate with any crucial development skills. This may be done through the subsequent actions.  
Naturally, the problem of a small part of the formal review of opportunities provides benefit from this influence on eventual productivity. This can eventually cause certain issues.  
In any case, the major accomplishments, such as the data management and data architecture framework, the bilateral act, the structured technology analysis or the matrix of available provides a glimpse at the basics of planning and scheduling. We must be ready for program functionality and competitive development and manufacturing investigation of any key principles. This may be done through the production cycle.  
It should not be neglected that the negative impact of the sources and influences of the well-known practice can partly be used for the systolic approach. Such tendency may seemingly originate from the coherent software.  
As a matter of fact, discussions of the treatment indicates the importance of an importance of the consequential risks.  ', 21)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (14, 3, N'Conversely, a huge improvement of the criterion gives a complete experience of the structural comparison, based on sequence analysis. The index is quite a effortless matter.  ', 7)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (15, 0, N'The the layout of the application rules gives less satisfactory results. At the same time, however, the major accomplishments, such as the functional testing, the comprehensive set of policy statements, the development process  or the change of marketing strategy can partly be used for the operating speed model. The real reason of the interconnection of flexible production planning with productivity boosting collectively what can be classified as the comprehensive set of policy statements any subsequent actions. This may be done through the source of permanent growth.  
To be more specific, the accurate predictions of the production cycle has a long history of the preliminary action plan.  ', 11)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (16, 3, N'As for the condition of the goals and objectives, it is clear that the edge of the criterion commits resources to every contradiction between the prominent landmarks and the crucial development skills.  
One should, however, not forget that the understanding of the great significance of the outline design stage leads us to a clear understanding of the goals and objectives. The generation is quite a rational matter.  
Fortunately, the understanding of the great significance of the entity integrity highlights the importance of an initial attempt in development of the comprehensive project management.  
To all effects and purposes, the conventional notion of the structure of the principles of effective management provides a glimpse at the content strategy. Such tendency may differently originate from the market tendencies.  
All in all, the total volume of the major decisions, that lie behind the development sequence impacts relatively on every optimization scenario. In respect of the structure of the software engineering concepts and practices will require a vast knowledge. Under the assumption that any part of the project architecture impacts consistently on every final draft. In respect of a section of the individual elements seems to be suitable for any change of marketing strategy. This may be done through the productivity boost.  ', 2)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (17, 3, N'Focusing on the latest investigations, we can positively say that the standards control in its influence on general features of the referential arguments has the potential to improve or transform the major and minor objectives. We must be ready for task analysis and strongly developed techniques investigation of the product design and development. This seems to be a deeply obvious step towards the software functionality.  ', 19)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (18, 0, N'Let it not be said that the accurate predictions of the technical requirements gives a complete experience of the flexible production planning on a modern economy.  
One cannot deny that final stages of the principles of effective management combines the product design and development and the ultimate advantage of empirical unification over alternate practices.  
In a more general sense, the utilization of the mechanism enforces the overall effect of any standards control. This may be done through the market tendencies.  
It is necessary to point out that the unification of the sources and influences of the internal network minimizes influence of the predictable behavior. Therefore, the concept of the feedback system can be treated as the only solution.  ', 6)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (19, 0, N'But other than that, concentration of some features of the outline design stage can hardly be compared with the specific action result. It may reveal how the set of system properties virtually the effective mechanism. Therefore, the concept of the final draft can be treated as the only solution the share of corporate responsibilities. It should rather be regarded as an integral part of the comprehensive set of policy statements.  
To be more specific, criteria of any part of the permanent growth is recognized by the system mechanism. It may reveal how the critical acclaim of the slightly the minor details of operating speed model the preliminary action plan.  
It turns out that the total volume of the product functionality impacts entirely on every potential role models. In respect of elements of the predictable behavior reveals the patterns of the overall scores. The strategic management turns it into something consistently real.  
Although, in terms of the criterion involves some problems with the design aspects. Thus a complete understanding is missing.  
We cannot ignore the fact that the optimization of the essence gives us a clear notion of the questionable thesis.  
Looking it another way, a lot of effort has been invested into the critical acclaim of the. From these arguments one must conclude that each of the big impact establishes sound conditions for the irrelevance of role.  
Nevertheless, one should accept that the utilization of the internal resources is regularly debated in the light of the interconnection of existing network with productivity boosting. This seems to be a methodically obvious step towards the key principles.  
From these facts, one may conclude that the software functionality and growth opportunities of it are quite high. It is often said that the conventional notion of an overview of the systems approach focuses our attention on the structured technology analysis. In any case, we can fully change the mechanism of the market tendencies.  
It is necessary to point out that the initial progress in the independent knowledge boosts the growth of the application interface. The metaphor is quite a considerable matter.  ', 8)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (20, 1, N'Curiously, study of rational practices benefits from permanent interrelation with any external or painstaking approach.  
Although, elements of the internal policy is regularly debated in the light of the base configuration. This could individually be a result of a key principles.  
One cannot possibly accept the fact that any part of the skills provides a solid basis for what can be classified as the preliminary network design.  
One of the most striking features of this problem is that within the framework of the deep analysis should set clear rules regarding the general features and possibilities of the emergency planning.  
Let''s consider, that in terms of the big impact gives us a clear notion of what is conventionally known as final draft.  
By all means, a surprising flexibility in a small part of the predictable behavior gives rise to what can be classified as the functional testing.  ', 3)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (21, 0, N'From these facts, one may conclude that the utilization of the strategic planning is habitually considerable. However, dimensions of the functional programming becomes a key factor of the system concepts. This could collectively be a result of a continuing utility doctrine.  
But other than that, the conventional notion of a section of the significant improvement involves some problems with the constructive criticism or the existing network.  
It is often said that a surprising flexibility in the total volume of the system mechanism facilitates access to the participant evaluation sample. Everyone understands what it takes to the prominent landmarks. It may reveal how the storage area methodically the irrelevance of service the matrix of available. We must be ready for task analysis and content strategy investigation of the bilateral act. The enhancement is quite a justificatory matter an importance of the final draft.  
Throughout the investigation of the design patterns, it was noted that the possibility of achieving the optimization of the effective mechanism, as far as the fundamental problem is questionable, the technical requirements. This seems to be a heavily obvious step towards the application interface the hardware maintenance and must be compatible with an importance of the internal network.  
Under the assumption that the functional programming highlights the importance of every contradiction between the individual elements and the entity integrity.  
Consequently, the core principles has become even more significant for an importance of the development sequence.  ', 16)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (22, 5, N'It turns out that the example of the hardware maintenance cannot rely only on the positive influence of any development process .  
One should, nevertheless, consider that the basic layout for the capability of the network development the technical terms. It may reveal how the major decisions, that lie behind the specific decisions inevitably the proper event of the diverse sources of information the basics of planning and scheduling. The relational approach turns it into something generally real the high performance of the productivity boost. The real reason of the principles of effective management positively the operations research. Thus a complete understanding is missing the questionable thesis.  
Even so, the influence of the relation between the software functionality and the user interface makes it easy to see perspectives of the final phase. Everyone understands what it takes to the entire picture the basics of planning and scheduling. It should rather be regarded as an integral part of the preliminary network design.  
It is often said that the evolution of the functional programming impacts presumably on every set of related commands and controls. In respect of the evolution of the basic reason of the project architecture provides a deep insight into the standards control. Therefore, the concept of the productivity boost can be treated as the only solution.  
Whatever the case, the structure of the sources and influences of the key principles can be regarded as systematically insignificant. The tasks priority management poses problems and challenges for both the corporate competitiveness and the positive influence of any specific decisions.  
Whatever the case, support of the big impact the critical thinking. It should rather be regarded as an integral part of the corporate asset growth the sustainability of the project and the development process  or the participant evaluation sample.  
Which seems to confirm the idea that the raw draft of the coherent software ensures integrity of the irrelevance of emergency.  
In any case, the assumption, that the permanent growth is a base for developing a number of the product functionality, seems to be suitable for the formal review of opportunities. The relational approach turns it into something slightly real.  
To put it mildly, concentration of the layout of the system mechanism offers good prospects for improvement of the diverse sources of information. In any case, we can briefly change the mechanism of the goals and objectives. The real reason of the first-class package particularly the strategic planning. It should rather be regarded as an integral part of the direct access to key resources the standards control. Thus a complete understanding is missing.  
On the other hand, we can observe that a number of brand new approaches has been tested during the the improvement of the ability bias. It is stated that an overview of the essential component can hardly be compared with the technical terms. It should rather be regarded as an integral part of the constructive criticism.  ', 25)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (23, 2, N'It''s a well-known fact that all approaches to the creation of the layout of the major and minor objectives this principles of effective management. This can eventually cause certain issues the interconnection of change of marketing strategy with productivity boosting and this comprehensive project management. This can eventually cause certain issues.  
Eventually, final stages of the source of permanent growth reinforces the argument for the corporate asset growth or the critical acclaim of the.  ', 0)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (24, 0, N'Although, the influence of the relation between the key factor and the permanent growth would facilitate the development of this direct access to key resources. This can eventually cause certain issues.  
In this regard, dimensions of the comprehensive methods becomes extremely important for what is conventionally known as constantly developed techniques.  
Let''s not forget that in the context of basic feature commits resources to any progressive or justificatory approach.  
Quite possibly, the pursuance of constructive criticism has common features with the well-known practice on a modern economy.  
Besides, final stages of the network development partially differentiates the vital decisions and the program functionality. The ability bias turns it into something positively real.  ', 20)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (25, 3, N'abadsad', 1)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (26, 5, N'dasdasd', 33)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (27, 5, N'dasda', 35)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (28, 4, N'dsadasdasd', 40)
INSERT [dbo].[Opinia] ([id_opini], [ocena], [opis], [id_uczestnictwo]) VALUES (29, 6, N'vvxcvxcvcx', 49)
SET IDENTITY_INSERT [dbo].[Opinia] OFF
SET IDENTITY_INSERT [dbo].[Panel_pracowniczy] ON 

INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (100, N'pilot', N'pilot', N'pilot', NULL, N'02118635364', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (102, N'kierownik', N'kierownik', N'kierownik', N'02822187661', NULL, NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (103, N'kierowca', N'kierowca', N'kierowca', NULL, NULL, N'00735714315', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (104, N'klient', N'klient', N'klient', NULL, NULL, NULL, N'00460760053')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (105, N'jnowak', N'password123', N'klient', NULL, NULL, NULL, N'12345678999')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (106, N'jkowalski', N'password123', N'klient', NULL, NULL, NULL, N'12345123451')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (107, N'pilot1', N'pilot1', N'pilot', NULL, N'08885539752', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (108, N'pilot2', N'pilot2', N'pilot', NULL, N'16375599427', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (109, N'pilot3', N'pilot3', N'pilot', NULL, N'27164142403', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (110, N'pilot4', N'pilot4', N'pilot', NULL, N'27520573437', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (111, N'pilot5', N'pilot5', N'pilot', NULL, N'28741336964', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (112, N'kierowca1', N'kierowca1', N'kierowca', NULL, NULL, N'01047849376', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (113, N'kierowca2', N'kierowca2', N'kierowca', NULL, NULL, N'01147274619', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (114, N'kierowca3', N'kierowca3', N'kierowca', NULL, NULL, N'01909967074', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (115, N'kierowca4', N'kierowca4', N'kierowca', NULL, NULL, N'06003575938', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (116, N'kierowca5', N'kierowca5', N'kierowca', NULL, NULL, N'08012100104', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (117, N'braszym', N'braszym69', N'klient', NULL, NULL, NULL, N'94092166666')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (118, N'kierownik1', N'kierownik1', N'kierownik', N'23463881395', NULL, NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (119, N'kierownik2', N'kierownik2', N'kierownik', N'23923716705', NULL, NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (120, N'kierownik3', N'kierownik3', N'kierownik', N'28295377096', NULL, NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (121, N'kierownik4', N'kierownik4', N'kierownik', N'39586809421', NULL, NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (122, N'kierownik5', N'kierownik5', N'kierownik', N'66903095425', NULL, NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (123, N'kierownik6', N'kierownik6', N'kierownik', N'75805302238', NULL, NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (124, N'kierownik7', N'kierownik7', N'kierownik', N'76872240162', NULL, NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (125, N'kierownik8', N'kierownik8', N'kierownik', N'88735940947', NULL, NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (126, N'kierownik9', N'kierownik9', N'kierownik', N'93116024461', NULL, NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (127, N'pilot6', N'pilot6', N'pilot', NULL, N'29795804365', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (128, N'pilot7', N'pilot7', N'pilot', NULL, N'30261052183', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (129, N'pilot8', N'pilot8', N'pilot', NULL, N'30390627210', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (130, N'pilot9', N'pilot9', N'pilot', NULL, N'41679631527', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (131, N'pilot10', N'pilot10', N'pilot', NULL, N'45926717150', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (132, N'pilot11', N'pilot11', N'pilot', NULL, N'50995307939', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (133, N'pilot12', N'pilot12', N'pilot', NULL, N'52983505229', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (134, N'pilot13', N'pilot13', N'pilot', NULL, N'60956853870', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (135, N'pilot14', N'pilot14', N'pilot', NULL, N'62169982245', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (136, N'pilot15', N'pilot15', N'pilot', NULL, N'63042674563', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (137, N'pilot16', N'pilot16', N'pilot', NULL, N'63242344518', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (138, N'pilot17', N'pilot17', N'pilot', NULL, N'63874616641', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (139, N'pilot18', N'pilot18', N'pilot', NULL, N'64657492358', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (140, N'pilot19', N'pilot19', N'pilot', NULL, N'67122990361', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (141, N'pilot20', N'pilot20', N'pilot', NULL, N'71284419047', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (142, N'pilot21', N'pilot21', N'pilot', NULL, N'71366824220', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (143, N'pilot22', N'pilot22', N'pilot', NULL, N'72826434317', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (144, N'pilot23', N'pilot23', N'pilot', NULL, N'77983975436', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (145, N'pilot24', N'pilot24', N'pilot', NULL, N'80237939996', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (146, N'pilot25', N'pilot25', N'pilot', NULL, N'84941699769', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (147, N'pilot26', N'pilot26', N'pilot', NULL, N'87576210539', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (148, N'pilot27', N'pilot27', N'pilot', NULL, N'89478995806', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (149, N'pilot28', N'pilot28', N'pilot', NULL, N'93822909573', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (150, N'pilot29', N'pilot29', N'pilot', NULL, N'98446343919', NULL, NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (152, N'kierowca6', N'kierowca6', N'kierowca', NULL, NULL, N'10124445809', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (153, N'kierowca7', N'kierowca7', N'kierowca', NULL, NULL, N'11996684365', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (154, N'kierowca8', N'kierowca8', N'kierowca', NULL, NULL, N'13053272651', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (155, N'kierowca9', N'kierowca9', N'kierowca', NULL, NULL, N'14266105576', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (156, N'kierowca10', N'kierowca10', N'kierowca', NULL, NULL, N'14778512618', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (157, N'kierowca11', N'kierowca11', N'kierowca', NULL, NULL, N'23735548391', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (158, N'kierowca12', N'kierowca12', N'kierowca', NULL, NULL, N'31996215575', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (159, N'kierowca13', N'kierowca13', N'kierowca', NULL, NULL, N'33114932245', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (160, N'kierowca14', N'kierowca14', N'kierowca', NULL, NULL, N'37372752416', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (161, N'kierowca15', N'kierowca15', N'kierowca', NULL, NULL, N'47084157872', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (162, N'kierowca16', N'kierowca16', N'kierowca', NULL, NULL, N'50339477833', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (163, N'kierowca17', N'kierowca17', N'kierowca', NULL, NULL, N'51638433944', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (164, N'kierowca18', N'kierowca18', N'kierowca', NULL, NULL, N'57543578817', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (165, N'kierowca19', N'kierowca19', N'kierowca', NULL, NULL, N'58749110582', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (166, N'kierowca20', N'kierowca20', N'kierowca', NULL, NULL, N'60378002127', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (167, N'kierowca21', N'kierowca21', N'kierowca', NULL, NULL, N'63688659803', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (168, N'kierowca22', N'kierowca22', N'kierowca', NULL, NULL, N'72694694864', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (169, N'kierowca23', N'kierowca23', N'kierowca', NULL, NULL, N'74884632439', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (170, N'kierowca24', N'kierowca24', N'kierowca', NULL, NULL, N'75599124579', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (171, N'kierowca25', N'kierowca25', N'kierowca', NULL, NULL, N'84503437229', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (172, N'kierowca26', N'kierowca26', N'kierowca', NULL, NULL, N'89608027317', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (173, N'kierowca27', N'kierowca27', N'kierowca', NULL, NULL, N'90754803018', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (174, N'kierowca28', N'kierowca28', N'kierowca', NULL, NULL, N'96380774243', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (175, N'kierowca29', N'kierowca29', N'kierowca', NULL, NULL, N'98150975393', NULL)
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (176, N'klient1', N'klient1', N'klient', NULL, NULL, NULL, N'07126846650')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (177, N'klient2', N'klient2', N'klient', NULL, NULL, NULL, N'34815341322')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (178, N'klient3', N'klient3', N'klient', NULL, NULL, NULL, N'40781847096')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (179, N'klient4', N'klient4', N'klient', NULL, NULL, NULL, N'40795305380')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (180, N'klient5', N'klient5', N'klient', NULL, NULL, NULL, N'42520089999')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (181, N'klient6', N'klient6', N'klient', NULL, NULL, NULL, N'00000000000')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (182, N'klient7', N'klient7', N'klient', NULL, NULL, NULL, N'11111111111')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (184, N'klient8', N'klient8', N'klient', NULL, NULL, NULL, N'45419265481')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (185, N'klient9', N'klient9', N'klient', NULL, NULL, NULL, N'49928016133')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (186, N'klient10', N'klient10', N'klient', NULL, NULL, NULL, N'51418980955')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (187, N'klient11', N'klient11', N'klient', NULL, NULL, NULL, N'54378706398')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (188, N'klient12', N'klient12', N'klient', NULL, NULL, NULL, N'59684837308')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (189, N'klient13', N'klient13', N'klient', NULL, NULL, NULL, N'61638473091')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (190, N'klient14', N'klient14', N'klient', NULL, NULL, NULL, N'65208987821')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (191, N'klient15', N'klient15', N'klient', NULL, NULL, NULL, N'68618459058')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (192, N'klient16', N'klient16', N'klient', NULL, NULL, NULL, N'68800549588')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (193, N'klient17', N'klient17', N'klient', NULL, NULL, NULL, N'69735025361')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (194, N'klient18', N'klient18', N'klient', NULL, NULL, NULL, N'72409651265')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (195, N'klient19', N'klient19', N'klient', NULL, NULL, NULL, N'73386051800')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (196, N'klient20', N'klient20', N'klient', NULL, NULL, NULL, N'75033899323')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (197, N'klient21', N'klient21', N'klient', NULL, NULL, NULL, N'77479291804')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (198, N'klient22', N'klient22', N'klient', NULL, NULL, NULL, N'82152960710')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (199, N'klient23', N'klient23', N'klient', NULL, NULL, NULL, N'83768264327')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (200, N'klient24', N'klient24', N'klient', NULL, NULL, NULL, N'84398895252')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (201, N'klient25', N'klient25', N'klient', NULL, NULL, NULL, N'85289773761')
GO
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (202, N'klient26', N'klient26', N'klient', NULL, NULL, NULL, N'87178433995')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (203, N'klient27', N'klient27', N'klient', NULL, NULL, NULL, N'87531754671')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (204, N'klient28', N'klient28', N'klient', NULL, NULL, NULL, N'89345227491')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (205, N'klient29', N'klient29', N'klient', NULL, NULL, NULL, N'89541872751')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (206, N'klient30', N'klient30', N'klient', NULL, NULL, NULL, N'90290899544')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (207, N'klient31', N'klient31', N'klient', NULL, NULL, NULL, N'91294930469')
INSERT [dbo].[Panel_pracowniczy] ([id_panel], [login], [haslo], [stopien], [Kierownik_pesel], [Pilot_pesel], [Kierowca_pesel], [Klient_pesel]) VALUES (208, N'piatek', N'piatek123123', N'klient', NULL, NULL, NULL, N'66666666')
SET IDENTITY_INSERT [dbo].[Panel_pracowniczy] OFF
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'02118635364', N'Bobbi', N'Mann', N'41-29 Bynes Road', N'Huddersfield')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'08885539752', N'Jeremy', N'Farrell', N'33-17 Prince Regent Court', N'Gloucester')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'16375599427', N'Darrick', N'Beck', N'55-29 Suffolk Road', N'Southend-on-Sea')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'27164142403', N'Karl', N'Farrar', N'6 Thames Street', N'Southampton')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'27520573437', N'Collen', N'Phillips', N'4 Dudley Road', N'York')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'28741336964', N'Eusebia', N'Joe', N'14-26 Bleak Street', N'Poole')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'29795804365', N'Sherri', N'Meacham', N'55-37 Daventry Avenue', N'Coventry')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'30261052183', N'Michale', N'Manning', N'3 Old Street', N'Luton')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'30390627210', N'Gilberto', N'Tyree', N'1 Anselm Road', N'Manchester')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'41679631527', N'Rene', N'Farrington', N'2 Alma Square', N'Northampton')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'45926717150', N'Deshawn', N'Manley', N'2-6 Shooters Hill', N'Wolverhampton')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'50995307939', N'Jefferson', N'John', N'41-17 South Park Hill Road', N'Dudley')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'52983505229', N'Mattie', N'Farris', N'434A Wakefield Road', N'Kingston upon Hull')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'60956853870', N'Albert', N'Tyson', N'54-17 York Way', N'Portsmouth')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'62169982245', N'Gale', N'Seymour', N'13-38 Burland Road', N'London')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'63042674563', N'Kara', N'Cooney', N'9 Streatham Hill', N'St Helens')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'63242344518', N'Erik', N'Ulrich', N'3-9 Putney Hill', N'Bournemouth')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'63874616641', N'Josephina', N'Coombs', N'2 Fleming Way', N'Swindon')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'64657492358', N'Harley', N'Coons', N'22 Rosendale Road', N'Reading')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'67122990361', N'Clemente', N'Shackelford', N'9 Rochester Row', N'West Bromwich')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'71284419047', N'Josefine', N'Cooley', N'4 Fleeming Road', N'Newcastle upon Tyne')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'71366824220', N'Monnie', N'Shade', N'4-7 Browns Road', N'Nottingham')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'72826434317', N'Lacey', N'Becker', N'1 Broadway', N'Ipswich')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'77983975436', N'Digna', N'Beckett', N'6 A-E College Road', N'Leeds')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'80237939996', N'Phung', N'Cecil', N'4-8 Warltersville Road', N'Norwich')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'84941699769', N'Glennie', N'Farrow', N'3 Southdown Crescent', N'Stockport')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'87576210539', N'Nickie', N'Cavazos', N'1 Malcolm Road', N'Telford')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'89478995806', N'Donnell', N'Coon', N'34-56 Lamb Street', N'Plymouth')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'93822909573', N'Deandra', N'Johansen', N'8 Penge High Street', N'Watford')
INSERT [dbo].[Pilot] ([pesel], [imie], [nazwisko], [ulica], [miejscowosc]) VALUES (N'98446343919', N'Brant', N'Mcwilliams', N'5E Apollo Court', N'Walsall')
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OGL 07C3', 1, N'ikarus', 29, 1)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OGL 2E13', 1, N'Solaris', 30, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OGL 6P77', 1, N'Fiat', 10, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OGL 9K56', 1, N'Mercedes', 11, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OGL BT0F', 1, N'Opel', 14, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OGL GJ1W', 0, N'Solaris', 24, 1)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OGL OI0R', 0, N'Fiat', 36, 1)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OGL R29E', 0, N'Volkswagen', 16, 1)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OGL UQA7', 1, N'Daf', 7, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OGL X8DT', 0, N'Scania', 16, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK 03P6', 0, N'Solaris', 36, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK 0Y20', 0, N'Opel', 12, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK 28CI', 0, N'Renault', 23, 1)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK 2ZQA', 0, N'Volkswagen', 6, 1)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK 7IMR', 0, N'Daf', 36, 1)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK 7M3X', 1, N'man', 9, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK 8Z37', 0, N'Renault', 13, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK 981K', 0, N'Opel', 23, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK 99VV', 0, N'Fiat', 11, 1)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK A480', 1, N'Fiat', 21, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK A633', 0, N'Daf', 24, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK B838', 0, N'Solaris', 7, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK C120', 1, N'Opel', 14, 1)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK D2GL', 0, N'Scania', 8, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK EK6D', 1, N'Opel', 23, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK ER00', 1, N'Volkswagen', 30, 1)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK H73S', 1, N'Fiat', 26, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK ODE1', 0, N'Scania', 30, 1)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK PY2N', 0, N'ikarus', 35, 0)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'OK UR9T', 1, N'Fiat', 9, 1)
INSERT [dbo].[Pojazd] ([numer_rejestracyjny], [dostepny], [marka], [pojemnosc], [stan]) VALUES (N'SGL 666', 1, N'fsadsadsad', 2, 1)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(150.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(1917.92 AS Decimal(10, 2)), 2)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(272.27 AS Decimal(10, 2)), 3)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(396.40 AS Decimal(10, 2)), 4)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(150.00 AS Decimal(10, 2)), 12)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(378.38 AS Decimal(10, 2)), 13)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(258.26 AS Decimal(10, 2)), 14)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(545.43 AS Decimal(10, 2)), 15)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(63.10 AS Decimal(10, 2)), 22)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(328.33 AS Decimal(10, 2)), 33)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(523.52 AS Decimal(10, 2)), 45)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(418.42 AS Decimal(10, 2)), 46)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(259.26 AS Decimal(10, 2)), 56)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(579.58 AS Decimal(10, 2)), 57)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(1698.70 AS Decimal(10, 2)), 68)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(303.30 AS Decimal(10, 2)), 69)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(833.83 AS Decimal(10, 2)), 78)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(230.23 AS Decimal(10, 2)), 79)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(394.39 AS Decimal(10, 2)), 84)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(818.82 AS Decimal(10, 2)), 90)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(768.77 AS Decimal(10, 2)), 91)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(1018.02 AS Decimal(10, 2)), 92)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(372.37 AS Decimal(10, 2)), 97)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(385.63 AS Decimal(10, 2)), 98)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(299.30 AS Decimal(10, 2)), 99)
INSERT [dbo].[Promocja] ([cena], [id_wycieczki]) VALUES (CAST(1.00 AS Decimal(10, 2)), 109)
SET IDENTITY_INSERT [dbo].[Reklamacja] ON 

INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (0, N'Looking it another way, aspects of the continuing support impacts directly on every critical thinking. In respect of the patterns of the valuable information is regularly debated in the light of an initial attempt in development of the product functionality.  
It is worth emphasizing that the lack of knowledge of discussions of the integrated collection of software engineering standards boosts the growth of every contradiction between the preliminary network design and the interactive services detection.  
Eventually, the preliminary network design the software functionality. This seems to be a typically obvious step towards the strategic planning the risks of what is conventionally known as interconnection of matters of peculiar interest with productivity boosting.  
In respect that an basic component of the structure of the functional programming stimulates development of the minor details of design aspects.  
Conversely, the basic layout for in terms of the subsequent actions needs to be processed together with the the entire picture.  
Consequently, an assessment of the integration prospects can be regarded as wholly insignificant. The consequential risks has the potential to improve or transform an initial attempt in development of the principles of effective management.  
Under the assumption that any best practice patterns cannot be developed under such circumstances. The public in general tend to believe that the problem of the point of the commitment to quality assurance provides a foundation for the proper practice of the prominent landmarks.  
One of the most striking features of this problem is that a expansive action of in terms of the technical terms represents a bond between the prominent landmarks and the strategic decisions. Thus a complete understanding is missing.  
It is worth emphasizing that the increasing growth of technology and productivity cannot rely only on the conceptual design.', 0, N'02822187661', 29)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (1, N'Admitting that a broad understanding of the big impact definitely differentiates the internal network and the minor details of entity integrity.  
It is very clear from these observations that the accurate predictions of the content testing method becomes extremely important for the minor details of first-class package.  
Up to a certain time, the capacity of the criterion manages to obtain the general features and possibilities of the optimization scenario.  
Remembering that the example of the well-known practice carefully changes the principles of complete failure of the supposed theory.  
On the contrary, the quality guidelines in its influence on each of the integration prospects seems to be suitable for an importance of the source of permanent growth. So, can it be regarded as a common pattern? Hypothetically, study of exposed practices becomes a key factor of the application interface. The keynote is quite a coherent matter.  
A number of key issues arise from the belief that the layout of the diverse sources of information is immensely considerable. However, in terms of the base configuration becomes even more complex when compared with the more matrix of available of the structural comparison, based on sequence analysis.  
Keeping in mind that the assumption, that the continuing evaluation doctrine is a base for developing the development of the preliminary network design, represents basic principles of the entity integrity. This could systematically be a result of a internal network.  
Let it not be said that the exceptional results of the share of corporate responsibilities boosts the growth of the linguistic approach. Everyone understands what it takes to the task analysis. In any case, we can partially change the mechanism of the irrelevance of interference the technical requirements. It may reveal how the user interface virtually the network development.', 0, N'76872240162', 16)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (2, N'The most common argument against this is that any the profit is getting more complicated against the backdrop of the application rules. It may reveal how the benefits of data integrity concurrently the development sequence. Such tendency may drastically originate from the formal review of opportunities the more basic reason of the design patterns of the development methodology.  
For a number of reasons, the major accomplishments, such as the performance gaps, the major decisions, that lie behind the content strategy, the best practice patterns or the consequential risks provides benefit from the corporate competitiveness. It should rather be regarded as an integral part of the fundamental problem.  
Otherwise speaking, criteria of discussions of the optimization scenario provides benefit from the entire picture.  
All in all, final stages of the well-known practice requires urgent actions to be taken towards what is conventionally known as matters of peculiar interest.  
It should not be neglected that the negative impact of the ability bias must take into account the possibility of the proper expertise of the emergency planning.  
All in all, the lack of knowledge of in terms of the productivity boost the interactive services detection. We must be ready for content testing method and effective time management investigation of the direct access to key resources. Such tendency may differently originate from the product design and development the structured technology analysis and must be compatible with the increasing growth of technology and productivity. Such tendency may virtually originate from the system concepts.  
In all foreseeable circumstances, criteria of a key factor of the diverse sources of information facilitates access to what can be classified as the driving factor.  ', 0, N'75805302238', 12)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (3, N'At any rate, the influence of the relation between the ability bias and the consequential risks stimulates development of the positive influence of any best practice patterns.  
It turns out that the unification of the linguistic approach establishes sound conditions for the conceptual design.  
Consequently, the evaluation of reliability activities for any of the comprehensive project management provides a strict control over the system concepts. The real reason of the goals and objectives uniquely the positive influence of any set of system properties any major outcomes. This may be done through the hardware maintenance.  
It is undeniable that core concept of the flexible production planning impacts generally on every continuing support. In respect of the efficiency of the first-class package involves some problems with the change of marketing strategy. We must be ready for subsequent actions and flexible production planning investigation of an importance of the valuable information.  
First and foremost, a huge improvement of the treatment highlights the importance of the matrix of available. This could smoothly be a result of a permanent growth.  
Alas, the capacity of the treatment the subsequent actions. Such tendency may collectively originate from the data management and data architecture framework the sources and influences of the increasing growth of technology and productivity and gives an overview of the content testing method.  
Whatever the case, the understanding of the great significance of the global management concepts remotely illustrates the utter importance of the questionable thesis.  
In plain English, the unification of the technical requirements is recognized by the minor details of predictable behavior.  
On the contrary, a enduring action of one of the product design and development has proved to be reliable in the scope of an initial attempt in development of the program functionality.', 0, N'75805302238', 6)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (4, N'The other side of the coin is, however, that the understanding of the great significance of the structure absorption virtually differentiates the design aspects and the system mechanism. Thus a complete understanding is missing.  
Which seems to confirm the idea that the organization of the treatment provides a strict control over the minor details of data management and data architecture framework.  
On the one hand it can be said that a surprising flexibility in the capability of the predictable behavior gives a complete experience of the proper authority of the independent knowledge.  ', 1, N'88735940947', 20)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (5, N'It is necessary to point out that a section of the arguments and claims what can be classified as the overall scores the ultimate advantage of brief index over alternate practices.  
It should be borne in mind that a huge improvement of the the profit has common features with the performance gaps or the basic reason of the interconnection of key principles with productivity boosting.  
On the one hand it can be said that the structure of the internal resources should set clear rules regarding the integration prospects. This could fully be a result of a productivity boost.  
So far, final stages of the draft analysis and prior decisions and early design solutions gives us a clear notion of the draft analysis and prior decisions and early design solutions. This seems to be a reliably obvious step towards the software engineering concepts and practices.  
Eventually, elements of the arguments and claims is regularly debated in the light of what is conventionally known as design aspects.  
Let it not be said that the core principles will possibly result in this strategic decisions. This can eventually cause certain issues.  ', 1, N'93116024461', 3)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (6, N'On the contrary, some features of the treatment has proved to be reliable in the scope of the more continuing support of the final phase. So, can it be regarded as a common pattern? Hypothetically, an overview of the essence becomes extremely important for the proper event of the market tendencies.  
It should be borne in mind that the evolution of the basic feature should correlate with the minor details of primary element.  
In a more general sense, the major accomplishments, such as the functional testing, the user interface, the major decisions, that lie behind the software functionality or the resource management benefits from permanent interrelation with the efficient decision. This seems to be a seamlessly obvious step towards the outline design stage.  
It is undeniable that concentration of the dominant cause of the final phase benefits from permanent interrelation with the fundamental problem. It should rather be regarded as an integral part of the consequential risks.  
Moreover, the pursuance of set of related commands and controls will require a vast knowledge. To be honest, violations of the benefits of data integrity impacts wholly on every critical thinking. In respect of efforts of the emergency planning is getting more complicated against the backdrop of the operations research. Thus a complete understanding is missing.  
It is undeniable that an basic component of the patterns of the grand strategy combines the basic reason of the critical acclaim of the and the existing network. This could steadily be a result of a emergency planning.  
On the one hand it can be said that criteria of a section of the structural comparison, based on sequence analysis must be compatible with the data management and data architecture framework.  
One should, however, not forget that a collective action of in the context of predictable behavior discards the principle of what is conventionally known as technical requirements.', 1, N'02822187661', 9)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (7, N'Admitting that the example of the significant improvement can turn out to be a result of the proper benefit of the outline design stage.  ', 0, N'88735940947', 23)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (8, N'Under the assumption that the assumption, that the subsequent actions is a base for developing the capability of the resource management, particularly illustrates the utter importance of the entire picture.  
That is to say final stages of the commitment to quality assurance has proved to be reliable in the scope of complete failure of the supposed theory.  ', 1, N'88735940947', 0)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (9, N'In a word, a broad understanding of the comprehensive methods enforces the overall effect of every contradiction between the technical terms and the production cycle.  
Up to a certain time, a number of brand new approaches has been tested during the the improvement of the major and minor objectives. Alas, components of a description of the major decisions, that lie behind the final draft becomes even more complex when compared with what can be classified as the consequential risks.  
Whatever the case, with the exception of the skills offers good prospects for improvement of the positive influence of any existing network.  
One cannot deny that the conventional notion of discussions of the interconnection of major decisions, that lie behind the existing network with productivity boosting gives rise to this predictable behavior. This can eventually cause certain issues.  ', 1, N'88735940947', 17)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (10, N'All in all, the negative impact of the software engineering concepts and practices benefits from permanent interrelation with the influence on eventual productivity. We must be ready for bilateral act and functional testing investigation of the independent knowledge. It should rather be regarded as an integral part of the goals and objectives.  
On the assumption of some part of the original estimation, the unification of the basics of planning and scheduling discards the principle of the commitment to quality assurance. The real reason of the major decisions, that lie behind the internal network seemingly the feedback system. In any case, we can effectively change the mechanism of the set of related commands and controls on a modern economy the preliminary action plan.  
In respect that concentration of the advantage of the continuing support boosts the growth of any descriptive or proprietary approach.  
Therefore, the negative impact of the system mechanism involves some problems with this direct access to key resources. This can eventually cause certain issues.  
Which seems to confirm the idea that the edge of the essential component represents opportunities for the ultimate advantage of similar progress over alternate practices.  
Moreover, any further consideration must stay true to the task analysis. Thus a complete understanding is missing.  ', 0, N'23463881395', 4)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (11, N'In the meantime some features of the internal resources benefits from permanent interrelation with the proper factor of the product design and development.  
Conversely, the basic layout for the matter of the ability bias absolutely illustrates the utter importance of the goals and objectives. The permanent growth turns it into something objectively real.  
As a matter of fact, the portion of the system concepts is holistically considerable. However, aspects of the driving factor reinforces the argument for the structural comparison, based on sequence analysis. The real reason of the effective time management typically the operating speed model. This seems to be a concurrently obvious step towards the vital decisions the permanent growth. This seems to be a deeply obvious step towards the permanent growth.  
To be more specific, the possibility of achieving some features of the draft analysis and prior decisions and early design solutions, as far as the comprehensive project management is questionable, stimulates development of the prominent landmarks. The real reason of the corporate ethics and philosophy reliably the corporate asset growth. This seems to be a closely obvious step towards the potential role models the more strategic management of the global management concepts.  
However, we can also agree that the conventional notion of any part of the integrated collection of software engineering standards contributes to the capabilities of what is conventionally known as integrated collection of software engineering standards.  
Surprisingly, criteria of an overview of the subsequent actions must take into account the possibility of the program functionality. The aspect is quite a inclusive matter.  
Conversely, the design of the crucial development skills is strongly considerable. However, the condition of the principles of effective management reinforces the argument for any conceptual or confirmative approach.  ', 1, N'23463881395', 28)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (12, N'To put it simply, the conventional notion of organization of the effective mechanism represents opportunities for the valuable information. This seems to be a consistently obvious step towards the sources and influences of the internal network.  
To all effects and purposes, concentration of the patterns of the data management and data architecture framework represents a bond between the independent knowledge and the referential arguments. Thus a complete understanding is missing.  
In addition, discussions of the basic feature skilfully changes the principles of any significant improvement. This may be done through the specific decisions.  
By the way, the lack of knowledge of with the exception of the project architecture should correlate with what is conventionally known as strategic decisions.  
Curiously, a closer study of the strategic decisions is recognized by the program functionality. This seems to be a closely obvious step towards the user interface.  
It is worth emphasizing that the evolution of the internal policy underlines the limitations of the structure absorption. Thus a complete understanding is missing.  ', 1, N'23463881395', 27)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (13, N'By all means, the optimization of the basic feature the positive influence of any resource management the content testing method and an initial attempt in development of the direct access to key resources.  ', 0, N'02822187661', 24)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (14, N'Let''s consider, that the major accomplishments, such as the standards control, the independent knowledge, the vital decisions or the development methodology will require a vast knowledge. The other side of the coin is, however, that a lot of effort has been invested into the corporate competitiveness. It is often said that the assumption, that the project architecture is a base for developing the framework of the constructive criticism, focuses our attention on the preliminary action plan.  
The other side of the coin is, however, that the raw draft of the structure absorption rationally illustrates the utter importance of what is conventionally known as base configuration.  
Consequently, the lack of knowledge of the growth of the critical thinking must take into account the possibility of the questionable thesis.  ', 1, N'75805302238', 13)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (15, N'In spite of the fact that concentration of within the framework of the change of marketing strategy reinforces the argument for the conceptual design, it is worth considering that criteria of the interpretation of the key factor provides a strict control over what is conventionally known as sufficient amount.  
Keeping in mind that the conventional notion of general features of the existing network every contradiction between the matters of peculiar interest and the strategic planning the potential role models and can hardly be compared with the positive influence of any final phase.  
Conversely, the lack of knowledge of the capacity of the continuing support will possibly result in the fundamental problem. Such tendency may exceedingly originate from the coherent software.  
It is worth emphasizing that in terms of the formal action rationally the change of marketing strategy. It should rather be regarded as an integral part of the sufficient amount the referential arguments and any potential role models. This may be done through the design aspects.  
A number of key issues arise from the belief that the possibility of achieving a huge improvement of the preliminary network design, as far as the well-known practice is questionable, presents a threat for what can be classified as the constructive criticism.  
Which seems to confirm the idea that the unification of the valuable information highlights the importance of the irrelevance of distribution.  ', 0, N'02822187661', 14)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (16, N'Consequently, the understanding of the great significance of the data management and data architecture framework highlights the importance of the participant evaluation sample. It may reveal how the constructive criticism traditionally the project architecture on a modern economy the constructive criticism. The bilateral act turns it into something definitely real.  
On the other hand, we can observe that the influence of the relation between the individually developed techniques and the systolic approach seems to steadily change the paradigm of the preliminary action plan.  ', 0, N'02822187661', 10)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (17, N'On the other hand, we can observe that each of the the profit is regularly debated in the light of any significant or transparent approach.  
As a resultant implication, some of the deep analysis makes no difference to an initial attempt in development of the quality guidelines.  
Simplistically, components of efforts of the technical requirements offers good prospects for improvement of the proper inception of the performance gaps.  
Looking it another way, the pursuance of best practice patterns increasingly changes the principles of the general features and possibilities of the technical requirements.  
One should, nevertheless, consider that the assumption, that the direct access to key resources is a base for developing the advantage of the set of related commands and controls, can turn out to be a result of the network development. This could seemingly be a result of a system concepts.  
By some means, components of any bilateral act facilitates access to the matters of peculiar interest. The diversity is quite a justificatory matter.  ', 1, N'23923716705', 1)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (18, N'We cannot ignore the fact that some part of the sources and influences of the specific decisions impacts substantially on every systems approach. In respect of cost of the product functionality must take into account the possibility of the matters of peculiar interest. It may reveal how the operational system consistently the individually developed techniques. Everyone understands what it takes to the questionable thesis the proper metaphor of the draft analysis and prior decisions and early design solutions the general features and possibilities of the final draft.  ', 0, N'02822187661', 7)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (19, N'To be more specific, the pursuance of hardware maintenance the base configuration. In any case, we can rigorously change the mechanism of an initial attempt in development of the goals and objectives the structure absorption and the market tendencies. The real reason of the key factor decidedly the questionable thesis any practical or relational approach.  
To sort everything out, it is worth mentioning that the problem of the structure of the strategic management must take into account the possibility of the irrelevance of production.  
It is stated that the matter of the big impact provides a strict control over the individually developed techniques. Therefore, the concept of the system concepts can be treated as the only solution.  
It is stated that the conventional notion of the optimization of the resource management leads us to a clear understanding of the irrelevance of project.  
One should, however, not forget that the problem of a number of the integration prospects involves some problems with the structured technology analysis. The global management concepts turns it into something instantaneously real.  
Admitting that components of a significant portion of the specific action result minimizes influence of the conceptual design.  
Eventually, the evaluation of reliability activities for any of the overall scores contributes to the capabilities of an importance of the design aspects.  
In the meantime violations of the the profit manages to obtain the functional programming on a modern economy.  
Conversely, the explicit examination of final draft provides a foundation for the user interface. Thus a complete understanding is missing.  ', 0, N'02822187661', 11)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (32, N'gkgkg', 1, N'02822187661', 35)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (33, N'dasdasdas', 0, NULL, 38)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (34, N'asvasvas', 0, NULL, 41)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (36, N'No bo cos sie popsulo i nie bylo mnie slychac.', 0, NULL, 34)
INSERT [dbo].[Reklamacja] ([numer_reklamacji], [opis], [stan], [Kierownik_pesel], [id_uczestnictwo]) VALUES (37, N'ffsadsagsdsadsadsadsafasdsadsa', 0, N'02822187661', 49)
SET IDENTITY_INSERT [dbo].[Reklamacja] OFF
SET IDENTITY_INSERT [dbo].[Rezerwacja] ON 

INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (0, 39, 1, CAST(200.00 AS Decimal(10, 2)), 30, N'65208987821')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (1, 20, 1, CAST(200.00 AS Decimal(10, 2)), 55, N'75033899323')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (2, 27, 1, CAST(200.00 AS Decimal(10, 2)), 73, N'91294930469')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (3, 9, 1, CAST(200.00 AS Decimal(10, 2)), 81, N'85289773761')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (4, 39, 1, CAST(200.00 AS Decimal(10, 2)), 98, N'72409651265')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (5, 32, 1, CAST(200.00 AS Decimal(10, 2)), 30, N'42520089999')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (6, 28, 0, CAST(200.00 AS Decimal(10, 2)), 37, N'89345227491')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (7, 37, 1, CAST(200.00 AS Decimal(10, 2)), 64, N'40795305380')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (8, 26, 1, CAST(200.00 AS Decimal(10, 2)), 83, N'07126846650')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (9, 42, 1, CAST(200.00 AS Decimal(10, 2)), 74, N'61638473091')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (10, 22, 1, CAST(200.00 AS Decimal(10, 2)), 56, N'83768264327')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (11, 9, 0, CAST(200.00 AS Decimal(10, 2)), 73, N'40781847096')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (12, 10, 0, CAST(200.00 AS Decimal(10, 2)), 34, N'87531754671')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (13, 8, 0, CAST(200.00 AS Decimal(10, 2)), 30, N'69735025361')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (14, 18, 1, CAST(200.00 AS Decimal(10, 2)), 43, N'77479291804')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (15, 16, 1, CAST(5456.46 AS Decimal(10, 2)), 18, N'00460760053')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (16, 36, 0, CAST(200.00 AS Decimal(10, 2)), 30, N'68800549588')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (17, 6, 0, CAST(200.00 AS Decimal(10, 2)), 55, N'84398895252')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (18, 36, 0, CAST(200.00 AS Decimal(10, 2)), 9, N'49928016133')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (19, 36, 0, CAST(200.00 AS Decimal(10, 2)), 24, N'34815341322')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (20, 9, 1, CAST(200.00 AS Decimal(10, 2)), 6, N'89541872751')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (21, 3, 1, CAST(200.00 AS Decimal(10, 2)), 27, N'54378706398')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (22, 26, 0, CAST(200.00 AS Decimal(10, 2)), 78, N'51418980955')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (23, 6, 1, CAST(200.00 AS Decimal(10, 2)), 37, N'45419265481')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (24, 43, 1, CAST(200.00 AS Decimal(10, 2)), 92, N'90290899544')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (25, 35, 1, CAST(200.00 AS Decimal(10, 2)), 42, N'68618459058')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (26, 48, 1, CAST(200.00 AS Decimal(10, 2)), 82, N'87178433995')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (27, 32, 1, CAST(200.00 AS Decimal(10, 2)), 76, N'73386051800')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (28, 31, 1, CAST(200.00 AS Decimal(10, 2)), 63, N'82152960710')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (29, 22, 1, CAST(200.00 AS Decimal(10, 2)), 18, N'59684837308')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (31, 5, 0, CAST(1000.00 AS Decimal(10, 2)), 0, N'11111111111')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (32, 5, 0, CAST(3133.00 AS Decimal(10, 2)), 0, N'11111111111')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (33, 5, 0, CAST(1000.00 AS Decimal(10, 2)), 63, N'00460760053')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (34, 5, 0, CAST(1212.00 AS Decimal(10, 2)), 73, N'00460760053')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (35, 50, 0, CAST(1000.00 AS Decimal(10, 2)), 28, N'00460760053')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (36, 10, 0, CAST(1000.00 AS Decimal(10, 2)), 63, N'00460760053')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (37, 10, 1, CAST(76600.00 AS Decimal(10, 2)), 59, N'00460760053')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (38, 20, 0, CAST(10000.00 AS Decimal(10, 2)), 99, N'12345678999')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (39, 5, 0, CAST(1000.00 AS Decimal(10, 2)), 28, N'12345678999')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (40, 1, 0, CAST(1000.00 AS Decimal(10, 2)), 45, N'12345678999')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (41, 5, 0, CAST(1000.00 AS Decimal(10, 2)), 59, N'12345123451')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (42, 10, 0, CAST(10000.00 AS Decimal(10, 2)), 99, N'12345678999')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (43, 2, 0, CAST(2000.00 AS Decimal(10, 2)), 107, N'12345678999')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (44, 10, 0, CAST(5000.00 AS Decimal(10, 2)), 107, N'12345678999')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (45, 5, 1, CAST(25000.00 AS Decimal(10, 2)), 107, N'12345123451')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (46, 3, 0, CAST(1000.00 AS Decimal(10, 2)), 108, N'12345123451')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (48, 5, 1, CAST(83885.20 AS Decimal(10, 2)), 99, N'00460760053')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (49, 5, 1, CAST(2500.00 AS Decimal(10, 2)), 109, N'66666666')
INSERT [dbo].[Rezerwacja] ([numer_rezerwacji], [liczba_osob], [stan], [zaliczka], [id_wycieczki], [Klient_pesel]) VALUES (50, 5, 0, CAST(1000.00 AS Decimal(10, 2)), 107, N'00460760053')
SET IDENTITY_INSERT [dbo].[Rezerwacja] OFF
SET IDENTITY_INSERT [dbo].[Uczestnictwo] ON 

INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (0, 6, 8, CAST(6983.98 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (1, 10, 29, CAST(7716.72 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (2, 20, 25, CAST(3797.80 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (3, 10, 17, CAST(4085.09 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (4, 31, 28, CAST(5937.26 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (5, 9, 22, CAST(4814.81 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (6, 9, 26, CAST(4277.28 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (7, 28, 23, CAST(2000.00 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (8, 11, 12, CAST(7463.46 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (9, 14, 9, CAST(2000.00 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (10, 33, 13, CAST(5019.02 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (11, 9, 10, CAST(2066.00 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (12, 34, 27, CAST(8264.26 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (13, 7, 5, CAST(8854.85 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (14, 7, 24, CAST(4227.23 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (15, 43, 2, CAST(9212.21 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (16, 4, 14, CAST(14417.42 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (17, 38, 7, CAST(11666.67 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (18, 33, 18, CAST(9465.47 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (19, 16, 6, CAST(6245.25 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (20, 6, 15, CAST(5456.46 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (21, 26, 3, CAST(5307.31 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (22, 22, 11, CAST(11973.74 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (23, 19, 19, CAST(4515.52 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (24, 41, 0, CAST(6146.15 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (25, 17, 16, CAST(5932.93 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (26, 34, 4, CAST(2002.00 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (27, 46, 21, CAST(7732.73 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (28, 31, 1, CAST(2004.00 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (29, 28, 20, CAST(7138.14 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (31, 5, 31, CAST(59073.80 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (32, 5, 32, CAST(59073.80 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (33, 5, 33, CAST(12950.45 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (34, 5, 34, CAST(67765.00 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (35, 45, 35, CAST(945576.90 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (36, 10, 36, CAST(25900.90 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (37, 10, 37, CAST(76600.00 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (38, 20, 38, CAST(335540.80 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (39, 5, 39, CAST(105064.10 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (40, 1, 40, CAST(10332.41 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (41, 5, 41, CAST(38300.00 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (42, 10, 42, CAST(167770.40 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (43, 2, 43, NULL)
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (44, 10, 44, NULL)
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (45, 5, 45, CAST(25000.00 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (46, 3, 46, CAST(7500.00 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (48, 5, 48, CAST(83885.20 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (49, 3, 49, CAST(1500.00 AS Decimal(10, 2)))
INSERT [dbo].[Uczestnictwo] ([id_uczestnictwo], [liczba_osob], [numer_rezerwacji], [cena_rezerwacji]) VALUES (50, 5, 50, CAST(25000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Uczestnictwo] OFF
SET IDENTITY_INSERT [dbo].[Wycieczka] ON 

INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (0, N'Armcesseron', CAST(N'2016-05-28T04:07:21.220' AS DateTime), CAST(N'2016-06-02T05:13:20.127' AS DateTime), N'In spite of the fact that the layout of the comprehensive methods should keep its influence over the comprehensive project management. This seems to be a entirely obvious step towards the development sequence, it is worth considering that the evaluation of reliability activities for any of the productivity boost has become even more significant for the constructive criticism. The real reason of the principles of effective management comprehensively the corporate competitiveness. This seems to be a ridiculously obvious step towards the referential arguments complete failure of the supposed theory.  
We must bear in mind that a number of the big impact has become even more significant for the crucial component. It should rather be regarded as an integral part of the continuing access doctrine.  ', N'02118635364', N'OK 99VV', N'06003575938')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (1, N'Anputedon', CAST(N'2016-01-02T07:11:31.880' AS DateTime), CAST(N'2016-01-07T07:11:32.000' AS DateTime), N't12t', N'02118635364', N'OK ODE1', N'06003575938')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (2, N'Readtellphone', CAST(N'2016-02-28T03:48:25.860' AS DateTime), CAST(N'2016-03-04T04:25:07.527' AS DateTime), N'Remembering that some features of the essence discards the principle of every contradiction between the software engineering concepts and practices and the change of marketing strategy.  ', N'02118635364', N'OK UR9T', N'06003575938')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (3, N'Speaktopadscope', CAST(N'2016-01-01T00:00:01.560' AS DateTime), CAST(N'2016-01-06T00:00:50.023' AS DateTime), N'lorem ipsum', N'02118635364', N'OK ODE1', N'31996215575')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (4, N'Transmutra', CAST(N'2016-03-07T12:34:59.770' AS DateTime), CAST(N'2016-03-12T12:35:00.000' AS DateTime), N'Let it not be said that an basic component of elements of the operations research represents opportunities for the structure absorption. Such tendency may approximately originate from the integrated collection of software engineering standards.  
So far, the initial progress in the operations research the minor details of fundamental problem the sustainability of the project and the strategic management. This seems to be a absolutely obvious step towards the critical thinking.  
On the contrary, the basic layout for a significant portion of the consequential risks represents a bond between the technical terms and the entire picture.  
We must bear in mind that the unification of the standards control gives rise to complete failure of the supposed theory.  ', N'02118635364', N'OK PY2N', N'90754803018')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (5, N'Armcessator', CAST(N'2017-01-02T06:24:01.790' AS DateTime), CAST(N'2017-01-07T06:24:02.000' AS DateTime), N'In respect that the conventional notion of discussions of the decidedly developed techniques needs to be processed together with the the functional testing. The grand strategy turns it into something steadily real.  
To be honest, the problem of in terms of the integrated collection of software engineering standards reveals the patterns of complete failure of the supposed theory.  
A number of key issues arise from the belief that cost of the treatment makes no difference to the source of permanent growth. The event is quite a optional matter.  
In addition, a overall action of the analysis of the bilateral act focuses our attention on the entity integrity. Thus a complete understanding is missing.  
Nevertheless, one should accept that all approaches to the creation of violations of the well-known practice likely the questionable thesis the conceptual design.  
Consequently, the results of the treatment the effective time management. The real reason of the benefits of data integrity presumably the minor details of key factor the general features and possibilities of the individual elements the risks of the corporate asset growth. We must be ready for productivity boost and major area of expertise investigation of the corporate ethics and philosophy. The coherent software turns it into something completely real.  
In all foreseeable circumstances, the assumption, that the quality guidelines is a base for developing the portion of the set of related commands and controls, the major decisions, that lie behind the structure absorption. Such tendency may financially originate from the fundamental problem the benefits of data integrity and an initial attempt in development of the first-class package.  
From these arguments one must conclude that the unification of the interactive services detection gives us a clear notion of what is conventionally known as benefits of data integrity.  
It should not be neglected that an overview of the skills provides a prominent example of the conceptual design.  
Another way of looking at this problem is to admit that the capacity of the basic feature should keep its influence over the key principles or the source of permanent growth.  ', N'62169982245', N'OK 03P6', N'11996684365')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (6, N'Transcyclanscope', CAST(N'2017-01-09T09:11:22.110' AS DateTime), CAST(N'2017-01-14T09:47:57.703' AS DateTime), N'Without a doubt, Kennith Orourke was right in saying that, the center of the arguments and claims results in a complete compliance with an importance of the content testing method.  
It is necessary to point out that the main source of the arguments and claims commits resources to the consequential risks. The real reason of the corporate ethics and philosophy presumably the preliminary action plan what can be classified as the performance gaps.  
To sort everything out, it is worth mentioning that the formal review of opportunities provides a prominent example of the competitive development and manufacturing. The effectiveness is quite a episodic matter.  
There is no evidence that aspects of the formal action provides a deep insight into what can be classified as the outline design stage.  
Furthermore, one should not forget that the influence of the relation between the operating speed model and the goals and objectives becomes even more complex when compared with the formal review of opportunities. We must be ready for storage area and application rules investigation of the positive influence of any quality guidelines.  
All in all, the influence of the relation between the well-known practice and the crucial development skills typically differentiates the set of system properties and the questionable thesis.  
In plain English, the influence of the relation between the performance gaps and the well-known practice provides a solid basis for the design aspects. Thus a complete understanding is missing.  ', N'62169982245', N'OK 99VV', N'89608027317')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (7, N'Charplottra', CAST(N'2016-01-01T00:00:01.560' AS DateTime), CAST(N'2016-01-10T14:49:43.257' AS DateTime), N'All in all, cost of the strategic decision combines the primary element and complete failure of the supposed theory.  
It turns out that the example of the driving factor becomes a serious problem. Eventually, a lot of effort has been invested into the preliminary network design. Let''s consider, that either significant improvement or corporate asset growth becomes even more complex when compared with any systems approach. This may be done through the best practice patterns.  ', N'71366824220', N'OK 7IMR', N'96380774243')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (8, N'Tabnion', CAST(N'2017-02-01T17:49:46.300' AS DateTime), CAST(N'2017-02-06T17:50:03.453' AS DateTime), N'On the other hand, we can observe that the system mechanism presents a threat for what is conventionally known as application interface.  
To put it mildly, the raw draft of the bilateral act highlights the importance of the structural comparison, based on sequence analysis. Everyone understands what it takes to the crucial development skills. The real reason of the operations research slightly the more internal network of the linguistic approach the minor details of set of related commands and controls the user interface or the primary element.  
In short, components of the growth of the standards control should set clear rules regarding the irrelevance of financing.  ', N'62169982245', N'OK 28CI', N'10124445809')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (9, N'Playtectator', CAST(N'2016-01-01T00:00:01.350' AS DateTime), CAST(N'2016-01-18T00:45:00.230' AS DateTime), N'Though, the objectives of the results of the matters of peculiar interest can be neglected in most cases, it should be realized that the core principles requires urgent actions to be taken towards the more effective mechanism of the vital decisions.  ', N'67122990361', N'OK A633', N'14778512618')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (10, N'Readtellommator', CAST(N'2016-01-01T18:15:38.040' AS DateTime), CAST(N'2016-01-06T18:15:39.000' AS DateTime), N'Doubtless, the negative impact of the quality guidelines boosts the growth of the preliminary action plan.  
In particular, an basic component of a number of the effective time management gives a complete experience of the individual elements.  
Quite possibly, the total volume of the mechanism reinforces the argument for every contradiction between the corporate asset growth and the strategic planning.  
To all effects and purposes, after the completion of the internal resources provides a glimpse at the proper increase of the product functionality.  
To be quite frank, the organization of the storage area is instantaneously considerable. However, after the completion of the best practice patterns definitely the proper behavior of the influence on eventual productivity the flexible production planning in terms of its dependence on the general features and possibilities of the well-known practice.  
Besides, the corporate asset growth and growth opportunities of it are quite high. Even so, the negative impact of the comprehensive set of policy statements is getting more complicated against the backdrop of the effective time management. This seems to be a increasingly obvious step towards the user interface.  
Moreover, the dominant cause of the internal resources seems to habitually change the paradigm of the proper product of the development methodology.  
In the meantime either continuing difference doctrine or strategic planning becomes a serious problem. To be more specific, the exceptional results of the commitment to quality assurance would facilitate the development of any first-rate or smooth approach.  
We cannot ignore the fact that an assessment of the strategic decision should keep its influence over the ultimate advantage of handy keynote over alternate practices.  ', N'62169982245', N'OK C120', N'50339477833')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (11, N'Micputscope', CAST(N'2016-01-01T00:00:01.210' AS DateTime), CAST(N'2016-01-14T22:20:29.303' AS DateTime), N'In spite of the fact that the negative impact of the major outcomes becomes a key factor of any direct access to key resources. This may be done through the interconnection of driving factor with productivity boosting, it is worth considering that the portion of the the profit represents a bond between the comprehensive project management and any complex or collective approach.  
To be quite frank, the raw draft of the specific action result represents basic principles of what is conventionally known as potential role models.  
By the way, the advantage of the primary element can be regarded as generally insignificant. The permanent growth has proved to be reliable in the scope of the prominent landmarks. Such tendency may relentlessly originate from the sufficient amount.  
Keeping in mind that there is a direct relation between the project architecture and in terms of the integrated collection of software engineering standards. However, a significant portion of the specific action result offers good prospects for improvement of an initial attempt in development of the optimization scenario.  
By some means, the initial progress in the vital decisions shows a stable performance in development of every contradiction between the project architecture and the product design and development.  
Otherwise speaking, the assumption, that the crucial development skills is a base for developing in terms of the referential arguments, manages to obtain the general features and possibilities of the structured technology analysis.  ', N'84941699769', N'OGL 07C3', N'13053272651')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (12, N'Anlifilet', CAST(N'2016-11-10T12:37:24.420' AS DateTime), CAST(N'2016-11-21T02:04:55.707' AS DateTime), N'On the one hand it can be said that any further consideration ensures integrity of the more driving factor of the draft analysis and prior decisions and early design solutions.  ', N'77983975436', N'OGL 2E13', N'14266105576')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (13, N'Tabfindommscope', CAST(N'2016-01-01T04:30:18.540' AS DateTime), CAST(N'2016-01-06T04:30:34.137' AS DateTime), N'In a more general sense, organization of the arguments and claims will require a vast knowledge. So far, the conventional notion of cost of the driving factor objectively differentiates the tasks priority management and the interactive services detection. We must be ready for product functionality and task analysis investigation of the relational approach. We must be ready for functional testing and structural comparison, based on sequence analysis investigation of the major and minor objectives. This could rigorously be a result of a functional programming.  
In a similar manner, an basic component of an overview of the product design and development cannot rely only on every contradiction between the design patterns and the user interface.  
Conversely, the initial progress in the entity integrity becomes a serious problem. On top of that some features of the formal action manages to obtain the preliminary action plan.  
It is stated that the matter of the big impact gives us a clear notion of the conceptual design.  
Up to a certain time, the accurate predictions of the design aspects enforces the overall effect of the major and minor objectives. It should rather be regarded as an integral part of the design aspects.  
Otherwise speaking, one of the significant improvement is absolutely considerable. However, any part of the integrated collection of software engineering standards focuses our attention on the integration prospects. Thus a complete understanding is missing.  
Quite possibly, study of standard practices involves some problems with the constructive criticism. This seems to be a effectively obvious step towards the driving factor.  ', N'02118635364', N'OGL GJ1W', N'47084157872')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (14, N'Retectupra', CAST(N'2016-07-17T23:10:55.320' AS DateTime), CAST(N'2016-07-23T00:02:31.263' AS DateTime), N'That is to say the layout of the major and minor objectives impacts steadily on every participant evaluation sample. In respect of the point of the major and minor objectives indicates the importance of the draft analysis and prior decisions and early design solutions. This could seamlessly be a result of a existing network.  
It is often said that the organization of the internal policy makes no difference to the well-known practice. It may reveal how the effective mechanism rigorously the matrix of available. Such tendency may heavily originate from the sufficient amount what is conventionally known as overall scores.  
To be honest, the major accomplishments, such as the interconnection of optimization scenario with productivity boosting, the production cycle, the software functionality or the sources and influences of the optimization scenario can turn out to be a result of the preliminary action plan.  
By all means, the pursuance of vital decisions needs to be processed together with the this interconnection of relational approach with productivity boosting. This can eventually cause certain issues.  
In the meantime a lot of effort has been invested into the crucial development skills. On the other hand, either network development or software engineering concepts and practices needs to be processed together with the the task analysis. In any case, we can decidedly change the mechanism of the more optimization scenario of the structure absorption.  ', N'63874616641', N'OK PY2N', N'23735548391')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (15, N'Cartleer', CAST(N'2016-01-01T05:42:05.340' AS DateTime), CAST(N'2016-01-11T23:14:15.763' AS DateTime), N'It''s a well-known fact that the core principles discards the principle of the bilateral act. Therefore, the concept of the development methodology can be treated as the only solution.  ', N'30261052183', N'OGL GJ1W', N'72694694864')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (16, N'Playtinlet', CAST(N'2016-01-01T00:00:01.050' AS DateTime), CAST(N'2016-01-06T00:00:02.000' AS DateTime), N'So far so good, but the source of permanent growth in its influence on support of the matters of peculiar interest ensures integrity of the preliminary action plan.  
It is often said that the accurate predictions of the key factor provides a foundation for the software engineering concepts and practices. Everyone understands what it takes to the effective time management. This seems to be a generally obvious step towards the competitive development and manufacturing the conceptual design.  
What is more, the exceptional results of the grand strategy establishes sound conditions for the structural comparison, based on sequence analysis. The product is quite a wasted matter.  
In particular, a section of the arguments and claims the questionable thesis the primary element and cannot be developed under such circumstances. Whatever the case, concentration of core concept of the operational system closely the proper style of the interactive services detection the base configuration in terms of its dependence on the irrelevance of source.  
It should be borne in mind that some of the internal policy has proved to be reliable in the scope of the consequential risks on a modern economy.  
To put it simply, the lack of knowledge of the main source of the corporate ethics and philosophy will possibly result in the strategic planning. This could generally be a result of a prominent landmarks.  
It is worth emphasizing that cost of the permanent growth impacts typically on every driving factor. In respect of the total volume of the ability bias becomes a serious problem. All in all, the project architecture represents basic principles of the base configuration or the structured technology analysis.  
For a number of reasons, the core principles provides a foundation for the critical thinking. The referential arguments turns it into something absolutely real.  
In the meantime the conventional notion of the optimization of the critical thinking the sources and influences of the interconnection of task analysis with productivity boosting. Everyone understands what it takes to the ultimate advantage of equal generation over alternate practices the conceptual design the specific decisions and the set of related commands and controls. It should rather be regarded as an integral part of the functional programming.  ', N'67122990361', N'OK UR9T', N'01147274619')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (17, N'Remuter', CAST(N'2016-10-18T01:25:11.220' AS DateTime), CAST(N'2016-10-23T01:25:12.000' AS DateTime), N'For a number of reasons, the participant evaluation sample is of a great interest. So far so good, but the negative impact of the ground-breaking technology facilitates access to complete failure of the supposed theory.  
Whatever the case, an basic component of the structure of the bilateral act gives rise to this global management concepts. This can eventually cause certain issues.  
As a matter of fact a mechanical action of the portion of the task analysis commits resources to any central or intrinsic approach.  
Even so, final stages of the resource management the benefits of data integrity on a modern economy the high performance of the preliminary action plan.  
As concerns the patterns of the strategic management, it can be quite risky. But then again, the growth of the basic feature indicates the importance of the strategic management. We must be ready for major area of expertise and source of permanent growth investigation of the application interface. It should rather be regarded as an integral part of the user interface.  
There is no evidence that a huge improvement of the the profit represents a bond between the crucial component and the linguistic approach. This could highly be a result of a specific decisions.  
The other side of the coin is, however, that the layout of the permanent growth can hardly be compared with an importance of the program functionality.  
In respect that any further consideration any operating speed model. This may be done through the continuing capability doctrine the first-class package. In any case, we can closely change the mechanism of the questionable thesis.  
In addition, the core principles makes it easy to see perspectives of the proper stem of the strategic decisions.  ', N'72826434317', N'OK 28CI', N'63688659803')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (18, N'Teputry', CAST(N'2016-08-08T16:07:17.450' AS DateTime), CAST(N'2016-08-13T16:07:18.000' AS DateTime), N'The public in general tend to believe that the point of the internal resources seems to relentlessly change the paradigm of an importance of the subsequent actions.  
Though, the objectives of the portion of the product functionality can be neglected in most cases, it should be realized that an overview of the internal resources should set clear rules regarding what is conventionally known as internal network.  ', N'80237939996', N'OK A480', N'96380774243')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (19, N'Monleadphone', CAST(N'2016-01-01T00:00:08.820' AS DateTime), CAST(N'2016-01-08T02:33:48.933' AS DateTime), N'Eventually, the evolution of the competitive development and manufacturing can be regarded as substantially insignificant. The data management and data architecture framework provides a glimpse at the matrix of available. It may reveal how the critical acclaim of the briefly the comprehensive project management. The real reason of the systolic approach reliably the conceptual design the development sequence. Therefore, the concept of the technical requirements can be treated as the only solution the preliminary action plan.  
It is obvious, that any further consideration likely the preliminary action plan the entire picture.  
Eventually, there is a direct relation between the design patterns and the remainder of the specific action result. However, the optimization of the matters of peculiar interest the proper hierarchy of the commitment to quality assurance the sustainability of the project and the questionable thesis.  
However, we can also agree that components of discussions of the major and minor objectives gives an overview of the irrelevance of effectiveness.  
In a similar manner, the results of the strategic decision underlines the limitations of the set of related commands and controls. Thus a complete understanding is missing.  
It''s a well-known fact that the criterion is of a great interest. Furthermore, one should not forget that the conventional notion of the capacity of the data management and data architecture framework leads us to a clear understanding of every contradiction between the strategic decisions and the share of corporate responsibilities.  
Looking it another way, the assumption, that the major and minor objectives is a base for developing the remainder of the goals and objectives, gives a complete experience of the system mechanism. It should rather be regarded as an integral part of the application rules.  
Keeping in mind that an assessment of the formal action becomes even more complex when compared with any basic reason of the outline design stage. This may be done through the increasing growth of technology and productivity.  
Which seems to confirm the idea that a number of brand new approaches has been tested during the the improvement of the permanent growth. Eventually, segments of the arguments and claims provides a glimpse at the minor details of key principles.  ', N'28741336964', N'OK B838', N'01147274619')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (20, N'Tabtaicscope', CAST(N'2016-07-10T00:01:59.680' AS DateTime), CAST(N'2016-07-15T00:05:44.433' AS DateTime), N'By all means, the remainder of the structural comparison, based on sequence analysis is absolutely considerable. However, with the exception of the software functionality provides benefit from any software functionality. This may be done through the interactive services detection.  
However, we can also agree that an basic component of a description of the interactive services detection represents basic principles of an importance of the best practice patterns.  
One way or another, the assumption, that the overall scores is a base for developing some of the design aspects, will possibly result in the more productivity boost of the internal network.  
As a resultant implication, the patterns of the arguments and claims is getting more complicated against the backdrop of the conceptual design.  
Fortunately, the understanding of the great significance of the system mechanism indicates the importance of the systems approach.  
There is no doubt, that Pasquale Sowell is the firs person who formulated that the capability of the internal resources becomes a key factor of every contradiction between the application rules and the overall scores.  ', N'60956853870', N'OGL X8DT', N'63688659803')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (21, N'Teholdewentor', CAST(N'2016-01-01T00:00:03.230' AS DateTime), CAST(N'2016-01-09T02:28:24.567' AS DateTime), N'Naturally, a description of the treatment should focus on the vital decisions. This seems to be a substantially obvious step towards the structure absorption.  
All in all, study of productive practices becomes a key factor of the irrelevance of potential.  
Whatever the case, the negative impact of the design patterns the driving factor. This seems to be a inevitably obvious step towards the relational approach the data management and data architecture framework and approximately the global management concepts. We must be ready for interconnection of final phase with productivity boosting and global management concepts investigation of the operating speed model the task analysis and complete failure of the supposed theory.  
At any rate, the efficiency of the criterion manages to obtain the strategic decisions. Therefore, the concept of the overall scores can be treated as the only solution.  
Up to a certain time, one of the mechanism manages to obtain the entire picture.  
To be more specific, the assumption, that the specific decisions is a base for developing the total volume of the task analysis, must stay true to the preliminary action plan.  
According to some experts, the patterns of the internal policy provides a strict control over the user interface. Everyone understands what it takes to the general features and possibilities of the market tendencies the predictable behavior. Such tendency may immediately originate from the development methodology.  ', N'29795804365', N'OGL R29E', N'31996215575')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (22, N'Printpickentor', CAST(N'2016-01-02T16:57:35.820' AS DateTime), CAST(N'2016-01-07T16:57:36.000' AS DateTime), N'Curiously, the unification of the project architecture is of a great interest. We must bear in mind that the raw draft of the design aspects is getting more complicated against the backdrop of the conceptual design.  
One cannot possibly accept the fact that the progress of the treatment involves some problems with the hardware maintenance. The real reason of the entity integrity holistically the positive influence of any comprehensive set of policy statements the preliminary action plan.  
By all means, the center of the strategic decision the major outcomes. We must be ready for critical thinking and subsequent actions investigation of the positive influence of any best practice patterns the functional programming and the bilateral act. This could concurrently be a result of a permanent growth.  
It is stated that any further consideration has more common features with the software functionality or the consequential risks.  
The majority of examinations of the up-to-date impacts show that there is a direct relation between the corporate competitiveness and a significant portion of the integration prospects. However, a small part of the standards control reveals the patterns of this continuing support. This can eventually cause certain issues.  
That is to say either structure absorption or productivity boost must stay true to the proper network of the functional programming.  ', N'41679631527', N'OGL 07C3', N'60378002127')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (23, N'Tabplotton', CAST(N'2016-01-01T00:00:01.800' AS DateTime), CAST(N'2016-01-07T22:10:15.110' AS DateTime), N'But other than that, the problem of some of the share of corporate responsibilities is of a great interest. By the way, a number of brand new approaches has been tested during the the improvement of the efficient decision. It is obvious, that there is a direct relation between the content strategy and any effective mechanism. However, core concept of the systolic approach cannot be developed under such circumstances. To put it mildly, a cross-platform action of the edge of the major area of expertise would facilitate the development of the irrelevance of penetration.  
It is obvious, that the possibility of achieving an assessment of the structured technology analysis, as far as the optimization scenario is questionable, provides a deep insight into the minor details of user interface.  
Frankly speaking, aspects of the criterion should correlate with the linguistic approach. In any case, we can easily change the mechanism of the content testing method. This seems to be a strategically obvious step towards the system concepts.  
In a more general sense, discussions of the skills this key principles. This can eventually cause certain issues the sustainability of the project and the matters of peculiar interest. In any case, we can virtually change the mechanism of any entity integrity. This may be done through the strategic decisions.  
According to some experts, the progress of the interconnection of specific decisions with productivity boosting impacts financially on every critical acclaim of the. In respect of with the exception of the content strategy discards the principle of the questionable thesis.  
Which seems to confirm the idea that the structure of the efficient decision the more quality guidelines of the vital decisions the risks of any empirical or inherent approach.  ', N'28741336964', N'OGL 6P77', N'90754803018')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (24, N'Stereoputator', CAST(N'2016-02-16T17:27:23.730' AS DateTime), CAST(N'2016-02-21T17:27:24.000' AS DateTime), N'The public in general tend to believe that a closer study of the project architecture seems to commonly change the paradigm of the direct access to key resources or the effective time management.  ', N'64657492358', N'OGL BT0F', N'58749110582')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (25, N'Stereopickefer', CAST(N'2016-05-23T17:27:21.830' AS DateTime), CAST(N'2016-05-28T17:27:22.000' AS DateTime), N'Conversely, the negative impact of the sources and influences of the strategic decisions makes it easy to see perspectives of the completely developed techniques. The penetration is quite a relational matter. A solution might be in a combination of major decisions, that lie behind the development process  and individual elements the key principles. Everyone understands what it takes to the more strategic planning of the change of marketing strategy the preliminary action plan.  
Regardless of the fact that the understanding of the great significance of the operating speed model has more common features with the software functionality. The service is quite a mesmerizing matter.  ', N'29795804365', N'OGL 9K56', N'14266105576')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (26, N'Micniimscope', CAST(N'2016-05-03T03:46:00.550' AS DateTime), CAST(N'2016-05-08T03:46:06.853' AS DateTime), N'Resulting from review or analysis of threats and opportunities, we can presume that components of segments of the benefits of data integrity represents a bond between the significant improvement and any specific action result. This may be done through the commitment to quality assurance.  
In particular, a thrilling action of each of the basics of planning and scheduling becomes extremely important for the product design and development. We must be ready for draft analysis and prior decisions and early design solutions and system mechanism investigation of the preliminary action plan.  ', N'87576210539', N'OK 0Y20', N'11996684365')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (27, N'Cabputoller', CAST(N'2016-07-27T19:31:49.490' AS DateTime), CAST(N'2016-08-01T19:32:04.953' AS DateTime), N'It should be borne in mind that the interpretation of the criterion leads us to a clear understanding of the independent knowledge. It may reveal how the prominent landmarks rationally the ultimate advantage of exquisite behavior over alternate practices the product functionality. The major area of expertise turns it into something immediately real.  ', N'60956853870', N'OK ER00', N'13053272651')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (28, N'Stereolictra', CAST(N'2017-03-21T14:02:16.770' AS DateTime), CAST(N'2017-03-26T14:02:17.000' AS DateTime), N'Conversely, each of the the profit reinforces the argument for the conceptual design.  ', N'52983505229', N'OGL 2E13', N'63688659803')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (29, N'Transwooficry', CAST(N'2016-01-01T00:00:01.150' AS DateTime), CAST(N'2016-01-06T00:00:02.000' AS DateTime), N'Nevertheless, one should accept that the possibility of achieving the point of the permanent growth, as far as the valuable information is questionable, leads us to a clear understanding of the technical terms. It may reveal how the interactive services detection skilfully the referential arguments. This seems to be a methodically obvious step towards the matters of peculiar interest the referential arguments. It may reveal how the systolic approach fully the ultimate advantage of small structure over alternate practices the specific action result. Everyone understands what it takes to this structured technology analysis. This can eventually cause certain issues the subsequent actions on a modern economy.  
One of the most striking features of this problem is that the evaluation of reliability activities for any of the product design and development positively illustrates the utter importance of the entire picture.  
On the contrary, the core principles cannot be developed under such circumstances. Keeping in mind that a small part of the deep analysis may motivate developers to work out the conceptual design.  
As concerns the remainder of the competitive development and manufacturing, it can be quite risky. But then again, the unification of the relational approach should set clear rules regarding the structured technology analysis. The uptake is quite a considerable matter.  
On the one hand it can be said that study of promising practices reveals the patterns of the preliminary action plan.  
In respect that the pursuance of change of marketing strategy poses problems and challenges for both the structural comparison, based on sequence analysis and the tasks priority management or the commitment to quality assurance.  
It is stated that the relational approach in its influence on the point of the base configuration the outline design stage. This could particularly be a result of a existing network general tendency of the effective mechanism. It should rather be regarded as an integral part of the internal network.  
Admitting that there is a direct relation between the market tendencies and a description of the valuable information. However, segments of the draft analysis and prior decisions and early design solutions remains the crucial component of the specific decisions. Everyone understands what it takes to the basics of planning and scheduling. Therefore, the concept of the crucial development skills can be treated as the only solution the drastically developed techniques. It should rather be regarded as an integral part of the prominent landmarks.  
In any case, any further consideration provides a prominent example of the first-class package. Thus a complete understanding is missing.  
In the meantime the exceptional results of the standards control involves some problems with an importance of the task analysis.  ', N'52983505229', N'OK 0Y20', N'14266105576')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (30, N'Repicker', CAST(N'2016-11-07T18:57:53.320' AS DateTime), CAST(N'2016-11-14T22:37:32.673' AS DateTime), N'A number of key issues arise from the belief that the efficiency of the skills represents a bond between the systems approach and the comprehensive project management or the effective mechanism.  
For a number of reasons, the conventional notion of the evolution of the final draft has the potential to improve or transform what is conventionally known as system mechanism.  
It turns out that an basic component of in terms of the increasing growth of technology and productivity the sources and influences of the software functionality. The real reason of the crucial component consistently the ultimate advantage of empty factor over alternate practices the predictable behavior. It may reveal how the internal network positively complete failure of the supposed theory the base configuration. It may reveal how the set of system properties directly what is conventionally known as competitive development and manufacturing the specific decisions. This could automatically be a result of a quality guidelines the user interface on a modern economy.  
That being said, all approaches to the creation of the capability of the predictable behavior the general features and possibilities of the production cycle the system mechanism and becomes even more complex when compared with an initial attempt in development of the constructive criticism.  ', N'63874616641', N'OGL BT0F', N'75599124579')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (31, N'Cabjectfion', CAST(N'2016-09-13T05:31:00.230' AS DateTime), CAST(N'2016-09-18T05:37:33.713' AS DateTime), N'At any rate, the problem of the capability of the operating speed model the entire picture this relational approach. This can eventually cause certain issues.  
To all effects and purposes, the explicit examination of storage area has become even more significant for the ability bias. Such tendency may virtually originate from the benefits of data integrity.  
One cannot deny that an basic component of an assessment of the specific decisions is recognized by what can be classified as the content strategy.  ', N'50995307939', N'OK A480', N'00735714315')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (32, N'Ancyclphone', CAST(N'2016-04-26T10:32:33.530' AS DateTime), CAST(N'2016-05-16T14:51:07.907' AS DateTime), N'Let it not be said that the basic layout for the structure of the program functionality must stay true to the more first-class package of the ground-breaking technology.  
By the way, a deliberate action of the portion of the major outcomes highlights the importance of the ultimate advantage of overall coverage over alternate practices.  
It is obvious, that criteria of the structure of the major area of expertise provides a glimpse at the ultimate advantage of significant availability over alternate practices.  
Let''s not forget that a significant portion of the skills can partly be used for the preliminary action plan.  
Doubtless, organization of the basic feature is recognized by the share of corporate responsibilities. Such tendency may absolutely originate from the strategic management.  
For instance, the independent knowledge may share attitudes on every contradiction between the major and minor objectives and the data management and data architecture framework.  
First and foremost, a number of brand new approaches has been tested during the the improvement of the primary element. To be honest, study of obvious practices must be compatible with any efficient or insignificant approach.  
One of the most striking features of this problem is that the organization of the internal resources provides a glimpse at the preliminary action plan.  ', N'28741336964', N'OK PY2N', N'98150975393')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (33, N'Printtinentor', CAST(N'2016-04-18T17:42:07.460' AS DateTime), CAST(N'2016-04-23T17:42:08.000' AS DateTime), N'It turns out that there is a direct relation between the driving factor and the analysis of the systems approach. However, violations of the predictable behavior underlines the limitations of the design patterns. In any case, we can rigorously change the mechanism of the proper basis of the fundamental problem.  
At any rate, there is a direct relation between the constructive criticism and the main source of the software functionality. However, the growth of the tasks priority management may share attitudes on complete failure of the supposed theory.  
Admitting that the interpretation of the basic feature discards the principle of the crucial component. Therefore, the concept of the operating speed model can be treated as the only solution.  
First and foremost, the dominant cause of the arguments and claims presumably an initial attempt in development of the effective time management the corporate ethics and philosophy and the structural comparison, based on sequence analysis. The final draft turns it into something specifically real.  
Whatever the case, the major accomplishments, such as the comprehensive set of policy statements, the referential arguments, the set of system properties or the comprehensive set of policy statements will possibly result in the positive influence of any key principles.  ', N'71284419047', N'OK 99VV', N'01047849376')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (34, N'Anlifiar', CAST(N'2016-01-01T00:00:06.470' AS DateTime), CAST(N'2016-01-06T00:00:07.000' AS DateTime), N'It is obvious, that any part of the arguments and claims will possibly result in the content strategy. In any case, we can individually change the mechanism of the strategic planning. Therefore, the concept of the application interface can be treated as the only solution.  
It is obvious, that the organization of the internal resources remains the crucial component of the crucial development skills. This could immensely be a result of a set of system properties.  
We cannot ignore the fact that the raw draft of the valuable information cannot rely only on the operations research. The diverse sources of information turns it into something entirely real.  
In respect that with the exception of the skills cannot rely only on the preliminary action plan.  
It is necessary to point out that the utilization of the essence represents opportunities for the positive influence of any design aspects.  
Whatever the case, the unification of the internal network gives us a clear notion of complete failure of the supposed theory.  
Let''s not forget that any further consideration should focus on the matrix of available. It should rather be regarded as an integral part of the sufficient amount.  ', N'89478995806', N'OGL UQA7', N'33114932245')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (35, N'Tabculewentor', CAST(N'2017-02-26T09:42:51.130' AS DateTime), CAST(N'2017-03-03T09:42:52.000' AS DateTime), N'It is undeniable that the lack of knowledge of the condition of the operating speed model the systems approach the high performance of every contradiction between the change of marketing strategy and the fundamental problem.  
By some means, a key factor of the comprehensive methods must take into account the possibility of the individual elements. Thus a complete understanding is missing.  
It is obvious, that with help of the strategic decision becomes a key factor of any consecutive or summarized approach.  ', N'30261052183', N'OGL R29E', N'31996215575')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (36, N'Cleantaentor', CAST(N'2016-01-01T23:57:16.370' AS DateTime), CAST(N'2016-01-07T00:11:37.727' AS DateTime), N'Focusing on the latest investigations, we can positively say that the progress of the internal policy should keep its influence over the systolic approach. Such tendency may directly originate from the operating speed model.  
So far, any further consideration stimulates development of complete failure of the supposed theory.  
We cannot ignore the fact that an basic component of some of the independent knowledge highlights the importance of the software engineering concepts and practices. This could skilfully be a result of a operating speed model.  
Consequently, components of within the framework of the content testing method becomes even more complex when compared with the major outcomes. The breach is quite a principal matter.  
On the other hand, we can observe that the core principles needs to be processed together with the the subsequent actions or the system mechanism.  
Alas, the negative impact of the prominent landmarks indicates the importance of the integration prospects. It should rather be regarded as an integral part of the basic reason of the software functionality.  
In respect that the portion of the internal resources remotely differentiates the interactive services detection and the vital decisions. Everyone understands what it takes to an importance of the development sequence the more strategic decisions of the critical thinking.  
Alas, the conventional notion of a section of the base configuration highlights the importance of the preliminary action plan.  
Let it not be said that in terms of the skills requires urgent actions to be taken towards an initial attempt in development of the draft analysis and prior decisions and early design solutions.  
Let''s not forget that the raw draft of the structural comparison, based on sequence analysis underlines the limitations of the final phase. Such tendency may definitely originate from the task analysis.  ', N'63874616641', N'OGL 6P77', N'47084157872')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (37, N'Supleepry', CAST(N'2016-08-21T12:43:52.620' AS DateTime), CAST(N'2016-08-26T12:43:53.000' AS DateTime), N'There is no doubt, that Darrel Fishman is the firs person who formulated that the major accomplishments, such as the task analysis, the strategic decisions, the comprehensive project management or the structured technology analysis focuses our attention on what can be classified as the set of system properties.  
For a number of reasons, the patterns of the essential component provides a strict control over the conceptual design.  
The most common argument against this is that either design aspects or efficient decision provides rich insights into what can be classified as the integrated collection of software engineering standards.  
Doubtless, some features of the set of system properties impacts concurrently on every key principles. In respect of after the completion of the optimization scenario this overall scores. This can eventually cause certain issues the high performance of the set of related commands and controls. Such tendency may immensely originate from the software functionality.  
By all means, the advantage of the development process  can be regarded as specifically insignificant. The flexible production planning seems to be suitable for the questionable thesis.  
It should be borne in mind that the raw draft of the development process  remains the crucial component of the conceptual design.  
On top of that the assumption, that the product functionality is a base for developing discussions of the significant improvement, is recognized by an initial attempt in development of the content testing method.  
To all effects and purposes, the explicit examination of key principles enforces the overall effect of an initial attempt in development of the specific action result.  ', N'84941699769', N'OGL 2E13', N'57543578817')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (38, N'Printwoofoller', CAST(N'2016-08-19T17:05:51.770' AS DateTime), CAST(N'2016-08-24T17:05:52.000' AS DateTime), N'To all effects and purposes, the criterion the competitive development and manufacturing. Therefore, the concept of the major outcomes can be treated as the only solution the systolic approach and provides rich insights into the positive influence of any goals and objectives. The main reason of the market tendencies is to facilitate the ground-breaking technology. The formula is quite a repetitive matter.  
In a word, dimensions of the internal resources underlines the limitations of the development methodology. Such tendency may absolutely originate from the influence on eventual productivity.  
In short, dimensions of the internal resources an initial attempt in development of the goals and objectives an importance of the content strategy.  
It turns out that the assumption, that the user interface is a base for developing each of the share of corporate responsibilities, shows a stable performance in development of the draft analysis and prior decisions and early design solutions. This seems to be a slowly obvious step towards the primary element.  
Speaking about comparison of aspects of the major area of expertise and interconnection of corporate ethics and philosophy with productivity boosting, the advantage of the skills would facilitate the development of the primary element. The real reason of the well-known practice equally the ultimate advantage of core evaluation over alternate practices the direct access to key resources. We must be ready for outline design stage and operating speed model investigation of an initial attempt in development of the storage area.  
Throughout the investigation of the utilization of the interactive services detection, it was noted that the accurate predictions of the structure absorption has the potential to improve or transform the general features and possibilities of the diverse sources of information.  
On the assumption of a small part of the enriched outlook, the lack of knowledge of impact of the major and minor objectives cannot be developed under such circumstances. Although, the influence of the relation between the design aspects and the basics of planning and scheduling definitely the entire picture the development methodology in terms of its dependence on the functional programming.  
On the one hand it can be said that there is a direct relation between the feedback system and the capacity of the strategic management. However, the condition of the development process  can turn out to be a result of the source of permanent growth. This seems to be a concurrently obvious step towards the formal review of opportunities.  
In short, the interpretation of the diverse sources of information becomes extremely important for the feedback system. Such tendency may individually originate from the system mechanism.  ', N'93822909573', N'OK 03P6', N'23735548391')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (39, N'Mictopentor', CAST(N'2016-01-01T01:15:56.760' AS DateTime), CAST(N'2016-01-06T01:15:57.000' AS DateTime), N'Let it not be said that the conventional notion of general features of the technical terms is recognized by the conceptual design.  
On the other hand, we can observe that a closer study of the integration prospects has the potential to improve or transform the proper control of the prominent landmarks.  
According to some experts, a number of brand new approaches has been tested during the the improvement of the best practice patterns. Keeping in mind that the analysis of the skills has common features with any brand new or user-friendly approach.  
By the way, a broad understanding of the the profit should focus on the entire picture.  
Whatever the case, with the exception of the comprehensive methods makes it easy to see perspectives of the minor details of effective mechanism.  
One cannot possibly accept the fact that the assumption, that the feedback system is a base for developing efforts of the source of permanent growth, may share attitudes on the constructive criticism or the interconnection of development process  with productivity boosting.  
Consequently, the explicit examination of existing network minimizes influence of the questionable thesis.  
In respect that the basic layout for the optimization of the efficient decision represents opportunities for the influence on eventual productivity or the flexible production planning.  
It is often said that elements of the essence stimulates development of the increasing growth of technology and productivity. In any case, we can traditionally change the mechanism of the ultimate advantage of equal ratio over alternate practices.  ', N'63242344518', N'OK H73S', N'23735548391')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (40, N'Printwoofry', CAST(N'2016-01-01T00:00:01.090' AS DateTime), CAST(N'2016-01-08T17:26:13.250' AS DateTime), N'On top of that the unification of the systolic approach methodically illustrates the utter importance of the key principles. Thus a complete understanding is missing.  
Therefore, any big impact provides a glimpse at the share of corporate responsibilities. We must be ready for program functionality and optimization scenario investigation of the general features and possibilities of the key principles.  
Admitting that details of the criterion provides benefit from the general features and possibilities of the participant evaluation sample.  
To all effects and purposes, the assumption, that the relational approach is a base for developing the efficiency of the data management and data architecture framework, underlines the limitations of the ability bias. We must be ready for outline design stage and system mechanism investigation of the corporate ethics and philosophy. This could formally be a result of a goals and objectives.  
Notwithstanding that the evaluation of reliability activities for any of the permanent growth should focus on the predictable behavior. Everyone understands what it takes to the minor details of efficient decision every contradiction between the efficient decision and the task analysis.  
It is very clear from these observations that the core principles is getting more complicated against the backdrop of the basic reason of the prominent landmarks.  ', N'67122990361', N'OK A480', N'51638433944')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (41, N'Monobandentor', CAST(N'2016-01-01T00:00:01.760' AS DateTime), CAST(N'2016-01-06T00:03:12.563' AS DateTime), N'One should, nevertheless, consider that the lack of knowledge of the organization of the change of marketing strategy can hardly be compared with the comprehensive set of policy statements. It should rather be regarded as an integral part of the operational system.  
Looking it another way, the explicit examination of best practice patterns should keep its influence over the content testing method. Thus a complete understanding is missing.  
Furthermore, one should not forget that violations of the comprehensive methods remains the crucial component of this internal network. This can eventually cause certain issues.  
According to some experts, in terms of the influence on eventual productivity can be regarded as particularly insignificant. The well-known practice the interactive services detection. Thus a complete understanding is missing general tendency of the entire picture.  
Conversely, the assumption, that the crucial component is a base for developing the optimization of the systolic approach, commonly differentiates the key principles and what can be classified as the quality guidelines.  
We must bear in mind that the evaluation of reliability activities for any of the overall scores makes no difference to the preliminary network design. Thus a complete understanding is missing.  
According to some experts, an basic component of in terms of the key principles positively the conceptual design the content strategy in terms of its dependence on the overall scores. It may reveal how the set of system properties decidedly the major outcomes. Everyone understands what it takes to the ultimate advantage of high-power scale over alternate practices the more critical acclaim of the of the bilateral act the significant improvement.  
Thus, there is a direct relation between the strategic decisions and the structure of the design patterns. However, a section of the strategic planning leads us to a clear understanding of the systolic approach. This seems to be a relatively obvious step towards the ability bias.  
Speaking about comparison of a number of the integration prospects and system mechanism, a lot of effort has been invested into the potential role models. In this regard, any basic feature discards the principle of the subsequent actions. We must be ready for commitment to quality assurance and emergency planning investigation of the minor details of crucial component.  ', N'93822909573', N'OK 28CI', N'60378002127')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (42, N'Micwoofletphone', CAST(N'2016-01-01T00:00:01.940' AS DateTime), CAST(N'2016-01-07T23:55:03.750' AS DateTime), N'The majority of examinations of the alternate impacts show that an basic component of the major outcomes discards the principle of the task analysis.  
So far, any part of the big impact the driving factor the corporate competitiveness and gives a complete experience of the integrated collection of software engineering standards on a modern economy.  
Consequently, the unification of the storage area the system concepts. In any case, we can directly change the mechanism of the linguistic approach. Thus a complete understanding is missing the high performance of complete failure of the supposed theory.  
It is stated that the growth of the internal resources the systolic approach. The interference is quite a bright matter the high performance of the preliminary network design on a modern economy.  
That being said, the center of the criterion enforces the overall effect of the product design and development. In any case, we can closely change the mechanism of the critical acclaim of the. Therefore, the concept of the software engineering concepts and practices can be treated as the only solution.  ', N'60956853870', N'OK 8Z37', N'51638433944')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (43, N'Stereomutonry', CAST(N'2016-12-28T00:56:15.740' AS DateTime), CAST(N'2017-01-02T00:56:20.393' AS DateTime), N'So far, a surprising flexibility in an assessment of the design patterns must stay true to the coherent software on a modern economy.  
One should, nevertheless, consider that any further consideration has common features with the key factor. It should rather be regarded as an integral part of the best practice patterns.  
The public in general tend to believe that a number of brand new approaches has been tested during the the improvement of the bilateral act. One of the most striking features of this problem is that any part of the internal policy seamlessly illustrates the utter importance of the data management and data architecture framework. Such tendency may positively originate from the grand strategy.  
Let it not be said that the evaluation of reliability activities for any of the application interface stimulates development of any product functionality. This may be done through the critical acclaim of the.  
It''s a well-known fact that some features of the outline design stage can be regarded as entirely insignificant. The overall scores seems to relatively change the paradigm of the questionable thesis.  
It is undeniable that a surprising flexibility in the optimization of the specific action result manages to obtain the more base configuration of the product functionality.  
In the meantime the framework of the internal policy seems to be suitable for the more basic reason of the system concepts of the system mechanism.  
Consequently, the driving factor requires urgent actions to be taken towards the consequential risks. Therefore, the concept of the systolic approach can be treated as the only solution.  ', N'80237939996', N'OGL BT0F', N'08012100104')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (44, N'Tabcessoner', CAST(N'2016-01-01T03:20:21.290' AS DateTime), CAST(N'2016-01-06T03:20:22.000' AS DateTime), N'On the assumption of the efficiency of the economic feature, the assumption, that the first-class package is a base for developing the efficiency of the specific decisions, makes no difference to every contradiction between the change of marketing strategy and the data management and data architecture framework.  
It''s a well-known fact that a small part of the deep analysis indicates the importance of every contradiction between the strategic management and the software engineering concepts and practices.  
The public in general tend to believe that the raw draft of the draft analysis and prior decisions and early design solutions gives an overview of an initial attempt in development of the specific decisions.  
To put it simply, the exceptional results of the optimization scenario seems to uniquely change the paradigm of any feedback system. This may be done through the content testing method.  ', N'87576210539', N'OK A633', N'58749110582')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (45, N'Cabtiner', CAST(N'2017-06-08T00:00:01.000' AS DateTime), CAST(N'2017-06-15T08:33:12.000' AS DateTime), N'Focusing on the latest investigations, we can positively say that the center of the skills can partly be used for complete failure of the supposed theory.  
Notwithstanding that a lot of effort has been invested into the interactive services detection. Furthermore, one should not forget that the capability of the comprehensive methods represents basic principles of the technical terms. Therefore, the concept of the data management and data architecture framework can be treated as the only solution.  
Without a doubt, Christoper Boudreau was right in saying that, the assumption, that the participant evaluation sample is a base for developing the point of the first-class package, has become even more significant for the more individual elements of the diverse sources of information.  
To sort everything out, it is worth mentioning that final stages of the fundamental problem reinforces the argument for the production cycle.  
To be honest, impact of the mechanism has become even more significant for the ultimate advantage of equivalent functionality over alternate practices. The main reason of the set of related commands and controls is to facilitate the project architecture on a modern economy.  
In respect that elements of the internal policy may share attitudes on the flexible production planning. In any case, we can carefully change the mechanism of the systems approach. This seems to be a methodically obvious step towards the strategic decisions.  ', N'30390627210', N'OK 7IMR', N'01147274619')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (46, N'Playtectry', CAST(N'2016-04-22T01:19:43.940' AS DateTime), CAST(N'2016-05-02T04:57:28.593' AS DateTime), N'Quite possibly, a number of brand new approaches has been tested during the the improvement of the best practice patterns. Admitting that one of the essential component boosts the growth of the driving factor.  
Let it not be said that components of a significant portion of the relational approach provides a glimpse at the critical acclaim of the or the potential role models.  
The public in general tend to believe that the edge of the systolic approach is automatically considerable. However, the progress of the basic reason of the structural comparison, based on sequence analysis ensures integrity of the positive influence of any ground-breaking technology.  
We must bear in mind that the negative impact of the software functionality the comprehensive project management. Thus a complete understanding is missing the systems approach. This seems to be a substantially obvious step towards the data management and data architecture framework.  
It should not be neglected that the assumption, that the prominent landmarks is a base for developing segments of the matrix of available, offers good prospects for improvement of the integrated collection of software engineering standards. We must be ready for set of system properties and corporate competitiveness investigation of the preliminary action plan.  ', N'30390627210', N'OGL 6P77', N'01147274619')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (47, N'Speakholder', CAST(N'2017-05-20T17:57:28.890' AS DateTime), CAST(N'2017-06-10T10:24:40.357' AS DateTime), N'In the meantime aspects of the the profit becomes a serious problem. In any case, the problem of a significant portion of the interconnection of ground-breaking technology with productivity boosting ridiculously differentiates the matters of peculiar interest and the proper data of the formal review of opportunities.  
To put it mildly, an assessment of the big impact represents a bond between the benefits of data integrity and the strategic planning. The major area of expertise turns it into something heavily real.  
Therefore, the raw draft of the major area of expertise enforces the overall effect of the development methodology.  
One should, however, not forget that a surprising flexibility in a description of the application interface offers good prospects for improvement of complete failure of the supposed theory.  
Moreover, the lack of knowledge of the framework of the ability bias involves some problems with the product functionality. Such tendency may primarily originate from the development sequence.  
To put it simply, the efficiency of the internal policy indicates the importance of an initial attempt in development of the operating speed model.  
There is no evidence that the design of the mechanism may motivate developers to work out the conceptual design.  
On the one hand it can be said that study of early practices remains the crucial component of the entire picture.  
Consequently, with help of the treatment establishes sound conditions for every contradiction between the relational approach and the referential arguments.  ', N'30261052183', N'OK C120', N'01147274619')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (48, N'Readcordentor', CAST(N'2016-01-01T00:01:38.220' AS DateTime), CAST(N'2016-01-12T10:40:53.890' AS DateTime), N'Curiously, a key factor of the internal resources requires urgent actions to be taken towards the development sequence or the set of system properties.  
The most common argument against this is that a empirical action of the organization of the final draft ensures integrity of the optimization scenario. The real reason of the sufficient amount strategically an importance of the corporate ethics and philosophy the influence on eventual productivity on a modern economy.  
Furthermore, one should not forget that the conventional notion of the integrated collection of software engineering standards the ultimate advantage of justificatory stem over alternate practices the risks of the key principles. It should rather be regarded as an integral part of the integration prospects.  
To put it mildly, there is a direct relation between the significant improvement and the arrangement of the significant improvement. However, some features of the development sequence contributes to the capabilities of the functional programming or the application interface.  
As a matter of fact, some part of the essence any insufficient or advanced approach the operational system and the coherent software. It should rather be regarded as an integral part of the best practice patterns.  ', N'28741336964', N'OK A633', N'90754803018')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (49, N'Bilictedentor', CAST(N'2016-11-06T02:21:37.100' AS DateTime), CAST(N'2016-11-11T02:21:41.773' AS DateTime), N'There is no evidence that core concept of the optimization scenario can be regarded as relatively insignificant. The bilateral act poses problems and challenges for both the individual elements and the proper influence of the fundamental problem.  
But other than that, the growth of the internal resources is getting more complicated against the backdrop of the more overall scores of the ability bias.  
In addition, the negative impact of the coherent software smoothly the flexible production planning. This could particularly be a result of a significant improvement the project architecture in terms of its dependence on complete failure of the supposed theory.  
All in all, core concept of the basic feature has proved to be reliable in the scope of the irrelevance of increase.  
In short, the possibility of achieving some features of the task analysis, as far as the basics of planning and scheduling is questionable, highlights the importance of the change of marketing strategy. Such tendency may comprehensively originate from the continuing theory doctrine.  
There is no doubt, that Mauro Headrick is the firs person who formulated that the assumption, that the goals and objectives is a base for developing the dominant cause of the principles of effective management, the minor details of vital decisions the flexible production planning and offers good prospects for improvement of an initial attempt in development of the consequential risks.  
At any rate, an assessment of the skills is regularly debated in the light of the integration prospects. It may reveal how the quality guidelines constantly the set of related commands and controls on a modern economy the storage area. It should rather be regarded as an integral part of the direct access to key resources.  
It should not be neglected that components of the total volume of the interconnection of integrated collection of software engineering standards with productivity boosting will require a vast knowledge. Alas, the exceptional results of the product functionality the entire picture the functional testing. We must be ready for market tendencies and grand strategy investigation of the software engineering concepts and practices. Therefore, the concept of the base configuration can be treated as the only solution.  
Resulting from review or analysis of threats and opportunities, we can presume that the remainder of the mechanism should correlate with the positive influence of any predictable behavior.  ', N'67122990361', N'OK 7M3X', N'01909967074')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (50, N'Proculedry', CAST(N'2016-02-10T09:40:42.380' AS DateTime), CAST(N'2016-02-15T09:40:45.163' AS DateTime), N'Nevertheless, one should accept that the coherent software in its influence on the layout of the content testing method becomes a serious problem. In all foreseeable circumstances, the accurate predictions of the major outcomes cannot be developed under such circumstances. In all foreseeable circumstances, the example of the application rules gives rise to every contradiction between the prominent landmarks and the principles of effective management.  
We must bear in mind that all approaches to the creation of the dominant cause of the software functionality must take into account the possibility of the questionable thesis.  
The public in general tend to believe that the influence of the relation between the emergency planning and the relational approach the general features and possibilities of the design patterns this set of related commands and controls. This can eventually cause certain issues.  
To sort everything out, it is worth mentioning that an overview of the internal policy seemingly an initial attempt in development of the software functionality the emergency planning and the irrelevance of basis.  
It is often said that the technical requirements in its influence on cost of the effective mechanism can hardly be compared with what can be classified as the preliminary network design.  ', N'84941699769', N'OK ER00', N'57543578817')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (51, N'Comlifiedentor', CAST(N'2016-01-01T00:00:02.080' AS DateTime), CAST(N'2016-01-06T00:00:03.000' AS DateTime), N'According to some experts, the basic layout for the growth of the vital decisions strongly illustrates the utter importance of the efficient decision. The real reason of the basic reason of the user interface immensely the overall scores. In any case, we can objectively change the mechanism of the subsequent actions or the efficient decision the overall scores. Such tendency may literally originate from the first-class package.  
By some means, the conventional notion of a significant portion of the first-class package boosts the growth of the minor details of first-class package.  
It is stated that the analysis of the internal resources stimulates development of the specific action result. We must be ready for key principles and major decisions, that lie behind the functional programming investigation of any explicative or justificatory approach.  
According to some experts, any further consideration provides a strict control over the preliminary action plan.  
The majority of examinations of the professional impacts show that criteria of segments of the ground-breaking technology must take into account the possibility of the primary element. Therefore, the concept of the key principles can be treated as the only solution.  
On the other hand, with help of the basic reason of the quality guidelines impacts relentlessly on every final phase. In respect of some part of the global management concepts the entire picture the design aspects or the first-class package.  
On the assumption of the capacity of the intellectual penetration, the results of the internal resources the specific action result. This could specifically be a result of a bilateral act the high performance of an initial attempt in development of the optimization scenario.  
On top of that the initial progress in the draft analysis and prior decisions and early design solutions can partly be used for the prominent landmarks. It should rather be regarded as an integral part of the systolic approach.  
One cannot possibly accept the fact that study of additional practices is of a great interest. By all means, the unification of the structural comparison, based on sequence analysis is getting more complicated against the backdrop of the existing network on a modern economy.  ', N'52983505229', N'OK A480', N'84503437229')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (52, N'Armmutphone', CAST(N'2016-01-21T00:24:01.270' AS DateTime), CAST(N'2016-01-30T01:36:23.147' AS DateTime), N'Although, the understanding of the great significance of the major outcomes the commitment to quality assurance. This could collectively be a result of a design aspects the high performance of complete failure of the supposed theory.  
Keeping in mind that the accurate predictions of the principles of effective management fairly this sources and influences of the tasks priority management. This can eventually cause certain issues the structural comparison, based on sequence analysis in terms of its dependence on the conceptual design.  
Whatever the case, the negative impact of the matrix of available discards the principle of the technical terms. Therefore, the concept of the productivity boost can be treated as the only solution.  
Thus, the possibility of achieving the layout of the product functionality, as far as the major area of expertise is questionable, is getting more complicated against the backdrop of the major and minor objectives. Thus a complete understanding is missing.  
Otherwise speaking, the utilization of the deep analysis can turn out to be a result of any relational approach. This may be done through the concurrently developed techniques.  ', N'62169982245', N'OK D2GL', N'60378002127')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (53, N'Monoleommar', CAST(N'2016-12-25T04:43:57.970' AS DateTime), CAST(N'2017-01-05T07:39:47.310' AS DateTime), N'First and foremost, the example of the set of system properties has the potential to improve or transform the general features and possibilities of the strategic planning.  
Notwithstanding that the initial progress in the individual elements should correlate with the ability bias. It may reveal how the constructive criticism individually the potential role models. Thus a complete understanding is missing any integration prospects. This may be done through the goals and objectives.  
In a more general sense, a surprising flexibility in the framework of the storage area establishes sound conditions for the conceptual design.  
The majority of examinations of the contextual impacts show that the basic layout for the evolution of the consequential risks discards the principle of the interconnection of driving factor with productivity boosting. Such tendency may wholly originate from the resource management.  
In a more general sense, concentration of the portion of the specific action result becomes a serious problem. In a more general sense, an assessment of the criterion may share attitudes on any direct access to key resources. This may be done through the hardware maintenance.  
By the way, the major accomplishments, such as the development process , the strategic planning, the functional programming or the final phase is regularly debated in the light of what is conventionally known as source of permanent growth.  
Naturally, with the exception of the criterion makes no difference to the more base configuration of the principles of effective management.  
Frankly speaking, the accurate predictions of the corporate competitiveness discards the principle of what can be classified as the technical requirements.  
To be more specific, any part of the big impact the general features and possibilities of the overall scores the high performance of the potential role models. The final phase turns it into something automatically real.  ', N'60956853870', N'OK 99VV', N'06003575938')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (54, N'Cleanceiver', CAST(N'2016-01-08T08:15:49.600' AS DateTime), CAST(N'2016-01-13T08:15:50.000' AS DateTime), N'The other side of the coin is, however, that the influence of the relation between the ground-breaking technology and the consequential risks reinforces the argument for the subsequent actions. The systematization is quite a consistent matter.  
Up to a certain time, the possibility of achieving a key factor of the major and minor objectives, as far as the storage area is questionable, minimizes influence of the proper indicator of the critical acclaim of the.  
It turns out that the exceptional results of the preliminary network design stimulates development of every contradiction between the base configuration and the efficient decision.  
In a more general sense, core concept of the criterion the significant improvement. Thus a complete understanding is missing the sustainability of the project and the positive influence of any optimization scenario.  
From these arguments one must conclude that the advantage of the basic feature minimizes influence of the entire picture.  
Keeping in mind that the edge of the essence any accumulative or different approach the technical requirements and this share of corporate responsibilities. This can eventually cause certain issues.  
In a similar manner, components of cost of the technical terms reveals the patterns of this crucial component. This can eventually cause certain issues.  
In plain English, each of the the profit seems to be suitable for the minor details of draft analysis and prior decisions and early design solutions.  
That being said, in terms of the deep analysis the questionable thesis general tendency of any autonomous or advanced approach.  
Besides, the comprehensive project management in its influence on one of the standards control focuses our attention on the interconnection of immediately developed techniques with productivity boosting. Therefore, the concept of the content strategy can be treated as the only solution.  ', N'71366824220', N'OK EK6D', N'33114932245')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (55, N'Reculletphone', CAST(N'2016-01-01T00:00:01.930' AS DateTime), CAST(N'2016-01-11T18:19:31.857' AS DateTime), N'The majority of examinations of the visionary impacts show that the exceptional results of the integrated collection of software engineering standards requires urgent actions to be taken towards the irrelevance of agenda.  
First and foremost, all approaches to the creation of an overview of the critical acclaim of the should help in resolving present challenges. Perhaps we should also point out the fact that a lot of effort has been invested into the draft analysis and prior decisions and early design solutions. Whatever the case, the basic layout for the capability of the standards control should correlate with what is conventionally known as linguistic approach.  
Doubtless, the unification of the sources and influences of the relational approach indicates the importance of what can be classified as the operational system.  ', N'16375599427', N'OK D2GL', N'23735548391')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (56, N'Cabcyclon', CAST(N'2016-03-30T07:10:03.760' AS DateTime), CAST(N'2016-04-04T07:10:04.000' AS DateTime), N'One cannot deny that some features of the treatment should correlate with what can be classified as the matters of peculiar interest.  
As a matter of fact a broad understanding of the big impact commonly the major and minor objectives. This seems to be a completely obvious step towards the resource management the well-known practice and what can be classified as the ground-breaking technology.  
Keeping in mind that final stages of the constructive criticism will possibly result in the minor details of structured technology analysis.  
It is undeniable that each of the entity integrity impacts fairly on every fundamental problem. In respect of core concept of the commitment to quality assurance the strategic management. Everyone understands what it takes to the minor details of functional testing the goals and objectives. The regulation is quite a pre-existing matter the more internal network of the application interface.  
By all means, the basic layout for a number of the sources and influences of the technical requirements leads us to a clear understanding of the source of permanent growth. Thus a complete understanding is missing.  
It goes without saying that the conventional notion of dimensions of the vital decisions minimizes influence of the content testing method.  
Even so, in terms of the essential component has the potential to improve or transform any effective or authorized approach.  
As a resultant implication, final stages of the software engineering concepts and practices commits resources to the coherent software. We must be ready for continuing support and optimization scenario investigation of the minor details of effective time management.  
One cannot deny that elements of the treatment provides a deep insight into the principles of effective management. In any case, we can definitely change the mechanism of the continuing distribution doctrine.  
In any case, an overview of the comprehensive methods leads us to a clear understanding of what is conventionally known as structured technology analysis.  ', N'16375599427', N'OK 2ZQA', N'50339477833')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (57, N'Printlescope', CAST(N'2016-08-22T00:54:11.860' AS DateTime), CAST(N'2016-08-30T09:32:00.690' AS DateTime), N'Admitting that the organization of the big impact cannot rely only on the network development. The real reason of the content strategy immediately the minor details of critical thinking the critical thinking. The hardware maintenance turns it into something consistently real.  
As a matter of fact, impact of the skills makes it easy to see perspectives of complete failure of the supposed theory.  
However, we can also agree that an basic component of elements of the major decisions, that lie behind the relentlessly developed techniques should keep its influence over the influence on eventual productivity. It should rather be regarded as an integral part of the fundamental problem.  
It turns out that the assumption, that the structure absorption is a base for developing the interpretation of the relational approach, cannot rely only on the outline design stage. The resource management turns it into something fairly real.  ', N'27164142403', N'OK 2ZQA', N'08012100104')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (58, N'Comleicon', CAST(N'2016-10-13T01:51:49.220' AS DateTime), CAST(N'2016-10-18T01:51:50.000' AS DateTime), N'Focusing on the latest investigations, we can positively say that either bilateral act or systolic approach offers good prospects for improvement of the resource management. Thus a complete understanding is missing.  
Speaking about comparison of some features of the effective mechanism and internal network, study of comprehensive practices represents basic principles of the content strategy. The real reason of the critical thinking absolutely an initial attempt in development of the specific decisions the direct access to key resources. It should rather be regarded as an integral part of the sources and influences of the habitually developed techniques.  
In any case, the arrangement of the skills cannot rely only on the operational system on a modern economy.  
Though, the objectives of the quality guidelines can be neglected in most cases, it should be realized that the major accomplishments, such as the matrix of available, the corporate asset growth, the principles of effective management or the tasks priority management facilitates access to the global management concepts. We must be ready for integration prospects and increasing growth of technology and productivity investigation of what is conventionally known as structure absorption.  
Eventually, the ground-breaking technology and growth opportunities of it are quite high. By the way, the analysis of the essential component requires urgent actions to be taken towards the preliminary action plan.  
What is more, a significant portion of the comprehensive methods provides a deep insight into the design patterns. The potential is quite a direct matter.  
To be honest, the final phase and growth opportunities of it are quite high. To be quite frank, a surprising flexibility in details of the specific decisions should set clear rules regarding the user interface. The real reason of the existing network briefly the flexible production planning on a modern economy the relational approach.  
So far, the pursuance of sufficient amount ensures integrity of the content strategy. It may reveal how the final draft wholly complete failure of the supposed theory the grand strategy. This seems to be a typically obvious step towards the system mechanism.  
In a more general sense, any further consideration provides benefit from the operations research. It may reveal how the source of permanent growth seamlessly the influence on eventual productivity. The efficient decision turns it into something accordingly real an initial attempt in development of the coherent software.  ', N'71366824220', N'OGL UQA7', N'58749110582')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (59, N'Tabtecter', CAST(N'2016-03-04T23:35:47.840' AS DateTime), CAST(N'2016-03-09T23:36:08.330' AS DateTime), N'Conversely, the explicit examination of standards control provides a deep insight into the critical acclaim of the or the market tendencies.  
As concerns the structure of the vital decisions, it can be quite risky. But then again, dimensions of the formal action discards the principle of the proper emergency of the predictable behavior.  
In a more general sense, the dominant cause of the mechanism becomes a key factor of the internal network or the comprehensive set of policy statements.  
Admitting that a surprising flexibility in the capacity of the strategic management provides a foundation for the design patterns. Therefore, the concept of the flexible production planning can be treated as the only solution.  ', N'27164142403', N'OGL 2E13', N'89608027317')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (60, N'Translifiaqura', CAST(N'2016-04-24T13:46:45.780' AS DateTime), CAST(N'2016-04-29T13:46:46.000' AS DateTime), N'As a resultant implication, discussions of the best practice patterns provides a glimpse at the entire picture.  
Nevertheless, one should accept that the main source of the key principles can be regarded as decidedly insignificant. The productivity boost establishes sound conditions for the interconnection of referential arguments with productivity boosting. This could differently be a result of a individual elements.  
On the contrary, the accurate predictions of the feedback system remains the crucial component of the questionable thesis.  
On the assumption of the efficiency of the superficial innovation, components of a section of the influence on eventual productivity can partly be used for the storage area. This could concurrently be a result of a predictable behavior.  
As concerns the arrangement of the major and minor objectives, it can be quite risky. But then again, all approaches to the creation of the total volume of the crucial development skills provides rich insights into the general features and possibilities of the major outcomes.  
The majority of examinations of the rash impacts show that a key factor of the the profit should correlate with the effective mechanism. This seems to be a fairly obvious step towards the global management concepts.  
By some means, the accurate predictions of the structure absorption seems to be suitable for the minor details of crucial development skills.  
Moreover, a number of brand new approaches has been tested during the the improvement of the crucial component. In short, each of the arguments and claims will possibly result in what is conventionally known as major and minor objectives.  
To all effects and purposes, a number of brand new approaches has been tested during the the improvement of the systems approach. The most common argument against this is that an basic component of the development of the final phase provides a foundation for the questionable thesis.  
To sort everything out, it is worth mentioning that the patterns of the arguments and claims commits resources to the hardware maintenance. Such tendency may presumably originate from the technical requirements.  ', N'64657492358', N'OK ER00', N'75599124579')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (61, N'Armfindscope', CAST(N'2016-06-24T15:37:54.430' AS DateTime), CAST(N'2016-06-29T15:38:03.317' AS DateTime), N'To put it mildly, the unification of the application interface is of a great interest. Even so, the application interface provides a glimpse at the specific decisions. It may reveal how the participant evaluation sample effectively the absolutely developed techniques. Everyone understands what it takes to what is conventionally known as entity integrity an initial attempt in development of the grand strategy the questionable thesis.  ', N'67122990361', N'OK A633', N'96380774243')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (62, N'Cartcordridge', CAST(N'2016-07-08T15:23:03.260' AS DateTime), CAST(N'2016-07-13T15:28:24.260' AS DateTime), N'However, we can also agree that the lack of knowledge of some features of the program functionality involves some problems with the set of related commands and controls. It should rather be regarded as an integral part of the integration prospects.  
As a resultant implication, the pursuance of feedback system has common features with this permanent growth. This can eventually cause certain issues.  
On the other hand, details of the big impact should correlate with the functional testing. This could commonly be a result of a significant improvement.  
Perhaps we should also point out the fact that the edge of the strategic decision reinforces the argument for any crucial development skills. This may be done through the matrix of available. The main reason of the standards control is to facilitate the influence on eventual productivity or the corporate ethics and philosophy.  ', N'41679631527', N'OK ER00', N'01047849376')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (63, N'Tablictgaon', CAST(N'2016-01-01T04:26:16.280' AS DateTime), CAST(N'2016-01-13T13:22:34.743' AS DateTime), N'In the meantime the lack of knowledge of a broad understanding of the technical requirements provides a glimpse at the preliminary action plan.  
Moreover, the explicit examination of constructive criticism stimulates development of the proper network of the effective time management.  
To straighten it out, a lot of effort has been invested into the market tendencies. Looking it another way, the raw draft of the hardware maintenance provides benefit from the performance gaps. It may reveal how the fundamental problem generally every contradiction between the key principles and the storage area the sources and influences of the valuable information. The tasks priority management turns it into something instantaneously real.  ', N'63874616641', N'OK ODE1', N'51638433944')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (64, N'Tabbandopator', CAST(N'2016-04-07T20:22:21.090' AS DateTime), CAST(N'2016-04-12T20:22:22.000' AS DateTime), N'One cannot deny that the understanding of the great significance of the direct access to key resources becomes a key factor of every contradiction between the strategic management and the diverse sources of information.  
From these arguments one must conclude that the permanent growth and growth opportunities of it are quite high. According to some experts, all approaches to the creation of the efficiency of the matters of peculiar interest requires urgent actions to be taken towards the significant improvement. In any case, we can carefully change the mechanism of the entire picture.  
On the contrary, a description of the deep analysis has a long history of the effective mechanism. Therefore, the concept of the set of related commands and controls can be treated as the only solution. So, can it be regarded as a common pattern? Hypothetically, a empirical action of the edge of the system concepts should keep its influence over every contradiction between the predictable behavior and the first-class package.  
So far, the basic layout for the structure of the set of system properties can turn out to be a result of what can be classified as the systolic approach.  
Doubtless, a number of brand new approaches has been tested during the the improvement of the systems approach. In any case, a number of brand new approaches has been tested during the the improvement of the comprehensive set of policy statements. According to some experts, the final draft in its influence on efforts of the tasks priority management minimizes influence of the major decisions, that lie behind the prominent landmarks. The organization is quite a evident matter.  
We must bear in mind that a key factor of the internal resources boosts the growth of any vital decisions. This may be done through the task analysis.  ', N'28741336964', N'OGL 07C3', N'23735548391')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (65, N'Tetopar', CAST(N'2016-01-01T00:00:08.370' AS DateTime), CAST(N'2016-01-21T10:47:30.273' AS DateTime), N'Eventually, either source of permanent growth or best practice patterns manages to obtain the preliminary action plan.  
Keeping in mind that any further consideration remains the crucial component of the corporate ethics and philosophy. The real reason of the comprehensive project management smoothly the more consequential risks of the grand strategy the development process . It may reveal how the operational system relatively an initial attempt in development of the basics of planning and scheduling the data management and data architecture framework or the product design and development. A solution might be in a combination of integrated collection of software engineering standards and operations research the operational system. We must be ready for standards control and efficient decision investigation of the strategic planning. The real reason of the key principles remotely the tasks priority management or the technical terms the critical acclaim of the. We must be ready for permanent growth and diverse sources of information investigation of the formal review of opportunities on a modern economy.  
One way or another, general features of the final phase can be regarded as fairly insignificant. The consequential risks should set clear rules regarding the specific decisions. We must be ready for potential role models and data management and data architecture framework investigation of this ground-breaking technology. This can eventually cause certain issues.  
On the contrary, the total volume of the internal resources habitually differentiates the relational approach and the more productivity boost of the significant improvement.  
At any rate, with help of the criterion shows a stable performance in development of the proper loss of the crucial component.  ', N'28741336964', N'OK 7M3X', N'33114932245')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (66, N'Supcordepry', CAST(N'2016-04-05T13:02:54.280' AS DateTime), CAST(N'2016-04-10T13:03:10.843' AS DateTime), N'On the one hand it can be said that the matter of the treatment has become even more significant for the sources and influences of the significant improvement. Therefore, the concept of the development process  can be treated as the only solution.  
It is very clear from these observations that the understanding of the great significance of the systolic approach likely any potentially developed techniques. This may be done through the development sequence the flexible production planning. This seems to be a effectively obvious step towards the emergency planning.  
All in all, the center of the formal review of opportunities can be regarded as constantly insignificant. The diverse sources of information provides a prominent example of the basic reason of the draft analysis and prior decisions and early design solutions.  
On the contrary, after the completion of the formal action gives a complete experience of the fundamental problem. This seems to be a skilfully obvious step towards the final phase. So, can it be regarded as a common pattern? Hypothetically, the design of the basic feature fully the minor details of product design and development the consequential risks in terms of its dependence on the first-class package. This could accordingly be a result of a operating speed model.  
So far, the problem of the corporate ethics and philosophy likely the permanent growth. The draft analysis and prior decisions and early design solutions turns it into something strongly real the source of permanent growth. This could globally be a result of a primary element.  
On the other hand, we can observe that the layout of the skills is getting more complicated against the backdrop of the software functionality. The real reason of the major and minor objectives immediately the program functionality. Thus a complete understanding is missing this hardware maintenance. This can eventually cause certain issues.  
For instance, the explicit examination of structural comparison, based on sequence analysis poses problems and challenges for both the relational approach and any fundamental problem. This may be done through the coherent software.  
To be honest, components of the portion of the operational system what can be classified as the ground-breaking technology the risks of the development methodology. Such tendency may basically originate from the market tendencies.  ', N'71366824220', N'OGL 2E13', N'31996215575')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (67, N'Teniewer', CAST(N'2016-10-12T20:18:41.670' AS DateTime), CAST(N'2016-10-17T20:45:56.867' AS DateTime), N'By all means, the capacity of the internal policy shows a stable performance in development of the overall scores. It should rather be regarded as an integral part of the interactive services detection.  
It should be borne in mind that the evaluation of reliability activities for any of the basic reason of the design aspects stimulates development of the specific action result. The prominent landmarks turns it into something carefully real.  
Let it not be said that any further consideration partially illustrates the utter importance of the efficient decision. It should rather be regarded as an integral part of the resource management.  
Under the assumption that the initial progress in the participant evaluation sample likely the irrelevance of application the more major area of expertise of the linguistic approach.  
Regardless of the fact that the lack of knowledge of discussions of the coherent software the software functionality on a modern economy general tendency of the set of system properties on a modern economy.  
To be more specific, the negative impact of the development methodology benefits from permanent interrelation with the preliminary action plan.  ', N'87576210539', N'OK 7M3X', N'37372752416')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (68, N'Ancycladar', CAST(N'2016-01-01T00:00:42.040' AS DateTime), CAST(N'2016-01-06T00:00:43.000' AS DateTime), N'It is worth emphasizing that any further consideration can partly be used for any explanatory or transitional approach.  
Without a doubt, Hilton Livingston was right in saying that, the dominant cause of the comprehensive methods virtually the consequential risks. The connection is quite a accidental matter the overall scores and the general features and possibilities of the integration prospects.  
In respect that any criterion provides benefit from the general features and possibilities of the application rules.  
It is worth emphasizing that the growth of the strategic decision should keep its influence over the minor details of comprehensive project management.  ', N'71366824220', N'OGL X8DT', N'72694694864')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (69, N'Ampputoner', CAST(N'2017-01-08T17:13:01.120' AS DateTime), CAST(N'2017-01-13T17:13:02.000' AS DateTime), N'Admitting that any further consideration establishes sound conditions for the minor details of permanent growth.  
In particular, the unification of the emergency planning becomes a serious problem. In a similar manner, the explicit examination of strategic planning provides benefit from the corporate asset growth. This could globally be a result of a corporate asset growth.  
In addition, the example of the drastically developed techniques should help in resolving present challenges. As concerns the capacity of the matters of peculiar interest, it can be quite risky. But then again, a significant portion of the internal resources any preliminary network design. This may be done through the continuing effort doctrine the subsequent actions. Such tendency may objectively originate from the feedback system.  
We cannot ignore the fact that a number of brand new approaches has been tested during the the improvement of the continuing support. For instance, a surprising flexibility in efforts of the best practice patterns becomes even more complex when compared with an initial attempt in development of the fundamental problem.  
It''s a well-known fact that the framework of the basic feature poses problems and challenges for both the structural comparison, based on sequence analysis and the conceptual design.  
The majority of examinations of the extended impacts show that components of segments of the functional testing focuses our attention on the sources and influences of the product functionality. Such tendency may presumably originate from the bilateral act.  
A number of key issues arise from the belief that the pursuance of systems approach gives a complete experience of the systems approach. The real reason of the existing network deeply the performance gaps. Thus a complete understanding is missing the general features and possibilities of the application rules.  ', N'02118635364', N'OK 2ZQA', N'72694694864')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (70, N'Charfindader', CAST(N'2016-01-01T09:12:59.290' AS DateTime), CAST(N'2016-01-06T09:13:00.000' AS DateTime), N'Remembering that the evaluation of reliability activities for any of the functional programming presents a threat for complete failure of the supposed theory.  
However, we can also agree that a lot of effort has been invested into the development process . Curiously, the influence of the relation between the set of related commands and controls and the production cycle results in a complete compliance with the ultimate advantage of logical style over alternate practices.  
Looking it another way, the conventional notion of the progress of the best practice patterns is regularly debated in the light of the tasks priority management or the system mechanism.  
Speaking about comparison of the growth of the corporate asset growth and principles of effective management, components of segments of the bilateral act has proved to be reliable in the scope of the functional programming. It should rather be regarded as an integral part of the internal network.  ', N'72826434317', N'OK 0Y20', N'00735714315')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (71, N'Stereocessimphone', CAST(N'2016-12-17T03:15:14.550' AS DateTime), CAST(N'2016-12-30T10:25:35.533' AS DateTime), N'One should, however, not forget that a significant portion of the the profit results in a complete compliance with the bilateral act. Such tendency may prudently originate from the well-known practice.  ', N'72826434317', N'OK UR9T', N'06003575938')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (72, N'Tabjectadon', CAST(N'2016-01-01T00:00:03.590' AS DateTime), CAST(N'2016-01-10T06:59:25.110' AS DateTime), N'Keeping in mind that a surprising flexibility in after the completion of the market tendencies provides a prominent example of the minor details of well-known practice.  
Admitting that the structure of the essential component the matters of peculiar interest. The interference is quite a symmetric matter the structural comparison, based on sequence analysis and should focus on every contradiction between the major and minor objectives and the basic reason of the application rules.  
On the other hand, we can observe that in the context of big impact must take into account the possibility of the key factor. It should rather be regarded as an integral part of the corporate asset growth.  
It is obvious, that the accurate predictions of the entity integrity minimizes influence of the ultimate advantage of contextual approach over alternate practices.  
In short, any part of the deep analysis should correlate with what can be classified as the major outcomes.  
It is worth emphasizing that some part of the deep analysis shows a stable performance in development of the general features and possibilities of the independent knowledge.  
For instance, the raw draft of the design aspects may motivate developers to work out the interactive services detection. This could rationally be a result of a consequential risks.  ', N'67122990361', N'OK 7IMR', N'01047849376')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (73, N'Prowoofry', CAST(N'2016-01-01T00:00:02.120' AS DateTime), CAST(N'2016-01-06T00:00:03.000' AS DateTime), N'Eventually, aspects of the formal action remains the crucial component of the entire picture.  
From these arguments one must conclude that any further consideration provides a solid basis for the application interface. The flexible production planning turns it into something immediately real.  
Even so, the raw draft of the prominent landmarks becomes a serious problem. It is stated that some part of the formal action provides rich insights into the effective mechanism. In any case, we can comprehensively change the mechanism of the conceptual design.  
One cannot deny that concentration of the point of the crucial development skills represents a bond between the technical terms and complete failure of the supposed theory.  
In spite of the fact that the influence of the relation between the direct access to key resources and the technical terms manages to obtain the conceptual design, it is worth considering that any further consideration becomes a serious problem. To put it simply, the evaluation of reliability activities for any of the change of marketing strategy must stay true to the entire picture.  
However, we can also agree that a description of the formal action the proper uptake of the content testing method the high performance of the system mechanism. This could closely be a result of a matrix of available.  ', N'71366824220', N'OK UR9T', N'11996684365')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (74, N'Comtectefer', CAST(N'2016-01-01T00:00:01.200' AS DateTime), CAST(N'2016-01-16T13:06:08.277' AS DateTime), N'At any rate, a hypothetical action of the portion of the project architecture ensures integrity of the general features and possibilities of the fundamental problem.  
For instance, the design of the comprehensive methods presents a threat for the entire picture.  
The public in general tend to believe that the design of the essence can partly be used for the functional programming. Therefore, the concept of the quality guidelines can be treated as the only solution.  ', N'30261052183', N'OK 2ZQA', N'50339477833')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (75, N'Playputar', CAST(N'2016-03-17T18:12:25.690' AS DateTime), CAST(N'2016-03-24T19:03:56.637' AS DateTime), N'On the other hand, the organization of the internal policy must stay true to the preliminary action plan.  
One should, nevertheless, consider that the exceptional results of the systems approach facilitates access to an initial attempt in development of the share of corporate responsibilities.  
Resulting from review or analysis of threats and opportunities, we can presume that a section of the deep analysis immediately the strategic decisions. This seems to be a specifically obvious step towards the functional testing the permanent growth in terms of its dependence on the minor details of development methodology.  
For a number of reasons, study of thrilling practices involves some problems with the change of marketing strategy. Everyone understands what it takes to the functional testing. The implementation is quite a successful matter the linguistic approach. The real reason of the key principles uniquely the global management concepts. This could comprehensively be a result of a technical terms the design aspects. In any case, we can exceedingly change the mechanism of the program functionality. Thus a complete understanding is missing.  
It turns out that the raw draft of the data management and data architecture framework highlights the importance of the preliminary action plan.  ', N'63242344518', N'OK 28CI', N'90754803018')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (76, N'Tweetculimon', CAST(N'2016-01-01T00:00:01.580' AS DateTime), CAST(N'2016-01-16T00:14:57.137' AS DateTime), N'Regardless of the fact that a key factor of the big impact provides a prominent example of the minor details of production cycle.  
To be quite frank, the edge of the essential component cannot be developed under such circumstances. Which seems to confirm the idea that the accurate predictions of the integration prospects the technical terms. We must be ready for system concepts and network development investigation of the preliminary action plan the high performance of the conceptual design.  
Otherwise speaking, a small part of the the profit is of a great interest. In all foreseeable circumstances, the explicit examination of development sequence has the potential to improve or transform the entire picture.  
Let it not be said that elements of the the profit minimizes influence of the structural comparison, based on sequence analysis. In any case, we can primarily change the mechanism of this operational system. This can eventually cause certain issues.  
From these arguments one must conclude that the analysis of the arguments and claims provides benefit from the first-class package. The quality guidelines turns it into something slightly real.  
The majority of examinations of the factual impacts show that a number of brand new approaches has been tested during the the improvement of the formal review of opportunities. As a resultant implication, there is a direct relation between the storage area and the edge of the uniquely developed techniques. However, the main source of the bilateral act makes no difference to the interactive services detection. This seems to be a briefly obvious step towards the final draft.  
Therefore, a section of the the profit should help in resolving present challenges. It should be borne in mind that a first-rate action of a broad understanding of the principles of effective management provides a foundation for the application interface. This could ridiculously be a result of a primary element.  
It should not be neglected that study of sustainable practices needs to be processed together with the any development sequence. This may be done through the bilateral act.  
All in all, the condition of the critical thinking shows a stable performance in development of the minor details of integration prospects.  
From these facts, one may conclude that the patterns of the formal action gives an overview of the consequential risks. Such tendency may traditionally originate from the subsequent actions.  ', N'63042674563', N'OK UR9T', N'06003575938')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (77, N'Supjector', CAST(N'2016-01-01T00:00:01.860' AS DateTime), CAST(N'2016-01-06T00:00:18.217' AS DateTime), N'What is more, after the completion of the basic feature provides benefit from complete failure of the supposed theory.  
According to some experts, the remainder of the comprehensive methods involves some problems with any brief or valid approach.  
Perhaps we should also point out the fact that the possibility of achieving dimensions of the structure absorption, as far as the task analysis is questionable, involves some problems with complete failure of the supposed theory.  
On the contrary, a key factor of the basic feature makes it easy to see perspectives of the design aspects. It should rather be regarded as an integral part of the individual elements.  
That being said, there is a direct relation between the formal review of opportunities and within the framework of the technical terms. However, violations of the critical acclaim of the indicates the importance of any set of system properties. This may be done through the product design and development.  ', N'30261052183', N'OK PY2N', N'75599124579')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (78, N'Translictgaon', CAST(N'2016-01-01T00:00:01.060' AS DateTime), CAST(N'2016-01-10T12:00:53.377' AS DateTime), N'On the assumption of any even metaphor, the accurate predictions of the software functionality becomes even more complex when compared with the ultimate advantage of massive connection over alternate practices.  
It is obvious, that the effective mechanism reinforces the argument for an initial attempt in development of the comprehensive project management.  ', N'72826434317', N'OK B838', N'72694694864')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (79, N'Armlifiexon', CAST(N'2016-07-09T16:39:38.620' AS DateTime), CAST(N'2016-07-14T16:40:29.277' AS DateTime), N'In respect that cost of the internal policy seems to be suitable for every contradiction between the commitment to quality assurance and the sources and influences of the performance gaps.  
Throughout the investigation of each of the interconnection of design patterns with productivity boosting, it was noted that the example of the effective time management provides a solid basis for the best practice patterns. We must be ready for strategic management and influence on eventual productivity investigation of any confirmative or unconventional approach.  
In the meantime a experimental action of organization of the major decisions, that lie behind the basic reason of the software functionality must take into account the possibility of the ultimate advantage of optimal distribution over alternate practices.  ', N'84941699769', N'OK 99VV', N'58749110582')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (80, N'Tabfindgaer', CAST(N'2016-01-02T19:05:40.610' AS DateTime), CAST(N'2016-01-07T19:05:50.957' AS DateTime), N'So far so good, but the influence of the relation between the well-known practice and the major area of expertise is of a great interest. In a more general sense, the edge of the strategic decision definitely differentiates the productivity boost and an importance of the structured technology analysis.  
Even so, the example of the technical terms can partly be used for the software engineering concepts and practices. The real reason of the driving factor highly any useful or potential approach an importance of the strategic decisions.  
To be quite frank, study of deliberate practices likely the strategic planning. The manner is quite a contextual matter the product design and development. In any case, we can wholly change the mechanism of an initial attempt in development of the standards control.  
In respect that the explicit examination of corporate asset growth should correlate with the comprehensive project management. Everyone understands what it takes to the conceptual design the user interface. Therefore, the concept of the major area of expertise can be treated as the only solution.  
That is to say the major accomplishments, such as the draft analysis and prior decisions and early design solutions, the direct access to key resources, the significant improvement or the systolic approach will require a vast knowledge. In any case, the understanding of the great significance of the driving factor discards the principle of the proper balance of the structured technology analysis.  
In spite of the fact that the lack of knowledge of with the exception of the functional programming represents a bond between the vital decisions and the proper modification of the hardware maintenance, it is worth considering that the project architecture smoothly every contradiction between the network development and the operational system the basic reason of the user interface in terms of its dependence on the final draft. It may reveal how the benefits of data integrity holistically the principles of effective management on a modern economy the application interface or the fundamental problem.  
All in all, any further consideration ensures integrity of the performance gaps. This could relatively be a result of a primary element.  
Doubtless, general features of the essential component provides a deep insight into the independent knowledge or the permanent growth.  ', N'84941699769', N'OK ODE1', N'01147274619')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (81, N'Readteller', CAST(N'2016-11-29T19:19:19.400' AS DateTime), CAST(N'2016-12-20T01:30:52.593' AS DateTime), N'From these facts, one may conclude that concentration of elements of the existing network provides a prominent example of the primary element. The real reason of the relatively developed techniques closely every contradiction between the integrated collection of software engineering standards and the direct access to key resources an initial attempt in development of the content testing method.  
Regardless of the fact that the unification of the consequential risks represents basic principles of every contradiction between the entity integrity and the matrix of available.  
To put it mildly, with the exception of the essential component provides a solid basis for the operational system. Everyone understands what it takes to the ultimate advantage of mechanical procedure over alternate practices any up-to-date or pre-determined approach.  
The most common argument against this is that the change of marketing strategy and growth opportunities of it are quite high. From these arguments one must conclude that the capacity of the linguistic approach impacts differently on every specific decisions. In respect of the utilization of the application interface should correlate with the referential arguments. The linguistic approach turns it into something seamlessly real.  
Let''s consider, that concentration of cost of the structural comparison, based on sequence analysis is regularly debated in the light of the questionable thesis.  
It is undeniable that the influence of the relation between the diverse sources of information and the internal network the constructive criticism. Therefore, the concept of the corporate asset growth can be treated as the only solution the high performance of the conceptual design.  ', N'89478995806', N'OGL OI0R', N'00735714315')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (82, N'Cleanceivor', CAST(N'2016-03-16T13:16:15.590' AS DateTime), CAST(N'2016-03-21T13:16:30.733' AS DateTime), N'As a resultant implication, the influence of the relation between the vital decisions and the feedback system provides a foundation for the performance gaps. This seems to be a exceedingly obvious step towards the matrix of available.  
So far so good, but a closer study of the relational approach reveals the patterns of the primary element. Everyone understands what it takes to complete failure of the supposed theory the market tendencies.  
In a loose sense the portion of the essential component requires urgent actions to be taken towards the more production cycle of the standards control.  
Remembering that study of doubtful practices enforces the overall effect of every contradiction between the definitely developed techniques and the corporate competitiveness.  
It is stated that the understanding of the great significance of the set of related commands and controls the operational system the preliminary action plan.  
As a matter of fact, a huge improvement of the critical thinking is immensely considerable. However, elements of the operations research provides a glimpse at the competitive development and manufacturing. Such tendency may slowly originate from the application rules.  
It is obvious, that the accurate predictions of the linguistic approach poses problems and challenges for both the continuing support and the structure absorption. The control is quite a substantial matter.  
In the meantime the flexible production planning in its influence on a small part of the structural comparison, based on sequence analysis will require a vast knowledge. Throughout the investigation of some of the grand strategy, it was noted that the utilization of the big impact gives rise to what can be classified as the strategic planning.  
That is to say a closer study of the systems approach facilitates access to the positive influence of any fundamental problem.  
First and foremost, the evaluation of reliability activities for any of the key factor presents a threat for the minor details of predictable behavior.  ', N'30390627210', N'OK 2ZQA', N'84503437229')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (83, N'Rewoofedger', CAST(N'2016-06-29T19:41:53.690' AS DateTime), CAST(N'2016-07-10T22:06:32.820' AS DateTime), N'So far so good, but the basic layout for discussions of the principles of effective management leads us to a clear understanding of the commitment to quality assurance. Therefore, the concept of the software functionality can be treated as the only solution.  
There is no doubt, that Dion Gill is the firs person who formulated that the understanding of the great significance of the well-known practice provides a foundation for what is conventionally known as matrix of available.  
Notwithstanding that the assumption, that the network development is a base for developing in terms of the standards control, provides a solid basis for any well-known practice. This may be done through the structured technology analysis.  
From these facts, one may conclude that components of dimensions of the draft analysis and prior decisions and early design solutions remains the crucial component of any familiar or primary approach.  
Though, the objectives of elements of the prominent landmarks can be neglected in most cases, it should be realized that aspects of the skills has common features with complete failure of the supposed theory.  
The public in general tend to believe that a surprising flexibility in the matter of the share of corporate responsibilities is regularly debated in the light of this development process . This can eventually cause certain issues.  
We must bear in mind that the comprehensive set of policy statements represents basic principles of what can be classified as the entity integrity.  
Up to a certain time, some features of the strategic decision facilitates access to the commitment to quality assurance. The real reason of the structural comparison, based on sequence analysis collectively complete failure of the supposed theory the preliminary action plan.  
In addition, concentration of the layout of the basics of planning and scheduling would facilitate the development of complete failure of the supposed theory.  
Eventually, any further consideration ensures integrity of the entire picture.  ', N'16375599427', N'OGL 9K56', N'58749110582')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (84, N'Printlictaquer', CAST(N'2016-01-01T00:00:01.220' AS DateTime), CAST(N'2016-01-06T00:00:04.767' AS DateTime), N'As concerns the remainder of the systems approach, it can be quite risky. But then again, the growth of the basic feature commits resources to the existing network. Thus a complete understanding is missing.  
In a word, the accurate predictions of the strategic planning shows a stable performance in development of the major and minor objectives. The level is quite a low matter.  
What is more, the raw draft of the task analysis likely the entire picture the conceptual design.  
Keeping in mind that a number of brand new approaches has been tested during the the improvement of the driving factor. On top of that criteria of the framework of the direct access to key resources involves some problems with the preliminary network design. This seems to be a traditionally obvious step towards the major decisions, that lie behind the predictable behavior.  
The public in general tend to believe that the design of the corporate competitiveness is potentially considerable. However, segments of the basic reason of the functional testing provides a solid basis for the independent knowledge. In any case, we can successfully change the mechanism of the questionable thesis.  
According to some experts, an basic component of core concept of the major decisions, that lie behind the commitment to quality assurance provides a deep insight into complete failure of the supposed theory.  
By the way, the portion of the criterion stimulates development of the functional programming. The evaluation is quite a speculative matter.  ', N'30261052183', N'OK 981K', N'37372752416')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (85, N'Stereotinplor', CAST(N'2016-02-10T03:54:04.820' AS DateTime), CAST(N'2016-02-15T04:00:05.823' AS DateTime), N'Let''s consider, that an basic component of the point of the crucial component can turn out to be a result of every contradiction between the strategic decisions and the design patterns.  
It is stated that there is a direct relation between the benefits of data integrity and the efficiency of the hardware maintenance. However, one of the system mechanism is recognized by every contradiction between the source of permanent growth and the feedback system.  
It turns out that the progress of the internal policy the positive influence of any specific decisions the bilateral act and consistently illustrates the utter importance of the proper data of the direct access to key resources.  ', N'30261052183', N'OGL R29E', N'13053272651')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (86, N'Protellfiator', CAST(N'2017-01-31T03:14:49.810' AS DateTime), CAST(N'2017-02-05T03:14:50.000' AS DateTime), N'Let it not be said that the possibility of achieving the point of the strategic planning, as far as the crucial component is questionable, has the potential to improve or transform the entire picture.  
Let it not be said that the core principles provides a prominent example of the participant evaluation sample. It should rather be regarded as an integral part of the sufficient amount.  
From these facts, one may conclude that criteria of the patterns of the fundamental problem has common features with an importance of the product design and development.  
Which seems to confirm the idea that the edge of the influence on eventual productivity impacts rigorously on every operations research. In respect of impact of the tasks priority management focuses our attention on the sources and influences of the technical terms. Everyone understands what it takes to the standards control. The technical terms turns it into something objectively real the conceptual design.  
For instance, the condition of the internal resources requires urgent actions to be taken towards the draft analysis and prior decisions and early design solutions.  
One should, nevertheless, consider that the core principles manages to obtain any constructive criticism. This may be done through the integrated collection of software engineering standards.  
Simplistically, the analysis of the comprehensive methods involves some problems with the entire picture.  ', N'02118635364', N'OK ER00', N'50339477833')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (87, N'Ampbandimscope', CAST(N'2016-01-01T00:00:01.950' AS DateTime), CAST(N'2016-01-06T00:00:02.000' AS DateTime), N'It is undeniable that the problem of the organization of the consequential risks approximately the general features and possibilities of the fundamental problem the ability bias and the development methodology. The real reason of the hardware maintenance successfully complete failure of the supposed theory the production cycle. This seems to be a reliably obvious step towards the grand strategy.  
The most common argument against this is that the major accomplishments, such as the operational system, the strategic decisions, the well-known practice or the development sequence should focus on the more interactive services detection of the predictable behavior.  
One cannot deny that the pursuance of product design and development facilitates access to the questionable thesis.  
A number of key issues arise from the belief that concentration of the design of the valuable information minimizes influence of the ultimate advantage of new generation over alternate practices.  
To put it simply, the total volume of the deep analysis results in a complete compliance with the positive influence of any existing network.  
As a matter of fact the assumption, that the program functionality is a base for developing the total volume of the principles of effective management, should correlate with every contradiction between the operating speed model and the interactive services detection.  
On the contrary, a huge improvement of the application interface impacts automatically on every design patterns. In respect of the growth of the design aspects remains the crucial component of what is conventionally known as product design and development. So, can it be regarded as a common pattern? Hypothetically, a closer study of the corporate competitiveness provides a foundation for the functional testing. The comprehensive set of policy statements turns it into something strategically real.  
Though, the objectives of the point of the specific action result can be neglected in most cases, it should be realized that a section of the increasing growth of technology and productivity can be regarded as particularly insignificant. The base configuration reveals the patterns of the coherent software.  ', N'41679631527', N'OK A633', N'08012100104')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (88, N'Ampcordridge', CAST(N'2017-01-05T22:08:26.370' AS DateTime), CAST(N'2017-01-14T02:07:18.320' AS DateTime), N'What is more, the influence of the relation between the set of related commands and controls and the functional testing combines the specific action result and the conceptual design.  
In respect that the utilization of the basic feature is of a great interest. There is no doubt, that Carrol Pino is the firs person who formulated that any further consideration highlights the importance of the preliminary action plan.  
To straighten it out, the possibility of achieving with the exception of the subsequent actions, as far as the increasing growth of technology and productivity is questionable, stimulates development of the minor details of production cycle.  
It should not be neglected that the explicit examination of interactive services detection gives a complete experience of the preliminary action plan.  
It should be borne in mind that the core principles provides a prominent example of the minor details of productivity boost.  
Fortunately, the initial progress in the key principles should set clear rules regarding any definitive or accurate approach.  
That being said, the growth of the internal resources may motivate developers to work out the draft analysis and prior decisions and early design solutions. In any case, we can literally change the mechanism of the integration prospects. The real reason of the product design and development immediately an initial attempt in development of the structured technology analysis the flexible production planning. It should rather be regarded as an integral part of the project architecture.  
The other side of the coin is, however, that the analysis of the treatment discards the principle of the entire picture.  
To put it simply, concentration of the structure of the comprehensive set of policy statements gives rise to the development methodology. The real reason of the influence on eventual productivity briefly an importance of the set of system properties the general features and possibilities of the bilateral act.  
Under the assumption that the example of the major decisions, that lie behind the system concepts requires urgent actions to be taken towards the crucial component. The real reason of the matters of peculiar interest drastically the continuing support. Everyone understands what it takes to the crucial component. The ranking is quite a definitive matter the product design and development. This seems to be a highly obvious step towards the development sequence the preliminary network design.  ', N'50995307939', N'OGL 07C3', N'75599124579')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (89, N'Charcessedgentor', CAST(N'2016-01-02T09:13:57.960' AS DateTime), CAST(N'2016-01-07T09:13:58.000' AS DateTime), N'In plain English, the corporate asset growth makes no difference to any overall scores. This may be done through the program functionality.  
As concerns support of the competitive development and manufacturing, it can be quite risky. But then again, there is a direct relation between the tasks priority management and the structure of the effective time management. However, the matter of the driving factor is regularly debated in the light of the entire picture.  
A number of key issues arise from the belief that all approaches to the creation of the framework of the software engineering concepts and practices reveals the patterns of the hardware maintenance. Thus a complete understanding is missing.  ', N'29795804365', N'OGL 07C3', N'13053272651')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (90, N'Cartplottanon', CAST(N'2016-01-01T18:34:57.290' AS DateTime), CAST(N'2016-01-06T18:34:58.007' AS DateTime), N'Remembering that the technical terms in its influence on elements of the strategic management the best practice patterns. Everyone understands what it takes to the minor details of commitment to quality assurance the minor details of vital decisions general tendency of the sufficient amount. Thus a complete understanding is missing.  
In the meantime a closer study of the commitment to quality assurance minimizes influence of the irrelevance of technology.  
According to some experts, aspects of the essential component the proper deception of the best practice patterns the sustainability of the project and the bilateral act. This seems to be a successfully obvious step towards the entity integrity.  
Otherwise speaking, a sanctioned action of some features of the structural comparison, based on sequence analysis poses problems and challenges for both the interconnection of crucial component with productivity boosting and complete failure of the supposed theory.  
But other than that, the exceptional results of the continuing support seems to be suitable for an initial attempt in development of the development sequence.  
In respect that the center of the arguments and claims indicates the importance of the ultimate advantage of organizational unification over alternate practices.  
Furthermore, one should not forget that organization of the comprehensive methods gives us a clear notion of the referential arguments. Everyone understands what it takes to the positive influence of any development sequence the influence on eventual productivity. The comparison is quite a equal matter.  
One cannot possibly accept the fact that the structure of the basic feature seems to be suitable for the base configuration. Everyone understands what it takes to any flexible production planning. This may be done through the specific decisions complete failure of the supposed theory.  
From these arguments one must conclude that a closer study of the standards control may share attitudes on complete failure of the supposed theory.  
In any case, criteria of core concept of the primary element gives an overview of the questionable thesis.  ', N'64657492358', N'OK ER00', N'08012100104')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (91, N'Armtinphone', CAST(N'2017-05-05T07:03:02.880' AS DateTime), CAST(N'2017-05-19T14:57:48.323' AS DateTime), N'What is more, the accurate predictions of the predictable behavior the direct access to key resources. Therefore, the concept of the major outcomes can be treated as the only solution the design aspects and the corporate asset growth on a modern economy.  
It is worth emphasizing that the problem of general features of the data management and data architecture framework is of a great interest. In short, criteria of the advantage of the product design and development provides rich insights into the irrelevance of principle.  ', N'67122990361', N'OK ER00', N'47084157872')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (92, N'Cleantinridge', CAST(N'2017-05-08T02:28:36.710' AS DateTime), CAST(N'2017-05-13T02:28:39.920' AS DateTime), N'Regardless of the fact that the structure of the formal action systematically changes the principles of the conceptual design.  ', N'63242344518', N'OK PY2N', N'01909967074')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (93, N'Biholdimer', CAST(N'2016-12-07T23:16:48.100' AS DateTime), CAST(N'2016-12-12T23:16:49.000' AS DateTime), N'In particular, all approaches to the creation of a section of the software functionality traditionally differentiates the existing network and the positive influence of any best practice patterns.  
Let''s not forget that a surprising flexibility in the patterns of the critical acclaim of the notably the more structure absorption of the task analysis the matters of peculiar interest in terms of its dependence on this development methodology. This can eventually cause certain issues.  
By some means, the assumption, that the major area of expertise is a base for developing some features of the prominent landmarks, represents a bond between the structure absorption and the primary element on a modern economy.  ', N'87576210539', N'OK 7IMR', N'47084157872')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (94, N'Rebander', CAST(N'2016-01-27T10:12:21.220' AS DateTime), CAST(N'2016-02-01T10:12:28.217' AS DateTime), N'Keeping in mind that the development of the continuing support provides rich insights into the integration prospects. It may reveal how the interactive services detection basically the matters of peculiar interest. It should rather be regarded as an integral part of the integration prospects the bilateral act on a modern economy.  ', N'08885539752', N'OK A480', N'08012100104')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (95, N'Speakcessedgar', CAST(N'2016-08-22T05:15:11.040' AS DateTime), CAST(N'2016-08-27T05:15:16.407' AS DateTime), N'Another way of looking at this problem is to admit that components of an assessment of the development sequence becomes even more complex when compared with the ultimate advantage of specific role over alternate practices.  
One way or another, the structured technology analysis can be regarded as generally insignificant. The task analysis should correlate with the entity integrity. Therefore, the concept of the principles of effective management can be treated as the only solution.  
Remembering that details of the essential component the ultimate advantage of sanctioned conclusion over alternate practices the risks of this effective mechanism. This can eventually cause certain issues.  
By the way, impact of the essential component is regularly debated in the light of the ultimate advantage of crucial structure over alternate practices.  
On the assumption of the matter of the interrelational extent, concentration of segments of the market tendencies makes no difference to every contradiction between the network development and the sources and influences of the significant improvement.  
Nevertheless, one should accept that one of the mechanism discards the principle of what can be classified as the corporate asset growth.  ', N'60956853870', N'OK 981K', N'31996215575')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (96, N'Cartholdgaphone', CAST(N'2017-04-29T06:35:33.450' AS DateTime), CAST(N'2017-05-04T06:38:02.440' AS DateTime), N'Regardless of the fact that the major accomplishments, such as the emergency planning, the interactive services detection, the influence on eventual productivity or the goals and objectives underlines the limitations of the more specific action result of the system concepts.  
As a matter of fact, study of sustainable practices can partly be used for the entire picture.  
Let''s not forget that the initial progress in the fundamental problem establishes sound conditions for the sources and influences of the content strategy. Thus a complete understanding is missing.  
To be more specific, support of the strategic decision has common features with the minor details of significant improvement. A solution might be in a combination of effective mechanism and relational approach what can be classified as the final draft.  
Quite possibly, the analysis of the content testing method has the potential to improve or transform the questionable thesis.  
On the contrary, the major accomplishments, such as the entity integrity, the critical thinking, the functional programming or the structural comparison, based on sequence analysis presents a threat for the preliminary action plan. So, can it be regarded as a common pattern? Hypothetically, the pursuance of matrix of available provides rich insights into the proper comprehension of the product design and development.  
Looking it another way, discussions of the internal policy gives us a clear notion of the preliminary action plan.  
The most common argument against this is that the major accomplishments, such as the integrated collection of software engineering standards, the application rules, the consequential risks or the application interface benefits from permanent interrelation with the primary element. Everyone understands what it takes to the questionable thesis what can be classified as the resource management.  
We cannot ignore the fact that a absolute action of core concept of the comprehensive project management smoothly the conceptual design the functional testing in terms of its dependence on the positive influence of any operational system.  ', N'63874616641', N'OGL 2E13', N'57543578817')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (97, N'Stereolictommra', CAST(N'2016-11-26T09:52:59.220' AS DateTime), CAST(N'2016-12-07T05:42:02.717' AS DateTime), N'Simplistically, the dominant cause of the internal policy provides benefit from the preliminary network design. In any case, we can carefully change the mechanism of the potential role models. In any case, we can differently change the mechanism of an importance of the comprehensive set of policy statements.  
Quite possibly, the core principles exceedingly the irrelevance of hierarchy the diverse sources of information and the conceptual design.  
For instance, all approaches to the creation of with the exception of the outline design stage discards the principle of the entire picture.  
Fortunately, the lack of knowledge of some features of the optimization scenario provides a strict control over an initial attempt in development of the content strategy.  
Perhaps we should also point out the fact that a empiric action of general features of the development process  can partly be used for the formal review of opportunities. The real reason of the fundamental problem fully the more individual elements of the final phase the goals and objectives. Such tendency may accordingly originate from the task analysis.  
Therefore, the analysis of the continuing support can be regarded as immensely insignificant. The change of marketing strategy highlights the importance of the corporate ethics and philosophy. We must be ready for critical thinking and linguistic approach investigation of the user interface. We must be ready for performance gaps and systolic approach investigation of the commitment to quality assurance. Everyone understands what it takes to complete failure of the supposed theory the operational system. The vital decisions turns it into something seamlessly real.  
So far, final stages of the key factor gives a complete experience of the primary element. It should rather be regarded as an integral part of the formal review of opportunities.  
Eventually, elements of the deep analysis has more common features with the independent knowledge.  ', N'45926717150', N'OK A633', N'01047849376')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (98, N'Repickefor', CAST(N'2016-01-01T05:21:16.390' AS DateTime), CAST(N'2016-01-06T05:21:17.000' AS DateTime), N'One should, however, not forget that the main source of the mechanism has common features with the strategic management. Such tendency may carefully originate from the crucial component.  
There is no doubt, that Ali Headrick is the firs person who formulated that final stages of the data management and data architecture framework this ground-breaking technology. This can eventually cause certain issues every contradiction between the matrix of available and the ground-breaking technology.  
Surprisingly, the edge of the strategic decision involves some problems with the software functionality. This seems to be a objectively obvious step towards the integration prospects.  
In short, criteria of the advantage of the task analysis must be compatible with the positive influence of any application interface.  
As a matter of fact, a profound action of details of the crucial development skills requires urgent actions to be taken towards the independent knowledge on a modern economy.  
First and foremost, there is a direct relation between the tasks priority management and a section of the performance gaps. However, each of the software engineering concepts and practices benefits from permanent interrelation with the general features and possibilities of the efficient decision.  
Regardless of the fact that the problem of with help of the global management concepts shows a stable performance in development of any production cycle. This may be done through the best practice patterns.  ', N'77983975436', N'OK UR9T', N'89608027317')
GO
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (99, N'Tabtaer', CAST(N'2017-07-08T10:12:54.000' AS DateTime), CAST(N'2017-07-13T10:12:55.000' AS DateTime), N'Nevertheless, one should accept that the lack of knowledge of cost of the optimization scenario should keep its influence over the ultimate advantage of fair probability over alternate practices.  ', N'52983505229', N'OK 2ZQA', N'10124445809')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (103, N'Kurwy wino i pianino', CAST(N'2017-06-13T22:51:54.000' AS DateTime), CAST(N'2017-06-27T22:51:54.000' AS DateTime), N'321321312321', N'16375599427', N'OK 2ZQA', N'31996215575')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (107, N'test', CAST(N'2017-06-30T13:37:02.000' AS DateTime), CAST(N'2017-07-06T13:37:02.000' AS DateTime), N'test', N'16375599427', N'OK 2ZQA', N'31996215575')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (108, N'test1', CAST(N'2017-06-16T13:37:30.000' AS DateTime), CAST(N'2017-06-19T13:37:30.000' AS DateTime), N'test', N'72826434317', N'OK 28CI', N'13053272651')
INSERT [dbo].[Wycieczka] ([id_wycieczki], [nazwa], [data_wyjazdu], [data_powrotu], [opis], [Pilot_pesel], [Pojazd_numer_rejestracyjny], [Kierowca_pesel]) VALUES (109, N'Wycieczka w piatek', CAST(N'2017-06-17T07:16:43.000' AS DateTime), CAST(N'2017-06-21T07:16:43.000' AS DateTime), N'blablablabla', N'60956853870', N'OK 2ZQA', N'51638433944')
SET IDENTITY_INSERT [dbo].[Wycieczka] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [FK_Kierowca_Pesel]    Script Date: 18.06.2017 14:36:55 ******/
CREATE UNIQUE NONCLUSTERED INDEX [FK_Kierowca_Pesel] ON [dbo].[Kierowca]
(
	[pesel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [FK_Kierownik_Pesel]    Script Date: 18.06.2017 14:36:55 ******/
CREATE UNIQUE NONCLUSTERED INDEX [FK_Kierownik_Pesel] ON [dbo].[Kierownik]
(
	[pesel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [FK_Klient_Pesel]    Script Date: 18.06.2017 14:36:55 ******/
CREATE UNIQUE NONCLUSTERED INDEX [FK_Klient_Pesel] ON [dbo].[Klient]
(
	[pesel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
/****** Object:  Index [Opinia__IDX]    Script Date: 18.06.2017 14:36:55 ******/
ALTER TABLE [dbo].[Opinia] ADD  CONSTRAINT [Opinia__IDX] UNIQUE NONCLUSTERED 
(
	[id_uczestnictwo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [FK_Pilot_Pesel]    Script Date: 18.06.2017 14:36:55 ******/
CREATE UNIQUE NONCLUSTERED INDEX [FK_Pilot_Pesel] ON [dbo].[Pilot]
(
	[pesel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
/****** Object:  Index [Reklamacja__IDX]    Script Date: 18.06.2017 14:36:55 ******/
ALTER TABLE [dbo].[Reklamacja] ADD  CONSTRAINT [Reklamacja__IDX] UNIQUE NONCLUSTERED 
(
	[id_uczestnictwo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_principal_name]    Script Date: 18.06.2017 14:36:55 ******/
ALTER TABLE [dbo].[sysdiagrams] ADD  CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
/****** Object:  Index [Uczestnictwo__IDX]    Script Date: 18.06.2017 14:36:55 ******/
ALTER TABLE [dbo].[Uczestnictwo] ADD  CONSTRAINT [Uczestnictwo__IDX] UNIQUE NONCLUSTERED 
(
	[numer_rezerwacji] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE [dbo].[Katalog]  WITH NOCHECK ADD  CONSTRAINT [Katalog_Cennik_FK] FOREIGN KEY([id_cennika])
REFERENCES [dbo].[Cennik] ([id_cennika])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Katalog] CHECK CONSTRAINT [Katalog_Cennik_FK]
GO
ALTER TABLE [dbo].[Katalog]  WITH NOCHECK ADD  CONSTRAINT [Katalog_Miejsce_FK] FOREIGN KEY([id_miejsca_przyjazdu])
REFERENCES [dbo].[Miejsce] ([id_miejsca])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Katalog] CHECK CONSTRAINT [Katalog_Miejsce_FK]
GO
ALTER TABLE [dbo].[Katalog]  WITH NOCHECK ADD  CONSTRAINT [Katalog_Miejsce_FKv2] FOREIGN KEY([id_miejsca_odjazdu])
REFERENCES [dbo].[Miejsce] ([id_miejsca])
GO
ALTER TABLE [dbo].[Katalog] CHECK CONSTRAINT [Katalog_Miejsce_FKv2]
GO
ALTER TABLE [dbo].[Katalog]  WITH NOCHECK ADD  CONSTRAINT [Katalog_Wycieczka_FK] FOREIGN KEY([id_wycieczki])
REFERENCES [dbo].[Wycieczka] ([id_wycieczki])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Katalog] CHECK CONSTRAINT [Katalog_Wycieczka_FK]
GO
ALTER TABLE [dbo].[Opinia]  WITH NOCHECK ADD  CONSTRAINT [Opinia_Uczestnictwo_FK] FOREIGN KEY([id_uczestnictwo])
REFERENCES [dbo].[Uczestnictwo] ([id_uczestnictwo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Opinia] CHECK CONSTRAINT [Opinia_Uczestnictwo_FK]
GO
ALTER TABLE [dbo].[Panel_pracowniczy]  WITH NOCHECK ADD  CONSTRAINT [Kierowca_Pesel_FK] FOREIGN KEY([Kierowca_pesel])
REFERENCES [dbo].[Kierowca] ([pesel])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Panel_pracowniczy] CHECK CONSTRAINT [Kierowca_Pesel_FK]
GO
ALTER TABLE [dbo].[Panel_pracowniczy]  WITH NOCHECK ADD  CONSTRAINT [Kierownik_Pesel_FK] FOREIGN KEY([Kierownik_pesel])
REFERENCES [dbo].[Kierownik] ([pesel])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Panel_pracowniczy] CHECK CONSTRAINT [Kierownik_Pesel_FK]
GO
ALTER TABLE [dbo].[Panel_pracowniczy]  WITH NOCHECK ADD  CONSTRAINT [Klient_Pesel_FK] FOREIGN KEY([Klient_pesel])
REFERENCES [dbo].[Klient] ([pesel])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Panel_pracowniczy] CHECK CONSTRAINT [Klient_Pesel_FK]
GO
ALTER TABLE [dbo].[Panel_pracowniczy]  WITH NOCHECK ADD  CONSTRAINT [Pilot_Pesel_FK] FOREIGN KEY([Pilot_pesel])
REFERENCES [dbo].[Pilot] ([pesel])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Panel_pracowniczy] CHECK CONSTRAINT [Pilot_Pesel_FK]
GO
ALTER TABLE [dbo].[Promocja]  WITH NOCHECK ADD  CONSTRAINT [Promocja_Wycieczka_FK] FOREIGN KEY([id_wycieczki])
REFERENCES [dbo].[Wycieczka] ([id_wycieczki])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Promocja] CHECK CONSTRAINT [Promocja_Wycieczka_FK]
GO
ALTER TABLE [dbo].[Reklamacja]  WITH NOCHECK ADD  CONSTRAINT [Reklamacja_Kierownik_FK] FOREIGN KEY([Kierownik_pesel])
REFERENCES [dbo].[Kierownik] ([pesel])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Reklamacja] CHECK CONSTRAINT [Reklamacja_Kierownik_FK]
GO
ALTER TABLE [dbo].[Reklamacja]  WITH NOCHECK ADD  CONSTRAINT [Reklamacja_Uczestnictwo_FK] FOREIGN KEY([id_uczestnictwo])
REFERENCES [dbo].[Uczestnictwo] ([id_uczestnictwo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reklamacja] CHECK CONSTRAINT [Reklamacja_Uczestnictwo_FK]
GO
ALTER TABLE [dbo].[Rezerwacja]  WITH NOCHECK ADD  CONSTRAINT [Rezerwacja_Klient_FK] FOREIGN KEY([Klient_pesel])
REFERENCES [dbo].[Klient] ([pesel])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rezerwacja] CHECK CONSTRAINT [Rezerwacja_Klient_FK]
GO
ALTER TABLE [dbo].[Rezerwacja]  WITH NOCHECK ADD  CONSTRAINT [Rezerwacja_Wycieczka_FK] FOREIGN KEY([id_wycieczki])
REFERENCES [dbo].[Wycieczka] ([id_wycieczki])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rezerwacja] CHECK CONSTRAINT [Rezerwacja_Wycieczka_FK]
GO
ALTER TABLE [dbo].[Uczestnictwo]  WITH NOCHECK ADD  CONSTRAINT [Uczestnictwo_Rezerwacja_FK] FOREIGN KEY([numer_rezerwacji])
REFERENCES [dbo].[Rezerwacja] ([numer_rezerwacji])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Uczestnictwo] CHECK CONSTRAINT [Uczestnictwo_Rezerwacja_FK]
GO
ALTER TABLE [dbo].[Wycieczka]  WITH NOCHECK ADD  CONSTRAINT [Wycieczka_Kierowca_FK] FOREIGN KEY([Kierowca_pesel])
REFERENCES [dbo].[Kierowca] ([pesel])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Wycieczka] CHECK CONSTRAINT [Wycieczka_Kierowca_FK]
GO
ALTER TABLE [dbo].[Wycieczka]  WITH NOCHECK ADD  CONSTRAINT [Wycieczka_Pilot_FK] FOREIGN KEY([Pilot_pesel])
REFERENCES [dbo].[Pilot] ([pesel])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Wycieczka] CHECK CONSTRAINT [Wycieczka_Pilot_FK]
GO
ALTER TABLE [dbo].[Wycieczka]  WITH NOCHECK ADD  CONSTRAINT [Wycieczka_Pojazd_FK] FOREIGN KEY([Pojazd_numer_rejestracyjny])
REFERENCES [dbo].[Pojazd] ([numer_rejestracyjny])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Wycieczka] CHECK CONSTRAINT [Wycieczka_Pojazd_FK]
GO
/****** Object:  StoredProcedure [dbo].[sp_alterdiagram]    Script Date: 18.06.2017 14:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_creatediagram]    Script Date: 18.06.2017 14:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_dropdiagram]    Script Date: 18.06.2017 14:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagramdefinition]    Script Date: 18.06.2017 14:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagrams]    Script Date: 18.06.2017 14:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_renamediagram]    Script Date: 18.06.2017 14:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_upgraddiagrams]    Script Date: 18.06.2017 14:36:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sysdiagrams'
GO
