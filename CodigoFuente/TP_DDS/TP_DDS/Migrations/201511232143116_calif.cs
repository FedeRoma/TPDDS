namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calif : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calificaciones", "Comentario", c => c.String());
            AddColumn("dbo.Calificaciones", "FechaHora", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calificaciones", "FechaHora");
            DropColumn("dbo.Calificaciones", "Comentario");
        }
    }
}
