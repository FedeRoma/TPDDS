namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixCol : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.IngredientesRecetas", "TipoIngrediente_Id", "dbo.TipoIngredientes");
            //DropIndex("dbo.IngredientesRecetas", new[] { "TipoIngrediente_Id" });
            //RenameColumn(table: "dbo.IngredientesRecetas", name: "TipoIngrediente_Id", newName: "TipoIngredienteId");
            //AlterColumn("dbo.IngredientesRecetas", "TipoIngredienteId", c => c.Int(nullable: false));
            //CreateIndex("dbo.IngredientesRecetas", "TipoIngredienteId");
            //AddForeignKey("dbo.IngredientesRecetas", "TipoIngredienteId", "dbo.TipoIngredientes", "Id", cascadeDelete: true);
            //DropColumn("dbo.IngredientesRecetas", "TipoId");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.IngredientesRecetas", "TipoId", c => c.Int(nullable: false));
            //DropForeignKey("dbo.IngredientesRecetas", "TipoIngredienteId", "dbo.TipoIngredientes");
            //DropIndex("dbo.IngredientesRecetas", new[] { "TipoIngredienteId" });
            //AlterColumn("dbo.IngredientesRecetas", "TipoIngredienteId", c => c.Int());
            //RenameColumn(table: "dbo.IngredientesRecetas", name: "TipoIngredienteId", newName: "TipoIngrediente_Id");
            //CreateIndex("dbo.IngredientesRecetas", "TipoIngrediente_Id");
            //AddForeignKey("dbo.IngredientesRecetas", "TipoIngrediente_Id", "dbo.TipoIngredientes", "Id");
        }
    }
}
