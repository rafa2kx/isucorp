
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/27/2016 10:12:56
-- Generated from EDMX file: C:\Users\admin\Documents\Visual Studio 2015\Projects\IsuCorpRound3\IsuCorpRound3\Models\DB\Test3EntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [isuCorpTest];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ContactTypeReservation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reservations] DROP CONSTRAINT [FK_ContactTypeReservation];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ContactTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContactTypes];
GO
IF OBJECT_ID(N'[dbo].[Reservations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reservations];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ContactTypes'
CREATE TABLE [dbo].[ContactTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Reservations'
CREATE TABLE [dbo].[Reservations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fullname] nvarchar(max)  NOT NULL,
    [birthdate] datetime  NULL,
    [description] nvarchar(max)  NULL,
    [ContactType_Id] int  NOT NULL,
    [phone] varchar(15)  NULL,
    [rating] smallint  NULL,
    [is_favorite] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ContactTypes'
ALTER TABLE [dbo].[ContactTypes]
ADD CONSTRAINT [PK_ContactTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reservations'
ALTER TABLE [dbo].[Reservations]
ADD CONSTRAINT [PK_Reservations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ContactType_Id] in table 'Reservations'
ALTER TABLE [dbo].[Reservations]
ADD CONSTRAINT [FK_ContactTypeReservation]
    FOREIGN KEY ([ContactType_Id])
    REFERENCES [dbo].[ContactTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContactTypeReservation'
CREATE INDEX [IX_FK_ContactTypeReservation]
ON [dbo].[Reservations]
    ([ContactType_Id]);
GO

-- Creating stored procedure for inserting Contact Types
CREATE PROCEDURE [dbo].[InsertContactType]
@Name NVARCHAR(50),
@Description NVARCHAR(50)
AS
INSERT INTO [dbo].[ContactTypes] ([name], [description])
VALUES (@Name, @Description)
SELECT SCOPE_IDENTITY() AS Id,@Name AS Name, @Description AS Desciption WHERE @@ROWCOUNT > 0;
GO

-- Populating Contact Types
EXEC dbo.InsertContactType @Name = 'Person', @Description = 'Type of common individuals';
EXEC dbo.InsertContactType @Name = 'Company', @Description = 'Type of Contact Points for companies';
EXEC dbo.InsertContactType @Name = 'Programmer', @Description = 'Well, you know...';
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------