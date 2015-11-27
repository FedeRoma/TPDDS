namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GrupoUsuEliminado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GruposUsuarios", "Eliminado", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GruposUsuarios", "Eliminado");
        }
    }
}
