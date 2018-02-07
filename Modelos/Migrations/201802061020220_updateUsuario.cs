namespace Modelos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "creado", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "creado");
        }
    }
}
