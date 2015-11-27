namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPesoUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Peso", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Peso");
        }
    }
}
