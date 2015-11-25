namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calificaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecetaId = c.Int(nullable: false),
                        Valor = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recetas", t => t.RecetaId, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: false)
                .Index(t => t.RecetaId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Recetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Dificultad = c.Int(nullable: false),
                        TotalCalorias = c.Single(nullable: false),
                        PiramideId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: false)
                .ForeignKey("dbo.PiramideAlimenticia", t => t.PiramideId, cascadeDelete: false)
                .Index(t => t.UsuarioId)
                .Index(t => t.PiramideId);
            
            CreateTable(
                "dbo.Clasificaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Condimentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Pass = c.String(),
                        Email = c.String(),
                        Nombre = c.String(),
                        Sexo = c.Int(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        FechaAltaPerfil = c.DateTime(nullable: false),
                        Altura = c.Decimal(precision: 18, scale: 2),
                        Rutina = c.Int(),
                        CondicionPreexistenteId = c.Int(),
                        ComplexionId = c.Int(nullable: false),
                        DietaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Complexiones", t => t.ComplexionId, cascadeDelete: false)
                .ForeignKey("dbo.CondicionesPreexistentes", t => t.CondicionPreexistenteId)
                .ForeignKey("dbo.Dietas", t => t.DietaId, cascadeDelete: false)
                .Index(t => t.ComplexionId)
                .Index(t => t.CondicionPreexistenteId)
                .Index(t => t.DietaId);
            
            CreateTable(
                "dbo.Complexiones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CondicionesPreexistentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dietas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Preferencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grupos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.IngredientesRecetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Tipo = c.Int(),
                        IngredienteId = c.Int(nullable: false),
                        RecetaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredientes", t => t.IngredienteId, cascadeDelete: false)
                .ForeignKey("dbo.Recetas", t => t.RecetaId, cascadeDelete: false)
                .Index(t => t.IngredienteId)
                .Index(t => t.RecetaId);
            
            CreateTable(
                "dbo.Ingredientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Porcion = c.Int(nullable: false),
                        CaloriasPorcion = c.Single(nullable: false),
                        PreferenciaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Preferencias", t => t.PreferenciaId, cascadeDelete: false)
                .Index(t => t.PreferenciaId);
            
            CreateTable(
                "dbo.PiramideAlimenticia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreGrupo = c.String(),
                        DescripcionGrupo = c.String(),
                        Contraindicaciones = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Procedimientos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Nombre = c.String(),
                        Imagen = c.String(),
                        RecetaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recetas", t => t.RecetaId, cascadeDelete: false)
                .Index(t => t.RecetaId);
            
            CreateTable(
                "dbo.Temporadas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClasificacionesRecetas",
                c => new
                    {
                        Clasificacion_Id = c.Int(nullable: false),
                        Receta_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Clasificacion_Id, t.Receta_Id })
                .ForeignKey("dbo.Clasificaciones", t => t.Clasificacion_Id, cascadeDelete: false)
                .ForeignKey("dbo.Recetas", t => t.Receta_Id, cascadeDelete: false)
                .Index(t => t.Clasificacion_Id)
                .Index(t => t.Receta_Id);
            
            CreateTable(
                "dbo.CondimentosRecetas",
                c => new
                    {
                        Condimento_Id = c.Int(nullable: false),
                        Receta_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Condimento_Id, t.Receta_Id })
                .ForeignKey("dbo.Condimentos", t => t.Condimento_Id, cascadeDelete: false)
                .ForeignKey("dbo.Recetas", t => t.Receta_Id, cascadeDelete: false)
                .Index(t => t.Condimento_Id)
                .Index(t => t.Receta_Id);
            
            CreateTable(
                "dbo.DietasPreferencias",
                c => new
                    {
                        Preferencia_Id = c.Int(nullable: false),
                        Dieta_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Preferencia_Id, t.Dieta_Id })
                .ForeignKey("dbo.Preferencias", t => t.Preferencia_Id, cascadeDelete: false)
                .ForeignKey("dbo.Dietas", t => t.Dieta_Id, cascadeDelete: false)
                .Index(t => t.Preferencia_Id)
                .Index(t => t.Dieta_Id);
            
            CreateTable(
                "dbo.GruposPreferencias",
                c => new
                    {
                        Grupo_Id = c.Int(nullable: false),
                        Preferencia_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Grupo_Id, t.Preferencia_Id })
                .ForeignKey("dbo.Grupos", t => t.Grupo_Id, cascadeDelete: false)
                .ForeignKey("dbo.Preferencias", t => t.Preferencia_Id, cascadeDelete: false)
                .Index(t => t.Grupo_Id)
                .Index(t => t.Preferencia_Id);
            
            CreateTable(
                "dbo.UsuariosPreferencias",
                c => new
                    {
                        Preferencia_Id = c.Int(nullable: false),
                        Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Preferencia_Id, t.Usuario_Id })
                .ForeignKey("dbo.Preferencias", t => t.Preferencia_Id, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id, cascadeDelete: false)
                .Index(t => t.Preferencia_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.TemporadasRecetas",
                c => new
                    {
                        Temporada_Id = c.Int(nullable: false),
                        Receta_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Temporada_Id, t.Receta_Id })
                .ForeignKey("dbo.Temporadas", t => t.Temporada_Id, cascadeDelete: false)
                .ForeignKey("dbo.Recetas", t => t.Receta_Id, cascadeDelete: false)
                .Index(t => t.Temporada_Id)
                .Index(t => t.Receta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calificaciones", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.TemporadasRecetas", "Receta_Id", "dbo.Recetas");
            DropForeignKey("dbo.TemporadasRecetas", "Temporada_Id", "dbo.Temporadas");
            DropForeignKey("dbo.Procedimientos", "RecetaId", "dbo.Recetas");
            DropForeignKey("dbo.Recetas", "PiramideId", "dbo.PiramideAlimenticia");
            DropForeignKey("dbo.IngredientesRecetas", "RecetaId", "dbo.Recetas");
            DropForeignKey("dbo.IngredientesRecetas", "IngredienteId", "dbo.Ingredientes");
            DropForeignKey("dbo.Ingredientes", "PreferenciaId", "dbo.Preferencias");
            DropForeignKey("dbo.Recetas", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Grupos", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "DietaId", "dbo.Dietas");
            DropForeignKey("dbo.UsuariosPreferencias", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.UsuariosPreferencias", "Preferencia_Id", "dbo.Preferencias");
            DropForeignKey("dbo.GruposPreferencias", "Preferencia_Id", "dbo.Preferencias");
            DropForeignKey("dbo.GruposPreferencias", "Grupo_Id", "dbo.Grupos");
            DropForeignKey("dbo.DietasPreferencias", "Dieta_Id", "dbo.Dietas");
            DropForeignKey("dbo.DietasPreferencias", "Preferencia_Id", "dbo.Preferencias");
            DropForeignKey("dbo.Usuarios", "CondicionPreexistenteId", "dbo.CondicionesPreexistentes");
            DropForeignKey("dbo.Usuarios", "ComplexionId", "dbo.Complexiones");
            DropForeignKey("dbo.CondimentosRecetas", "Receta_Id", "dbo.Recetas");
            DropForeignKey("dbo.CondimentosRecetas", "Condimento_Id", "dbo.Condimentos");
            DropForeignKey("dbo.ClasificacionesRecetas", "Receta_Id", "dbo.Recetas");
            DropForeignKey("dbo.ClasificacionesRecetas", "Clasificacion_Id", "dbo.Clasificaciones");
            DropForeignKey("dbo.Calificaciones", "RecetaId", "dbo.Recetas");
            DropIndex("dbo.Calificaciones", new[] { "UsuarioId" });
            DropIndex("dbo.TemporadasRecetas", new[] { "Receta_Id" });
            DropIndex("dbo.TemporadasRecetas", new[] { "Temporada_Id" });
            DropIndex("dbo.Procedimientos", new[] { "RecetaId" });
            DropIndex("dbo.Recetas", new[] { "PiramideId" });
            DropIndex("dbo.IngredientesRecetas", new[] { "RecetaId" });
            DropIndex("dbo.IngredientesRecetas", new[] { "IngredienteId" });
            DropIndex("dbo.Ingredientes", new[] { "PreferenciaId" });
            DropIndex("dbo.Recetas", new[] { "UsuarioId" });
            DropIndex("dbo.Grupos", new[] { "Usuario_Id" });
            DropIndex("dbo.Usuarios", new[] { "DietaId" });
            DropIndex("dbo.UsuariosPreferencias", new[] { "Usuario_Id" });
            DropIndex("dbo.UsuariosPreferencias", new[] { "Preferencia_Id" });
            DropIndex("dbo.GruposPreferencias", new[] { "Preferencia_Id" });
            DropIndex("dbo.GruposPreferencias", new[] { "Grupo_Id" });
            DropIndex("dbo.DietasPreferencias", new[] { "Dieta_Id" });
            DropIndex("dbo.DietasPreferencias", new[] { "Preferencia_Id" });
            DropIndex("dbo.Usuarios", new[] { "CondicionPreexistenteId" });
            DropIndex("dbo.Usuarios", new[] { "ComplexionId" });
            DropIndex("dbo.CondimentosRecetas", new[] { "Receta_Id" });
            DropIndex("dbo.CondimentosRecetas", new[] { "Condimento_Id" });
            DropIndex("dbo.ClasificacionesRecetas", new[] { "Receta_Id" });
            DropIndex("dbo.ClasificacionesRecetas", new[] { "Clasificacion_Id" });
            DropIndex("dbo.Calificaciones", new[] { "RecetaId" });
            DropTable("dbo.TemporadasRecetas");
            DropTable("dbo.UsuariosPreferencias");
            DropTable("dbo.GruposPreferencias");
            DropTable("dbo.DietasPreferencias");
            DropTable("dbo.CondimentosRecetas");
            DropTable("dbo.ClasificacionesRecetas");
            DropTable("dbo.Temporadas");
            DropTable("dbo.Procedimientos");
            DropTable("dbo.PiramideAlimenticia");
            DropTable("dbo.Ingredientes");
            DropTable("dbo.IngredientesRecetas");
            DropTable("dbo.Grupos");
            DropTable("dbo.Preferencias");
            DropTable("dbo.Dietas");
            DropTable("dbo.CondicionesPreexistentes");
            DropTable("dbo.Complexiones");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Condimentos");
            DropTable("dbo.Clasificaciones");
            DropTable("dbo.Recetas");
            DropTable("dbo.Calificaciones");
        }
    }
}
