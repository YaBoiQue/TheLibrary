
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/14/2022 01:03:51
-- Generated from EDMX file: C:\dev\gitlab\QuintenKnight7601\TheLibrary\EasyEstimates\EasyEstimates\Data\EasyEstimatesModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EasyEstimates];
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

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Specs'
CREATE TABLE [dbo].[Specs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ServiceId] int  NOT NULL,
    [VehicleType] nvarchar(max)  NOT NULL,
    [TireSize] nvarchar(max)  NOT NULL,
    [Service_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id], [ServiceId] in table 'Specs'
ALTER TABLE [dbo].[Specs]
ADD CONSTRAINT [PK_Specs]
    PRIMARY KEY CLUSTERED ([Id], [ServiceId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Service_Id] in table 'Specs'
ALTER TABLE [dbo].[Specs]
ADD CONSTRAINT [FK_ServiceSpecs]
    FOREIGN KEY ([Service_Id])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceSpecs'
CREATE INDEX [IX_FK_ServiceSpecs]
ON [dbo].[Specs]
    ([Service_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------