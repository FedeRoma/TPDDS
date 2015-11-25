namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixBugEF : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComidasRecetas", "ComidaId", c => c.Int(nullable: false));
            AddColumn("dbo.ComidasRecetas", "RecetaId", c => c.Int(nullable: false));
            AddColumn("dbo.ComidasRecetas", "Eliminada", c => c.Boolean(nullable: false));
            CreateIndex("dbo.ComidasRecetas", "ComidaId");
            CreateIndex("dbo.ComidasRecetas", "RecetaId");
            AddForeignKey("dbo.ComidasRecetas", "ComidaId", "dbo.Comidas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ComidasRecetas", "RecetaId", "dbo.Recetas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComidasRecetas", "RecetaId", "dbo.Recetas");
            DropForeignKey("dbo.ComidasRecetas", "ComidaId", "dbo.Comidas");
            DropIndex("dbo.ComidasRecetas", new[] { "RecetaId" });
            DropIndex("dbo.ComidasRecetas", new[] { "ComidaId" });
            DropColumn("dbo.ComidasRecetas", "Eliminada");
            DropColumn("dbo.ComidasRecetas", "RecetaId");
            DropColumn("dbo.ComidasRecetas", "ComidaId");
        }
    }
}
