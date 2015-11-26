namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userBajaID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GruposRecetas", "UsuarioBajaId", c => c.Int(nullable: true));
            CreateIndex("dbo.GruposRecetas", "UsuarioBajaId");
            AddForeignKey("dbo.GruposRecetas", "UsuarioBajaId", "dbo.Usuarios", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GruposRecetas", "UsuarioBajaId", "dbo.Usuarios");
            DropIndex("dbo.GruposRecetas", new[] { "UsuarioBajaId" });
            DropColumn("dbo.GruposRecetas", "UsuarioBajaId");
        }
    }
}
