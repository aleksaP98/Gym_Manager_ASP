USE [master]
GO
/****** Object:  Database [Gym_Manager]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE DATABASE [Gym_Manager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Gym_Manager', FILENAME = N'D:\SQL server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Gym_Manager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Gym_Manager_log', FILENAME = N'D:\SQL server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Gym_Manager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Gym_Manager] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Gym_Manager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Gym_Manager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Gym_Manager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Gym_Manager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Gym_Manager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Gym_Manager] SET ARITHABORT OFF 
GO
ALTER DATABASE [Gym_Manager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Gym_Manager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Gym_Manager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Gym_Manager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Gym_Manager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Gym_Manager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Gym_Manager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Gym_Manager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Gym_Manager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Gym_Manager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Gym_Manager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Gym_Manager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Gym_Manager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Gym_Manager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Gym_Manager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Gym_Manager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Gym_Manager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Gym_Manager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Gym_Manager] SET  MULTI_USER 
GO
ALTER DATABASE [Gym_Manager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Gym_Manager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Gym_Manager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Gym_Manager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Gym_Manager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Gym_Manager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Gym_Manager] SET QUERY_STORE = OFF
GO
USE [Gym_Manager]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Authentification] [nvarchar](450) NOT NULL,
	[ExpiresAt] [datetime2](7) NOT NULL,
	[RenewedAt] [datetime2](7) NULL,
	[MembershipId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GymImages]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GymImages](
	[GymId] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
 CONSTRAINT [PK_GymImages] PRIMARY KEY CLUSTERED 
(
	[GymId] ASC,
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gyms]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gyms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[Address] [nvarchar](max) NOT NULL,
	[PersonalTrainingPrice] [decimal](18, 2) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Gyms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GymUsers]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GymUsers](
	[GymId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_GymUsers] PRIMARY KEY CLUSTERED 
(
	[GymId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Src] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Memberships]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Memberships](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[GymMembership] [bit] NOT NULL,
	[PersonalizedCard] [bit] NOT NULL,
	[MobileApp] [bit] NOT NULL,
	[ProgressTracker] [bit] NOT NULL,
	[FreePersonalTrainings] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Memberships] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalTrainings]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalTrainings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TrainerId] [int] NOT NULL,
	[TrainingStart] [datetime2](7) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_PersonalTrainings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainers]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [int] NOT NULL,
	[Height] [real] NULL,
	[Weight] [real] NULL,
	[BodyFatPercent] [real] NULL,
	[BodyMusclePercent] [real] NULL,
	[CardId] [int] NOT NULL,
	[GymId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Trainers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainerUseCases]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainerUseCases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TrainerId] [int] NOT NULL,
	[UseCaseId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TrainerUseCases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UseCaseLogs]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UseCaseLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[UseCaseName] [nvarchar](max) NULL,
	[Data] [nvarchar](max) NULL,
	[Actor] [nvarchar](max) NULL,
 CONSTRAINT [PK_UseCaseLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](450) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [int] NOT NULL,
	[Height] [real] NULL,
	[Weight] [real] NULL,
	[BodyFatPercent] [real] NULL,
	[BodyMusclePercent] [real] NULL,
	[RoleId] [int] NOT NULL,
	[CardId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUseCases]    Script Date: 6/17/2021 11:51:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUseCases](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[UseCaseId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserUseCases] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Cards_Authentification]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cards_Authentification] ON [dbo].[Cards]
(
	[Authentification] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cards_MembershipId]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_Cards_MembershipId] ON [dbo].[Cards]
(
	[MembershipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GymImages_ImageId]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_GymImages_ImageId] ON [dbo].[GymImages]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GymUsers_UserId]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_GymUsers_UserId] ON [dbo].[GymUsers]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonalTrainings_TrainerId]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_PersonalTrainings_TrainerId] ON [dbo].[PersonalTrainings]
(
	[TrainerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonalTrainings_UserId]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_PersonalTrainings_UserId] ON [dbo].[PersonalTrainings]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Trainers_CardId]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Trainers_CardId] ON [dbo].[Trainers]
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Trainers_Email]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Trainers_Email] ON [dbo].[Trainers]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Trainers_GymId]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_Trainers_GymId] ON [dbo].[Trainers]
(
	[GymId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TrainerUseCases_TrainerId]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_TrainerUseCases_TrainerId] ON [dbo].[TrainerUseCases]
(
	[TrainerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_CardId]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_CardId] ON [dbo].[Users]
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Email]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserUseCases_UserId]    Script Date: 6/17/2021 11:51:29 AM ******/
CREATE NONCLUSTERED INDEX [IX_UserUseCases_UserId] ON [dbo].[UserUseCases]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cards]  WITH CHECK ADD  CONSTRAINT [FK_Cards_Memberships_MembershipId] FOREIGN KEY([MembershipId])
REFERENCES [dbo].[Memberships] ([Id])
GO
ALTER TABLE [dbo].[Cards] CHECK CONSTRAINT [FK_Cards_Memberships_MembershipId]
GO
ALTER TABLE [dbo].[GymImages]  WITH CHECK ADD  CONSTRAINT [FK_GymImages_Gyms_GymId] FOREIGN KEY([GymId])
REFERENCES [dbo].[Gyms] ([Id])
GO
ALTER TABLE [dbo].[GymImages] CHECK CONSTRAINT [FK_GymImages_Gyms_GymId]
GO
ALTER TABLE [dbo].[GymImages]  WITH CHECK ADD  CONSTRAINT [FK_GymImages_Images_ImageId] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
GO
ALTER TABLE [dbo].[GymImages] CHECK CONSTRAINT [FK_GymImages_Images_ImageId]
GO
ALTER TABLE [dbo].[GymUsers]  WITH CHECK ADD  CONSTRAINT [FK_GymUsers_Gyms_GymId] FOREIGN KEY([GymId])
REFERENCES [dbo].[Gyms] ([Id])
GO
ALTER TABLE [dbo].[GymUsers] CHECK CONSTRAINT [FK_GymUsers_Gyms_GymId]
GO
ALTER TABLE [dbo].[GymUsers]  WITH CHECK ADD  CONSTRAINT [FK_GymUsers_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[GymUsers] CHECK CONSTRAINT [FK_GymUsers_Users_UserId]
GO
ALTER TABLE [dbo].[PersonalTrainings]  WITH CHECK ADD  CONSTRAINT [FK_PersonalTrainings_Trainers_TrainerId] FOREIGN KEY([TrainerId])
REFERENCES [dbo].[Trainers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonalTrainings] CHECK CONSTRAINT [FK_PersonalTrainings_Trainers_TrainerId]
GO
ALTER TABLE [dbo].[PersonalTrainings]  WITH CHECK ADD  CONSTRAINT [FK_PersonalTrainings_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PersonalTrainings] CHECK CONSTRAINT [FK_PersonalTrainings_Users_UserId]
GO
ALTER TABLE [dbo].[Trainers]  WITH CHECK ADD  CONSTRAINT [FK_Trainers_Cards_CardId] FOREIGN KEY([CardId])
REFERENCES [dbo].[Cards] ([Id])
GO
ALTER TABLE [dbo].[Trainers] CHECK CONSTRAINT [FK_Trainers_Cards_CardId]
GO
ALTER TABLE [dbo].[Trainers]  WITH CHECK ADD  CONSTRAINT [FK_Trainers_Gyms_GymId] FOREIGN KEY([GymId])
REFERENCES [dbo].[Gyms] ([Id])
GO
ALTER TABLE [dbo].[Trainers] CHECK CONSTRAINT [FK_Trainers_Gyms_GymId]
GO
ALTER TABLE [dbo].[TrainerUseCases]  WITH CHECK ADD  CONSTRAINT [FK_TrainerUseCases_Trainers_TrainerId] FOREIGN KEY([TrainerId])
REFERENCES [dbo].[Trainers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TrainerUseCases] CHECK CONSTRAINT [FK_TrainerUseCases_Trainers_TrainerId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Cards_CardId] FOREIGN KEY([CardId])
REFERENCES [dbo].[Cards] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Cards_CardId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserUseCases]  WITH CHECK ADD  CONSTRAINT [FK_UserUseCases_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserUseCases] CHECK CONSTRAINT [FK_UserUseCases_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [Gym_Manager] SET  READ_WRITE 
GO
