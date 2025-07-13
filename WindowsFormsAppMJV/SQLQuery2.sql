

USE [master]
GO
/****** Object:  Database [MJV]    Script Date: 07/11/2024 08:58:01 ******/
CREATE DATABASE [MJV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MJV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MJV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MJV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MJV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MJV] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MJV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MJV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MJV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MJV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MJV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MJV] SET ARITHABORT OFF 
GO
ALTER DATABASE [MJV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MJV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MJV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MJV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MJV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MJV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MJV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MJV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MJV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MJV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MJV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MJV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MJV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MJV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MJV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MJV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MJV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MJV] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MJV] SET  MULTI_USER 
GO
ALTER DATABASE [MJV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MJV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MJV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MJV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MJV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MJV] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MJV] SET QUERY_STORE = ON
GO
ALTER DATABASE [MJV] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MJV]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 07/11/2024 08:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ID_CLIENT] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](50) NOT NULL,
	[Mail] [varchar](50) NULL,
	[Tel] [varchar](50) NULL,
 CONSTRAINT [Client_PK] PRIMARY KEY CLUSTERED 
(
	[ID_CLIENT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Intervention]    Script Date: 07/11/2024 08:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Intervention](
	[ID_INTER] [int] IDENTITY(1,1) NOT NULL,
	[Date_inter] [date] NOT NULL,
	[Comment] [text] NULL,
	[ID_MATOS] [int] NOT NULL,
 CONSTRAINT [Intervention_PK] PRIMARY KEY CLUSTERED 
(
	[ID_INTER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MATOS]    Script Date: 07/11/2024 08:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MATOS](
	[ID_MATOS] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](50) NOT NULL,
	[Description] [text] NULL,
	[NSerie] [text] NOT NULL,
	[Marque] [varchar](50) NULL,
	[DateInst] [date] NULL,
	[ID_TYPE] [int] NOT NULL,
	[ID_CLIENT] [int] NOT NULL,
	[MTBF] [int] NULL,
 CONSTRAINT [MATOS_PK] PRIMARY KEY CLUSTERED 
(
	[ID_MATOS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TYPE_MATOS]    Script Date: 07/11/2024 08:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TYPE_MATOS](
	[ID_TYPE] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](50) NOT NULL,
 CONSTRAINT [TYPE_MATOS_PK] PRIMARY KEY CLUSTERED 
(
	[ID_TYPE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 07/11/2024 08:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateur](
	[ID_USER] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](50) NOT NULL,
	[MDP] [varchar](128) NOT NULL,
 CONSTRAINT [Utilisateur_PK] PRIMARY KEY CLUSTERED 
(
	[ID_USER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ID_CLIENT], [Nom], [Mail], [Tel]) VALUES (1, N'Galeries', NULL, N'06855268615')
INSERT [dbo].[Client] ([ID_CLIENT], [Nom], [Mail], [Tel]) VALUES (2, N'Printemps', N'loin@prin.fr', NULL)
INSERT [dbo].[Client] ([ID_CLIENT], [Nom], [Mail], [Tel]) VALUES (3, N'Carrefour', N'contact@carrefour.com', N'062255885')
INSERT [dbo].[Client] ([ID_CLIENT], [Nom], [Mail], [Tel]) VALUES (4, N'Intermarché', N'inter@gmail.com', NULL)
INSERT [dbo].[Client] ([ID_CLIENT], [Nom], [Mail], [Tel]) VALUES (5, N'Harrods', N'har@har.are', NULL)
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Intervention] ON 

INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (1, CAST(N'2023-08-20' AS Date), N'je me suis perdu', 4)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (3, CAST(N'2023-08-22' AS Date), N'Mince, ecore perdu !!', 5)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (4, CAST(N'2001-01-31' AS Date), N'J''ai retrouvé', 13)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (6, CAST(N'2020-12-25' AS Date), N'Noyeux Joel !!', 11)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (7, CAST(N'2039-11-30' AS Date), N'super inter et hop !!', 3)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (8, CAST(N'2039-02-28' AS Date), N'sufffet hop !!', 3)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (9, CAST(N'2021-06-10' AS Date), N'The, allways', 11)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (10, CAST(N'2003-06-07' AS Date), N'salut gg', 4)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (11, CAST(N'2024-10-28' AS Date), N'incroyable que ça ait marché', 11)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (12, CAST(N'2024-10-31' AS Date), N'le chien des basker''ville', 9)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (13, CAST(N'2024-10-31' AS Date), N'l''apostrophe de l''iaudet', 10)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (14, CAST(N'2024-10-31' AS Date), N'cucou et ''voila'' moi', 10)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (15, CAST(N'2024-10-31' AS Date), N'sdgsgdsgd', 9)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (16, CAST(N'2048-11-30' AS Date), N''' (1=1) --', 1)
INSERT [dbo].[Intervention] ([ID_INTER], [Date_inter], [Comment], [ID_MATOS]) VALUES (17, CAST(N'2019-11-07' AS Date), N'toooooooodllllllllllllllllllllllllllcfkfjSQFF', 11)
SET IDENTITY_INSERT [dbo].[Intervention] OFF
GO
SET IDENTITY_INSERT [dbo].[MATOS] ON 

INSERT [dbo].[MATOS] ([ID_MATOS], [Nom], [Description], [NSerie], [Marque], [DateInst], [ID_TYPE], [ID_CLIENT], [MTBF]) VALUES (1, N'UC485', N'Le top du top du rien du top', N'05065656', N'Dell', CAST(N'2021-05-09' AS Date), 1, 4, 2)
INSERT [dbo].[MATOS] ([ID_MATOS], [Nom], [Description], [NSerie], [Marque], [DateInst], [ID_TYPE], [ID_CLIENT], [MTBF]) VALUES (2, N'EP474', NULL, N'4544545', N'EPSON', CAST(N'2015-09-18' AS Date), 11, 1, 60)
INSERT [dbo].[MATOS] ([ID_MATOS], [Nom], [Description], [NSerie], [Marque], [DateInst], [ID_TYPE], [ID_CLIENT], [MTBF]) VALUES (3, N'switchy', N'bien connecté', N'66565', N'Cisco', NULL, 7, 1, 55)
INSERT [dbo].[MATOS] ([ID_MATOS], [Nom], [Description], [NSerie], [Marque], [DateInst], [ID_TYPE], [ID_CLIENT], [MTBF]) VALUES (4, N'screen big cool', NULL, N'98268616', N'Display', CAST(N'2024-08-31' AS Date), 4, 2, 120)
INSERT [dbo].[MATOS] ([ID_MATOS], [Nom], [Description], [NSerie], [Marque], [DateInst], [ID_TYPE], [ID_CLIENT], [MTBF]) VALUES (5, N'Disque Tres dur', N'pas mal', N'8987454', N'Claude françois', CAST(N'1979-01-08' AS Date), 2, 4, 120)
INSERT [dbo].[MATOS] ([ID_MATOS], [Nom], [Description], [NSerie], [Marque], [DateInst], [ID_TYPE], [ID_CLIENT], [MTBF]) VALUES (7, N'I15', N'vroooom', N'45', N'intel', NULL, 10, 2, 62)
INSERT [dbo].[MATOS] ([ID_MATOS], [Nom], [Description], [NSerie], [Marque], [DateInst], [ID_TYPE], [ID_CLIENT], [MTBF]) VALUES (8, N'I19', N'coolpop', N'8767564', N'intel', CAST(N'2024-09-30' AS Date), 10, 3, 100)
INSERT [dbo].[MATOS] ([ID_MATOS], [Nom], [Description], [NSerie], [Marque], [DateInst], [ID_TYPE], [ID_CLIENT], [MTBF]) VALUES (9, N'I3', N'une daube', N'66', N'intel', CAST(N'1905-05-19' AS Date), 10, 1, NULL)
INSERT [dbo].[MATOS] ([ID_MATOS], [Nom], [Description], [NSerie], [Marque], [DateInst], [ID_TYPE], [ID_CLIENT], [MTBF]) VALUES (10, N'HP74', N'ou est le papier ?', N'15726286', N'HP', CAST(N'2023-05-19' AS Date), 11, 2, NULL)
INSERT [dbo].[MATOS] ([ID_MATOS], [Nom], [Description], [NSerie], [Marque], [DateInst], [ID_TYPE], [ID_CLIENT], [MTBF]) VALUES (11, N'HP711', N'oui', N'45412', N'HP', CAST(N'2022-05-19' AS Date), 11, 1, 12)
INSERT [dbo].[MATOS] ([ID_MATOS], [Nom], [Description], [NSerie], [Marque], [DateInst], [ID_TYPE], [ID_CLIENT], [MTBF]) VALUES (13, N'Canon J777', N'K none ??', N'875775', N'Canon', NULL, 11, 4, 240)
SET IDENTITY_INSERT [dbo].[MATOS] OFF
GO
SET IDENTITY_INSERT [dbo].[TYPE_MATOS] ON 

INSERT [dbo].[TYPE_MATOS] ([ID_TYPE], [Nom]) VALUES (1, N'UC')
INSERT [dbo].[TYPE_MATOS] ([ID_TYPE], [Nom]) VALUES (2, N'HDD')
INSERT [dbo].[TYPE_MATOS] ([ID_TYPE], [Nom]) VALUES (3, N'Clavier')
INSERT [dbo].[TYPE_MATOS] ([ID_TYPE], [Nom]) VALUES (4, N'Ecran')
INSERT [dbo].[TYPE_MATOS] ([ID_TYPE], [Nom]) VALUES (5, N'Souris')
INSERT [dbo].[TYPE_MATOS] ([ID_TYPE], [Nom]) VALUES (6, N'Routeur')
INSERT [dbo].[TYPE_MATOS] ([ID_TYPE], [Nom]) VALUES (7, N'Switch')
INSERT [dbo].[TYPE_MATOS] ([ID_TYPE], [Nom]) VALUES (8, N'Hub')
INSERT [dbo].[TYPE_MATOS] ([ID_TYPE], [Nom]) VALUES (9, N'RAM')
INSERT [dbo].[TYPE_MATOS] ([ID_TYPE], [Nom]) VALUES (10, N'CPU')
INSERT [dbo].[TYPE_MATOS] ([ID_TYPE], [Nom]) VALUES (11, N'Imprimante')
SET IDENTITY_INSERT [dbo].[TYPE_MATOS] OFF
GO
SET IDENTITY_INSERT [dbo].[Utilisateur] ON 

INSERT [dbo].[Utilisateur] ([ID_USER], [Nom], [MDP]) VALUES (1, N'toto', N'toto')
INSERT [dbo].[Utilisateur] ([ID_USER], [Nom], [MDP]) VALUES (2, N'titi', N'grosminet')
INSERT [dbo].[Utilisateur] ([ID_USER], [Nom], [MDP]) VALUES (3, N'steph', N'mdp')
SET IDENTITY_INSERT [dbo].[Utilisateur] OFF
GO
ALTER TABLE [dbo].[Intervention]  WITH CHECK ADD  CONSTRAINT [Intervention_MATOS_FK] FOREIGN KEY([ID_MATOS])
REFERENCES [dbo].[MATOS] ([ID_MATOS])
GO
ALTER TABLE [dbo].[Intervention] CHECK CONSTRAINT [Intervention_MATOS_FK]
GO
ALTER TABLE [dbo].[MATOS]  WITH CHECK ADD  CONSTRAINT [MATOS_Client0_FK] FOREIGN KEY([ID_CLIENT])
REFERENCES [dbo].[Client] ([ID_CLIENT])
GO
ALTER TABLE [dbo].[MATOS] CHECK CONSTRAINT [MATOS_Client0_FK]
GO
ALTER TABLE [dbo].[MATOS]  WITH CHECK ADD  CONSTRAINT [MATOS_TYPE_MATOS_FK] FOREIGN KEY([ID_TYPE])
REFERENCES [dbo].[TYPE_MATOS] ([ID_TYPE])
GO
ALTER TABLE [dbo].[MATOS] CHECK CONSTRAINT [MATOS_TYPE_MATOS_FK]
GO
USE [master]
GO
ALTER DATABASE [MJV] SET  READ_WRITE 
GO