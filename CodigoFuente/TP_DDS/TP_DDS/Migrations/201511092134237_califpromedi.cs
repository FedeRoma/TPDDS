namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class califpromedi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recetas", "CalificacionPromedio", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recetas", "CalificacionPromedio");
        }
    }
}
