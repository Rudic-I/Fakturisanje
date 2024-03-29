USE [master]
GO
/****** Object:  Database [Fakturisanje]    Script Date: 27-Jul-19 10:08:43 AM ******/
CREATE DATABASE [Fakturisanje]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Fakturisanje', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Fakturisanje.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Fakturisanje_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Fakturisanje_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Fakturisanje] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Fakturisanje].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Fakturisanje] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Fakturisanje] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Fakturisanje] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Fakturisanje] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Fakturisanje] SET ARITHABORT OFF 
GO
ALTER DATABASE [Fakturisanje] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Fakturisanje] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Fakturisanje] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Fakturisanje] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Fakturisanje] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Fakturisanje] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Fakturisanje] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Fakturisanje] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Fakturisanje] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Fakturisanje] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Fakturisanje] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Fakturisanje] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Fakturisanje] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Fakturisanje] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Fakturisanje] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Fakturisanje] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Fakturisanje] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Fakturisanje] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Fakturisanje] SET  MULTI_USER 
GO
ALTER DATABASE [Fakturisanje] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Fakturisanje] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Fakturisanje] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Fakturisanje] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Fakturisanje] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Fakturisanje]
GO
/****** Object:  Table [dbo].[Field]    Script Date: 27-Jul-19 10:08:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Field](
	[FieldId] [int] IDENTITY(1,1) NOT NULL,
	[FieldName] [nvarchar](256) NOT NULL,
	[DocumentId] [nvarchar](10) NOT NULL,
	[Price] [float] NOT NULL,
	[Amount] [int] NOT NULL,
 CONSTRAINT [PK_Field] PRIMARY KEY CLUSTERED 
(
	[FieldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 27-Jul-19 10:08:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[DocumentId] [nvarchar](10) NOT NULL,
	[InvoiceId] [nvarchar](10) NOT NULL,
	[InvoiceDate] [date] NOT NULL,
	[Total] [float] NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27-Jul-19 10:08:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Role] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](15) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Field] ON 

INSERT [dbo].[Field] ([FieldId], [FieldName], [DocumentId], [Price], [Amount]) VALUES (37, N'Hleb', N'201902m4', 45, 2)
INSERT [dbo].[Field] ([FieldId], [FieldName], [DocumentId], [Price], [Amount]) VALUES (38, N'Mleko', N'201902m4', 79.99, 3)
INSERT [dbo].[Field] ([FieldId], [FieldName], [DocumentId], [Price], [Amount]) VALUES (40, N'Maline 100g', N'201904m12', 129.99, 4)
INSERT [dbo].[Field] ([FieldId], [FieldName], [DocumentId], [Price], [Amount]) VALUES (41, N'Kupine 250g', N'201904m12', 256.99, 2)
INSERT [dbo].[Field] ([FieldId], [FieldName], [DocumentId], [Price], [Amount]) VALUES (42, N'Lubenica', N'201904m12', 34, 1)
INSERT [dbo].[Field] ([FieldId], [FieldName], [DocumentId], [Price], [Amount]) VALUES (43, N'Jogurt', N'201902m4', 124.99, 2)
SET IDENTITY_INSERT [dbo].[Field] OFF
INSERT [dbo].[Invoice] ([DocumentId], [InvoiceId], [InvoiceDate], [Total]) VALUES (N'201902m4', N'm4', CAST(N'2019-02-02' AS Date), 579.95)
INSERT [dbo].[Invoice] ([DocumentId], [InvoiceId], [InvoiceDate], [Total]) VALUES (N'201904m12', N'mx456', CAST(N'2019-07-26' AS Date), 1067.94)
INSERT [dbo].[Invoice] ([DocumentId], [InvoiceId], [InvoiceDate], [Total]) VALUES (N'201905m22', N'm22', CAST(N'2019-02-26' AS Date), 0)
INSERT [dbo].[User] ([Role], [Password]) VALUES (N'saradnik', N'saradnik')
INSERT [dbo].[User] ([Role], [Password]) VALUES (N'korisnik', N'korisnik')
ALTER TABLE [dbo].[Field]  WITH CHECK ADD  CONSTRAINT [FK_Field_Invoice] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[Invoice] ([DocumentId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Field] CHECK CONSTRAINT [FK_Field_Invoice]
GO
USE [master]
GO
ALTER DATABASE [Fakturisanje] SET  READ_WRITE 
GO
