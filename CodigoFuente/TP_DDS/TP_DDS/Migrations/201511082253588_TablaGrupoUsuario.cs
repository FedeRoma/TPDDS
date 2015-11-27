namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaGrupoUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GruposUsuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrupoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grupos", t => t.GrupoId, cascadeDelete: false)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: false)
                .Index(t => t.GrupoId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GruposUsuarios", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.GruposUsuarios", "GrupoId", "dbo.Grupos");
            DropIndex("dbo.GruposUsuarios", new[] { "UsuarioId" });
            DropIndex("dbo.GruposUsuarios", new[] { "GrupoId" });
            DropTable("dbo.GruposUsuarios");
        }
    }
}
