namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba12 : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.TemporadaRecetas", newName: "TemporadasRecetas");
            //DropForeignKey("dbo.TemporadaRecetas", "Temporada_Id", "dbo.Temporadas");
            //DropForeignKey("dbo.TemporadaRecetas", "Receta_Id", "dbo.Recetas");
            //DropIndex("dbo.TemporadaRecetas", new[] { "Temporada_Id" });
            //DropIndex("dbo.TemporadaRecetas", new[] { "Receta_Id" });
            //CreateIndex("dbo.TemporadasRecetas", "TemporadaId");
            //CreateIndex("dbo.TemporadasRecetas", "RecetaId");
            //AddForeignKey("dbo.TemporadasRecetas", "TemporadaId", "dbo.Temporadas", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.TemporadasRecetas", "RecetaId", "dbo.Recetas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.TemporadasRecetas", "RecetaId", "dbo.Recetas");
            //DropForeignKey("dbo.TemporadasRecetas", "TemporadaId", "dbo.Temporadas");
            //DropIndex("dbo.TemporadasRecetas", new[] { "RecetaId" });
            //DropIndex("dbo.TemporadasRecetas", new[] { "TemporadaId" });
            //CreateIndex("dbo.TemporadaRecetas", "Receta_Id");
            //CreateIndex("dbo.TemporadaRecetas", "Temporada_Id");
            //AddForeignKey("dbo.TemporadaRecetas", "Receta_Id", "dbo.Recetas", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.TemporadaRecetas", "Temporada_Id", "dbo.Temporadas", "Id", cascadeDelete: true);
            //RenameTable(name: "dbo.TemporadasRecetas", newName: "TemporadaRecetas");
        }
    }
}
