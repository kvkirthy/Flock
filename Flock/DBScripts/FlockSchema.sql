USE [master]
GO

/****** Object:  Database [Flock]    Script Date: 8/30/2013 8:30:50 PM ******/
DROP DATABASE [Flock]
GO

/****** Object:  Database [Flock]    Script Date: 8/30/2013 8:29:50 PM ******/
CREATE DATABASE [Flock]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Flock', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Flock.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Flock_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Flock_log.ldf' , SIZE = 4096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Flock] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Flock].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Flock] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Flock] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Flock] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Flock] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Flock] SET ARITHABORT OFF 
GO
ALTER DATABASE [Flock] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Flock] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Flock] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Flock] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Flock] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Flock] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Flock] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Flock] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Flock] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Flock] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Flock] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Flock] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Flock] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Flock] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Flock] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Flock] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Flock] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Flock] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Flock] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Flock] SET  MULTI_USER 
GO
ALTER DATABASE [Flock] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Flock] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Flock] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Flock] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Flock', N'ON'
GO
USE [Flock]
GO
/****** Object:  Table [dbo].[Interest]    Script Date: 8/30/2013 8:29:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Interest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Project]    Script Date: 8/30/2013 8:29:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Details] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Quack]    Script Date: 8/30/2013 8:29:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quack](
	[ID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[ContentID] [int] NOT NULL,
	[QuackTypeID] [int] NOT NULL,
	[ConversationID] [int] NOT NULL,
	[ParentQuackID] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Quack] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuackContent]    Script Date: 8/30/2013 8:29:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuackContent](
	[ID] [int] NOT NULL,
	[MessageText] [nvarchar](140) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_QuackContent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuackType]    Script Date: 8/30/2013 8:29:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuackType](
	[ID] [int] NOT NULL,
	[Type] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_QuackType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 8/30/2013 8:29:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[AdditionalDetails] [xml] NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK__ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Uq_UserName] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserInterest]    Script Date: 8/30/2013 8:29:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInterest](
	[UserId] [int] NOT NULL,
	[InterestId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserInterest] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[InterestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProject]    Script Date: 8/30/2013 8:29:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProject](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_User_Project] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Project] ADD  CONSTRAINT [DF_Project_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Project] ADD  CONSTRAINT [DF_Project_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Quack] ADD  CONSTRAINT [DF_Quack_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[QuackContent] ADD  CONSTRAINT [DF_QuackContent_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[UserInterest] ADD  CONSTRAINT [DF_UserInterest_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[UserProject] ADD  CONSTRAINT [DF_UserProject_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Quack]  WITH CHECK ADD  CONSTRAINT [FK_Quack_Quack] FOREIGN KEY([ParentQuackID])
REFERENCES [dbo].[Quack] ([ID])
GO
ALTER TABLE [dbo].[Quack] CHECK CONSTRAINT [FK_Quack_Quack]
GO
ALTER TABLE [dbo].[Quack]  WITH CHECK ADD  CONSTRAINT [FK_Quack_Quack1] FOREIGN KEY([ConversationID])
REFERENCES [dbo].[Quack] ([ID])
GO
ALTER TABLE [dbo].[Quack] CHECK CONSTRAINT [FK_Quack_Quack1]
GO
ALTER TABLE [dbo].[Quack]  WITH CHECK ADD  CONSTRAINT [FK_Quack_QuackContent] FOREIGN KEY([ContentID])
REFERENCES [dbo].[QuackContent] ([ID])
GO
ALTER TABLE [dbo].[Quack] CHECK CONSTRAINT [FK_Quack_QuackContent]
GO
ALTER TABLE [dbo].[Quack]  WITH CHECK ADD  CONSTRAINT [FK_Quack_QuackType] FOREIGN KEY([QuackTypeID])
REFERENCES [dbo].[QuackType] ([ID])
GO
ALTER TABLE [dbo].[Quack] CHECK CONSTRAINT [FK_Quack_QuackType]
GO
ALTER TABLE [dbo].[Quack]  WITH CHECK ADD  CONSTRAINT [FK_Quack_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Quack] CHECK CONSTRAINT [FK_Quack_User]
GO
ALTER TABLE [dbo].[UserInterest]  WITH CHECK ADD  CONSTRAINT [FK_UserInterest_Interest] FOREIGN KEY([InterestId])
REFERENCES [dbo].[Interest] ([Id])
GO
ALTER TABLE [dbo].[UserInterest] CHECK CONSTRAINT [FK_UserInterest_Interest]
GO
ALTER TABLE [dbo].[UserInterest]  WITH CHECK ADD  CONSTRAINT [FK_UserInterest_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserInterest] CHECK CONSTRAINT [FK_UserInterest_User]
GO
ALTER TABLE [dbo].[UserProject]  WITH CHECK ADD  CONSTRAINT [FK_UserProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[UserProject] CHECK CONSTRAINT [FK_UserProject_Project]
GO
ALTER TABLE [dbo].[UserProject]  WITH CHECK ADD  CONSTRAINT [FK_UserProject_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserProject] CHECK CONSTRAINT [FK_UserProject_User]
GO
USE [master]
GO
ALTER DATABASE [Flock] SET  READ_WRITE 
GO
