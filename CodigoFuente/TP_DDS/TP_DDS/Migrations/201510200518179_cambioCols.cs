namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambioCols : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recetas", "TotalCalorias", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.Ingredientes", "CaloriasPorcion", c => c.Decimal(nullable: false, precision: 18, scale: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ingredientes", "CaloriasPorcion", c => c.Single(nullable: false));
            AlterColumn("dbo.Recetas", "TotalCalorias", c => c.Single(nullable: false));
        }
    }
}
