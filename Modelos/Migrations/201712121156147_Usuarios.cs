namespace Modelos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usuarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nick = c.String(nullable: false, maxLength: 20),
                        nombre = c.String(nullable: false, maxLength: 20),
                        apellidos = c.String(nullable: false, maxLength: 50),
                        clave = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false, maxLength: 50),
                        bloqueado = c.Boolean(nullable: false),
                        administrador = c.Boolean(nullable: false),
                        idPoblacion = c.Int(nullable: false),
                        telefono = c.String(maxLength: 9),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Poblacion", t => t.idPoblacion, cascadeDelete: true)
                .Index(t => t.nick, unique: true)
                .Index(t => t.email, unique: true)
                .Index(t => t.idPoblacion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "idPoblacion", "dbo.Poblacion");
            DropIndex("dbo.Usuario", new[] { "idPoblacion" });
            DropIndex("dbo.Usuario", new[] { "email" });
            DropIndex("dbo.Usuario", new[] { "nick" });
            DropTable("dbo.Usuario");
        }
    }
}
