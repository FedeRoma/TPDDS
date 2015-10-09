
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/07/2015 17:22:54
-- Generated from EDMX file: c:\users\diego\documents\visual studio 2012\Projects\MvcApplication1\MvcApplication1\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [baseDatosTP];
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

-- Creating table 'UsuariosConjunto'
CREATE TABLE [dbo].[UsuariosConjunto] (
    [nombreUsuario] int IDENTITY(1,1) NOT NULL,
    [Clave] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Sexo] nvarchar(max)  NOT NULL,
    [Altura] nvarchar(max)  NOT NULL,
    [idComplexion] nvarchar(max)  NOT NULL,
    [idRutina] nvarchar(max)  NOT NULL,
    [relacionUsuarioPreferencia_idPreferencia] int  NOT NULL,
    [Complexion_idComplexion] int  NOT NULL,
    [RelacionUsuarioGrupos_idGrupo] int  NOT NULL
);
GO

-- Creating table 'RutinaConjunto'
CREATE TABLE [dbo].[RutinaConjunto] (
    [IdRutina] int IDENTITY(1,1) NOT NULL,
    [Usuarios_nombreUsuario] int  NOT NULL
);
GO

-- Creating table 'RelacionUsuarioGruposConjunto'
CREATE TABLE [dbo].[RelacionUsuarioGruposConjunto] (
    [idGrupo] int IDENTITY(1,1) NOT NULL,
    [nombreUsuario] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GruposConjunto'
CREATE TABLE [dbo].[GruposConjunto] (
    [idGrupo] int IDENTITY(1,1) NOT NULL,
    [nombreGrupo] nvarchar(max)  NOT NULL,
    [Creador] nvarchar(max)  NOT NULL,
    [RelacionUsuarioGrupos_idGrupo] int  NOT NULL
);
GO

-- Creating table 'ComplexionConjunto'
CREATE TABLE [dbo].[ComplexionConjunto] (
    [idComplexion] int IDENTITY(1,1) NOT NULL,
    [complexion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CondicionesConjunto'
CREATE TABLE [dbo].[CondicionesConjunto] (
    [idCondicion] int IDENTITY(1,1) NOT NULL,
    [Condicion] nvarchar(max)  NOT NULL,
    [Usuarios_nombreUsuario] int  NOT NULL
);
GO

-- Creating table 'relacionUsuarioPreferenciaConjunto'
CREATE TABLE [dbo].[relacionUsuarioPreferenciaConjunto] (
    [idPreferencia] int IDENTITY(1,1) NOT NULL,
    [nombreUsuario] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'preferenciasAlimenticiasConjunto'
CREATE TABLE [dbo].[preferenciasAlimenticiasConjunto] (
    [idPreferencia] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [relacionUsuarioPreferencia_idPreferencia] int  NOT NULL
);
GO

-- Creating table 'RecetasConjunto'
CREATE TABLE [dbo].[RecetasConjunto] (
    [idReceta] int IDENTITY(1,1) NOT NULL,
    [idDificultad] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Creador] nvarchar(max)  NOT NULL,
    [Usuarios_nombreUsuario] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [nombreUsuario] in table 'UsuariosConjunto'
ALTER TABLE [dbo].[UsuariosConjunto]
ADD CONSTRAINT [PK_UsuariosConjunto]
    PRIMARY KEY CLUSTERED ([nombreUsuario] ASC);
GO

-- Creating primary key on [IdRutina] in table 'RutinaConjunto'
ALTER TABLE [dbo].[RutinaConjunto]
ADD CONSTRAINT [PK_RutinaConjunto]
    PRIMARY KEY CLUSTERED ([IdRutina] ASC);
GO

-- Creating primary key on [idGrupo] in table 'RelacionUsuarioGruposConjunto'
ALTER TABLE [dbo].[RelacionUsuarioGruposConjunto]
ADD CONSTRAINT [PK_RelacionUsuarioGruposConjunto]
    PRIMARY KEY CLUSTERED ([idGrupo] ASC);
GO

-- Creating primary key on [idGrupo] in table 'GruposConjunto'
ALTER TABLE [dbo].[GruposConjunto]
ADD CONSTRAINT [PK_GruposConjunto]
    PRIMARY KEY CLUSTERED ([idGrupo] ASC);
GO

-- Creating primary key on [idComplexion] in table 'ComplexionConjunto'
ALTER TABLE [dbo].[ComplexionConjunto]
ADD CONSTRAINT [PK_ComplexionConjunto]
    PRIMARY KEY CLUSTERED ([idComplexion] ASC);
GO

-- Creating primary key on [idCondicion] in table 'CondicionesConjunto'
ALTER TABLE [dbo].[CondicionesConjunto]
ADD CONSTRAINT [PK_CondicionesConjunto]
    PRIMARY KEY CLUSTERED ([idCondicion] ASC);
GO

-- Creating primary key on [idPreferencia] in table 'relacionUsuarioPreferenciaConjunto'
ALTER TABLE [dbo].[relacionUsuarioPreferenciaConjunto]
ADD CONSTRAINT [PK_relacionUsuarioPreferenciaConjunto]
    PRIMARY KEY CLUSTERED ([idPreferencia] ASC);
GO

-- Creating primary key on [idPreferencia] in table 'preferenciasAlimenticiasConjunto'
ALTER TABLE [dbo].[preferenciasAlimenticiasConjunto]
ADD CONSTRAINT [PK_preferenciasAlimenticiasConjunto]
    PRIMARY KEY CLUSTERED ([idPreferencia] ASC);
GO

-- Creating primary key on [idReceta] in table 'RecetasConjunto'
ALTER TABLE [dbo].[RecetasConjunto]
ADD CONSTRAINT [PK_RecetasConjunto]
    PRIMARY KEY CLUSTERED ([idReceta] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [relacionUsuarioPreferencia_idPreferencia] in table 'UsuariosConjunto'
ALTER TABLE [dbo].[UsuariosConjunto]
ADD CONSTRAINT [FK_UsuariosrelacionUsuarioPreferencia]
    FOREIGN KEY ([relacionUsuarioPreferencia_idPreferencia])
    REFERENCES [dbo].[relacionUsuarioPreferenciaConjunto]
        ([idPreferencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuariosrelacionUsuarioPreferencia'
CREATE INDEX [IX_FK_UsuariosrelacionUsuarioPreferencia]
ON [dbo].[UsuariosConjunto]
    ([relacionUsuarioPreferencia_idPreferencia]);
GO

-- Creating foreign key on [relacionUsuarioPreferencia_idPreferencia] in table 'preferenciasAlimenticiasConjunto'
ALTER TABLE [dbo].[preferenciasAlimenticiasConjunto]
ADD CONSTRAINT [FK_relacionUsuarioPreferenciapreferenciasAlimenticias]
    FOREIGN KEY ([relacionUsuarioPreferencia_idPreferencia])
    REFERENCES [dbo].[relacionUsuarioPreferenciaConjunto]
        ([idPreferencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_relacionUsuarioPreferenciapreferenciasAlimenticias'
CREATE INDEX [IX_FK_relacionUsuarioPreferenciapreferenciasAlimenticias]
ON [dbo].[preferenciasAlimenticiasConjunto]
    ([relacionUsuarioPreferencia_idPreferencia]);
GO

-- Creating foreign key on [Usuarios_nombreUsuario] in table 'RutinaConjunto'
ALTER TABLE [dbo].[RutinaConjunto]
ADD CONSTRAINT [FK_UsuariosRutina]
    FOREIGN KEY ([Usuarios_nombreUsuario])
    REFERENCES [dbo].[UsuariosConjunto]
        ([nombreUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuariosRutina'
CREATE INDEX [IX_FK_UsuariosRutina]
ON [dbo].[RutinaConjunto]
    ([Usuarios_nombreUsuario]);
GO

-- Creating foreign key on [Complexion_idComplexion] in table 'UsuariosConjunto'
ALTER TABLE [dbo].[UsuariosConjunto]
ADD CONSTRAINT [FK_UsuariosComplexion]
    FOREIGN KEY ([Complexion_idComplexion])
    REFERENCES [dbo].[ComplexionConjunto]
        ([idComplexion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuariosComplexion'
CREATE INDEX [IX_FK_UsuariosComplexion]
ON [dbo].[UsuariosConjunto]
    ([Complexion_idComplexion]);
GO

-- Creating foreign key on [Usuarios_nombreUsuario] in table 'CondicionesConjunto'
ALTER TABLE [dbo].[CondicionesConjunto]
ADD CONSTRAINT [FK_UsuariosCondiciones]
    FOREIGN KEY ([Usuarios_nombreUsuario])
    REFERENCES [dbo].[UsuariosConjunto]
        ([nombreUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuariosCondiciones'
CREATE INDEX [IX_FK_UsuariosCondiciones]
ON [dbo].[CondicionesConjunto]
    ([Usuarios_nombreUsuario]);
GO

-- Creating foreign key on [RelacionUsuarioGrupos_idGrupo] in table 'UsuariosConjunto'
ALTER TABLE [dbo].[UsuariosConjunto]
ADD CONSTRAINT [FK_UsuariosRelacionUsuarioGrupos]
    FOREIGN KEY ([RelacionUsuarioGrupos_idGrupo])
    REFERENCES [dbo].[RelacionUsuarioGruposConjunto]
        ([idGrupo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuariosRelacionUsuarioGrupos'
CREATE INDEX [IX_FK_UsuariosRelacionUsuarioGrupos]
ON [dbo].[UsuariosConjunto]
    ([RelacionUsuarioGrupos_idGrupo]);
GO

-- Creating foreign key on [RelacionUsuarioGrupos_idGrupo] in table 'GruposConjunto'
ALTER TABLE [dbo].[GruposConjunto]
ADD CONSTRAINT [FK_RelacionUsuarioGruposGrupos]
    FOREIGN KEY ([RelacionUsuarioGrupos_idGrupo])
    REFERENCES [dbo].[RelacionUsuarioGruposConjunto]
        ([idGrupo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RelacionUsuarioGruposGrupos'
CREATE INDEX [IX_FK_RelacionUsuarioGruposGrupos]
ON [dbo].[GruposConjunto]
    ([RelacionUsuarioGrupos_idGrupo]);
GO

-- Creating foreign key on [Usuarios_nombreUsuario] in table 'RecetasConjunto'
ALTER TABLE [dbo].[RecetasConjunto]
ADD CONSTRAINT [FK_UsuariosRecetas]
    FOREIGN KEY ([Usuarios_nombreUsuario])
    REFERENCES [dbo].[UsuariosConjunto]
        ([nombreUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuariosRecetas'
CREATE INDEX [IX_FK_UsuariosRecetas]
ON [dbo].[RecetasConjunto]
    ([Usuarios_nombreUsuario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------