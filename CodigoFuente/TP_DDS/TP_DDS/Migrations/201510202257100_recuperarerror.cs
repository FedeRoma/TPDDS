namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recuperarerror : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Usuarios", "Grupo_Id", "dbo.Grupos");
            //DropForeignKey("dbo.Grupos", "Usuario_Id1", "dbo.Usuarios");
            //DropForeignKey("dbo.Grupos", "Creador_Id", "dbo.Usuarios");
            //DropForeignKey("dbo.Grupos", "Usuario_Id", "dbo.Usuarios");
            //DropIndex("dbo.Usuarios", new[] { "Grupo_Id" });
            //DropIndex("dbo.Grupos", new[] { "Usuario_Id1" });
            //DropIndex("dbo.Grupos", new[] { "Creador_Id" });
            //DropIndex("dbo.Grupos", new[] { "Usuario_Id" });
            //DropColumn("dbo.Grupos", "UsuarioId");
            //RenameColumn(table: "dbo.Grupos", name: "Creador_Id", newName: "UsuarioId");
            //AlterColumn("dbo.Grupos", "UsuarioId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Grupos", "UsuarioId");
            //CreateIndex("dbo.Grupos", "UsuarioId");
            //AddForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
            //DropColumn("dbo.Usuarios", "Grupo_Id");
            //DropColumn("dbo.Grupos", "Usuario_Id");
            //DropColumn("dbo.Grupos", "Usuario_Id1");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Grupos", "Usuario_Id1", c => c.Int());
            //AddColumn("dbo.Grupos", "Usuario_Id", c => c.Int());
            //AddColumn("dbo.Usuarios", "Grupo_Id", c => c.Int());
            //DropForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios");
            //DropForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios");
            //DropIndex("dbo.Grupos", new[] { "UsuarioId" });
            //DropIndex("dbo.Grupos", new[] { "UsuarioId" });
            //AlterColumn("dbo.Grupos", "UsuarioId", c => c.Int());
            //RenameColumn(table: "dbo.Grupos", name: "UsuarioId", newName: "Creador_Id");
            //AddColumn("dbo.Grupos", "UsuarioId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Grupos", "Usuario_Id");
            //CreateIndex("dbo.Grupos", "Creador_Id");
            //CreateIndex("dbo.Grupos", "Usuario_Id1");
            //CreateIndex("dbo.Usuarios", "Grupo_Id");
            //AddForeignKey("dbo.Grupos", "Usuario_Id", "dbo.Usuarios", "Id");
            //AddForeignKey("dbo.Grupos", "Creador_Id", "dbo.Usuarios", "Id");
            //AddForeignKey("dbo.Grupos", "Usuario_Id1", "dbo.Usuarios", "Id");
            //AddForeignKey("dbo.Usuarios", "Grupo_Id", "dbo.Grupos", "Id");
        }
    }
}
