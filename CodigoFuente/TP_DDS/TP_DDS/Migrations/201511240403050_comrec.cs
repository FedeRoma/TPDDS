namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comrec : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ComidasRecetas", "ComidaId", "dbo.Comidas");
            DropForeignKey("dbo.ComidasRecetas", "RecetaId", "dbo.Recetas");
            DropIndex("dbo.ComidasRecetas", new[] { "ComidaId" });
            DropIndex("dbo.ComidasRecetas", new[] { "RecetaId" });
            RenameColumn(table: "dbo.ComidasRecetas", name: "ComidaId", newName: "Comida_Id");
            RenameColumn(table: "dbo.ComidasRecetas", name: "RecetaId", newName: "Receta_Id");
            //AddColumn("dbo.ComidasRecetas", "Comida_Id", c => c.Int(nullable: false));
            //AddColumn("dbo.ComidasRecetas", "Receta_Id", c => c.Int(nullable: false));
            //AlterColumn("dbo.ComidasRecetas", "Comida_Id1", c => c.Int());
            //AlterColumn("dbo.ComidasRecetas", "Receta_Id1", c => c.Int());
            CreateIndex("dbo.ComidasRecetas", "Comida_Id");
            CreateIndex("dbo.ComidasRecetas", "Receta_Id");
            AddForeignKey("dbo.ComidasRecetas", "Comida_Id", "dbo.Comidas", "Id");
            AddForeignKey("dbo.ComidasRecetas", "Receta_Id", "dbo.Recetas", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.ComidasRecetas", "Receta_Id1", "dbo.Recetas");
            //DropForeignKey("dbo.ComidasRecetas", "Comida_Id1", "dbo.Comidas");
            //DropIndex("dbo.ComidasRecetas", new[] { "Receta_Id1" });
            //DropIndex("dbo.ComidasRecetas", new[] { "Comida_Id1" });
            //AlterColumn("dbo.ComidasRecetas", "Receta_Id1", c => c.Int(nullable: false));
            //AlterColumn("dbo.ComidasRecetas", "Comida_Id1", c => c.Int(nullable: false));
            //DropColumn("dbo.ComidasRecetas", "Receta_Id");
            //DropColumn("dbo.ComidasRecetas", "Comida_Id");
            //RenameColumn(table: "dbo.ComidasRecetas", name: "Receta_Id1", newName: "RecetaId");
            //RenameColumn(table: "dbo.ComidasRecetas", name: "Comida_Id1", newName: "ComidaId");
            //CreateIndex("dbo.ComidasRecetas", "RecetaId");
            //CreateIndex("dbo.ComidasRecetas", "ComidaId");
            //AddForeignKey("dbo.ComidasRecetas", "RecetaId", "dbo.Recetas", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.ComidasRecetas", "ComidaId", "dbo.Comidas", "Id", cascadeDelete: true);
        }
    }
}
