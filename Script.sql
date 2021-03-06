USE [master]
GO
/****** Object:  Database [MostriVSEroi]    Script Date: 03/09/2021 15:31:01 ******/
CREATE DATABASE [MostriVSEroi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MostriVSEroi', FILENAME = N'C:\Users\Elena\MostriVSEroi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MostriVSEroi_log', FILENAME = N'C:\Users\Elena\MostriVSEroi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MostriVSEroi] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MostriVSEroi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MostriVSEroi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MostriVSEroi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MostriVSEroi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MostriVSEroi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MostriVSEroi] SET ARITHABORT OFF 
GO
ALTER DATABASE [MostriVSEroi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MostriVSEroi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MostriVSEroi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MostriVSEroi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MostriVSEroi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MostriVSEroi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MostriVSEroi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MostriVSEroi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MostriVSEroi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MostriVSEroi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MostriVSEroi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MostriVSEroi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MostriVSEroi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MostriVSEroi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MostriVSEroi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MostriVSEroi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MostriVSEroi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MostriVSEroi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MostriVSEroi] SET  MULTI_USER 
GO
ALTER DATABASE [MostriVSEroi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MostriVSEroi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MostriVSEroi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MostriVSEroi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MostriVSEroi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MostriVSEroi] SET QUERY_STORE = OFF
GO
USE [MostriVSEroi]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MostriVSEroi]
GO
/****** Object:  Table [dbo].[Arma]    Script Date: 03/09/2021 15:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](25) NULL,
	[PuntiDanno] [int] NULL,
	[IdCategoria] [int] NULL,
 CONSTRAINT [PK_Arma] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 03/09/2021 15:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](25) NULL,
	[Avversario] [bit] NULL,
 CONSTRAINT [PK__Categori__3214EC0760672C2E] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eroe]    Script Date: 03/09/2021 15:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eroe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](25) NULL,
	[IdUtente] [int] NULL,
	[IdArma] [int] NULL,
	[IdCategoria] [int] NULL,
 CONSTRAINT [PK_Eroe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 03/09/2021 15:31:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nickname] [nvarchar](25) NOT NULL,
	[Pass] [nvarchar](10) NOT NULL,
	[Livello] [int] NULL,
	[PuntiVita] [int] NULL,
	[Autenticazione] [bit] NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK__Utente__3214EC0755D3DE5E] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Arma] ON 

INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (1, N'Alabarda', 15, 1)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (2, N'Ascia', 8, 1)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (3, N'Mazza', 5, 1)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (4, N'Spada', 10, 1)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (5, N'Spadone', 15, 1)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (6, N'Arco e frecce', 8, 2)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (7, N'Bacchetta', 5, 2)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (8, N'Bastone magico', 10, 2)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (9, N'Onda d''urto', 15, 2)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (10, N'Pugnale', 5, 2)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (11, N'Discorso noioso', 4, 3)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (12, N'Farneticazione', 7, 3)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (13, N'Imprecazione', 5, 3)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (14, N'Magia nera', 3, 3)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (15, N'Arco', 7, 4)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (16, N'Clava', 5, 4)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (17, N'Spada rotta', 3, 4)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (18, N'Mazza chiodata', 10, 4)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (19, N'Alabarda del drago', 30, 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (20, N'Divinazione', 15, 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (21, N'Fulmine', 10, 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (22, N'Fulmine celeste', 15, 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (23, N'Tempesta', 8, 5)
INSERT [dbo].[Arma] ([Id], [Nome], [PuntiDanno], [IdCategoria]) VALUES (24, N'Tempesta oscura', 15, 5)
SET IDENTITY_INSERT [dbo].[Arma] OFF
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id], [Nome], [Avversario]) VALUES (1, N'Guerriero', 0)
INSERT [dbo].[Categoria] ([Id], [Nome], [Avversario]) VALUES (2, N'Mago', 0)
INSERT [dbo].[Categoria] ([Id], [Nome], [Avversario]) VALUES (3, N'Cultista', 1)
INSERT [dbo].[Categoria] ([Id], [Nome], [Avversario]) VALUES (4, N'Orco', 1)
INSERT [dbo].[Categoria] ([Id], [Nome], [Avversario]) VALUES (5, N'Signore del male', 1)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Eroe] ON 

INSERT [dbo].[Eroe] ([Id], [Nome], [IdUtente], [IdArma], [IdCategoria]) VALUES (1, N'Batman', 6, 3, 1)
SET IDENTITY_INSERT [dbo].[Eroe] OFF
GO
SET IDENTITY_INSERT [dbo].[Utente] ON 

INSERT [dbo].[Utente] ([Id], [Nickname], [Pass], [Livello], [PuntiVita], [Autenticazione], [IsAdmin]) VALUES (6, N'Elena', N'1234', 1, 20, 1, 0)
SET IDENTITY_INSERT [dbo].[Utente] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Utente__CC6CD17E8CD0E08B]    Script Date: 03/09/2021 15:31:44 ******/
ALTER TABLE [dbo].[Utente] ADD  CONSTRAINT [UQ__Utente__CC6CD17E8CD0E08B] UNIQUE NONCLUSTERED 
(
	[Nickname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Arma]  WITH CHECK ADD  CONSTRAINT [FK_Arma_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Arma] CHECK CONSTRAINT [FK_Arma_Categoria]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Utente] FOREIGN KEY([IdUtente])
REFERENCES [dbo].[Utente] ([Id])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Utente]
GO
USE [master]
GO
ALTER DATABASE [MostriVSEroi] SET  READ_WRITE 
GO
