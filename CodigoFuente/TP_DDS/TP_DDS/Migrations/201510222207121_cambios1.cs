namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios1 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Usuarios", "CondicionPreexistenteId", "dbo.CondicionesPreexistentes");
            //DropIndex("dbo.Usuarios", new[] { "CondicionPreexistenteId" });
            //AlterColumn("dbo.Usuarios", "Peso", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Usuarios", "Altura", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            //AlterColumn("dbo.Usuarios", "CondicionPreexistenteId", c => c.Int(nullable: false));
            //CreateIndex("dbo.Usuarios", "CondicionPreexistenteId");
            //AddForeignKey("dbo.Usuarios", "CondicionPreexistenteId", "dbo.CondicionesPreexistentes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Usuarios", "CondicionPreexistenteId", "dbo.CondicionesPreexistentes");
            //DropIndex("dbo.Usuarios", new[] { "CondicionPreexistenteId" });
            //AlterColumn("dbo.Usuarios", "CondicionPreexistenteId", c => c.Int());
            //AlterColumn("dbo.Usuarios", "Altura", c => c.Decimal(precision: 18, scale: 2));
            //AlterColumn("dbo.Usuarios", "Peso", c => c.Decimal(precision: 18, scale: 2));
            //CreateIndex("dbo.Usuarios", "CondicionPreexistenteId");
            //AddForeignKey("dbo.Usuarios", "CondicionPreexistenteId", "dbo.CondicionesPreexistentes", "Id");
        }
    }
}
