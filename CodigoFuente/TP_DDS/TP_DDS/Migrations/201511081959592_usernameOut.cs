namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernameOut : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuarios", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "UserName", c => c.String());
        }
    }
}
