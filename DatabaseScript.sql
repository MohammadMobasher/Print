USE [master]
GO
/****** Object:  Database [PrintingSolutionDB4]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE DATABASE [PrintingSolutionDB4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PrintingSolutionDB4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PrintingSolutionDB4.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PrintingSolutionDB4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PrintingSolutionDB4_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PrintingSolutionDB4] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PrintingSolutionDB4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PrintingSolutionDB4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET ARITHABORT OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PrintingSolutionDB4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PrintingSolutionDB4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PrintingSolutionDB4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PrintingSolutionDB4] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [PrintingSolutionDB4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET RECOVERY FULL 
GO
ALTER DATABASE [PrintingSolutionDB4] SET  MULTI_USER 
GO
ALTER DATABASE [PrintingSolutionDB4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PrintingSolutionDB4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PrintingSolutionDB4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PrintingSolutionDB4] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PrintingSolutionDB4] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PrintingSolutionDB4', N'ON'
GO
USE [PrintingSolutionDB4]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/8/2020 12:49:24 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[RoleTitle] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[ProfilePic] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[IsModerator] [bit] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bill]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubProjectId] [int] NOT NULL,
	[PriceEachPage] [float] NULL,
	[SumPriceEachPage] [float] NULL,
	[NumberOfPage] [int] NULL,
	[PriceEachCover] [float] NULL,
	[SumPriceEachCover] [float] NULL,
	[PriceDelivery] [float] NULL,
	[SumPrice] [float] NULL,
	[Created] [datetime2](7) NULL,
	[IsPayed] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FAQ]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAQ](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [nvarchar](max) NULL,
	[AnswerText] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[FaqGroupId] [int] NOT NULL,
 CONSTRAINT [PK_FAQ] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FaqGroup]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaqGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Icon] [nvarchar](60) NULL,
 CONSTRAINT [PK_FaqGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[News]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[SummeryNews] [nvarchar](600) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Date] [datetime2](7) NOT NULL,
	[ViewCount] [int] NOT NULL,
	[Tags] [nvarchar](400) NULL,
	[UserId] [int] NOT NULL,
	[ImageAddress] [nvarchar](1000) NOT NULL,
	[NewsGroupId] [int] NOT NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NewsComment]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsComment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NewsId] [int] NOT NULL,
	[Text] [nvarchar](max) NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_NewsComment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NewsGroup]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_NewsGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NewsTag]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_NewsTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Organization]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationTitle] [nvarchar](max) NULL,
	[OrganizationPhone] [nvarchar](max) NULL,
	[OrganizationAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[UserId] [int] NOT NULL,
	[Status] [int] NOT NULL DEFAULT ((0)),
	[Address] [nvarchar](500) NULL,
	[lat] [float] NULL,
	[lng] [float] NULL,
	[IsPayed] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SlideShow]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SlideShow](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImgAddress] [nvarchar](300) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[URL] [nvarchar](400) NULL,
	[Title] [nvarchar](100) NULL,
	[Alt] [nvarchar](200) NULL,
 CONSTRAINT [PK_SlideShow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubProject]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubProject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[SubProjectType] [int] NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[Number] [int] NOT NULL DEFAULT ((0)),
	[BindingNumber] [int] NULL,
	[BindingType] [int] NULL,
	[BookCover] [nvarchar](max) NULL,
	[BookCoverColor] [int] NULL,
	[BookCoverMaterial] [int] NULL,
	[BookOrSeet] [nvarchar](max) NULL,
	[Color] [int] NULL,
	[Height] [int] NULL,
	[PaperMaterial] [int] NOT NULL DEFAULT ((0)),
	[Priority] [int] NOT NULL DEFAULT ((0)),
	[Size] [int] NULL,
	[SuggestedTime] [datetime2](7) NOT NULL DEFAULT ('0001-01-01T00:00:00.0000000'),
	[Width] [int] NULL,
	[BookPageNumber] [int] NULL,
	[NumOfBinding] [int] NOT NULL DEFAULT ((0)),
	[NumOfCovering] [int] NOT NULL DEFAULT ((0)),
	[NumOfPrinting] [int] NOT NULL DEFAULT ((0)),
	[Status] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_SubProject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserOrganization]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOrganization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OrganizationId] [int] NOT NULL,
 CONSTRAINT [PK_UserOrganization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsersAccess]    Script Date: 3/8/2020 12:49:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersAccess](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Controller] [nvarchar](max) NULL,
	[Actions] [nvarchar](max) NULL,
 CONSTRAINT [PK_UsersAccess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200210092823_init', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200210101816_add_Number_Filed_to_SubProject_table', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200210110827_add_some_filed_to_SubProject', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200211202014_add_status_field_to_project_table', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200216104255_add_address_ProjectTable', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200216111723_add_lat_lng_ProjectTable', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200216122408_add_BookPageNumber_SubProjectTable', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200218070524_add_bill_table', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200218085651_test', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200218143807_add_some_field_to_BillTable', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200303174435_add_IsPayed_field_to_Project', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200303193702_add_NumOf_Binding_Covering_Printing_for_subproject', N'2.2.4-servicing-10062')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200304144803_add_Status_field_to_SubProject', N'2.2.4-servicing-10062')
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 

INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleTitle]) VALUES (13, N'Admin', N'ADMIN', NULL, N'مدیریت')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleTitle]) VALUES (14, N'Administrator', N'ADMINISTRATOR', N'f0c48baf-80d2-4d70-becf-bfdb54e3f923', N'المدیر')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleTitle]) VALUES (15, N'AdminCustomer', N'ADMINCUSTOMER', N'59101cbf-0e30-46ca-9d86-82b34bee4fd2', N'المدیر الکاستومر')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleTitle]) VALUES (16, N'Customer', N'CUSTOMER', N'55883006-0e21-4e58-85bd-35b79eb1de99', N'الکاستومر')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleTitle]) VALUES (17, N'Employee(Print)', N'EMPLOYEE(PRINT)', N'f76eb4ad-84de-46f4-995f-b1fece5d9d43', N'الکارمند(الپرینت)')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleTitle]) VALUES (18, N'Employee(Binding)', N'EMPLOYEE(BINDING)', N'f5830409-1aa6-40b0-b516-051cf7c8071c', N'الکارمند (المنگنه)')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [RoleTitle]) VALUES (19, N'employee(Cover)', N'EMPLOYEE(COVER)', N'2cfc0cd5-7dca-4d50-bb21-3e2373a6fc92', N'الکارمند(الکاور)')
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 14)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (4, 15)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (5, 16)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (6, 17)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (7, 18)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (8, 19)
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 

INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePic], [CreateDate], [IsActive], [IsModerator]) VALUES (1, N'emran', N'EMRAN', N'emraanjadidi2@gmail.com', N'EMRAANJADIDI2@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEL1nWg97hpfkbH5BWQlk6+jNIk54s5CabiD0Gu7RMujSFxoVx5TYxBPiSad8lm8q3A==', N'DWPZIUVGEBFY75YEOF5H2AGLGLHUELJ6', N'8cde4cb8-3bd8-4ab7-a877-a130d24ad50c', N'09191600836', 1, 0, NULL, 0, 0, N'Emran2', N'Jadidi', N'Uploads/UserImage/f7ca902d-953a-4f1b-a2a9-5067efbe6b76.jpg', NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePic], [CreateDate], [IsActive], [IsModerator]) VALUES (4, N'vardasbi', N'VARDASBI', N'mvardasbi@gamil.com', N'MVARDASBI@GAMIL.COM', 0, N'AQAAAAEAACcQAAAAEOBcYXPt5DOq6970v5JQ0Qk9Db/22Q5sOa8nD9+6aq3Cq7FIDnAFYlXIr+bCkqS4sQ==', N'F3U2F2IWUU6AATZZWFKTECRAPMMXVQ74', N'e229a010-a9ee-4593-bd13-c2595e256a6e', N'09127493133', 0, 0, NULL, 0, 0, N'mohammad', N'Vardasbi', N'', CAST(N'2020-02-01 15:57:20.0791960' AS DateTime2), 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePic], [CreateDate], [IsActive], [IsModerator]) VALUES (5, N'ramzi', N'RAMZI', N'aliramzi@gmail.com', N'ALIRAMZI@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEMpwVi487tcZTR6LY6i5GHRo8n15Ku3q352GubFYCCNErMBWqxXtHnmbkZ7rpvZMEg==', N'RKGN2IAL2HA4RWWJ6NKEZ57DNFW6B62R', N'a322a44e-4d47-4971-932b-dbc885295826', N'09117493133', 0, 0, NULL, 0, 0, N'ali', N'ramzi', NULL, CAST(N'2020-02-03 21:37:33.4209021' AS DateTime2), 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePic], [CreateDate], [IsActive], [IsModerator]) VALUES (6, N'cheraghi', N'CHERAGHI', N'cheraghi@gmail.com', N'CHERAGHI@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEMzIP9kRHBnMH5pa+GwPpnCWNvru3gb8GrPr96T/dI8of5+VeY2s/bMgQ0A27I4y3g==', N'NWKQTLHCWPTZL5V4KUOV2W5MEETDMQLF', N'95eb7925-0d82-4e17-a7a7-7abca506f40d', N'09127483133', 0, 0, NULL, 0, 0, N'farshad', N'cheraghi', NULL, CAST(N'2020-03-04 16:45:33.8065983' AS DateTime2), 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePic], [CreateDate], [IsActive], [IsModerator]) VALUES (7, N'delavar', N'DELAVAR', N'delavar@gmail.com', N'DELAVAR@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOrQvkz4egs+A4kRxRNP9jL/yf+UtXaYvuqX0hhV28jh+6OL90t0Pa2Q2tYkrdkcWQ==', N'EO5LNINBHYYXJHJOMSPZVWCEA3ZH2KSQ', N'e6cf24b4-264b-4f38-ad9e-8b3267b7fa7c', N'09191600837', 0, 0, NULL, 0, 0, N'farshad', N'delavar', NULL, CAST(N'2020-03-08 01:54:20.5484753' AS DateTime2), 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePic], [CreateDate], [IsActive], [IsModerator]) VALUES (8, N'mohsen', N'MOHSEN', N'mohsen@gmail.com', N'MOHSEN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEIk0WjYNJezSFiXXhdeRTnrYjytGaWHx9laUWFyQq0ojCoXV05eP2g/A5DlBoTmezw==', N'ZPQSQTHJ6TA6H7RGXYJNDOHUCN7AZN7V', N'dcb3bd09-13e5-4031-85db-c1e410f691b7', N'09123512424', 0, 0, NULL, 0, 0, N'mohsen', N'yazdi', NULL, CAST(N'2020-03-08 01:59:31.1367581' AS DateTime2), 1, 0)
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([Id], [SubProjectId], [PriceEachPage], [SumPriceEachPage], [NumberOfPage], [PriceEachCover], [SumPriceEachCover], [PriceDelivery], [SumPrice], [Created], [IsPayed]) VALUES (1, 10, 214, 11.77, 5, 501, 55, 121, 187.76999999999998, NULL, 0)
SET IDENTITY_INSERT [dbo].[Bill] OFF
SET IDENTITY_INSERT [dbo].[FAQ] ON 

INSERT [dbo].[FAQ] ([Id], [QuestionText], [AnswerText], [IsActive], [FaqGroupId]) VALUES (2, N'1', N'1', 1, 2)
INSERT [dbo].[FAQ] ([Id], [QuestionText], [AnswerText], [IsActive], [FaqGroupId]) VALUES (3, N'2', N'2', 1, 2)
INSERT [dbo].[FAQ] ([Id], [QuestionText], [AnswerText], [IsActive], [FaqGroupId]) VALUES (4, N'2', N'2', 1, 2)
INSERT [dbo].[FAQ] ([Id], [QuestionText], [AnswerText], [IsActive], [FaqGroupId]) VALUES (5, N'3', N'3', 1, 3)
INSERT [dbo].[FAQ] ([Id], [QuestionText], [AnswerText], [IsActive], [FaqGroupId]) VALUES (6, N'4', N'4', 1, 3)
INSERT [dbo].[FAQ] ([Id], [QuestionText], [AnswerText], [IsActive], [FaqGroupId]) VALUES (9, N'5', N'5', 1, 2)
INSERT [dbo].[FAQ] ([Id], [QuestionText], [AnswerText], [IsActive], [FaqGroupId]) VALUES (10, N'6', N'6', 1, 2)
INSERT [dbo].[FAQ] ([Id], [QuestionText], [AnswerText], [IsActive], [FaqGroupId]) VALUES (11, N'6', N'6', 1, 2)
INSERT [dbo].[FAQ] ([Id], [QuestionText], [AnswerText], [IsActive], [FaqGroupId]) VALUES (12, N'7', N'7', 1, 2)
INSERT [dbo].[FAQ] ([Id], [QuestionText], [AnswerText], [IsActive], [FaqGroupId]) VALUES (13, N'8', N'8', 1, 2)
INSERT [dbo].[FAQ] ([Id], [QuestionText], [AnswerText], [IsActive], [FaqGroupId]) VALUES (14, N'9', N'9', 1, 2)
INSERT [dbo].[FAQ] ([Id], [QuestionText], [AnswerText], [IsActive], [FaqGroupId]) VALUES (16, N'11', N'11', 1, 2)
INSERT [dbo].[FAQ] ([Id], [QuestionText], [AnswerText], [IsActive], [FaqGroupId]) VALUES (17, N'111', N'111', 1, 2)
SET IDENTITY_INSERT [dbo].[FAQ] OFF
SET IDENTITY_INSERT [dbo].[FaqGroup] ON 

INSERT [dbo].[FaqGroup] ([Id], [Title], [Icon]) VALUES (2, N'Track Post Order', N'fa fa-truck')
INSERT [dbo].[FaqGroup] ([Id], [Title], [Icon]) VALUES (3, N'Other', N'fa fa-truck')
SET IDENTITY_INSERT [dbo].[FaqGroup] OFF
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([Id], [Title], [SummeryNews], [Description], [Date], [ViewCount], [Tags], [UserId], [ImageAddress], [NewsGroupId]) VALUES (5, N'1', N'1', N'<p>1</p>
', CAST(N'2020-01-29 19:16:39.1962111' AS DateTime2), 0, N'1', 1, N'Uploads/NewsImages/9f567695-09c8-40dd-a5c9-f1afc824f911.jpg', 1)
INSERT [dbo].[News] ([Id], [Title], [SummeryNews], [Description], [Date], [ViewCount], [Tags], [UserId], [ImageAddress], [NewsGroupId]) VALUES (6, N'1', N'1', N'<p>1</p>
', CAST(N'2020-02-01 17:26:29.4786947' AS DateTime2), 0, N'tag', 1, N'Uploads/NewsImages/c9a55ae4-4a87-4c6d-9ade-300a49cb695e.jpg', 1)
SET IDENTITY_INSERT [dbo].[News] OFF
SET IDENTITY_INSERT [dbo].[NewsGroup] ON 

INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (1, N'علمی')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (2, N'اطلاعات عمومی')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (3, N'دسته دوم')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (12, N'sdgfsd')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (13, N'sdfsdf')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (14, N'sascz')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (15, N'pjnil;okn')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (16, N'sd')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (17, N'دسته جدید')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (18, N'دسته جدید 1')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (19, N'sad')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (20, N'123')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (22, N'1234567')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (23, N'12')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (24, N'13')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (25, N'1/29/2020 7:16:39 PM')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (26, N'14')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (27, N'12')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (28, N'13')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (29, N'2/1/2020 5:26:29 PM')
INSERT [dbo].[NewsGroup] ([Id], [Title]) VALUES (30, N'14')
SET IDENTITY_INSERT [dbo].[NewsGroup] OFF
SET IDENTITY_INSERT [dbo].[Organization] ON 

INSERT [dbo].[Organization] ([Id], [OrganizationTitle], [OrganizationPhone], [OrganizationAddress]) VALUES (3, N'OrganizationName', N'1', N'1')
INSERT [dbo].[Organization] ([Id], [OrganizationTitle], [OrganizationPhone], [OrganizationAddress]) VALUES (4, N'2', N'2', N'2')
INSERT [dbo].[Organization] ([Id], [OrganizationTitle], [OrganizationPhone], [OrganizationAddress]) VALUES (6, N'OrganizationName 1', N'OrganizationPhone 1', N'OrganizationAddress 1')
SET IDENTITY_INSERT [dbo].[Organization] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Title], [OrganizationId], [Created], [UserId], [Status], [Address], [lat], [lng], [IsPayed]) VALUES (9, N'123', 3, CAST(N'2020-02-09 19:52:00.3008568' AS DateTime2), 1, 3, NULL, NULL, NULL, 0)
INSERT [dbo].[Project] ([Id], [Title], [OrganizationId], [Created], [UserId], [Status], [Address], [lat], [lng], [IsPayed]) VALUES (13, N'First customer project', 3, CAST(N'2020-02-12 12:04:02.0651309' AS DateTime2), 1, 2, NULL, NULL, NULL, 0)
INSERT [dbo].[Project] ([Id], [Title], [OrganizationId], [Created], [UserId], [Status], [Address], [lat], [lng], [IsPayed]) VALUES (14, N'First', 3, CAST(N'2020-02-12 23:33:08.4956205' AS DateTime2), 1, 1, NULL, NULL, NULL, 0)
INSERT [dbo].[Project] ([Id], [Title], [OrganizationId], [Created], [UserId], [Status], [Address], [lat], [lng], [IsPayed]) VALUES (15, N'Project1', 3, CAST(N'2020-02-15 13:26:39.2619412' AS DateTime2), 5, 3, N'Address', NULL, NULL, 0)
INSERT [dbo].[Project] ([Id], [Title], [OrganizationId], [Created], [UserId], [Status], [Address], [lat], [lng], [IsPayed]) VALUES (16, N'Project2', 3, CAST(N'2020-02-15 14:23:46.3428538' AS DateTime2), 5, 1, NULL, NULL, NULL, 0)
INSERT [dbo].[Project] ([Id], [Title], [OrganizationId], [Created], [UserId], [Status], [Address], [lat], [lng], [IsPayed]) VALUES (18, N'mobasher Project', 3, CAST(N'2020-03-03 13:55:40.9742622' AS DateTime2), 5, 6, N'mobasher Address', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[SlideShow] ON 

INSERT [dbo].[SlideShow] ([Id], [ImgAddress], [IsActive], [URL], [Title], [Alt]) VALUES (1, N'Uploads/SlideShow/e3ebb539-c296-489b-85ca-bfac216d6995.jpg', 1, N'http://localhost:49772/SlideShow/ManageSlideShow', N'عنوان', N'متن پیش فرض')
INSERT [dbo].[SlideShow] ([Id], [ImgAddress], [IsActive], [URL], [Title], [Alt]) VALUES (2, N'Uploads/SlideShow/ce9c6321-5981-4527-9dc4-1a7cb91bad13.jpg', 1, N'URL2', N'Title2', N'Default Text2')
INSERT [dbo].[SlideShow] ([Id], [ImgAddress], [IsActive], [URL], [Title], [Alt]) VALUES (4, N'Uploads/SlideShow/7b1e5390-d415-4e23-bccc-003cd9ffc750.jpg', 1, N'URL3', N'Title1', N'Default Text2')
INSERT [dbo].[SlideShow] ([Id], [ImgAddress], [IsActive], [URL], [Title], [Alt]) VALUES (5, N'Uploads/SlideShow/9c536751-1090-427b-94c7-b4528c67e977.jpg', 1, N'd', N'd', N'd')
SET IDENTITY_INSERT [dbo].[SlideShow] OFF
SET IDENTITY_INSERT [dbo].[SubProject] ON 

INSERT [dbo].[SubProject] ([Id], [ProjectId], [Title], [SubProjectType], [OrganizationId], [Number], [BindingNumber], [BindingType], [BookCover], [BookCoverColor], [BookCoverMaterial], [BookOrSeet], [Color], [Height], [PaperMaterial], [Priority], [Size], [SuggestedTime], [Width], [BookPageNumber], [NumOfBinding], [NumOfCovering], [NumOfPrinting], [Status]) VALUES (4, 15, N'Task 1', 1, 3, 1000, NULL, NULL, NULL, NULL, NULL, N'Uploads/BookOrSeet/98d5d580-ffee-43db-9765-1f8fb2b9cb26.png', 0, NULL, 0, 0, 1, CAST(N'2020-03-01 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, 0, 0)
INSERT [dbo].[SubProject] ([Id], [ProjectId], [Title], [SubProjectType], [OrganizationId], [Number], [BindingNumber], [BindingType], [BookCover], [BookCoverColor], [BookCoverMaterial], [BookOrSeet], [Color], [Height], [PaperMaterial], [Priority], [Size], [SuggestedTime], [Width], [BookPageNumber], [NumOfBinding], [NumOfCovering], [NumOfPrinting], [Status]) VALUES (5, 15, N'Task 2', 1, 3, 1200, NULL, NULL, NULL, NULL, NULL, N'Uploads/BookOrSeet/99e6d3f7-a06b-4152-9a15-97746fdac776.png', 0, NULL, 1, 0, 1, CAST(N'2020-03-02 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, 0, 0)
INSERT [dbo].[SubProject] ([Id], [ProjectId], [Title], [SubProjectType], [OrganizationId], [Number], [BindingNumber], [BindingType], [BookCover], [BookCoverColor], [BookCoverMaterial], [BookOrSeet], [Color], [Height], [PaperMaterial], [Priority], [Size], [SuggestedTime], [Width], [BookPageNumber], [NumOfBinding], [NumOfCovering], [NumOfPrinting], [Status]) VALUES (6, 16, N'Task 1', 1, 3, 1, NULL, NULL, NULL, NULL, NULL, N'Uploads/BookOrSeet/c463ee96-fabc-40e6-a2dc-1944201fb0a1.png', 0, NULL, 0, 0, 2, CAST(N'2020-02-08 00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, 0, 0)
INSERT [dbo].[SubProject] ([Id], [ProjectId], [Title], [SubProjectType], [OrganizationId], [Number], [BindingNumber], [BindingType], [BookCover], [BookCoverColor], [BookCoverMaterial], [BookOrSeet], [Color], [Height], [PaperMaterial], [Priority], [Size], [SuggestedTime], [Width], [BookPageNumber], [NumOfBinding], [NumOfCovering], [NumOfPrinting], [Status]) VALUES (9, 15, N'Task Book', 0, 3, 1000, NULL, 2, N'Uploads/BookCover/960423b5-8cf7-456e-b255-bf1ba35a8d3a.jpg', 0, 0, N'Uploads/BookOrSeet/13cf6a09-8021-4001-9e7a-63298a54491f.pdf', 0, NULL, 0, 0, 1, CAST(N'2020-02-21 00:00:00.0000000' AS DateTime2), NULL, 6, 0, 0, 0, 0)
INSERT [dbo].[SubProject] ([Id], [ProjectId], [Title], [SubProjectType], [OrganizationId], [Number], [BindingNumber], [BindingType], [BookCover], [BookCoverColor], [BookCoverMaterial], [BookOrSeet], [Color], [Height], [PaperMaterial], [Priority], [Size], [SuggestedTime], [Width], [BookPageNumber], [NumOfBinding], [NumOfCovering], [NumOfPrinting], [Status]) VALUES (10, 9, N'1', 0, 3, 11, NULL, 0, N'Uploads/BookCover/72ae6ee9-6d50-41a9-9a7c-cbe109fb9bc9.png', 0, 0, N'Uploads/BookOrSeet/054c5c8d-079e-4ced-b369-6e93a323d901.pdf', 0, 25, 0, 0, 5, CAST(N'2020-02-25 00:00:00.0000000' AS DateTime2), 38, 6, 0, 0, 0, 0)
INSERT [dbo].[SubProject] ([Id], [ProjectId], [Title], [SubProjectType], [OrganizationId], [Number], [BindingNumber], [BindingType], [BookCover], [BookCoverColor], [BookCoverMaterial], [BookOrSeet], [Color], [Height], [PaperMaterial], [Priority], [Size], [SuggestedTime], [Width], [BookPageNumber], [NumOfBinding], [NumOfCovering], [NumOfPrinting], [Status]) VALUES (12, 18, N'Task 1', 1, 3, 1200, NULL, NULL, NULL, NULL, NULL, N'Uploads/BookOrSeet/0f1c169b-c721-4433-979d-4b0ebf5729b0.JPG', 0, NULL, 0, 0, 1, CAST(N'2020-03-31 00:00:00.0000000' AS DateTime2), NULL, NULL, 1200, 1200, 1200, 4)
SET IDENTITY_INSERT [dbo].[SubProject] OFF
SET IDENTITY_INSERT [dbo].[UserOrganization] ON 

INSERT [dbo].[UserOrganization] ([Id], [UserId], [OrganizationId]) VALUES (2, 1, 3)
INSERT [dbo].[UserOrganization] ([Id], [UserId], [OrganizationId]) VALUES (3, 4, 6)
INSERT [dbo].[UserOrganization] ([Id], [UserId], [OrganizationId]) VALUES (5, 1, 6)
INSERT [dbo].[UserOrganization] ([Id], [UserId], [OrganizationId]) VALUES (8, 5, 3)
INSERT [dbo].[UserOrganization] ([Id], [UserId], [OrganizationId]) VALUES (9, 4, 3)
SET IDENTITY_INSERT [dbo].[UserOrganization] OFF
SET IDENTITY_INSERT [dbo].[UsersAccess] ON 

INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (889, 14, N'RoleManageController', N'["Index","Create","Edit","Delete"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (890, 14, N'UserManageController', N'["Index","NewUser","SetRole","EditPassword","UserChangeStatus","CreateUser","SetOrganization"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (891, 14, N'ManageSlideShowController', N'["Index","Insert","Update","Delete"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (892, 14, N'ManageNewsController', N'["Index","Insert","Update","Delete"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (893, 14, N'ManageNewsGroupController', N'["Index","Insert","Update","Delete"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (894, 14, N'ManageFAQController', N'["Index","Insert","Update","Delete"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (895, 14, N'ManageFaqGroupController', N'["Index","Insert","Update","Delete"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (896, 14, N'ManageSubProjectController', N'["Index","Insert","Update","Delete","Bills"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (897, 14, N'ManageOrganizationController', N'["Index","Insert","Update","Delete"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (898, 14, N'ManageUserOrganizationController', N'["Index","Insert","Delete"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (899, 14, N'ManageBillController', N'["ProjectBills"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (900, 14, N'ManageProjectAController', N'["Index","Insert","Update","Delete","Deny","Send","ProjevtSummery"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (901, 14, N'ManageSubProjectAController', N'["Index","Insert","Update","Delete","Bills"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (902, 14, N'HomeController', N'["Index","Profile"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (903, 15, N'ManageBillACController', N'["ProjectBills"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (904, 15, N'ManageProjectController', N'["Index","Insert","Update","Delete","Send","ProjevtSummery","PayProject"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (905, 15, N'ManageSubProjectACController', N'["Index","Insert","Update","Delete"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (906, 15, N'ManageUserACController', N'["Index","Insert","UserChangeStatus","ChangeOrganization"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (907, 15, N'ManageSubProjectController', N'["Index","Insert","Update","Delete"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (908, 15, N'HomeController', N'["Index","Profile"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (919, 17, N'ManagePrintingController', N'["Index","Send"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (920, 17, N'ManageTaskPrintingController', N'["Index","DoPrint"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (921, 17, N'HomeController', N'["Index","Profile"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (922, 16, N'ManageProjectCController', N'["Index","Insert","Update","Delete","Send","ProjevtSummery","WorkProcess"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (923, 16, N'ManageSubProjectCController', N'["Index","Insert","Update","Delete"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (924, 16, N'HomeController', N'["Index","Profile"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (925, 18, N'ManageTaskBindingController', N'["Index","DoPrint"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (926, 18, N'HomeController', N'["Index","Profile"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (927, 19, N'ManageTaskCoveringController', N'["Index","DoPrint"]')
INSERT [dbo].[UsersAccess] ([Id], [RoleId], [Controller], [Actions]) VALUES (928, 19, N'HomeController', N'["Index","Profile"]')
SET IDENTITY_INSERT [dbo].[UsersAccess] OFF
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [EmailIndex]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bill_SubProjectId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bill_SubProjectId] ON [dbo].[Bill]
(
	[SubProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FAQ_FaqGroupId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_FAQ_FaqGroupId] ON [dbo].[FAQ]
(
	[FaqGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_News_NewsGroupId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_News_NewsGroupId] ON [dbo].[News]
(
	[NewsGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_News_UserId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_News_UserId] ON [dbo].[News]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_NewsComment_NewsId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_NewsComment_NewsId] ON [dbo].[NewsComment]
(
	[NewsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Project_OrganizationId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Project_OrganizationId] ON [dbo].[Project]
(
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Project_UserId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Project_UserId] ON [dbo].[Project]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SubProject_ProjectId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_SubProject_ProjectId] ON [dbo].[SubProject]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserOrganization_OrganizationId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserOrganization_OrganizationId] ON [dbo].[UserOrganization]
(
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserOrganization_UserId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserOrganization_UserId] ON [dbo].[UserOrganization]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UsersAccess_RoleId]    Script Date: 3/8/2020 12:49:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_UsersAccess_RoleId] ON [dbo].[UsersAccess]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_SubProject_SubProjectId] FOREIGN KEY([SubProjectId])
REFERENCES [dbo].[SubProject] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_SubProject_SubProjectId]
GO
ALTER TABLE [dbo].[FAQ]  WITH CHECK ADD  CONSTRAINT [FK_FAQ_FaqGroup_FaqGroupId] FOREIGN KEY([FaqGroupId])
REFERENCES [dbo].[FaqGroup] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FAQ] CHECK CONSTRAINT [FK_FAQ_FaqGroup_FaqGroupId]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_NewsGroup_NewsGroupId] FOREIGN KEY([NewsGroupId])
REFERENCES [dbo].[NewsGroup] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_NewsGroup_NewsGroupId]
GO
ALTER TABLE [dbo].[NewsComment]  WITH CHECK ADD  CONSTRAINT [FK_NewsComment_News_NewsId] FOREIGN KEY([NewsId])
REFERENCES [dbo].[News] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NewsComment] CHECK CONSTRAINT [FK_NewsComment_News_NewsId]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Organization_OrganizationId] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Organization_OrganizationId]
GO
ALTER TABLE [dbo].[SubProject]  WITH CHECK ADD  CONSTRAINT [FK_SubProject_Project_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubProject] CHECK CONSTRAINT [FK_SubProject_Project_ProjectId]
GO
ALTER TABLE [dbo].[UserOrganization]  WITH CHECK ADD  CONSTRAINT [FK_UserOrganization_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserOrganization] CHECK CONSTRAINT [FK_UserOrganization_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[UserOrganization]  WITH CHECK ADD  CONSTRAINT [FK_UserOrganization_Organization_OrganizationId] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organization] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserOrganization] CHECK CONSTRAINT [FK_UserOrganization_Organization_OrganizationId]
GO
ALTER TABLE [dbo].[UsersAccess]  WITH CHECK ADD  CONSTRAINT [FK_UsersAccess_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsersAccess] CHECK CONSTRAINT [FK_UsersAccess_AspNetRoles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [PrintingSolutionDB4] SET  READ_WRITE 
GO
