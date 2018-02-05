namespace Modelos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bdtotal2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Valoracion", "valor", c => c.Int(nullable: false));
            DropColumn("dbo.Valoracion", "calor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Valoracion", "calor", c => c.Int(nullable: false));
            DropColumn("dbo.Valoracion", "valor");
        }
    }
}
