namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixnullfieldReceta : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Recetas", "FechaUltModif", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Recetas", "FechaUltModif", c => c.DateTime());
        }
    }
}
