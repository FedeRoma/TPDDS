namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comidas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comidas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        ClasificacionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clasificaciones", t => t.ClasificacionId, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: false)
                .Index(t => t.ClasificacionId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.ComidasRecetas",
                c => new
                    {
                        Comida_Id = c.Int(nullable: false),
                        Receta_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Comida_Id, t.Receta_Id })
                .ForeignKey("dbo.Comidas", t => t.Comida_Id, cascadeDelete: false)
                .ForeignKey("dbo.Recetas", t => t.Receta_Id, cascadeDelete: false)
                .Index(t => t.Comida_Id)
                .Index(t => t.Receta_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comidas", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.ComidasRecetas", "Receta_Id", "dbo.Recetas");
            DropForeignKey("dbo.ComidasRecetas", "Comida_Id", "dbo.Comidas");
            DropForeignKey("dbo.Comidas", "ClasificacionId", "dbo.Clasificaciones");
            DropIndex("dbo.Comidas", new[] { "UsuarioId" });
            DropIndex("dbo.ComidasRecetas", new[] { "Receta_Id" });
            DropIndex("dbo.ComidasRecetas", new[] { "Comida_Id" });
            DropIndex("dbo.Comidas", new[] { "ClasificacionId" });
            DropTable("dbo.ComidasRecetas");
            DropTable("dbo.Comidas");
        }
    }
}
