namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixComRec : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Comidas", "Receta_Id", "dbo.Recetas");
            //DropIndex("dbo.Comidas", new[] { "Receta_Id" });
            //DropColumn("dbo.Comidas", "Receta_Id");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Comidas", "Receta_Id", c => c.Int());
            //CreateIndex("dbo.Comidas", "Receta_Id");
            //AddForeignKey("dbo.Comidas", "Receta_Id", "dbo.Recetas", "Id");
        }
    }
}
