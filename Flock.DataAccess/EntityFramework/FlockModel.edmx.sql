
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/11/2013 02:04:54
-- Generated from EDMX file: C:\local\Flock\Flock.DataAccess\EntityFramework\FlockModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Flock];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Quack_Quack]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Quacks] DROP CONSTRAINT [FK_Quack_Quack];
GO
IF OBJECT_ID(N'[dbo].[FK_Quack_QuackContent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Quacks] DROP CONSTRAINT [FK_Quack_QuackContent];
GO
IF OBJECT_ID(N'[dbo].[FK_Quack_QuackType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Quacks] DROP CONSTRAINT [FK_Quack_QuackType];
GO
IF OBJECT_ID(N'[dbo].[FK_Quack_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Quacks] DROP CONSTRAINT [FK_Quack_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInterest_Interest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInterests] DROP CONSTRAINT [FK_UserInterest_Interest];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInterest_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInterests] DROP CONSTRAINT [FK_UserInterest_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProject_Project]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserProjects] DROP CONSTRAINT [FK_UserProject_Project];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProject_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserProjects] DROP CONSTRAINT [FK_UserProject_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Interests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Interests];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[QuackContents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuackContents];
GO
IF OBJECT_ID(N'[dbo].[Quacks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Quacks];
GO
IF OBJECT_ID(N'[dbo].[QuackTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuackTypes];
GO
IF OBJECT_ID(N'[dbo].[UserInterests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInterests];
GO
IF OBJECT_ID(N'[dbo].[UserProjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProjects];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Interests'
CREATE TABLE [dbo].[Interests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Details] nvarchar(max)  NULL,
    [Active] bit  NOT NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- Creating table 'Quacks'
CREATE TABLE [dbo].[Quacks] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [ContentID] int  NOT NULL,
    [QuackTypeID] int  NOT NULL,
    [ConversationID] int  NOT NULL,
    [ParentQuackID] int  NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- Creating table 'QuackContents'
CREATE TABLE [dbo].[QuackContents] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [MessageText] nvarchar(140)  NOT NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- Creating table 'QuackTypes'
CREATE TABLE [dbo].[QuackTypes] (
    [ID] int  NOT NULL,
    [Type] nvarchar(25)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(50)  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Active] bit  NOT NULL,
    [AdditionalDetails] nvarchar(max)  NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- Creating table 'UserInterests'
CREATE TABLE [dbo].[UserInterests] (
    [UserId] int  NOT NULL,
    [InterestId] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- Creating table 'UserProjects'
CREATE TABLE [dbo].[UserProjects] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [ProjectId] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Interests'
ALTER TABLE [dbo].[Interests]
ADD CONSTRAINT [PK_Interests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'Quacks'
ALTER TABLE [dbo].[Quacks]
ADD CONSTRAINT [PK_Quacks]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'QuackContents'
ALTER TABLE [dbo].[QuackContents]
ADD CONSTRAINT [PK_QuackContents]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'QuackTypes'
ALTER TABLE [dbo].[QuackTypes]
ADD CONSTRAINT [PK_QuackTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [UserId], [InterestId] in table 'UserInterests'
ALTER TABLE [dbo].[UserInterests]
ADD CONSTRAINT [PK_UserInterests]
    PRIMARY KEY CLUSTERED ([UserId], [InterestId] ASC);
GO

-- Creating primary key on [UserId], [ProjectId] in table 'UserProjects'
ALTER TABLE [dbo].[UserProjects]
ADD CONSTRAINT [PK_UserProjects]
    PRIMARY KEY CLUSTERED ([UserId], [ProjectId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [InterestId] in table 'UserInterests'
ALTER TABLE [dbo].[UserInterests]
ADD CONSTRAINT [FK_UserInterest_Interest]
    FOREIGN KEY ([InterestId])
    REFERENCES [dbo].[Interests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInterest_Interest'
CREATE INDEX [IX_FK_UserInterest_Interest]
ON [dbo].[UserInterests]
    ([InterestId]);
GO

-- Creating foreign key on [ProjectId] in table 'UserProjects'
ALTER TABLE [dbo].[UserProjects]
ADD CONSTRAINT [FK_UserProject_Project]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProject_Project'
CREATE INDEX [IX_FK_UserProject_Project]
ON [dbo].[UserProjects]
    ([ProjectId]);
GO

-- Creating foreign key on [ParentQuackID] in table 'Quacks'
ALTER TABLE [dbo].[Quacks]
ADD CONSTRAINT [FK_Quack_Quack]
    FOREIGN KEY ([ParentQuackID])
    REFERENCES [dbo].[Quacks]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Quack_Quack'
CREATE INDEX [IX_FK_Quack_Quack]
ON [dbo].[Quacks]
    ([ParentQuackID]);
GO

-- Creating foreign key on [ContentID] in table 'Quacks'
ALTER TABLE [dbo].[Quacks]
ADD CONSTRAINT [FK_Quack_QuackContent]
    FOREIGN KEY ([ContentID])
    REFERENCES [dbo].[QuackContents]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Quack_QuackContent'
CREATE INDEX [IX_FK_Quack_QuackContent]
ON [dbo].[Quacks]
    ([ContentID]);
GO

-- Creating foreign key on [QuackTypeID] in table 'Quacks'
ALTER TABLE [dbo].[Quacks]
ADD CONSTRAINT [FK_Quack_QuackType]
    FOREIGN KEY ([QuackTypeID])
    REFERENCES [dbo].[QuackTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Quack_QuackType'
CREATE INDEX [IX_FK_Quack_QuackType]
ON [dbo].[Quacks]
    ([QuackTypeID]);
GO

-- Creating foreign key on [UserID] in table 'Quacks'
ALTER TABLE [dbo].[Quacks]
ADD CONSTRAINT [FK_Quack_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Quack_User'
CREATE INDEX [IX_FK_Quack_User]
ON [dbo].[Quacks]
    ([UserID]);
GO

-- Creating foreign key on [UserId] in table 'UserInterests'
ALTER TABLE [dbo].[UserInterests]
ADD CONSTRAINT [FK_UserInterest_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'UserProjects'
ALTER TABLE [dbo].[UserProjects]
ADD CONSTRAINT [FK_UserProject_User]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------