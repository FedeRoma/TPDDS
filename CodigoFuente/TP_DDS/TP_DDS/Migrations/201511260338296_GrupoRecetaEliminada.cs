namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GrupoRecetaEliminada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GruposRecetas", "Eliminada", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GruposRecetas", "Eliminada");
        }
    }
}
