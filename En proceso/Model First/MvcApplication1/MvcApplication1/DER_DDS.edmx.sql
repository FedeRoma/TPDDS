
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/14/2015 18:13:35
-- Generated from EDMX file: C:\Users\Diego\Desktop\DDS TP\TPDDS\En proceso\Model First\MvcApplication1\MvcApplication1\Model1.edmx
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

IF OBJECT_ID(N'[dbo].[FK_UsuarioRecetaUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioConjunto] DROP CONSTRAINT [FK_UsuarioRecetaUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioRecetaReceta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecetaConjunto] DROP CONSTRAINT [FK_UsuarioRecetaReceta];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioUsuarioGrupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioConjunto] DROP CONSTRAINT [FK_UsuarioUsuarioGrupo];
GO
IF OBJECT_ID(N'[dbo].[FK_GrupoUsuarioGrupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GrupoConjunto] DROP CONSTRAINT [FK_GrupoUsuarioGrupo];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioUsuarioPreferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioConjunto] DROP CONSTRAINT [FK_UsuarioUsuarioPreferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioPreferenciaPreferencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PreferenciaConjunto] DROP CONSTRAINT [FK_UsuarioPreferenciaPreferencia];
GO
IF OBJECT_ID(N'[dbo].[FK_ClasificacionRecetaCalificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClasificacionRecetaConjunto] DROP CONSTRAINT [FK_ClasificacionRecetaCalificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_RecetaClasificacionReceta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecetaConjunto] DROP CONSTRAINT [FK_RecetaClasificacionReceta];
GO
IF OBJECT_ID(N'[dbo].[FK_CondimentoRecetaReceta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecetaConjunto] DROP CONSTRAINT [FK_CondimentoRecetaReceta];
GO
IF OBJECT_ID(N'[dbo].[FK_CondimentoCondimentoReceta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CondimentoConjunto] DROP CONSTRAINT [FK_CondimentoCondimentoReceta];
GO
IF OBJECT_ID(N'[dbo].[FK_IngredienteRecetaIngrediente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IngredienteConjunto] DROP CONSTRAINT [FK_IngredienteRecetaIngrediente];
GO
IF OBJECT_ID(N'[dbo].[FK_IngredienteRecetaReceta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RecetaConjunto] DROP CONSTRAINT [FK_IngredienteRecetaReceta];
GO
IF OBJECT_ID(N'[dbo].[FK_GrupoPreferenciasGrupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GrupoConjunto] DROP CONSTRAINT [FK_GrupoPreferenciasGrupo];
GO
IF OBJECT_ID(N'[dbo].[FK_PreferenciaGrupoPreferencias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PreferenciaConjunto] DROP CONSTRAINT [FK_PreferenciaGrupoPreferencias];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioCondicionPreexistente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CondicionPreexistenteConjunto] DROP CONSTRAINT [FK_UsuarioCondicionPreexistente];
GO
IF OBJECT_ID(N'[dbo].[FK_ComplexionUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComplexionConjunto] DROP CONSTRAINT [FK_ComplexionUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_ProcedimientoReceta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProcedimientoConjunto] DROP CONSTRAINT [FK_ProcedimientoReceta];
GO
IF OBJECT_ID(N'[dbo].[FK_DietaUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DietaConjunto] DROP CONSTRAINT [FK_DietaUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_GrupoPiramideAlimenticia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GrupoConjunto] DROP CONSTRAINT [FK_GrupoPiramideAlimenticia];
GO
IF OBJECT_ID(N'[dbo].[FK_RecetaTemporada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TemporadaConjunto] DROP CONSTRAINT [FK_RecetaTemporada];
GO
IF OBJECT_ID(N'[dbo].[FK_ClasificacionReceta1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClasificacionConjunto] DROP CONSTRAINT [FK_ClasificacionReceta1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CalificacionConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalificacionConjunto];
GO
IF OBJECT_ID(N'[dbo].[ClasificacionConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClasificacionConjunto];
GO
IF OBJECT_ID(N'[dbo].[ComplexionConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComplexionConjunto];
GO
IF OBJECT_ID(N'[dbo].[CondicionPreexistenteConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CondicionPreexistenteConjunto];
GO
IF OBJECT_ID(N'[dbo].[CondimentoConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CondimentoConjunto];
GO
IF OBJECT_ID(N'[dbo].[DietaConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DietaConjunto];
GO
IF OBJECT_ID(N'[dbo].[GrupoConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GrupoConjunto];
GO
IF OBJECT_ID(N'[dbo].[IngredienteConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IngredienteConjunto];
GO
IF OBJECT_ID(N'[dbo].[IngredienteRecetaConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IngredienteRecetaConjunto];
GO
IF OBJECT_ID(N'[dbo].[PiramideAlimenticiaConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PiramideAlimenticiaConjunto];
GO
IF OBJECT_ID(N'[dbo].[PreferenciaConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PreferenciaConjunto];
GO
IF OBJECT_ID(N'[dbo].[ProcedimientoConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProcedimientoConjunto];
GO
IF OBJECT_ID(N'[dbo].[RecetaConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecetaConjunto];
GO
IF OBJECT_ID(N'[dbo].[TemporadaConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemporadaConjunto];
GO
IF OBJECT_ID(N'[dbo].[UsuarioConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioConjunto];
GO
IF OBJECT_ID(N'[dbo].[UsuarioPreferenciaConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioPreferenciaConjunto];
GO
IF OBJECT_ID(N'[dbo].[UsuarioRecetaConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioRecetaConjunto];
GO
IF OBJECT_ID(N'[dbo].[UsuarioGrupoConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioGrupoConjunto];
GO
IF OBJECT_ID(N'[dbo].[GrupoPreferenciasConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GrupoPreferenciasConjunto];
GO
IF OBJECT_ID(N'[dbo].[CondimentoRecetaConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CondimentoRecetaConjunto];
GO
IF OBJECT_ID(N'[dbo].[ClasificacionRecetaConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClasificacionRecetaConjunto];
GO
IF OBJECT_ID(N'[dbo].[DietasExcluidasConjunto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DietasExcluidasConjunto];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CalificacionConjunto'
CREATE TABLE [dbo].[CalificacionConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Valor] smallint  NOT NULL,
    [UsuarioID] smallint  NOT NULL
);
GO

-- Creating table 'ClasificacionConjunto'
CREATE TABLE [dbo].[ClasificacionConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [Receta_Id] int  NOT NULL
);
GO

-- Creating table 'ComplexionConjunto'
CREATE TABLE [dbo].[ComplexionConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [Usuario_Id] int  NOT NULL
);
GO

-- Creating table 'CondicionPreexistenteConjunto'
CREATE TABLE [dbo].[CondicionPreexistenteConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [UsuarioId] int  NOT NULL
);
GO

-- Creating table 'CondimentoConjunto'
CREATE TABLE [dbo].[CondimentoConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [tipo] nvarchar(max)  NOT NULL,
    [CondimentoReceta_IdReceta] int  NOT NULL
);
GO

-- Creating table 'DietaConjunto'
CREATE TABLE [dbo].[DietaConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [Usuario_Id] int  NOT NULL
);
GO

-- Creating table 'GrupoConjunto'
CREATE TABLE [dbo].[GrupoConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [GrupoPreferenciasIdGrupo] int  NOT NULL,
    [UsuarioGrupo_IdUsuario] int  NOT NULL,
    [PiramideAlimenticia_Id] int  NOT NULL
);
GO

-- Creating table 'IngredienteConjunto'
CREATE TABLE [dbo].[IngredienteConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [porcion] smallint  NOT NULL,
    [caloriasPorcion] smallint  NOT NULL,
    [IngredienteReceta_id] int  NOT NULL,
    [preferenciaId] smallint  NOT NULL
);
GO

-- Creating table 'IngredienteRecetaConjunto'
CREATE TABLE [dbo].[IngredienteRecetaConjunto] (
    [id] int IDENTITY(1,1) NOT NULL,
    [tipoIngrediente] nvarchar(max)  NOT NULL,
    [ingredienteID] smallint  NOT NULL,
    [recetaID] smallint  NOT NULL
);
GO

-- Creating table 'PiramideAlimenticiaConjunto'
CREATE TABLE [dbo].[PiramideAlimenticiaConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombreGrupo] nvarchar(max)  NOT NULL,
    [descripcionGrupo] nvarchar(max)  NOT NULL,
    [contraindicaciones] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PreferenciaConjunto'
CREATE TABLE [dbo].[PreferenciaConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [UsuarioPreferenciaIdUsuario] int  NOT NULL,
    [GrupoPreferencias_IdGrupo] int  NOT NULL
);
GO

-- Creating table 'ProcedimientoConjunto'
CREATE TABLE [dbo].[ProcedimientoConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [numero] smallint  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [imagen] nvarchar(max)  NOT NULL,
    [Receta_Id] int  NOT NULL
);
GO

-- Creating table 'RecetaConjunto'
CREATE TABLE [dbo].[RecetaConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [dificultad] smallint  NOT NULL,
    [totalCalorias] float  NOT NULL,
    [piramideID] nvarchar(max)  NOT NULL,
    [usuarioID] nvarchar(max)  NOT NULL,
    [UsuarioRecetaIdUsuario] int  NOT NULL,
    [CondimentoRecetaIdReceta] int  NOT NULL,
    [IngredienteReceta_id] int  NOT NULL,
    [ClasificacionReceta_IdClasificacion] int  NOT NULL
);
GO

-- Creating table 'TemporadaConjunto'
CREATE TABLE [dbo].[TemporadaConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [RecetaId] int  NOT NULL
);
GO

-- Creating table 'UsuarioConjunto'
CREATE TABLE [dbo].[UsuarioConjunto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [userName] nvarchar(max)  NOT NULL,
    [Pass] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Sexo] nvarchar(max)  NOT NULL,
    [FechaDeNacimiento] nvarchar(max)  NOT NULL,
    [FechaAltaPerfil] nvarchar(max)  NOT NULL,
    [Altura] nvarchar(max)  NOT NULL,
    [Rutina] nvarchar(max)  NOT NULL,
    [CondicionPreexistenteID] nvarchar(max)  NOT NULL,
    [ComplexionID] nvarchar(max)  NOT NULL,
    [DietaID] nvarchar(max)  NOT NULL,
    [UsuarioRecetaIdUsuario] int  NOT NULL,
    [UsuarioGrupo_IdUsuario] int  NOT NULL,
    [UsuarioPreferencia_IdUsuario] int  NOT NULL
);
GO

-- Creating table 'UsuarioPreferenciaConjunto'
CREATE TABLE [dbo].[UsuarioPreferenciaConjunto] (
    [IdUsuario] int IDENTITY(1,1) NOT NULL,
    [idPreferencia] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsuarioRecetaConjunto'
CREATE TABLE [dbo].[UsuarioRecetaConjunto] (
    [IdUsuario] int IDENTITY(1,1) NOT NULL,
    [IdReceta] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsuarioGrupoConjunto'
CREATE TABLE [dbo].[UsuarioGrupoConjunto] (
    [IdUsuario] int IDENTITY(1,1) NOT NULL,
    [IdGrupo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'GrupoPreferenciasConjunto'
CREATE TABLE [dbo].[GrupoPreferenciasConjunto] (
    [IdGrupo] int IDENTITY(1,1) NOT NULL,
    [IdPreferencia] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CondimentoRecetaConjunto'
CREATE TABLE [dbo].[CondimentoRecetaConjunto] (
    [IdReceta] int IDENTITY(1,1) NOT NULL,
    [IdCondimento] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ClasificacionRecetaConjunto'
CREATE TABLE [dbo].[ClasificacionRecetaConjunto] (
    [IdClasificacion] int IDENTITY(1,1) NOT NULL,
    [IdReceta] nvarchar(max)  NOT NULL,
    [Calificacion_Id] int  NOT NULL
);
GO

-- Creating table 'DietasExcluidasConjunto'
CREATE TABLE [dbo].[DietasExcluidasConjunto] (
    [Id_Dieta] int IDENTITY(1,1) NOT NULL,
    [Id_preferencia] smallint  NOT NULL,
    [Preferencia_Id] int  NOT NULL
);
GO

-- Creating table 'DietasExcluidasDieta'
CREATE TABLE [dbo].[DietasExcluidasDieta] (
    [DietasExcluidas_Id_Dieta] int  NOT NULL,
    [Dieta_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CalificacionConjunto'
ALTER TABLE [dbo].[CalificacionConjunto]
ADD CONSTRAINT [PK_CalificacionConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClasificacionConjunto'
ALTER TABLE [dbo].[ClasificacionConjunto]
ADD CONSTRAINT [PK_ClasificacionConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComplexionConjunto'
ALTER TABLE [dbo].[ComplexionConjunto]
ADD CONSTRAINT [PK_ComplexionConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CondicionPreexistenteConjunto'
ALTER TABLE [dbo].[CondicionPreexistenteConjunto]
ADD CONSTRAINT [PK_CondicionPreexistenteConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CondimentoConjunto'
ALTER TABLE [dbo].[CondimentoConjunto]
ADD CONSTRAINT [PK_CondimentoConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DietaConjunto'
ALTER TABLE [dbo].[DietaConjunto]
ADD CONSTRAINT [PK_DietaConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GrupoConjunto'
ALTER TABLE [dbo].[GrupoConjunto]
ADD CONSTRAINT [PK_GrupoConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IngredienteConjunto'
ALTER TABLE [dbo].[IngredienteConjunto]
ADD CONSTRAINT [PK_IngredienteConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'IngredienteRecetaConjunto'
ALTER TABLE [dbo].[IngredienteRecetaConjunto]
ADD CONSTRAINT [PK_IngredienteRecetaConjunto]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'PiramideAlimenticiaConjunto'
ALTER TABLE [dbo].[PiramideAlimenticiaConjunto]
ADD CONSTRAINT [PK_PiramideAlimenticiaConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PreferenciaConjunto'
ALTER TABLE [dbo].[PreferenciaConjunto]
ADD CONSTRAINT [PK_PreferenciaConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProcedimientoConjunto'
ALTER TABLE [dbo].[ProcedimientoConjunto]
ADD CONSTRAINT [PK_ProcedimientoConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RecetaConjunto'
ALTER TABLE [dbo].[RecetaConjunto]
ADD CONSTRAINT [PK_RecetaConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TemporadaConjunto'
ALTER TABLE [dbo].[TemporadaConjunto]
ADD CONSTRAINT [PK_TemporadaConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioConjunto'
ALTER TABLE [dbo].[UsuarioConjunto]
ADD CONSTRAINT [PK_UsuarioConjunto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [IdUsuario] in table 'UsuarioPreferenciaConjunto'
ALTER TABLE [dbo].[UsuarioPreferenciaConjunto]
ADD CONSTRAINT [PK_UsuarioPreferenciaConjunto]
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC);
GO

-- Creating primary key on [IdUsuario] in table 'UsuarioRecetaConjunto'
ALTER TABLE [dbo].[UsuarioRecetaConjunto]
ADD CONSTRAINT [PK_UsuarioRecetaConjunto]
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC);
GO

-- Creating primary key on [IdUsuario] in table 'UsuarioGrupoConjunto'
ALTER TABLE [dbo].[UsuarioGrupoConjunto]
ADD CONSTRAINT [PK_UsuarioGrupoConjunto]
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC);
GO

-- Creating primary key on [IdGrupo] in table 'GrupoPreferenciasConjunto'
ALTER TABLE [dbo].[GrupoPreferenciasConjunto]
ADD CONSTRAINT [PK_GrupoPreferenciasConjunto]
    PRIMARY KEY CLUSTERED ([IdGrupo] ASC);
GO

-- Creating primary key on [IdReceta] in table 'CondimentoRecetaConjunto'
ALTER TABLE [dbo].[CondimentoRecetaConjunto]
ADD CONSTRAINT [PK_CondimentoRecetaConjunto]
    PRIMARY KEY CLUSTERED ([IdReceta] ASC);
GO

-- Creating primary key on [IdClasificacion] in table 'ClasificacionRecetaConjunto'
ALTER TABLE [dbo].[ClasificacionRecetaConjunto]
ADD CONSTRAINT [PK_ClasificacionRecetaConjunto]
    PRIMARY KEY CLUSTERED ([IdClasificacion] ASC);
GO

-- Creating primary key on [Id_Dieta] in table 'DietasExcluidasConjunto'
ALTER TABLE [dbo].[DietasExcluidasConjunto]
ADD CONSTRAINT [PK_DietasExcluidasConjunto]
    PRIMARY KEY CLUSTERED ([Id_Dieta] ASC);
GO

-- Creating primary key on [DietasExcluidas_Id_Dieta], [Dieta_Id] in table 'DietasExcluidasDieta'
ALTER TABLE [dbo].[DietasExcluidasDieta]
ADD CONSTRAINT [PK_DietasExcluidasDieta]
    PRIMARY KEY NONCLUSTERED ([DietasExcluidas_Id_Dieta], [Dieta_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UsuarioRecetaIdUsuario] in table 'UsuarioConjunto'
ALTER TABLE [dbo].[UsuarioConjunto]
ADD CONSTRAINT [FK_UsuarioRecetaUsuario]
    FOREIGN KEY ([UsuarioRecetaIdUsuario])
    REFERENCES [dbo].[UsuarioRecetaConjunto]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioRecetaUsuario'
CREATE INDEX [IX_FK_UsuarioRecetaUsuario]
ON [dbo].[UsuarioConjunto]
    ([UsuarioRecetaIdUsuario]);
GO

-- Creating foreign key on [UsuarioRecetaIdUsuario] in table 'RecetaConjunto'
ALTER TABLE [dbo].[RecetaConjunto]
ADD CONSTRAINT [FK_UsuarioRecetaReceta]
    FOREIGN KEY ([UsuarioRecetaIdUsuario])
    REFERENCES [dbo].[UsuarioRecetaConjunto]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioRecetaReceta'
CREATE INDEX [IX_FK_UsuarioRecetaReceta]
ON [dbo].[RecetaConjunto]
    ([UsuarioRecetaIdUsuario]);
GO

-- Creating foreign key on [UsuarioGrupo_IdUsuario] in table 'UsuarioConjunto'
ALTER TABLE [dbo].[UsuarioConjunto]
ADD CONSTRAINT [FK_UsuarioUsuarioGrupo]
    FOREIGN KEY ([UsuarioGrupo_IdUsuario])
    REFERENCES [dbo].[UsuarioGrupoConjunto]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioUsuarioGrupo'
CREATE INDEX [IX_FK_UsuarioUsuarioGrupo]
ON [dbo].[UsuarioConjunto]
    ([UsuarioGrupo_IdUsuario]);
GO

-- Creating foreign key on [UsuarioGrupo_IdUsuario] in table 'GrupoConjunto'
ALTER TABLE [dbo].[GrupoConjunto]
ADD CONSTRAINT [FK_GrupoUsuarioGrupo]
    FOREIGN KEY ([UsuarioGrupo_IdUsuario])
    REFERENCES [dbo].[UsuarioGrupoConjunto]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GrupoUsuarioGrupo'
CREATE INDEX [IX_FK_GrupoUsuarioGrupo]
ON [dbo].[GrupoConjunto]
    ([UsuarioGrupo_IdUsuario]);
GO

-- Creating foreign key on [UsuarioPreferencia_IdUsuario] in table 'UsuarioConjunto'
ALTER TABLE [dbo].[UsuarioConjunto]
ADD CONSTRAINT [FK_UsuarioUsuarioPreferencia]
    FOREIGN KEY ([UsuarioPreferencia_IdUsuario])
    REFERENCES [dbo].[UsuarioPreferenciaConjunto]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioUsuarioPreferencia'
CREATE INDEX [IX_FK_UsuarioUsuarioPreferencia]
ON [dbo].[UsuarioConjunto]
    ([UsuarioPreferencia_IdUsuario]);
GO

-- Creating foreign key on [UsuarioPreferenciaIdUsuario] in table 'PreferenciaConjunto'
ALTER TABLE [dbo].[PreferenciaConjunto]
ADD CONSTRAINT [FK_UsuarioPreferenciaPreferencia]
    FOREIGN KEY ([UsuarioPreferenciaIdUsuario])
    REFERENCES [dbo].[UsuarioPreferenciaConjunto]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioPreferenciaPreferencia'
CREATE INDEX [IX_FK_UsuarioPreferenciaPreferencia]
ON [dbo].[PreferenciaConjunto]
    ([UsuarioPreferenciaIdUsuario]);
GO

-- Creating foreign key on [Calificacion_Id] in table 'ClasificacionRecetaConjunto'
ALTER TABLE [dbo].[ClasificacionRecetaConjunto]
ADD CONSTRAINT [FK_ClasificacionRecetaCalificacion]
    FOREIGN KEY ([Calificacion_Id])
    REFERENCES [dbo].[CalificacionConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClasificacionRecetaCalificacion'
CREATE INDEX [IX_FK_ClasificacionRecetaCalificacion]
ON [dbo].[ClasificacionRecetaConjunto]
    ([Calificacion_Id]);
GO

-- Creating foreign key on [ClasificacionReceta_IdClasificacion] in table 'RecetaConjunto'
ALTER TABLE [dbo].[RecetaConjunto]
ADD CONSTRAINT [FK_RecetaClasificacionReceta]
    FOREIGN KEY ([ClasificacionReceta_IdClasificacion])
    REFERENCES [dbo].[ClasificacionRecetaConjunto]
        ([IdClasificacion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RecetaClasificacionReceta'
CREATE INDEX [IX_FK_RecetaClasificacionReceta]
ON [dbo].[RecetaConjunto]
    ([ClasificacionReceta_IdClasificacion]);
GO

-- Creating foreign key on [CondimentoRecetaIdReceta] in table 'RecetaConjunto'
ALTER TABLE [dbo].[RecetaConjunto]
ADD CONSTRAINT [FK_CondimentoRecetaReceta]
    FOREIGN KEY ([CondimentoRecetaIdReceta])
    REFERENCES [dbo].[CondimentoRecetaConjunto]
        ([IdReceta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CondimentoRecetaReceta'
CREATE INDEX [IX_FK_CondimentoRecetaReceta]
ON [dbo].[RecetaConjunto]
    ([CondimentoRecetaIdReceta]);
GO

-- Creating foreign key on [CondimentoReceta_IdReceta] in table 'CondimentoConjunto'
ALTER TABLE [dbo].[CondimentoConjunto]
ADD CONSTRAINT [FK_CondimentoCondimentoReceta]
    FOREIGN KEY ([CondimentoReceta_IdReceta])
    REFERENCES [dbo].[CondimentoRecetaConjunto]
        ([IdReceta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CondimentoCondimentoReceta'
CREATE INDEX [IX_FK_CondimentoCondimentoReceta]
ON [dbo].[CondimentoConjunto]
    ([CondimentoReceta_IdReceta]);
GO

-- Creating foreign key on [IngredienteReceta_id] in table 'IngredienteConjunto'
ALTER TABLE [dbo].[IngredienteConjunto]
ADD CONSTRAINT [FK_IngredienteRecetaIngrediente]
    FOREIGN KEY ([IngredienteReceta_id])
    REFERENCES [dbo].[IngredienteRecetaConjunto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_IngredienteRecetaIngrediente'
CREATE INDEX [IX_FK_IngredienteRecetaIngrediente]
ON [dbo].[IngredienteConjunto]
    ([IngredienteReceta_id]);
GO

-- Creating foreign key on [IngredienteReceta_id] in table 'RecetaConjunto'
ALTER TABLE [dbo].[RecetaConjunto]
ADD CONSTRAINT [FK_IngredienteRecetaReceta]
    FOREIGN KEY ([IngredienteReceta_id])
    REFERENCES [dbo].[IngredienteRecetaConjunto]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_IngredienteRecetaReceta'
CREATE INDEX [IX_FK_IngredienteRecetaReceta]
ON [dbo].[RecetaConjunto]
    ([IngredienteReceta_id]);
GO

-- Creating foreign key on [GrupoPreferenciasIdGrupo] in table 'GrupoConjunto'
ALTER TABLE [dbo].[GrupoConjunto]
ADD CONSTRAINT [FK_GrupoPreferenciasGrupo]
    FOREIGN KEY ([GrupoPreferenciasIdGrupo])
    REFERENCES [dbo].[GrupoPreferenciasConjunto]
        ([IdGrupo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GrupoPreferenciasGrupo'
CREATE INDEX [IX_FK_GrupoPreferenciasGrupo]
ON [dbo].[GrupoConjunto]
    ([GrupoPreferenciasIdGrupo]);
GO

-- Creating foreign key on [GrupoPreferencias_IdGrupo] in table 'PreferenciaConjunto'
ALTER TABLE [dbo].[PreferenciaConjunto]
ADD CONSTRAINT [FK_PreferenciaGrupoPreferencias]
    FOREIGN KEY ([GrupoPreferencias_IdGrupo])
    REFERENCES [dbo].[GrupoPreferenciasConjunto]
        ([IdGrupo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PreferenciaGrupoPreferencias'
CREATE INDEX [IX_FK_PreferenciaGrupoPreferencias]
ON [dbo].[PreferenciaConjunto]
    ([GrupoPreferencias_IdGrupo]);
GO

-- Creating foreign key on [UsuarioId] in table 'CondicionPreexistenteConjunto'
ALTER TABLE [dbo].[CondicionPreexistenteConjunto]
ADD CONSTRAINT [FK_UsuarioCondicionPreexistente]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[UsuarioConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioCondicionPreexistente'
CREATE INDEX [IX_FK_UsuarioCondicionPreexistente]
ON [dbo].[CondicionPreexistenteConjunto]
    ([UsuarioId]);
GO

-- Creating foreign key on [Usuario_Id] in table 'ComplexionConjunto'
ALTER TABLE [dbo].[ComplexionConjunto]
ADD CONSTRAINT [FK_ComplexionUsuario]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[UsuarioConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ComplexionUsuario'
CREATE INDEX [IX_FK_ComplexionUsuario]
ON [dbo].[ComplexionConjunto]
    ([Usuario_Id]);
GO

-- Creating foreign key on [Receta_Id] in table 'ProcedimientoConjunto'
ALTER TABLE [dbo].[ProcedimientoConjunto]
ADD CONSTRAINT [FK_ProcedimientoReceta]
    FOREIGN KEY ([Receta_Id])
    REFERENCES [dbo].[RecetaConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProcedimientoReceta'
CREATE INDEX [IX_FK_ProcedimientoReceta]
ON [dbo].[ProcedimientoConjunto]
    ([Receta_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'DietaConjunto'
ALTER TABLE [dbo].[DietaConjunto]
ADD CONSTRAINT [FK_DietaUsuario]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[UsuarioConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DietaUsuario'
CREATE INDEX [IX_FK_DietaUsuario]
ON [dbo].[DietaConjunto]
    ([Usuario_Id]);
GO

-- Creating foreign key on [PiramideAlimenticia_Id] in table 'GrupoConjunto'
ALTER TABLE [dbo].[GrupoConjunto]
ADD CONSTRAINT [FK_GrupoPiramideAlimenticia]
    FOREIGN KEY ([PiramideAlimenticia_Id])
    REFERENCES [dbo].[PiramideAlimenticiaConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GrupoPiramideAlimenticia'
CREATE INDEX [IX_FK_GrupoPiramideAlimenticia]
ON [dbo].[GrupoConjunto]
    ([PiramideAlimenticia_Id]);
GO

-- Creating foreign key on [RecetaId] in table 'TemporadaConjunto'
ALTER TABLE [dbo].[TemporadaConjunto]
ADD CONSTRAINT [FK_RecetaTemporada]
    FOREIGN KEY ([RecetaId])
    REFERENCES [dbo].[RecetaConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RecetaTemporada'
CREATE INDEX [IX_FK_RecetaTemporada]
ON [dbo].[TemporadaConjunto]
    ([RecetaId]);
GO

-- Creating foreign key on [Receta_Id] in table 'ClasificacionConjunto'
ALTER TABLE [dbo].[ClasificacionConjunto]
ADD CONSTRAINT [FK_ClasificacionReceta1]
    FOREIGN KEY ([Receta_Id])
    REFERENCES [dbo].[RecetaConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClasificacionReceta1'
CREATE INDEX [IX_FK_ClasificacionReceta1]
ON [dbo].[ClasificacionConjunto]
    ([Receta_Id]);
GO

-- Creating foreign key on [DietasExcluidas_Id_Dieta] in table 'DietasExcluidasDieta'
ALTER TABLE [dbo].[DietasExcluidasDieta]
ADD CONSTRAINT [FK_DietasExcluidasDieta_DietasExcluidas]
    FOREIGN KEY ([DietasExcluidas_Id_Dieta])
    REFERENCES [dbo].[DietasExcluidasConjunto]
        ([Id_Dieta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Dieta_Id] in table 'DietasExcluidasDieta'
ALTER TABLE [dbo].[DietasExcluidasDieta]
ADD CONSTRAINT [FK_DietasExcluidasDieta_Dieta]
    FOREIGN KEY ([Dieta_Id])
    REFERENCES [dbo].[DietaConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DietasExcluidasDieta_Dieta'
CREATE INDEX [IX_FK_DietasExcluidasDieta_Dieta]
ON [dbo].[DietasExcluidasDieta]
    ([Dieta_Id]);
GO

-- Creating foreign key on [Preferencia_Id] in table 'DietasExcluidasConjunto'
ALTER TABLE [dbo].[DietasExcluidasConjunto]
ADD CONSTRAINT [FK_DietasExcluidasPreferencia]
    FOREIGN KEY ([Preferencia_Id])
    REFERENCES [dbo].[PreferenciaConjunto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DietasExcluidasPreferencia'
CREATE INDEX [IX_FK_DietasExcluidasPreferencia]
ON [dbo].[DietasExcluidasConjunto]
    ([Preferencia_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------