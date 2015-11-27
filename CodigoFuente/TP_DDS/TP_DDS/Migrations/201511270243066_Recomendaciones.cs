namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recomendaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recomendaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        CondicionPreexistenteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CondicionesPreexistentes", t => t.CondicionPreexistenteId, cascadeDelete: false)
                .Index(t => t.CondicionPreexistenteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recomendaciones", "CondicionPreexistenteId", "dbo.CondicionesPreexistentes");
            DropIndex("dbo.Recomendaciones", new[] { "CondicionPreexistenteId" });
            DropTable("dbo.Recomendaciones");
        }
    }
}
