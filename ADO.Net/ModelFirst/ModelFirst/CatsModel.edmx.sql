
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/27/2019 19:10:53
-- Generated from EDMX file: D:\ADO.NET\ModelFirst\ModelFirst\CatsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Kote];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CatSet'
CREATE TABLE [dbo].[CatSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Age] int  NOT NULL,
    [Owner_Id] int  NOT NULL
);
GO

-- Creating table 'OwnerSet'
CREATE TABLE [dbo].[OwnerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CatSet'
ALTER TABLE [dbo].[CatSet]
ADD CONSTRAINT [PK_CatSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OwnerSet'
ALTER TABLE [dbo].[OwnerSet]
ADD CONSTRAINT [PK_OwnerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Owner_Id] in table 'CatSet'
ALTER TABLE [dbo].[CatSet]
ADD CONSTRAINT [FK_OwnerCat]
    FOREIGN KEY ([Owner_Id])
    REFERENCES [dbo].[OwnerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OwnerCat'
CREATE INDEX [IX_FK_OwnerCat]
ON [dbo].[CatSet]
    ([Owner_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------