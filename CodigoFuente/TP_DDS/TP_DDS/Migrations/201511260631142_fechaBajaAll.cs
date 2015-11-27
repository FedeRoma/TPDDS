namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fechaBajaAll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recetas", "FechaBaja", c => c.DateTime());
            AddColumn("dbo.Grupos", "FechaBaja", c => c.DateTime());
            AddColumn("dbo.GruposRecetas", "FechaBaja", c => c.DateTime());
            AddColumn("dbo.GruposUsuarios", "FechaBaja", c => c.DateTime());
            AddColumn("dbo.ComidasRecetas", "FechaBaja", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ComidasRecetas", "FechaBaja");
            DropColumn("dbo.GruposUsuarios", "FechaBaja");
            DropColumn("dbo.GruposRecetas", "FechaBaja");
            DropColumn("dbo.Grupos", "FechaBaja");
            DropColumn("dbo.Recetas", "FechaBaja");
        }
    }
}
