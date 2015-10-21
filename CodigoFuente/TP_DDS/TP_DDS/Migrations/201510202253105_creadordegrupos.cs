namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creadordegrupos : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Grupos", "Usuario_Id", "dbo.Usuarios");
            //DropIndex("dbo.Grupos", new[] { "Usuario_Id" });
            //DropColumn("dbo.Grupos", "Usuario_Id");
            //AddColumn("dbo.Grupos", "UsuarioId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Grupos", "UsuarioId");
            //AddForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios");
            //DropIndex("dbo.Grupos", new[] { "UsuarioId" });
            //DropColumn("dbo.Grupos", "UsuarioId");
            //AddColumn("dbo.Grupos", "Usuario_Id", c => c.Int());
            //CreateIndex("dbo.Grupos", "Usuario_Id");
            //AddForeignKey("dbo.Grupos", "Usuario_Id", "dbo.Usuarios", "Id");
        }
    }
}
