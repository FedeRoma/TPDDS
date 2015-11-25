namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevarelusrgrp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grupos", "UsuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Grupos", "UsuarioId");
            AddForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Grupos", new[] { "UsuarioId" });
            DropColumn("dbo.Grupos", "UsuarioId");
        }
    }
}
