namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambioAltura : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Altura", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Altura", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
