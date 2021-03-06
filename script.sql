USE [Emlak]
GO
/****** Object:  Table [dbo].[IlanFoto]    Script Date: 17.11.2017 21:30:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IlanFoto](
	[TabloID] [int] IDENTITY(1,1) NOT NULL,
	[IlanID] [int] NULL,
	[Foto1] [varchar](1) NULL,
	[Foto2] [varchar](1) NULL,
	[Foto3] [varchar](1) NULL,
	[Foto4] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[TabloID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ilanlar]    Script Date: 17.11.2017 21:30:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ilanlar](
	[IlanID] [int] IDENTITY(1,1) NOT NULL,
	[IlanBaslik] [nvarchar](150) NULL,
	[EvTuru] [varchar](20) NULL,
	[EvAdres1] [varchar](30) NULL,
	[EvAdres2] [varchar](50) NULL,
	[EvAdres3] [varchar](50) NULL,
	[IsitmaTuru] [varchar](30) NULL,
	[EvKati] [varchar](15) NULL,
	[EvFiyat] [bigint] NULL,
	[EvTarih] [varchar](20) NULL,
	[MetreKare] [varchar](20) NULL,
	[KullaniciID_FK] [int] NOT NULL,
 CONSTRAINT [PK_Ilanlar] PRIMARY KEY CLUSTERED 
(
	[IlanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 17.11.2017 21:30:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[KullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAd] [varchar](30) NULL,
	[KullaniciSoyad] [varchar](40) NULL,
	[KullaniciNick] [varchar](50) NULL,
	[KayitTarihi] [date] NULL,
	[DogumTarih] [date] NULL,
	[KullaniciMail] [varchar](50) NULL,
	[KullaniciSifre] [varchar](20) NULL,
	[Telefon] [varchar](12) NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[KullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KullaniciTema]    Script Date: 17.11.2017 21:30:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KullaniciTema](
	[KullaniciID_fk] [int] NOT NULL,
	[KullaniciRenk] [varchar](30) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Ilanlar] ON 

INSERT [dbo].[Ilanlar] ([IlanID], [IlanBaslik], [EvTuru], [EvAdres1], [EvAdres2], [EvAdres3], [IsitmaTuru], [EvKati], [EvFiyat], [EvTarih], [MetreKare], [KullaniciID_FK]) VALUES (1, N'3+1 EV', N'Kiralık', N'İstanbul', N'Kadıköy', N'Göztepe Mahallesi', N'Soba', N'1', 150000, N'19.10.1998', N'120', 1)
SET IDENTITY_INSERT [dbo].[Ilanlar] OFF
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON 

INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciNick], [KayitTarihi], [DogumTarih], [KullaniciMail], [KullaniciSifre], [Telefon]) VALUES (1, N'Tuğrul', N'ERBAŞ', N'tugrulerbas', CAST(N'2017-11-17' AS Date), CAST(N'1998-10-19' AS Date), N'tgrlerbas@gmail.com', N'tugrul34', N'05380857247')
INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciNick], [KayitTarihi], [DogumTarih], [KullaniciMail], [KullaniciSifre], [Telefon]) VALUES (2, N'', N'', N'', NULL, NULL, N'', N'', NULL)
INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciNick], [KayitTarihi], [DogumTarih], [KullaniciMail], [KullaniciSifre], [Telefon]) VALUES (3, N'', N'', N'', CAST(N'2017-11-17' AS Date), CAST(N'2017-11-17' AS Date), N'', N'', NULL)
INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciNick], [KayitTarihi], [DogumTarih], [KullaniciMail], [KullaniciSifre], [Telefon]) VALUES (4, N'', N'', N'', CAST(N'2017-11-17' AS Date), CAST(N'2017-11-17' AS Date), N'', N'', NULL)
INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciNick], [KayitTarihi], [DogumTarih], [KullaniciMail], [KullaniciSifre], [Telefon]) VALUES (5, N'', N'', N'', CAST(N'2017-11-17' AS Date), CAST(N'1998-10-19' AS Date), N'', N'', NULL)
INSERT [dbo].[Kullanicilar] ([KullaniciID], [KullaniciAd], [KullaniciSoyad], [KullaniciNick], [KayitTarihi], [DogumTarih], [KullaniciMail], [KullaniciSifre], [Telefon]) VALUES (6, N'', N'', N'', CAST(N'2017-11-17' AS Date), CAST(N'2017-11-17' AS Date), N'', N'', N'')
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
ALTER TABLE [dbo].[IlanFoto]  WITH CHECK ADD  CONSTRAINT [FK_IlanFoto_Ilanlar] FOREIGN KEY([IlanID])
REFERENCES [dbo].[Ilanlar] ([IlanID])
GO
ALTER TABLE [dbo].[IlanFoto] CHECK CONSTRAINT [FK_IlanFoto_Ilanlar]
GO
ALTER TABLE [dbo].[Ilanlar]  WITH CHECK ADD  CONSTRAINT [FK_Ilanlar_Kullanicilar] FOREIGN KEY([KullaniciID_FK])
REFERENCES [dbo].[Kullanicilar] ([KullaniciID])
GO
ALTER TABLE [dbo].[Ilanlar] CHECK CONSTRAINT [FK_Ilanlar_Kullanicilar]
GO
ALTER TABLE [dbo].[KullaniciTema]  WITH CHECK ADD  CONSTRAINT [FK_KullaniciTema_Kullanicilar] FOREIGN KEY([KullaniciID_fk])
REFERENCES [dbo].[Kullanicilar] ([KullaniciID])
GO
ALTER TABLE [dbo].[KullaniciTema] CHECK CONSTRAINT [FK_KullaniciTema_Kullanicilar]
GO
