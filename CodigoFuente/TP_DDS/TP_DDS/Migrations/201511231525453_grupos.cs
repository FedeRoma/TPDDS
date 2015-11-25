namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grupos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grupos", "FechaCreacion", c => c.DateTime(nullable: true));
            AddColumn("dbo.Grupos", "FechaUltModif", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grupos", "FechaUltModif");
            DropColumn("dbo.Grupos", "FechaCreacion");
        }
    }
}
