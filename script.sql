USE [master]
GO
/****** Object:  Database [ElectionSystem]    Script Date: 04-Oct-18 12:28:13 PM ******/
CREATE DATABASE [ElectionSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ElectionSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ElectionSystem.mdf' , SIZE = 28672KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ElectionSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ElectionSystem_log.ldf' , SIZE = 24384KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ElectionSystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ElectionSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ElectionSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ElectionSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ElectionSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ElectionSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ElectionSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [ElectionSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ElectionSystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ElectionSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ElectionSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ElectionSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ElectionSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ElectionSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ElectionSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ElectionSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ElectionSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ElectionSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ElectionSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ElectionSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ElectionSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ElectionSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ElectionSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ElectionSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ElectionSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ElectionSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [ElectionSystem] SET  MULTI_USER 
GO
ALTER DATABASE [ElectionSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ElectionSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ElectionSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ElectionSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ElectionSystem', N'ON'
GO
USE [ElectionSystem]
GO
/****** Object:  Table [dbo].[Contact_us]    Script Date: 04-Oct-18 12:28:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact_us](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Message] [nvarchar](max) NULL,
 CONSTRAINT [PK_Contact_us] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nad]    Script Date: 04-Oct-18 12:28:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nad](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Full_name] [varchar](50) NULL,
	[Father_Name] [varchar](50) NULL,
	[Identity_Number] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[DOB] [date] NULL,
	[Gender] [varchar](50) NULL,
	[Permanent_address] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[fingerprint] [image] NULL,
	[profilepic] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 04-Oct-18 12:28:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Registration](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [varchar](255) NULL,
	[Identity_Number] [varchar](15) NULL,
	[Email] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[Country] [varchar](100) NULL,
	[fingerprint] [image] NULL,
	[VoteFor] [varchar](50) NULL,
	[isVoted] [bit] NULL,
	[profilepic] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [ElectionSystem] SET  READ_WRITE 
GO
