USE [master]
GO
/****** Object:  Database [BetizagastiGnocchi]    Script Date: 30/11/2017 3:09:35 ******/
CREATE DATABASE [BetizagastiGnocchi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BetizagastiGnocchi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BetizagastiGnocchi.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BetizagastiGnocchi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BetizagastiGnocchi_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BetizagastiGnocchi] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BetizagastiGnocchi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BetizagastiGnocchi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET ARITHABORT OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BetizagastiGnocchi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BetizagastiGnocchi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BetizagastiGnocchi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BetizagastiGnocchi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BetizagastiGnocchi] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BetizagastiGnocchi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BetizagastiGnocchi] SET  MULTI_USER 
GO
ALTER DATABASE [BetizagastiGnocchi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BetizagastiGnocchi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BetizagastiGnocchi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BetizagastiGnocchi] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BetizagastiGnocchi] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BetizagastiGnocchi]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ActionOperations]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionOperations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ActionOperations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Batches]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Batches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[User_Id] [int] NULL,
	[BatchTransport_Id] [int] NULL,
	[UserdId] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Batches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BatchTransports]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BatchTransports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[FinishDate] [datetime] NOT NULL,
	[UserdId] [int] NULL,
	[CreatorUserId] [int] NULL,
 CONSTRAINT [PK_dbo.BatchTransports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DamageRegistries]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DamageRegistries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Inspection_Id] [int] NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_dbo.DamageRegistries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Inspections]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inspections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [smallint] NOT NULL,
	[DateAndTime] [datetime] NOT NULL,
	[Place] [smallint] NOT NULL,
	[VehicleId] [int] NOT NULL,
	[Inspector_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Inspections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RouteZones]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteZones](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[ZonesToPass] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.RouteZones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[States]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlaceInMoment] [smallint] NOT NULL,
	[CurrentDate] [datetime] NOT NULL,
	[Vehicle_Id] [int] NULL,
 CONSTRAINT [PK_dbo.States] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRolActionOperations]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRolActionOperations](
	[UserRol_Id] [int] NOT NULL,
	[ActionOperation_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserRolActionOperations] PRIMARY KEY CLUSTERED 
(
	[UserRol_Id] ASC,
	[ActionOperation_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRols]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRols](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UType] [smallint] NOT NULL,
 CONSTRAINT [PK_dbo.UserRols] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Token] [uniqueidentifier] NOT NULL,
	[Rol_Id] [int] NOT NULL,
	[Salt] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Telephone] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VehicleMovements]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleMovements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Time] [datetime] NOT NULL,
	[DestinationZone_Id] [int] NULL,
	[OriginZone_Id] [int] NULL,
	[User_Id] [int] NULL,
	[Vehicle_Id] [int] NULL,
 CONSTRAINT [PK_dbo.VehicleMovements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Brand] [nvarchar](max) NULL,
	[Model] [nvarchar](max) NULL,
	[Year] [int] NOT NULL,
	[BatchId] [int] NULL,
	[Color] [nvarchar](max) NULL,
	[VehicleType] [smallint] NOT NULL,
	[VIN] [nvarchar](max) NULL,
	[ZoneId] [int] NULL,
	[readyToBuy] [bit] NOT NULL DEFAULT ((0)),
	[SellId] [int] NULL,
	[sell_Name] [nvarchar](max) NULL,
	[sell_Surname] [nvarchar](max) NULL,
	[sell_Telephone] [nvarchar](max) NULL,
	[sell_Price] [bigint] NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Vehicles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Zones]    Script Date: 30/11/2017 3:09:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[MaxCapacity] [int] NOT NULL,
	[UsedCapacity] [int] NOT NULL,
	[Zone_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Zones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_BatchTransport_Id]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_BatchTransport_Id] ON [dbo].[Batches]
(
	[BatchTransport_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_Id]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[Batches]
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CreatorUserId]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_CreatorUserId] ON [dbo].[BatchTransports]
(
	[CreatorUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserdId]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_UserdId] ON [dbo].[BatchTransports]
(
	[UserdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Inspection_Id]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_Inspection_Id] ON [dbo].[DamageRegistries]
(
	[Inspection_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Inspector_Id]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_Inspector_Id] ON [dbo].[Inspections]
(
	[Inspector_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehicleId]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_VehicleId] ON [dbo].[Inspections]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicle_Id]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_Vehicle_Id] ON [dbo].[States]
(
	[Vehicle_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ActionOperation_Id]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_ActionOperation_Id] ON [dbo].[UserRolActionOperations]
(
	[ActionOperation_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserRol_Id]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_UserRol_Id] ON [dbo].[UserRolActionOperations]
(
	[UserRol_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rol_Id]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_Rol_Id] ON [dbo].[Users]
(
	[Rol_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DestinationZone_Id]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_DestinationZone_Id] ON [dbo].[VehicleMovements]
(
	[DestinationZone_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OriginZone_Id]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_OriginZone_Id] ON [dbo].[VehicleMovements]
(
	[OriginZone_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_Id]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[VehicleMovements]
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Vehicle_Id]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_Vehicle_Id] ON [dbo].[VehicleMovements]
(
	[Vehicle_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BatchId]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_BatchId] ON [dbo].[Vehicles]
(
	[BatchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ZoneId]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_ZoneId] ON [dbo].[Vehicles]
(
	[ZoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Zone_Id]    Script Date: 30/11/2017 3:09:36 ******/
CREATE NONCLUSTERED INDEX [IX_Zone_Id] ON [dbo].[Zones]
(
	[Zone_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Batches]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Batches_dbo.BatchTransports_BatchTransport_Id] FOREIGN KEY([BatchTransport_Id])
REFERENCES [dbo].[BatchTransports] ([Id])
GO
ALTER TABLE [dbo].[Batches] CHECK CONSTRAINT [FK_dbo.Batches_dbo.BatchTransports_BatchTransport_Id]
GO
ALTER TABLE [dbo].[Batches]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Batches_dbo.Users_Creator_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Batches] CHECK CONSTRAINT [FK_dbo.Batches_dbo.Users_Creator_Id]
GO
ALTER TABLE [dbo].[BatchTransports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BatchTransports_dbo.Users_CreatorUserId] FOREIGN KEY([CreatorUserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[BatchTransports] CHECK CONSTRAINT [FK_dbo.BatchTransports_dbo.Users_CreatorUserId]
GO
ALTER TABLE [dbo].[BatchTransports]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BatchTransports_dbo.Users_Transporter_Id] FOREIGN KEY([UserdId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[BatchTransports] CHECK CONSTRAINT [FK_dbo.BatchTransports_dbo.Users_Transporter_Id]
GO
ALTER TABLE [dbo].[DamageRegistries]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DamageRegistries_dbo.Inspections_Inspection_Id] FOREIGN KEY([Inspection_Id])
REFERENCES [dbo].[Inspections] ([Id])
GO
ALTER TABLE [dbo].[DamageRegistries] CHECK CONSTRAINT [FK_dbo.DamageRegistries_dbo.Inspections_Inspection_Id]
GO
ALTER TABLE [dbo].[Inspections]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Inspections_dbo.Users_Inspector_Id] FOREIGN KEY([Inspector_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Inspections] CHECK CONSTRAINT [FK_dbo.Inspections_dbo.Users_Inspector_Id]
GO
ALTER TABLE [dbo].[Inspections]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Inspections_dbo.Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inspections] CHECK CONSTRAINT [FK_dbo.Inspections_dbo.Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[States]  WITH CHECK ADD  CONSTRAINT [FK_dbo.States_dbo.Vehicles_Vehicle_Id] FOREIGN KEY([Vehicle_Id])
REFERENCES [dbo].[Vehicles] ([Id])
GO
ALTER TABLE [dbo].[States] CHECK CONSTRAINT [FK_dbo.States_dbo.Vehicles_Vehicle_Id]
GO
ALTER TABLE [dbo].[UserRolActionOperations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRolActionOperations_dbo.ActionOperations_ActionOperation_Id] FOREIGN KEY([ActionOperation_Id])
REFERENCES [dbo].[ActionOperations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRolActionOperations] CHECK CONSTRAINT [FK_dbo.UserRolActionOperations_dbo.ActionOperations_ActionOperation_Id]
GO
ALTER TABLE [dbo].[UserRolActionOperations]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRolActionOperations_dbo.UserRols_UserRol_Id] FOREIGN KEY([UserRol_Id])
REFERENCES [dbo].[UserRols] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRolActionOperations] CHECK CONSTRAINT [FK_dbo.UserRolActionOperations_dbo.UserRols_UserRol_Id]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.UserRols_Rol_Id] FOREIGN KEY([Rol_Id])
REFERENCES [dbo].[UserRols] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.UserRols_Rol_Id]
GO
ALTER TABLE [dbo].[VehicleMovements]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VehicleMovements_dbo.Users_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[VehicleMovements] CHECK CONSTRAINT [FK_dbo.VehicleMovements_dbo.Users_User_Id]
GO
ALTER TABLE [dbo].[VehicleMovements]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VehicleMovements_dbo.Vehicles_Vehicle_Id] FOREIGN KEY([Vehicle_Id])
REFERENCES [dbo].[Vehicles] ([Id])
GO
ALTER TABLE [dbo].[VehicleMovements] CHECK CONSTRAINT [FK_dbo.VehicleMovements_dbo.Vehicles_Vehicle_Id]
GO
ALTER TABLE [dbo].[VehicleMovements]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VehicleMovements_dbo.Zones_DestinationZone_Id] FOREIGN KEY([DestinationZone_Id])
REFERENCES [dbo].[Zones] ([Id])
GO
ALTER TABLE [dbo].[VehicleMovements] CHECK CONSTRAINT [FK_dbo.VehicleMovements_dbo.Zones_DestinationZone_Id]
GO
ALTER TABLE [dbo].[VehicleMovements]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VehicleMovements_dbo.Zones_OriginZone_Id] FOREIGN KEY([OriginZone_Id])
REFERENCES [dbo].[Zones] ([Id])
GO
ALTER TABLE [dbo].[VehicleMovements] CHECK CONSTRAINT [FK_dbo.VehicleMovements_dbo.Zones_OriginZone_Id]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Vehicles_dbo.Batches_BatchId] FOREIGN KEY([BatchId])
REFERENCES [dbo].[Batches] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_dbo.Vehicles_dbo.Batches_BatchId]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Vehicles_dbo.Zones_ZoneId] FOREIGN KEY([ZoneId])
REFERENCES [dbo].[Zones] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_dbo.Vehicles_dbo.Zones_ZoneId]
GO
ALTER TABLE [dbo].[Zones]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Zones_dbo.Zones_Zone_Id] FOREIGN KEY([Zone_Id])
REFERENCES [dbo].[Zones] ([Id])
GO
ALTER TABLE [dbo].[Zones] CHECK CONSTRAINT [FK_dbo.Zones_dbo.Zones_Zone_Id]
GO
USE [master]
GO
ALTER DATABASE [BetizagastiGnocchi] SET  READ_WRITE 
GO
