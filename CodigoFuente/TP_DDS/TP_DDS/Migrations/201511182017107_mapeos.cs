namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mapeos : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.PreferenciaDietas", newName: "DietasPreferencias");
        }
        
        public override void Down()
        {
            //RenameTable(name: "dbo.DietasPreferencias", newName: "PreferenciaDietas");
        }
    }
}
