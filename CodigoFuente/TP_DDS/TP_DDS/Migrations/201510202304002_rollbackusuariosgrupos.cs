namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rollbackusuariosgrupos : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios");
            //DropIndex("dbo.Grupos", new[] { "UsuarioId" });
            //DropColumn("dbo.Grupos", "UsuarioId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Grupos", "UsuarioId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Grupos", "UsuarioId");
            //AddForeignKey("dbo.Grupos", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
        }
    }
}
