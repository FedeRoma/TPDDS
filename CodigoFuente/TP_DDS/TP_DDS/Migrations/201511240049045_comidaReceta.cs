namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comidaReceta : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.ComidasRecetas", newName: "Comidas");
            //DropForeignKey("dbo.ComidasRecetas", "Comida_Id", "dbo.Comidas");
            //DropForeignKey("dbo.ComidasRecetas", "Receta_Id", "dbo.Recetas");
            //DropIndex("dbo.ComidasRecetas", new[] { "Comida_Id" });
            //DropIndex("dbo.ComidasRecetas", new[] { "Receta_Id" });
            CreateTable(
                "dbo.ComidasRecetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComidaId = c.Int(nullable: false),
                        RecetaId = c.Int(nullable: false),
                        Eliminada = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comidas", t => t.ComidaId, cascadeDelete: false)
                .ForeignKey("dbo.Recetas", t => t.RecetaId, cascadeDelete: false)
                .Index(t => t.ComidaId)
                .Index(t => t.RecetaId);
            
            AddColumn("dbo.Comidas", "Eliminada", c => c.Boolean(nullable: false));
            //AddColumn("dbo.Comidas", "Receta_Id", c => c.Int());
            //AddColumn("dbo.ComidasRecetas", "Id", c => c.Int(nullable: false, identity: true));
            //AddColumn("dbo.ComidasRecetas", "ComidaId", c => c.Int(nullable: false));
            //AddColumn("dbo.ComidasRecetas", "RecetaId", c => c.Int(nullable: false));
            //AddColumn("dbo.ComidasRecetas", "Eliminada", c => c.Boolean(nullable: false));
            //DropPrimaryKey("dbo.ComidasRecetas");
            //AddPrimaryKey("dbo.ComidasRecetas", "Id");
            //CreateIndex("dbo.Comidas", "Receta_Id");
            //AddForeignKey("dbo.Comidas", "Receta_Id", "dbo.Recetas", "Id");
            //DropColumn("dbo.ComidasRecetas", "Comida_Id");
            //DropColumn("dbo.ComidasRecetas", "Receta_Id");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.ComidasRecetas", "Receta_Id", c => c.Int(nullable: false));
            //AddColumn("dbo.ComidasRecetas", "Comida_Id", c => c.Int(nullable: false));
            //DropForeignKey("dbo.Comidas", "Receta_Id", "dbo.Recetas");
            //DropForeignKey("dbo.ComidasRecetas", "RecetaId", "dbo.Recetas");
            //DropForeignKey("dbo.ComidasRecetas", "ComidaId", "dbo.Comidas");
            //DropIndex("dbo.Comidas", new[] { "Receta_Id" });
            //DropIndex("dbo.ComidasRecetas", new[] { "RecetaId" });
            //DropIndex("dbo.ComidasRecetas", new[] { "ComidaId" });
            //DropPrimaryKey("dbo.ComidasRecetas");
            //AddPrimaryKey("dbo.ComidasRecetas", new[] { "Comida_Id", "Receta_Id" });
            //DropColumn("dbo.ComidasRecetas", "Eliminada");
            //DropColumn("dbo.ComidasRecetas", "RecetaId");
            //DropColumn("dbo.ComidasRecetas", "ComidaId");
            //DropColumn("dbo.ComidasRecetas", "Id");
            //DropColumn("dbo.Comidas", "Receta_Id");
            //DropColumn("dbo.Comidas", "Eliminada");
            //DropTable("dbo.ComidasRecetas");
            //CreateIndex("dbo.ComidasRecetas", "Receta_Id");
            //CreateIndex("dbo.ComidasRecetas", "Comida_Id");
            //AddForeignKey("dbo.ComidasRecetas", "Receta_Id", "dbo.Recetas", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.ComidasRecetas", "Comida_Id", "dbo.Comidas", "Id", cascadeDelete: true);
            //RenameTable(name: "dbo.Comidas", newName: "ComidasRecetas");
        }
    }
}
