
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/10/2017 15:10:57
-- Generated from EDMX file: C:\Users\adria\OneDrive\Documentos\TP-DDS-Grupo13\TPDDS2017_GRUPO13_DONDE_INVIERTO\DONDE_INVIERTO.Entity\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dondeinvierto];
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

-- Creating table 'CuentaSet'
CREATE TABLE [dbo].[CuentaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [EmpresaId] int  NOT NULL
);
GO

-- Creating table 'EmpresaSet'
CREATE TABLE [dbo].[EmpresaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FechaCreacion] datetime  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'IndicadorSet'
CREATE TABLE [dbo].[IndicadorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Contenido] nvarchar(max)  NOT NULL,
    [UsuarioId] int  NULL
);
GO

-- Creating table 'MetodologiaSet'
CREATE TABLE [dbo].[MetodologiaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [UsuarioId] int  NULL
);
GO

-- Creating table 'PeriodoSet'
CREATE TABLE [dbo].[PeriodoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Anio] smallint  NOT NULL,
    [Semestre] smallint  NOT NULL
);
GO

-- Creating table 'CuentaXPeriodoSet'
CREATE TABLE [dbo].[CuentaXPeriodoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CuentaId] int  NOT NULL,
    [PeriodoId] int  NOT NULL
);
GO

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Contrasenia] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'IndicadorXCuentaSet'
CREATE TABLE [dbo].[IndicadorXCuentaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CuentaId] int  NOT NULL,
    [IndicadorId] int  NOT NULL
);
GO

-- Creating table 'CondicionSet'
CREATE TABLE [dbo].[CondicionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IndicadorId] int  NOT NULL,
    [ComoDescartar] nvarchar(max)  NOT NULL,
    [ComoOrdenar] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CondicionXMetodologiaSet'
CREATE TABLE [dbo].[CondicionXMetodologiaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MetodologiaId] int  NOT NULL,
    [CondicionId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CuentaSet'
ALTER TABLE [dbo].[CuentaSet]
ADD CONSTRAINT [PK_CuentaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmpresaSet'
ALTER TABLE [dbo].[EmpresaSet]
ADD CONSTRAINT [PK_EmpresaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IndicadorSet'
ALTER TABLE [dbo].[IndicadorSet]
ADD CONSTRAINT [PK_IndicadorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MetodologiaSet'
ALTER TABLE [dbo].[MetodologiaSet]
ADD CONSTRAINT [PK_MetodologiaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PeriodoSet'
ALTER TABLE [dbo].[PeriodoSet]
ADD CONSTRAINT [PK_PeriodoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CuentaXPeriodoSet'
ALTER TABLE [dbo].[CuentaXPeriodoSet]
ADD CONSTRAINT [PK_CuentaXPeriodoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IndicadorXCuentaSet'
ALTER TABLE [dbo].[IndicadorXCuentaSet]
ADD CONSTRAINT [PK_IndicadorXCuentaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CondicionSet'
ALTER TABLE [dbo].[CondicionSet]
ADD CONSTRAINT [PK_CondicionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CondicionXMetodologiaSet'
ALTER TABLE [dbo].[CondicionXMetodologiaSet]
ADD CONSTRAINT [PK_CondicionXMetodologiaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CuentaId] in table 'CuentaXPeriodoSet'
ALTER TABLE [dbo].[CuentaXPeriodoSet]
ADD CONSTRAINT [FK_CuentaXPeriodoCuenta]
    FOREIGN KEY ([CuentaId])
    REFERENCES [dbo].[CuentaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CuentaXPeriodoCuenta'
CREATE INDEX [IX_FK_CuentaXPeriodoCuenta]
ON [dbo].[CuentaXPeriodoSet]
    ([CuentaId]);
GO

-- Creating foreign key on [PeriodoId] in table 'CuentaXPeriodoSet'
ALTER TABLE [dbo].[CuentaXPeriodoSet]
ADD CONSTRAINT [FK_CuentaXPeriodoPeriodo]
    FOREIGN KEY ([PeriodoId])
    REFERENCES [dbo].[PeriodoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CuentaXPeriodoPeriodo'
CREATE INDEX [IX_FK_CuentaXPeriodoPeriodo]
ON [dbo].[CuentaXPeriodoSet]
    ([PeriodoId]);
GO

-- Creating foreign key on [CuentaId] in table 'IndicadorXCuentaSet'
ALTER TABLE [dbo].[IndicadorXCuentaSet]
ADD CONSTRAINT [FK_IndicadorXCuentaCuenta]
    FOREIGN KEY ([CuentaId])
    REFERENCES [dbo].[CuentaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndicadorXCuentaCuenta'
CREATE INDEX [IX_FK_IndicadorXCuentaCuenta]
ON [dbo].[IndicadorXCuentaSet]
    ([CuentaId]);
GO

-- Creating foreign key on [IndicadorId] in table 'IndicadorXCuentaSet'
ALTER TABLE [dbo].[IndicadorXCuentaSet]
ADD CONSTRAINT [FK_IndicadorXCuentaIndicador]
    FOREIGN KEY ([IndicadorId])
    REFERENCES [dbo].[IndicadorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IndicadorXCuentaIndicador'
CREATE INDEX [IX_FK_IndicadorXCuentaIndicador]
ON [dbo].[IndicadorXCuentaSet]
    ([IndicadorId]);
GO

-- Creating foreign key on [EmpresaId] in table 'CuentaSet'
ALTER TABLE [dbo].[CuentaSet]
ADD CONSTRAINT [FK_EmpresaCuenta]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[EmpresaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaCuenta'
CREATE INDEX [IX_FK_EmpresaCuenta]
ON [dbo].[CuentaSet]
    ([EmpresaId]);
GO

-- Creating foreign key on [UsuarioId] in table 'IndicadorSet'
ALTER TABLE [dbo].[IndicadorSet]
ADD CONSTRAINT [FK_UsuarioIndicador]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioIndicador'
CREATE INDEX [IX_FK_UsuarioIndicador]
ON [dbo].[IndicadorSet]
    ([UsuarioId]);
GO

-- Creating foreign key on [UsuarioId] in table 'MetodologiaSet'
ALTER TABLE [dbo].[MetodologiaSet]
ADD CONSTRAINT [FK_UsuarioMetodologia]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioMetodologia'
CREATE INDEX [IX_FK_UsuarioMetodologia]
ON [dbo].[MetodologiaSet]
    ([UsuarioId]);
GO

-- Creating foreign key on [IndicadorId] in table 'CondicionSet'
ALTER TABLE [dbo].[CondicionSet]
ADD CONSTRAINT [FK_CondicionIndicador]
    FOREIGN KEY ([IndicadorId])
    REFERENCES [dbo].[IndicadorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CondicionIndicador'
CREATE INDEX [IX_FK_CondicionIndicador]
ON [dbo].[CondicionSet]
    ([IndicadorId]);
GO

-- Creating foreign key on [MetodologiaId] in table 'CondicionXMetodologiaSet'
ALTER TABLE [dbo].[CondicionXMetodologiaSet]
ADD CONSTRAINT [FK_CondicionXMetodologiaMetodologia]
    FOREIGN KEY ([MetodologiaId])
    REFERENCES [dbo].[MetodologiaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CondicionXMetodologiaMetodologia'
CREATE INDEX [IX_FK_CondicionXMetodologiaMetodologia]
ON [dbo].[CondicionXMetodologiaSet]
    ([MetodologiaId]);
GO

-- Creating foreign key on [CondicionId] in table 'CondicionXMetodologiaSet'
ALTER TABLE [dbo].[CondicionXMetodologiaSet]
ADD CONSTRAINT [FK_CondicionXMetodologiaCondicion]
    FOREIGN KEY ([CondicionId])
    REFERENCES [dbo].[CondicionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CondicionXMetodologiaCondicion'
CREATE INDEX [IX_FK_CondicionXMetodologiaCondicion]
ON [dbo].[CondicionXMetodologiaSet]
    ([CondicionId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------