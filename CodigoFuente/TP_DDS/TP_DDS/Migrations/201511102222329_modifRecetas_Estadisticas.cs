namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifRecetas_Estadisticas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estadisticas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecetaId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        FechaHora = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recetas", t => t.RecetaId, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: false)
                .Index(t => t.RecetaId)
                .Index(t => t.UsuarioId);
            
            AddColumn("dbo.Recetas", "FechaCreacion", c => c.DateTime(nullable: true));
            AddColumn("dbo.Recetas", "FechaUltModif", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estadisticas", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Estadisticas", "RecetaId", "dbo.Recetas");
            DropIndex("dbo.Estadisticas", new[] { "UsuarioId" });
            DropIndex("dbo.Estadisticas", new[] { "RecetaId" });
            DropColumn("dbo.Recetas", "FechaUltModif");
            DropColumn("dbo.Recetas", "FechaCreacion");
            DropTable("dbo.Estadisticas");
        }
    }
}
