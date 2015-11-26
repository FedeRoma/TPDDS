namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixcolumn : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.GruposRecetas", "UsuarioBajaId", "dbo.Usuarios");
            //DropIndex("dbo.GruposRecetas", new[] { "UsuarioBajaId" });
            //AlterColumn("dbo.GruposRecetas", "UsuarioBajaId", c => c.Int());
            //CreateIndex("dbo.GruposRecetas", "UsuarioBajaId");
            //AddForeignKey("dbo.GruposRecetas", "UsuarioBajaId", "dbo.Usuarios", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.GruposRecetas", "UsuarioBajaId", "dbo.Usuarios");
            //DropIndex("dbo.GruposRecetas", new[] { "UsuarioBajaId" });
            //AlterColumn("dbo.GruposRecetas", "UsuarioBajaId", c => c.Int(nullable: false));
            //CreateIndex("dbo.GruposRecetas", "UsuarioBajaId");
            //AddForeignKey("dbo.GruposRecetas", "UsuarioBajaId", "dbo.Usuarios", "Id", cascadeDelete: true);
        }
    }
}
