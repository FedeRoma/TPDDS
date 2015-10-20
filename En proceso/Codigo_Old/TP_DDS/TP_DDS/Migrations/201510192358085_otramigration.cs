namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class otramigration : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.Sexoes", newName: "Sexo");
        }
        
        public override void Down()
        {
            //RenameTable(name: "dbo.Sexo", newName: "Sexoes");
        }
    }
}
