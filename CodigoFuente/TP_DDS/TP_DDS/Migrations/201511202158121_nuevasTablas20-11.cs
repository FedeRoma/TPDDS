namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevasTablas2011 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dificultades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoIngredientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Recetas", "DificultadId", c => c.Int(nullable: true));
            AddColumn("dbo.IngredientesRecetas", "TipoIngredienteId", c => c.Int(nullable: true));
            CreateIndex("dbo.Recetas", "DificultadId");
            CreateIndex("dbo.IngredientesRecetas", "TipoIngredienteId");
            AddForeignKey("dbo.Recetas", "DificultadId", "dbo.Dificultades", "Id", cascadeDelete: false);
            AddForeignKey("dbo.IngredientesRecetas", "TipoIngredienteId", "dbo.TipoIngredientes", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recetas", "Dificultad", c => c.Int(nullable: false));
            DropForeignKey("dbo.IngredientesRecetas", "TipoIngredienteId", "dbo.TipoIngredientes");
            DropForeignKey("dbo.Recetas", "DificultadId", "dbo.Dificultades");
            DropIndex("dbo.IngredientesRecetas", new[] { "TipoIngredienteId" });
            DropIndex("dbo.Recetas", new[] { "DificultadId" });
            DropColumn("dbo.IngredientesRecetas", "TipoIngredienteId");
            DropColumn("dbo.Recetas", "DificultadId");
            DropTable("dbo.TipoIngredientes");
            DropTable("dbo.Dificultades");
        }
    }
}
