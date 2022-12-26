
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/24/2022 12:58:13
-- Generated from EDMX file: C:\Users\Knigh\dev\GitHub\TheLibrary\RapidTireEstimates\RapidTireEstimates\Data\RapidTireEstimatesModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RapidTireEstimatesdb];
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

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Contents] nvarchar(max)  NOT NULL,
    [DateCreated] datetime  NOT NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'VehicleTypes'
CREATE TABLE [dbo].[VehicleTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ServiceId] int  NOT NULL
);
GO

-- Creating table 'Prices'
CREATE TABLE [dbo].[Prices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Estimates'
CREATE TABLE [dbo].[Estimates] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [FinishDate] datetime  NOT NULL,
    [FinalPrice] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ServiceEstimates'
CREATE TABLE [dbo].[ServiceEstimates] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ServiceId] int  NOT NULL,
    [EstimateId] int  NOT NULL,
    [EstimatePrice_Id] int  NOT NULL
);
GO

-- Creating table 'Parts'
CREATE TABLE [dbo].[Parts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [PartPrice_Id] int  NOT NULL
);
GO

-- Creating table 'Vehicles'
CREATE TABLE [dbo].[Vehicles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Year] nvarchar(max)  NOT NULL,
    [VehicleTypeId] int  NOT NULL,
    [CustomerId] int  NOT NULL,
    [Estimate_Id] int  NOT NULL
);
GO

-- Creating table 'Prices_ServicePrice'
CREATE TABLE [dbo].[Prices_ServicePrice] (
    [Description] nvarchar(max)  NOT NULL,
    [Level] smallint  NOT NULL,
    [ServiceId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Prices_EstimatePrice'
CREATE TABLE [dbo].[Prices_EstimatePrice] (
    [Description] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Comments_CustomerComment'
CREATE TABLE [dbo].[Comments_CustomerComment] (
    [CustomerId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Comments_EstimateComment'
CREATE TABLE [dbo].[Comments_EstimateComment] (
    [EstimateId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Comments_ServiceEstimateComment'
CREATE TABLE [dbo].[Comments_ServiceEstimateComment] (
    [ServiceEstimateId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Prices_PartPrice'
CREATE TABLE [dbo].[Prices_PartPrice] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Parts_ShopPart'
CREATE TABLE [dbo].[Parts_ShopPart] (
    [EstimateId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Parts_VehiclePart'
CREATE TABLE [dbo].[Parts_VehiclePart] (
    [EstimateId] int  NOT NULL,
    [VehicleId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VehicleTypes'
ALTER TABLE [dbo].[VehicleTypes]
ADD CONSTRAINT [PK_VehicleTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [PK_Prices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Estimates'
ALTER TABLE [dbo].[Estimates]
ADD CONSTRAINT [PK_Estimates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceEstimates'
ALTER TABLE [dbo].[ServiceEstimates]
ADD CONSTRAINT [PK_ServiceEstimates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Parts'
ALTER TABLE [dbo].[Parts]
ADD CONSTRAINT [PK_Parts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [PK_Vehicles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prices_ServicePrice'
ALTER TABLE [dbo].[Prices_ServicePrice]
ADD CONSTRAINT [PK_Prices_ServicePrice]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prices_EstimatePrice'
ALTER TABLE [dbo].[Prices_EstimatePrice]
ADD CONSTRAINT [PK_Prices_EstimatePrice]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments_CustomerComment'
ALTER TABLE [dbo].[Comments_CustomerComment]
ADD CONSTRAINT [PK_Comments_CustomerComment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments_EstimateComment'
ALTER TABLE [dbo].[Comments_EstimateComment]
ADD CONSTRAINT [PK_Comments_EstimateComment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments_ServiceEstimateComment'
ALTER TABLE [dbo].[Comments_ServiceEstimateComment]
ADD CONSTRAINT [PK_Comments_ServiceEstimateComment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prices_PartPrice'
ALTER TABLE [dbo].[Prices_PartPrice]
ADD CONSTRAINT [PK_Prices_PartPrice]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Parts_ShopPart'
ALTER TABLE [dbo].[Parts_ShopPart]
ADD CONSTRAINT [PK_Parts_ShopPart]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Parts_VehiclePart'
ALTER TABLE [dbo].[Parts_VehiclePart]
ADD CONSTRAINT [PK_Parts_VehiclePart]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ServiceId] in table 'Prices_ServicePrice'
ALTER TABLE [dbo].[Prices_ServicePrice]
ADD CONSTRAINT [FK_ServiceServicePrice]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceServicePrice'
CREATE INDEX [IX_FK_ServiceServicePrice]
ON [dbo].[Prices_ServicePrice]
    ([ServiceId]);
GO

-- Creating foreign key on [EstimatePrice_Id] in table 'ServiceEstimates'
ALTER TABLE [dbo].[ServiceEstimates]
ADD CONSTRAINT [FK_ServiceEstimatePriceEstimate]
    FOREIGN KEY ([EstimatePrice_Id])
    REFERENCES [dbo].[Prices_EstimatePrice]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceEstimatePriceEstimate'
CREATE INDEX [IX_FK_ServiceEstimatePriceEstimate]
ON [dbo].[ServiceEstimates]
    ([EstimatePrice_Id]);
GO

-- Creating foreign key on [ServiceId] in table 'VehicleTypes'
ALTER TABLE [dbo].[VehicleTypes]
ADD CONSTRAINT [FK_ServiceVehicleType]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceVehicleType'
CREATE INDEX [IX_FK_ServiceVehicleType]
ON [dbo].[VehicleTypes]
    ([ServiceId]);
GO

-- Creating foreign key on [ServiceId] in table 'ServiceEstimates'
ALTER TABLE [dbo].[ServiceEstimates]
ADD CONSTRAINT [FK_ServiceServiceEstimate]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceServiceEstimate'
CREATE INDEX [IX_FK_ServiceServiceEstimate]
ON [dbo].[ServiceEstimates]
    ([ServiceId]);
GO

-- Creating foreign key on [CustomerId] in table 'Estimates'
ALTER TABLE [dbo].[Estimates]
ADD CONSTRAINT [FK_CustomerEstimate]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerEstimate'
CREATE INDEX [IX_FK_CustomerEstimate]
ON [dbo].[Estimates]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'Comments_CustomerComment'
ALTER TABLE [dbo].[Comments_CustomerComment]
ADD CONSTRAINT [FK_CustomerCustomerComment]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerCustomerComment'
CREATE INDEX [IX_FK_CustomerCustomerComment]
ON [dbo].[Comments_CustomerComment]
    ([CustomerId]);
GO

-- Creating foreign key on [EstimateId] in table 'Comments_EstimateComment'
ALTER TABLE [dbo].[Comments_EstimateComment]
ADD CONSTRAINT [FK_EstimateEstimateComment]
    FOREIGN KEY ([EstimateId])
    REFERENCES [dbo].[Estimates]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstimateEstimateComment'
CREATE INDEX [IX_FK_EstimateEstimateComment]
ON [dbo].[Comments_EstimateComment]
    ([EstimateId]);
GO

-- Creating foreign key on [ServiceEstimateId] in table 'Comments_ServiceEstimateComment'
ALTER TABLE [dbo].[Comments_ServiceEstimateComment]
ADD CONSTRAINT [FK_ServiceEstimateServiceEstimateComment]
    FOREIGN KEY ([ServiceEstimateId])
    REFERENCES [dbo].[ServiceEstimates]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceEstimateServiceEstimateComment'
CREATE INDEX [IX_FK_ServiceEstimateServiceEstimateComment]
ON [dbo].[Comments_ServiceEstimateComment]
    ([ServiceEstimateId]);
GO

-- Creating foreign key on [EstimateId] in table 'ServiceEstimates'
ALTER TABLE [dbo].[ServiceEstimates]
ADD CONSTRAINT [FK_EstimateServiceEstimate]
    FOREIGN KEY ([EstimateId])
    REFERENCES [dbo].[Estimates]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstimateServiceEstimate'
CREATE INDEX [IX_FK_EstimateServiceEstimate]
ON [dbo].[ServiceEstimates]
    ([EstimateId]);
GO

-- Creating foreign key on [PartPrice_Id] in table 'Parts'
ALTER TABLE [dbo].[Parts]
ADD CONSTRAINT [FK_PartPartPrice]
    FOREIGN KEY ([PartPrice_Id])
    REFERENCES [dbo].[Prices_PartPrice]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PartPartPrice'
CREATE INDEX [IX_FK_PartPartPrice]
ON [dbo].[Parts]
    ([PartPrice_Id]);
GO

-- Creating foreign key on [EstimateId] in table 'Parts_ShopPart'
ALTER TABLE [dbo].[Parts_ShopPart]
ADD CONSTRAINT [FK_EstimateShopPart]
    FOREIGN KEY ([EstimateId])
    REFERENCES [dbo].[Estimates]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstimateShopPart'
CREATE INDEX [IX_FK_EstimateShopPart]
ON [dbo].[Parts_ShopPart]
    ([EstimateId]);
GO

-- Creating foreign key on [EstimateId] in table 'Parts_VehiclePart'
ALTER TABLE [dbo].[Parts_VehiclePart]
ADD CONSTRAINT [FK_EstimateVehiclePart]
    FOREIGN KEY ([EstimateId])
    REFERENCES [dbo].[Estimates]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstimateVehiclePart'
CREATE INDEX [IX_FK_EstimateVehiclePart]
ON [dbo].[Parts_VehiclePart]
    ([EstimateId]);
GO

-- Creating foreign key on [VehicleTypeId] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_VehicleVehicleType]
    FOREIGN KEY ([VehicleTypeId])
    REFERENCES [dbo].[VehicleTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleVehicleType'
CREATE INDEX [IX_FK_VehicleVehicleType]
ON [dbo].[Vehicles]
    ([VehicleTypeId]);
GO

-- Creating foreign key on [CustomerId] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_CustomerVehicle1]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerVehicle1'
CREATE INDEX [IX_FK_CustomerVehicle1]
ON [dbo].[Vehicles]
    ([CustomerId]);
GO

-- Creating foreign key on [Estimate_Id] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_VehicleEstimate1]
    FOREIGN KEY ([Estimate_Id])
    REFERENCES [dbo].[Estimates]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleEstimate1'
CREATE INDEX [IX_FK_VehicleEstimate1]
ON [dbo].[Vehicles]
    ([Estimate_Id]);
GO

-- Creating foreign key on [VehicleId] in table 'Parts_VehiclePart'
ALTER TABLE [dbo].[Parts_VehiclePart]
ADD CONSTRAINT [FK_VehicleVehiclePart1]
    FOREIGN KEY ([VehicleId])
    REFERENCES [dbo].[Vehicles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleVehiclePart1'
CREATE INDEX [IX_FK_VehicleVehiclePart1]
ON [dbo].[Parts_VehiclePart]
    ([VehicleId]);
GO

-- Creating foreign key on [Id] in table 'Prices_ServicePrice'
ALTER TABLE [dbo].[Prices_ServicePrice]
ADD CONSTRAINT [FK_ServicePrice_inherits_Price]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Prices]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Prices_EstimatePrice'
ALTER TABLE [dbo].[Prices_EstimatePrice]
ADD CONSTRAINT [FK_EstimatePrice_inherits_Price]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Prices]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Comments_CustomerComment'
ALTER TABLE [dbo].[Comments_CustomerComment]
ADD CONSTRAINT [FK_CustomerComment_inherits_Comment]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Comments]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Comments_EstimateComment'
ALTER TABLE [dbo].[Comments_EstimateComment]
ADD CONSTRAINT [FK_EstimateComment_inherits_Comment]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Comments]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Comments_ServiceEstimateComment'
ALTER TABLE [dbo].[Comments_ServiceEstimateComment]
ADD CONSTRAINT [FK_ServiceEstimateComment_inherits_Comment]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Comments]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Prices_PartPrice'
ALTER TABLE [dbo].[Prices_PartPrice]
ADD CONSTRAINT [FK_PartPrice_inherits_Price]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Prices]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Parts_ShopPart'
ALTER TABLE [dbo].[Parts_ShopPart]
ADD CONSTRAINT [FK_ShopPart_inherits_Part]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Parts]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Parts_VehiclePart'
ALTER TABLE [dbo].[Parts_VehiclePart]
ADD CONSTRAINT [FK_VehiclePart_inherits_Part]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Parts]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------