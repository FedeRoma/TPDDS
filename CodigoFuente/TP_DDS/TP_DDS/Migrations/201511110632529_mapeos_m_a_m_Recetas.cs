namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mapeos_m_a_m_Recetas : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.ClasificacionRecetas", newName: "ClasificacionesRecetas");
            //RenameTable(name: "dbo.CondimentoRecetas", newName: "CondimentosRecetas");
            //RenameColumn(table: "dbo.TemporadasRecetas", name: "RecetaId", newName: "Receta_Id");
            //RenameColumn(table: "dbo.TemporadasRecetas", name: "TemporadaId", newName: "Temporada_Id");
        }
        
        public override void Down()
        {
            //RenameColumn(table: "dbo.TemporadasRecetas", name: "Temporada_Id", newName: "TemporadaId");
            //RenameColumn(table: "dbo.TemporadasRecetas", name: "Receta_Id", newName: "RecetaId");
            //RenameTable(name: "dbo.CondimentosRecetas", newName: "CondimentoRecetas");
            //RenameTable(name: "dbo.ClasificacionesRecetas", newName: "ClasificacionRecetas");
        }
    }
}
