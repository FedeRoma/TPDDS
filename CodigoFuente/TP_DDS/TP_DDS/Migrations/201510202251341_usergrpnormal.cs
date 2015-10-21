namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usergrpnormal : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Grupos", "Creador_Id", "dbo.Usuarios");
            //DropForeignKey("dbo.Usuarios", "Grupo_Id", "dbo.Grupos");
            //DropIndex("dbo.Grupos", new[] { "Creador_Id" });
            //DropIndex("dbo.Usuarios", new[] { "Grupo_Id" });
            //DropColumn("dbo.Usuarios", "Grupo_Id");
            //DropColumn("dbo.Grupos", "UsuarioId");
            //DropColumn("dbo.Grupos", "Creador_Id");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Grupos", "Creador_Id", c => c.Int());
            //AddColumn("dbo.Grupos", "UsuarioId", c => c.Int(nullable: false));
            //AddColumn("dbo.Usuarios", "Grupo_Id", c => c.Int());
            //CreateIndex("dbo.Usuarios", "Grupo_Id");
            //CreateIndex("dbo.Grupos", "Creador_Id");
            //AddForeignKey("dbo.Usuarios", "Grupo_Id", "dbo.Grupos", "Id");
            //AddForeignKey("dbo.Grupos", "Creador_Id", "dbo.Usuarios", "Id");
        }
    }
}
