namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixColEliminado : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GruposUsuarios", "Eliminado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GruposUsuarios", "Eliminado", c => c.Boolean());
        }
    }
}
