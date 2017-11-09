namespace Modelos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class provinciapoblacion2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Poblacion",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NombrePoblacion = c.String(nullable: false, maxLength: 100),
                        idProvincia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Provincia", t => t.idProvincia, cascadeDelete: true)
                .Index(t => t.idProvincia);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NombreProvincia = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Poblacion", "idProvincia", "dbo.Provincia");
            DropIndex("dbo.Poblacion", new[] { "idProvincia" });
            DropTable("dbo.Provincia");
            DropTable("dbo.Poblacion");
        }
    }
}
