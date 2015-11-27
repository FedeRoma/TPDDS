namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuariosgrupos : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Usuarios", "Grupo_Id", c => c.Int());
            //AddColumn("dbo.Grupos", "Usuario_Id1", c => c.Int());
            //CreateIndex("dbo.Usuarios", "Grupo_Id");
            //CreateIndex("dbo.Grupos", "Usuario_Id1");
            //AddForeignKey("dbo.Usuarios", "Grupo_Id", "dbo.Grupos", "Id");
            //AddForeignKey("dbo.Grupos", "Usuario_Id1", "dbo.Usuarios", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Grupos", "Usuario_Id1", "dbo.Usuarios");
            //DropForeignKey("dbo.Usuarios", "Grupo_Id", "dbo.Grupos");
            //DropIndex("dbo.Grupos", new[] { "Usuario_Id1" });
            //DropIndex("dbo.Usuarios", new[] { "Grupo_Id" });
            //DropColumn("dbo.Grupos", "Usuario_Id1");
            //DropColumn("dbo.Usuarios", "Grupo_Id");
        }
    }
}
