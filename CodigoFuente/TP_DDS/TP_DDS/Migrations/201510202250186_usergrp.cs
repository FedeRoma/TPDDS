namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usergrp : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.GrupoUsuarios", newName: "Grupos");
            //RenameTable(name: "dbo.GrupoUsuarios", newName: "Usuarios");
            //DropForeignKey("dbo.GrupoUsuarios", "Grupo_Id", "dbo.Grupos");
            //DropForeignKey("dbo.GrupoUsuarios", "Usuario_Id", "dbo.Usuarios");
            //DropIndex("dbo.GrupoUsuarios", new[] { "Grupo_Id" });
            //DropIndex("dbo.GrupoUsuarios", new[] { "Usuario_Id" });
            //AddColumn("dbo.Usuarios", "Grupo_Id", c => c.Int());
            //AddColumn("dbo.Grupos", "UsuarioId", c => c.Int(nullable: false));
            //AddColumn("dbo.Grupos", "Creador_Id", c => c.Int());
            //AddColumn("dbo.Grupos", "Usuario_Id", c => c.Int());
            //CreateIndex("dbo.Grupos", "Creador_Id");
            //CreateIndex("dbo.Usuarios", "Grupo_Id");
            //CreateIndex("dbo.Grupos", "Usuario_Id");
            //AddForeignKey("dbo.Grupos", "Creador_Id", "dbo.Usuarios", "Id");
            //AddForeignKey("dbo.Usuarios", "Grupo_Id", "dbo.Grupos", "Id");
            //AddForeignKey("dbo.Grupos", "Usuario_Id", "dbo.Usuarios", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Grupos", "Usuario_Id", "dbo.Usuarios");
            //DropForeignKey("dbo.Usuarios", "Grupo_Id", "dbo.Grupos");
            //DropForeignKey("dbo.Grupos", "Creador_Id", "dbo.Usuarios");
            //DropIndex("dbo.Grupos", new[] { "Usuario_Id" });
            //DropIndex("dbo.Usuarios", new[] { "Grupo_Id" });
            //DropIndex("dbo.Grupos", new[] { "Creador_Id" });
            //DropColumn("dbo.Grupos", "Usuario_Id");
            //DropColumn("dbo.Grupos", "Creador_Id");
            //DropColumn("dbo.Grupos", "UsuarioId");
            //DropColumn("dbo.Usuarios", "Grupo_Id");
            //CreateIndex("dbo.GrupoUsuarios", "Usuario_Id");
            //CreateIndex("dbo.GrupoUsuarios", "Grupo_Id");
            //AddForeignKey("dbo.GrupoUsuarios", "Usuario_Id", "dbo.Usuarios", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.GrupoUsuarios", "Grupo_Id", "dbo.Grupos", "Id", cascadeDelete: true);
            //RenameTable(name: "dbo.Usuarios", newName: "GrupoUsuarios");
            //RenameTable(name: "dbo.Grupos", newName: "GrupoUsuarios");
        }
    }
}
