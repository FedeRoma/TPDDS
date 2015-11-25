namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class avances1111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recetas", "Eliminada", c => c.Boolean(nullable: false));
            AddColumn("dbo.Grupos", "Eliminado", c => c.Boolean(nullable: false));
            //AlterColumn("dbo.Usuarios", "Peso", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Usuarios", "Peso", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Grupos", "Eliminado");
            DropColumn("dbo.Recetas", "Eliminada");
        }
    }
}
