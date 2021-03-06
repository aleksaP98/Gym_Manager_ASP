USE [master]
GO
/****** Object:  Database [Gym_Manager]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[Cards]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[GymImages]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[Gyms]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[GymUsers]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[Images]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[Memberships]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[PersonalTrainings]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[Trainers]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[TrainerUseCases]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[UseCaseLogs]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 6/17/2021 12:31:45 PM ******/
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
/****** Object:  Table [dbo].[UserUseCases]    Script Date: 6/17/2021 12:31:45 PM ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210615204832_initial-mig', N'5.0.7')
GO
SET IDENTITY_INSERT [dbo].[Cards] ON 

INSERT [dbo].[Cards] ([Id], [Authentification], [ExpiresAt], [RenewedAt], [MembershipId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (4, N'JY6TABP$', CAST(N'2021-07-25T00:00:00.0000000' AS DateTime2), NULL, 1, CAST(N'2021-06-16T13:17:15.2044344' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Cards] ([Id], [Authentification], [ExpiresAt], [RenewedAt], [MembershipId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (5, N'K5HV3VCV', CAST(N'2021-07-30T00:00:00.0000000' AS DateTime2), NULL, 2, CAST(N'2021-06-16T13:18:13.7240769' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Cards] ([Id], [Authentification], [ExpiresAt], [RenewedAt], [MembershipId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (6, N'PHWTQHKY', CAST(N'2021-09-11T00:00:00.0000000' AS DateTime2), NULL, 3, CAST(N'2021-06-16T13:18:36.9835477' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Cards] ([Id], [Authentification], [ExpiresAt], [RenewedAt], [MembershipId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (7, N'$64I86TF', CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), NULL, 4, CAST(N'2021-06-16T13:18:49.7786002' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Cards] ([Id], [Authentification], [ExpiresAt], [RenewedAt], [MembershipId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (8, N'JTB54HOY', CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), NULL, 5, CAST(N'2021-06-16T13:18:57.5688891' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Cards] ([Id], [Authentification], [ExpiresAt], [RenewedAt], [MembershipId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (11, N'3$3OV1MH', CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), NULL, 4, CAST(N'2021-06-16T13:31:28.0303814' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Cards] ([Id], [Authentification], [ExpiresAt], [RenewedAt], [MembershipId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (12, N'439SB#TW', CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), NULL, 4, CAST(N'2021-06-16T13:31:31.0133016' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Cards] ([Id], [Authentification], [ExpiresAt], [RenewedAt], [MembershipId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (13, N'B#TB7#85', CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2), NULL, 4, CAST(N'2021-06-16T13:31:32.0528313' AS DateTime2), NULL, 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[Cards] OFF
GO
INSERT [dbo].[GymImages] ([GymId], [ImageId]) VALUES (2, 1)
INSERT [dbo].[GymImages] ([GymId], [ImageId]) VALUES (1, 2)
INSERT [dbo].[GymImages] ([GymId], [ImageId]) VALUES (1, 3)
INSERT [dbo].[GymImages] ([GymId], [ImageId]) VALUES (1, 4)
INSERT [dbo].[GymImages] ([GymId], [ImageId]) VALUES (3, 5)
INSERT [dbo].[GymImages] ([GymId], [ImageId]) VALUES (3, 6)
GO
SET IDENTITY_INSERT [dbo].[Gyms] ON 

INSERT [dbo].[Gyms] ([Id], [Name], [Description], [Address], [PersonalTrainingPrice], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1, N'Gym 1', N'Gym 1 descriiption', N'Gym 1 address', CAST(4.99 AS Decimal(18, 2)), CAST(N'2021-06-16T12:26:49.6899553' AS DateTime2), CAST(N'2021-06-16T12:36:31.6253383' AS DateTime2), 0, NULL, 1)
INSERT [dbo].[Gyms] ([Id], [Name], [Description], [Address], [PersonalTrainingPrice], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (2, N'Gym 2', N'Gym 2 descriiption', N'Gym 2 address', CAST(0.00 AS Decimal(18, 2)), CAST(N'2021-06-16T12:37:25.7894950' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Gyms] ([Id], [Name], [Description], [Address], [PersonalTrainingPrice], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (3, N'Gym 3', N'Gym 3 descriiption', N'Gym 3 address', CAST(0.00 AS Decimal(18, 2)), CAST(N'2021-06-16T12:37:46.6062005' AS DateTime2), NULL, 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[Gyms] OFF
GO
INSERT [dbo].[GymUsers] ([GymId], [UserId]) VALUES (2, 3)
INSERT [dbo].[GymUsers] ([GymId], [UserId]) VALUES (3, 3)
INSERT [dbo].[GymUsers] ([GymId], [UserId]) VALUES (2, 4)
INSERT [dbo].[GymUsers] ([GymId], [UserId]) VALUES (1, 5)
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1, N'wwwroot\images\263a5a51-8ae4-4c1a-8763-656d3ccacb22.jpg', CAST(N'2021-06-16T12:24:00.2533048' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (2, N'wwwroot\images\b4d37b5d-8f4a-4ff0-9b69-d826febee34a.jpg', CAST(N'2021-06-16T12:24:08.1656710' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (3, N'wwwroot\images\86a1c6f9-791b-431c-b31f-792e677c968d.jpg', CAST(N'2021-06-16T12:24:12.7380065' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (4, N'wwwroot\images\e9d887ef-b3bd-40e3-aee3-7d58f921143d.jpg', CAST(N'2021-06-16T12:25:21.5643520' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (5, N'wwwroot\images\8ba9ca35-bb37-4805-bdac-2c25ebf8ca32.jpg', CAST(N'2021-06-16T12:25:26.8861645' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (6, N'wwwroot\images\8af87ac6-ebf9-414f-8d84-d3d2933ce2ad.png', CAST(N'2021-06-16T12:25:32.3686378' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (7, N'wwwroot\images\45004a9c-d8bd-4138-93a1-f5c8c4bccff7.jpg', CAST(N'2021-06-16T12:25:36.1448926' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (8, N'wwwroot\images\1cd397d4-b5e9-4b4e-84c0-912fd39a0f44.jpg', CAST(N'2021-06-16T12:25:39.4550666' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (9, N'wwwroot\images\1cc9a11e-ab00-4b6a-b970-f9cbb3e9cde0.jpg', CAST(N'2021-06-16T12:25:43.8086649' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (10, N'wwwroot\images\0797926d-5c83-448e-92eb-68324cdc4810.jpg', CAST(N'2021-06-16T12:25:51.4936176' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (11, N'wwwroot\images\2969c866-0e4f-41c2-81f8-55f0f31a40c9.jpg', CAST(N'2021-06-16T12:25:55.1069603' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (12, N'wwwroot\images\0e9c73c0-79d6-4699-8a46-ee182ed17388.jpg', CAST(N'2021-06-16T12:25:59.2999581' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (13, N'wwwroot\images\7f103a41-7a01-4812-9e9a-690cbf09bc8a.jpg', CAST(N'2021-06-16T12:26:03.3512043' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (14, N'wwwroot\images\b6fe9dd7-4d38-4d64-9704-184e8977cc81.jpg', CAST(N'2021-06-16T12:26:07.5922256' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (15, N'wwwroot\images\06aeeeb4-16a4-4362-938e-3f9d4894c2bd.jpg', CAST(N'2021-06-16T12:26:10.7240285' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Images] ([Id], [Src], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (16, N'wwwroot\images\9711f2a0-1440-4154-8086-7ab6013d77f1.jpg', CAST(N'2021-06-16T12:26:14.5818637' AS DateTime2), NULL, 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Memberships] ON 

INSERT [dbo].[Memberships] ([Id], [Name], [Price], [GymMembership], [PersonalizedCard], [MobileApp], [ProgressTracker], [FreePersonalTrainings], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1, N'Standard Pack', CAST(9.99 AS Decimal(18, 2)), 1, 1, 0, 0, 0, CAST(N'2021-06-16T12:40:17.3539125' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Memberships] ([Id], [Name], [Price], [GymMembership], [PersonalizedCard], [MobileApp], [ProgressTracker], [FreePersonalTrainings], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (2, N'Premium Pack', CAST(19.99 AS Decimal(18, 2)), 1, 1, 1, 1, 0, CAST(N'2021-06-16T12:40:31.3396493' AS DateTime2), CAST(N'2021-06-16T12:46:15.7289444' AS DateTime2), 0, NULL, 1)
INSERT [dbo].[Memberships] ([Id], [Name], [Price], [GymMembership], [PersonalizedCard], [MobileApp], [ProgressTracker], [FreePersonalTrainings], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (3, N'Pro Pack', CAST(34.99 AS Decimal(18, 2)), 1, 1, 1, 1, 1, CAST(N'2021-06-16T12:40:40.7908213' AS DateTime2), CAST(N'2021-06-16T12:46:02.4311998' AS DateTime2), 0, NULL, 1)
INSERT [dbo].[Memberships] ([Id], [Name], [Price], [GymMembership], [PersonalizedCard], [MobileApp], [ProgressTracker], [FreePersonalTrainings], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (4, N'Trainer Pack', CAST(0.00 AS Decimal(18, 2)), 1, 1, 1, 1, 1, CAST(N'2021-06-16T12:43:20.0239667' AS DateTime2), CAST(N'2021-06-16T12:45:24.6229237' AS DateTime2), 0, NULL, 1)
INSERT [dbo].[Memberships] ([Id], [Name], [Price], [GymMembership], [PersonalizedCard], [MobileApp], [ProgressTracker], [FreePersonalTrainings], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (5, N'Admin Pack', CAST(0.00 AS Decimal(18, 2)), 1, 1, 0, 0, 0, CAST(N'2021-06-16T12:44:00.4222165' AS DateTime2), NULL, 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[Memberships] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonalTrainings] ON 

INSERT [dbo].[PersonalTrainings] ([Id], [UserId], [TrainerId], [TrainingStart], [Price], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1, 4, 4, CAST(N'2021-07-25T18:00:00.0000000' AS DateTime2), CAST(4.99 AS Decimal(18, 2)), CAST(N'2021-06-16T17:28:30.5697620' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[PersonalTrainings] ([Id], [UserId], [TrainerId], [TrainingStart], [Price], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (2, 3, 4, CAST(N'2021-06-18T18:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), CAST(N'2021-06-16T17:40:01.4559930' AS DateTime2), CAST(N'2021-06-17T00:35:55.0843276' AS DateTime2), 0, NULL, 1)
INSERT [dbo].[PersonalTrainings] ([Id], [UserId], [TrainerId], [TrainingStart], [Price], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (3, 4, 3, CAST(N'2021-05-24T18:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), CAST(N'2021-06-16T17:40:19.3303511' AS DateTime2), CAST(N'2021-06-16T18:03:30.3127740' AS DateTime2), 1, CAST(N'2021-06-16T18:03:30.2543841' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[PersonalTrainings] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1, N'admin', CAST(N'2021-06-16T11:23:36.2670553' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (2, N'user', CAST(N'2021-06-16T11:23:43.0033048' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (3, N'aaa', CAST(N'2021-06-16T11:23:46.4096854' AS DateTime2), CAST(N'2021-06-16T11:24:22.3698871' AS DateTime2), 1, CAST(N'2021-06-16T11:24:22.3698057' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Trainers] ON 

INSERT [dbo].[Trainers] ([Id], [FirstName], [LastName], [Email], [Address], [Age], [Gender], [Height], [Weight], [BodyFatPercent], [BodyMusclePercent], [CardId], [GymId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1, N'Trainer Pera', N'Peric', N'pera@gmail.com', N'Add PP', 33, 1, 192, 98, 38, 40, 7, 3, CAST(N'2021-06-16T14:08:29.7753089' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Trainers] ([Id], [FirstName], [LastName], [Email], [Address], [Age], [Gender], [Height], [Weight], [BodyFatPercent], [BodyMusclePercent], [CardId], [GymId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (3, N'Trainer Mika', N'Mikic', N'Mika@gmail.com', N'Add MM', 23, 1, 172, 78, 18, 30, 11, 2, CAST(N'2021-06-16T14:13:19.8201202' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Trainers] ([Id], [FirstName], [LastName], [Email], [Address], [Age], [Gender], [Height], [Weight], [BodyFatPercent], [BodyMusclePercent], [CardId], [GymId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (4, N'Trainer Milica', N'Micic', N'Milica@gmail.com', N'Add MM', 40, 2, 152, 48, 9, 30, 12, 1, CAST(N'2021-06-16T14:14:14.0610802' AS DateTime2), NULL, 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[Trainers] OFF
GO
SET IDENTITY_INSERT [dbo].[TrainerUseCases] ON 

INSERT [dbo].[TrainerUseCases] ([Id], [TrainerId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (1, 3, 25, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[TrainerUseCases] ([Id], [TrainerId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (2, 3, 26, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[TrainerUseCases] ([Id], [TrainerId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (3, 3, 27, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[TrainerUseCases] ([Id], [TrainerId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (4, 3, 28, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[TrainerUseCases] ([Id], [TrainerId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (5, 3, 30, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[TrainerUseCases] ([Id], [TrainerId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (6, 3, 11, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[TrainerUseCases] ([Id], [TrainerId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (7, 3, 12, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[TrainerUseCases] ([Id], [TrainerId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (8, 3, 13, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[TrainerUseCases] ([Id], [TrainerId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (9, 3, 1, CAST(N'2021-06-17T10:33:59.7286430' AS DateTime2), CAST(N'2021-06-17T10:34:29.9745874' AS DateTime2), 1, CAST(N'2021-06-17T10:34:29.9743591' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[TrainerUseCases] OFF
GO
SET IDENTITY_INSERT [dbo].[UseCaseLogs] ON 

INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1, CAST(N'2021-06-16T19:56:01.1725795' AS DateTime2), N'Getting Cards using EF', N'{"Authentification":null,"ExpiresAt":null,"RenewedAt":null,"MembershipId":0,"PerPage":2,"Page":1}', N'JTB54HOY')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (2, CAST(N'2021-06-16T19:56:14.2093090' AS DateTime2), N'Getting Cards using EF', N'{"Authentification":null,"ExpiresAt":null,"RenewedAt":null,"MembershipId":0,"PerPage":2,"Page":1}', N'JTB54HOY')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (3, CAST(N'2021-06-16T19:58:24.0895838' AS DateTime2), N'Getting Cards using EF', N'{"Authentification":null,"ExpiresAt":null,"RenewedAt":null,"MembershipId":0,"PerPage":2,"Page":1}', N'PHWTQHKY')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (4, CAST(N'2021-06-16T23:33:59.2309326' AS DateTime2), N'Getting Cards using EF', N'{"Authentification":null,"ExpiresAt":null,"RenewedAt":null,"MembershipId":0,"PerPage":2,"Page":1}', N'JTB54HOY')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (5, CAST(N'2021-06-17T08:23:01.4058442' AS DateTime2), N'Creating User Use Case using EF', N'{"Id":0,"UserId":3,"UseCaseId":40}', N'JTB54HOY')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (6, CAST(N'2021-06-17T08:27:00.6543084' AS DateTime2), N'Creating User Use Case using EF', N'{"Id":0,"UserId":3,"UseCaseId":1}', N'JTB54HOY')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (7, CAST(N'2021-06-17T08:31:27.7862290' AS DateTime2), N'Creating User Use Case using EF', N'{"Id":0,"UserId":3,"UseCaseId":1}', N'JTB54HOY')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (8, CAST(N'2021-06-17T08:32:06.0579216' AS DateTime2), N'Deleting User Use Case using EF', N'105', N'JTB54HOY')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (9, CAST(N'2021-06-17T08:33:33.9424346' AS DateTime2), N'Creating Trainer Use Case using EF', N'{"Id":0,"TrainerId":0,"UseCaseId":1}', N'JTB54HOY')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (10, CAST(N'2021-06-17T08:33:59.6592260' AS DateTime2), N'Creating Trainer Use Case using EF', N'{"Id":0,"TrainerId":3,"UseCaseId":1}', N'JTB54HOY')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (11, CAST(N'2021-06-17T08:34:29.9422337' AS DateTime2), N'Deleting Use Case using EF', N'9', N'JTB54HOY')
SET IDENTITY_INSERT [dbo].[UseCaseLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Address], [Age], [Gender], [Height], [Weight], [BodyFatPercent], [BodyMusclePercent], [RoleId], [CardId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (2, N'Admin', N'Admin', N'admin@gmail.com', N'Addresa admin', 17, 1, 172, 68, 19, 20, 1, 8, CAST(N'2021-06-16T14:34:52.3594835' AS DateTime2), CAST(N'2021-06-16T14:36:35.7276877' AS DateTime2), 0, NULL, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Address], [Age], [Gender], [Height], [Weight], [BodyFatPercent], [BodyMusclePercent], [RoleId], [CardId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (3, N'Ana', N'Nanic', N'smorime71@gmail.com', N'addersa aana', 20, 2, 182, 70, 29, 30, 2, 6, CAST(N'2021-06-16T14:59:21.5772718' AS DateTime2), CAST(N'2021-06-17T00:25:21.1570022' AS DateTime2), 0, NULL, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Address], [Age], [Gender], [Height], [Weight], [BodyFatPercent], [BodyMusclePercent], [RoleId], [CardId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (4, N'Milos', N'Milosevic', N'milos@gmail.com', N'addersa milos', 33, 1, 191, 90, 40.12, 35.99, 2, 5, CAST(N'2021-06-16T17:27:25.1798777' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Address], [Age], [Gender], [Height], [Weight], [BodyFatPercent], [BodyMusclePercent], [RoleId], [CardId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (5, N'Test', N'test', N'test@gmail.com', N'addersa test', 33, 1, 191, 90, 40.12, 35.99, 2, 4, CAST(N'2021-06-16T22:49:56.5051972' AS DateTime2), NULL, 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[UserUseCases] ON 

INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (47, 2, 1, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (48, 2, 2, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (49, 2, 3, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (50, 2, 4, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (51, 2, 5, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (52, 2, 6, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (53, 2, 7, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (54, 2, 8, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (55, 2, 9, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (56, 2, 10, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (57, 2, 11, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (58, 2, 12, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (59, 2, 13, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (60, 2, 14, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (61, 2, 15, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (62, 2, 16, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (63, 2, 17, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (64, 2, 18, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (65, 2, 19, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (66, 2, 20, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (67, 2, 21, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (68, 2, 22, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (69, 2, 23, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (70, 2, 24, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (71, 2, 25, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (72, 2, 26, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (73, 2, 27, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (74, 2, 28, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (75, 2, 29, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (76, 2, 30, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (77, 2, 31, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (78, 2, 32, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (79, 2, 33, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (80, 2, 34, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (81, 2, 35, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (82, 2, 36, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (83, 3, 25, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (84, 3, 26, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (85, 3, 27, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (86, 3, 28, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (87, 3, 29, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (88, 3, 30, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (89, 3, 11, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (90, 3, 12, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (91, 3, 13, CAST(N'2021-06-16T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (92, 5, 26, CAST(N'2021-06-16T22:49:56.5094364' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (93, 5, 25, CAST(N'2021-06-16T22:49:56.5094427' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (94, 5, 28, CAST(N'2021-06-16T22:49:56.5094437' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (95, 5, 27, CAST(N'2021-06-16T22:49:56.5094454' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (96, 5, 11, CAST(N'2021-06-16T22:49:56.5094461' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (97, 5, 13, CAST(N'2021-06-16T22:49:56.5094468' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (98, 5, 12, CAST(N'2021-06-16T22:49:56.5094475' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (99, 5, 30, CAST(N'2021-06-16T22:49:56.5094482' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (100, 5, 29, CAST(N'2021-06-16T22:49:56.5094487' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (101, 2, 37, CAST(N'2021-06-17T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (102, 2, 38, CAST(N'2021-06-17T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (103, 2, 39, CAST(N'2021-06-17T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (104, 2, 40, CAST(N'2021-06-17T10:03:08.9475628' AS DateTime2), NULL, 0, NULL, 1)
INSERT [dbo].[UserUseCases] ([Id], [UserId], [UseCaseId], [CreatedAt], [ModifiedAt], [IsDeleted], [DeletedAt], [IsActive]) VALUES (105, 3, 1, CAST(N'2021-06-17T10:31:28.0781512' AS DateTime2), CAST(N'2021-06-17T10:32:06.0903331' AS DateTime2), 1, CAST(N'2021-06-17T10:32:06.0900226' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[UserUseCases] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Cards_Authentification]    Script Date: 6/17/2021 12:31:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cards_Authentification] ON [dbo].[Cards]
(
	[Authentification] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Cards_MembershipId]    Script Date: 6/17/2021 12:31:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Cards_MembershipId] ON [dbo].[Cards]
(
	[MembershipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GymImages_ImageId]    Script Date: 6/17/2021 12:31:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_GymImages_ImageId] ON [dbo].[GymImages]
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_GymUsers_UserId]    Script Date: 6/17/2021 12:31:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_GymUsers_UserId] ON [dbo].[GymUsers]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonalTrainings_TrainerId]    Script Date: 6/17/2021 12:31:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_PersonalTrainings_TrainerId] ON [dbo].[PersonalTrainings]
(
	[TrainerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonalTrainings_UserId]    Script Date: 6/17/2021 12:31:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_PersonalTrainings_UserId] ON [dbo].[PersonalTrainings]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Trainers_CardId]    Script Date: 6/17/2021 12:31:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Trainers_CardId] ON [dbo].[Trainers]
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Trainers_Email]    Script Date: 6/17/2021 12:31:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Trainers_Email] ON [dbo].[Trainers]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Trainers_GymId]    Script Date: 6/17/2021 12:31:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Trainers_GymId] ON [dbo].[Trainers]
(
	[GymId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TrainerUseCases_TrainerId]    Script Date: 6/17/2021 12:31:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_TrainerUseCases_TrainerId] ON [dbo].[TrainerUseCases]
(
	[TrainerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_CardId]    Script Date: 6/17/2021 12:31:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_CardId] ON [dbo].[Users]
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Email]    Script Date: 6/17/2021 12:31:45 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 6/17/2021 12:31:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserUseCases_UserId]    Script Date: 6/17/2021 12:31:45 PM ******/
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
