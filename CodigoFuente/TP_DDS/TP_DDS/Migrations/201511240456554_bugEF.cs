namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bugEF : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ComidasRecetas", "Comida_Id", "dbo.Comidas");
            DropForeignKey("dbo.ComidasRecetas", "Receta_Id", "dbo.Recetas");
            DropIndex("dbo.ComidasRecetas", new[] { "Comida_Id" });
            DropIndex("dbo.ComidasRecetas", new[] { "Receta_Id" });
            DropColumn("dbo.ComidasRecetas", "Comida_Id");
            DropColumn("dbo.ComidasRecetas", "Receta_Id");
            DropColumn("dbo.ComidasRecetas", "Eliminada");
            //DropColumn("dbo.ComidasRecetas", "Comida_Id1");
            //DropColumn("dbo.ComidasRecetas", "Receta_Id1");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.ComidasRecetas", "Receta_Id1", c => c.Int());
            //AddColumn("dbo.ComidasRecetas", "Comida_Id1", c => c.Int());
            //AddColumn("dbo.ComidasRecetas", "Eliminada", c => c.Boolean(nullable: false));
            //AddColumn("dbo.ComidasRecetas", "Receta_Id", c => c.Int(nullable: false));
            //AddColumn("dbo.ComidasRecetas", "Comida_Id", c => c.Int(nullable: false));
            //CreateIndex("dbo.ComidasRecetas", "Receta_Id1");
            //CreateIndex("dbo.ComidasRecetas", "Comida_Id1");
            //AddForeignKey("dbo.ComidasRecetas", "Receta_Id1", "dbo.Recetas", "Id");
            //AddForeignKey("dbo.ComidasRecetas", "Comida_Id1", "dbo.Comidas", "Id");
        }
    }
}
