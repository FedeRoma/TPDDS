namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gruposrecetas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GruposRecetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrupoId = c.Int(nullable: false),
                        RecetaId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grupos", t => t.GrupoId, cascadeDelete: false)
                .ForeignKey("dbo.Recetas", t => t.RecetaId, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: false)
                .Index(t => t.GrupoId)
                .Index(t => t.RecetaId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GruposRecetas", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.GruposRecetas", "RecetaId", "dbo.Recetas");
            DropForeignKey("dbo.GruposRecetas", "GrupoId", "dbo.Grupos");
            DropIndex("dbo.GruposRecetas", new[] { "UsuarioId" });
            DropIndex("dbo.GruposRecetas", new[] { "RecetaId" });
            DropIndex("dbo.GruposRecetas", new[] { "GrupoId" });
            DropTable("dbo.GruposRecetas");
        }
    }
}
