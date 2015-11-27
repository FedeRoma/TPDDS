namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unidos : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios");
            //DropForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios");
            //DropIndex("dbo.Grupos", new[] { "UsuarioId" });
            //DropIndex("dbo.Grupos", new[] { "UsuarioId" });
            //AddColumn("dbo.Usuarios", "Grupo_Id", c => c.Int());
            //AddColumn("dbo.Grupos", "Creador_Id", c => c.Int());
            //AddColumn("dbo.Grupos", "Usuario_Id", c => c.Int());
            //AddColumn("dbo.Grupos", "Usuario_Id1", c => c.Int());
            //CreateIndex("dbo.Usuarios", "Grupo_Id");
            //CreateIndex("dbo.Grupos", "Usuario_Id1");
            //CreateIndex("dbo.Grupos", "Creador_Id");
            //CreateIndex("dbo.Grupos", "Usuario_Id");
            //AddForeignKey("dbo.Usuarios", "Grupo_Id", "dbo.Grupos", "Id");
            //AddForeignKey("dbo.Grupos", "Usuario_Id1", "dbo.Usuarios", "Id");
            //AddForeignKey("dbo.Grupos", "Creador_Id", "dbo.Usuarios", "Id");
            //AddForeignKey("dbo.Grupos", "Usuario_Id", "dbo.Usuarios", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Grupos", "Usuario_Id", "dbo.Usuarios");
            //DropForeignKey("dbo.Grupos", "Creador_Id", "dbo.Usuarios");
            //DropForeignKey("dbo.Grupos", "Usuario_Id1", "dbo.Usuarios");
            //DropForeignKey("dbo.Usuarios", "Grupo_Id", "dbo.Grupos");
            //DropIndex("dbo.Grupos", new[] { "Usuario_Id" });
            //DropIndex("dbo.Grupos", new[] { "Creador_Id" });
            //DropIndex("dbo.Grupos", new[] { "Usuario_Id1" });
            //DropIndex("dbo.Usuarios", new[] { "Grupo_Id" });
            //DropColumn("dbo.Grupos", "Usuario_Id1");
            //DropColumn("dbo.Grupos", "Usuario_Id");
            //DropColumn("dbo.Grupos", "Creador_Id");
            //DropColumn("dbo.Usuarios", "Grupo_Id");
            //CreateIndex("dbo.Grupos", "UsuarioId");
            //CreateIndex("dbo.Grupos", "UsuarioId");
            //AddForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
        }
    }
}
