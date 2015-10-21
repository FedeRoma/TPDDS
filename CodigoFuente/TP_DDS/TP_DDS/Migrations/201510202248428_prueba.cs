namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.Grupos", newName: "GrupoUsuarios");
            //RenameTable(name: "dbo.Usuarios", newName: "GrupoUsuarios");
            //DropForeignKey("dbo.Usuarios", "Grupo_Id", "dbo.Grupos");
            //DropForeignKey("dbo.Grupos", "Usuario_Id", "dbo.Usuarios");
            //DropForeignKey("dbo.Grupos", "Usuario_Id1", "dbo.Usuarios");
            //DropIndex("dbo.Usuarios", new[] { "Grupo_Id" });
            //DropIndex("dbo.Grupos", new[] { "Usuario_Id" });
            //DropIndex("dbo.Grupos", new[] { "Usuario_Id1" });
            //CreateIndex("dbo.GrupoUsuarios", "Grupo_Id");
            //CreateIndex("dbo.GrupoUsuarios", "Usuario_Id");
            //AddForeignKey("dbo.GrupoUsuarios", "Grupo_Id", "dbo.Grupos", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.GrupoUsuarios", "Usuario_Id", "dbo.Usuarios", "Id", cascadeDelete: true);
            //DropColumn("dbo.Usuarios", "Grupo_Id");
            //DropColumn("dbo.Grupos", "Usuario_Id");
            //DropColumn("dbo.Grupos", "Usuario_Id1");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Grupos", "Usuario_Id1", c => c.Int());
            //AddColumn("dbo.Grupos", "Usuario_Id", c => c.Int());
            //AddColumn("dbo.Usuarios", "Grupo_Id", c => c.Int());
            //DropForeignKey("dbo.GrupoUsuarios", "Usuario_Id", "dbo.Usuarios");
            //DropForeignKey("dbo.GrupoUsuarios", "Grupo_Id", "dbo.Grupos");
            //DropIndex("dbo.GrupoUsuarios", new[] { "Usuario_Id" });
            //DropIndex("dbo.GrupoUsuarios", new[] { "Grupo_Id" });
            //CreateIndex("dbo.Grupos", "Usuario_Id1");
            //CreateIndex("dbo.Grupos", "Usuario_Id");
            //CreateIndex("dbo.Usuarios", "Grupo_Id");
            //AddForeignKey("dbo.Grupos", "Usuario_Id1", "dbo.Usuarios", "Id");
            //AddForeignKey("dbo.Grupos", "Usuario_Id", "dbo.Usuarios", "Id");
            //AddForeignKey("dbo.Usuarios", "Grupo_Id", "dbo.Grupos", "Id");
            //RenameTable(name: "dbo.GrupoUsuarios", newName: "Usuarios");
            //RenameTable(name: "dbo.GrupoUsuarios", newName: "Grupos");
        }
    }
}
