namespace TP_DDS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class avancesTp : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.GrupoUsuario", newName: "GruposUsuarios");
            //RenameTable(name: "dbo.PreferenciaUsuarios", newName: "UsuariosPreferencias");
            //RenameTable(name: "dbo.GrupoPreferencias", newName: "GruposPreferencias");
        }
        
        public override void Down()
        {
            //RenameTable(name: "dbo.GruposPreferencias", newName: "GrupoPreferencias");
            //RenameTable(name: "dbo.UsuariosPreferencias", newName: "PreferenciaUsuarios");
            //RenameTable(name: "dbo.GruposUsuarios", newName: "GrupoUsuario");
        }
    }
}
