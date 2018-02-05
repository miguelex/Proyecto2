namespace Modelos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bdtotal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentario",
                c => new
                    {
                        idUsuario = c.Int(nullable: false),
                        idEmpresa = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        comentario = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => new { t.idUsuario, t.idEmpresa, t.fecha })
                .ForeignKey("dbo.Empresa", t => t.idEmpresa, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario)
                .Index(t => t.idEmpresa);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                        latitud = c.Single(nullable: false),
                        longitud = c.Single(nullable: false),
                        idPropietario = c.Int(nullable: false),
                        idPoblacion = c.Int(nullable: false),
                        bloqueado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Poblacion", t => t.idPoblacion, cascadeDelete: false)
                .ForeignKey("dbo.Propietario", t => t.idPropietario, cascadeDelete: false)
                .Index(t => t.idPropietario)
                .Index(t => t.idPoblacion);
            
            CreateTable(
                "dbo.Denuncia",
                c => new
                    {
                        idUsuario = c.Int(nullable: false),
                        idEmpresa = c.Int(nullable: false),
                        idTipoDenuncia = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        descripcion = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => new { t.idUsuario, t.idEmpresa, t.idTipoDenuncia, t.fecha })
                .ForeignKey("dbo.Empresa", t => t.idEmpresa, cascadeDelete: true)
                .ForeignKey("dbo.TipoDenuncia", t => t.idTipoDenuncia, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario)
                .Index(t => t.idEmpresa)
                .Index(t => t.idTipoDenuncia);
            
            CreateTable(
                "dbo.TipoDenuncia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Valoracion",
                c => new
                    {
                        idUsuario = c.Int(nullable: false),
                        idEmpresa = c.Int(nullable: false),
                        idFacilitador = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        calor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idUsuario, t.idEmpresa, t.idFacilitador, t.fecha })
                .ForeignKey("dbo.Empresa", t => t.idEmpresa, cascadeDelete: true)
                .ForeignKey("dbo.Facilitador", t => t.idFacilitador, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.idUsuario, cascadeDelete: true)
                .Index(t => t.idUsuario)
                .Index(t => t.idEmpresa)
                .Index(t => t.idFacilitador);
            
            CreateTable(
                "dbo.Propietario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nick = c.String(nullable: false, maxLength: 20),
                        nombre = c.String(nullable: false, maxLength: 20),
                        apellidos = c.String(nullable: false, maxLength: 50),
                        clave = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false, maxLength: 50),
                        direccion = c.String(),
                        telefono = c.String(),
                        bloqueado = c.Boolean(nullable: false),
                        activado = c.Boolean(nullable: false),
                        reseteado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.nick, unique: true)
                .Index(t => t.email, unique: true);
            
            CreateTable(
                "dbo.FacilitadorEmpresas",
                c => new
                    {
                        Facilitador_id = c.Int(nullable: false),
                        Empresa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Facilitador_id, t.Empresa_id })
                .ForeignKey("dbo.Facilitador", t => t.Facilitador_id, cascadeDelete: true)
                .ForeignKey("dbo.Empresa", t => t.Empresa_id, cascadeDelete: true)
                .Index(t => t.Facilitador_id)
                .Index(t => t.Empresa_id);
            
            CreateTable(
                "dbo.TipoEmpresaEmpresas",
                c => new
                    {
                        TipoEmpresa_id = c.Int(nullable: false),
                        Empresa_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TipoEmpresa_id, t.Empresa_id })
                .ForeignKey("dbo.TipoEmpresa", t => t.TipoEmpresa_id, cascadeDelete: true)
                .ForeignKey("dbo.Empresa", t => t.Empresa_id, cascadeDelete: true)
                .Index(t => t.TipoEmpresa_id)
                .Index(t => t.Empresa_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TipoEmpresaEmpresas", "Empresa_id", "dbo.Empresa");
            DropForeignKey("dbo.TipoEmpresaEmpresas", "TipoEmpresa_id", "dbo.TipoEmpresa");
            DropForeignKey("dbo.Empresa", "idPropietario", "dbo.Propietario");
            DropForeignKey("dbo.Valoracion", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Valoracion", "idFacilitador", "dbo.Facilitador");
            DropForeignKey("dbo.FacilitadorEmpresas", "Empresa_id", "dbo.Empresa");
            DropForeignKey("dbo.FacilitadorEmpresas", "Facilitador_id", "dbo.Facilitador");
            DropForeignKey("dbo.Valoracion", "idEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.Empresa", "idPoblacion", "dbo.Poblacion");
            DropForeignKey("dbo.Denuncia", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Comentario", "idUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Denuncia", "idTipoDenuncia", "dbo.TipoDenuncia");
            DropForeignKey("dbo.Denuncia", "idEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.Comentario", "idEmpresa", "dbo.Empresa");
            DropIndex("dbo.TipoEmpresaEmpresas", new[] { "Empresa_id" });
            DropIndex("dbo.TipoEmpresaEmpresas", new[] { "TipoEmpresa_id" });
            DropIndex("dbo.FacilitadorEmpresas", new[] { "Empresa_id" });
            DropIndex("dbo.FacilitadorEmpresas", new[] { "Facilitador_id" });
            DropIndex("dbo.Propietario", new[] { "email" });
            DropIndex("dbo.Propietario", new[] { "nick" });
            DropIndex("dbo.Valoracion", new[] { "idFacilitador" });
            DropIndex("dbo.Valoracion", new[] { "idEmpresa" });
            DropIndex("dbo.Valoracion", new[] { "idUsuario" });
            DropIndex("dbo.Denuncia", new[] { "idTipoDenuncia" });
            DropIndex("dbo.Denuncia", new[] { "idEmpresa" });
            DropIndex("dbo.Denuncia", new[] { "idUsuario" });
            DropIndex("dbo.Empresa", new[] { "idPoblacion" });
            DropIndex("dbo.Empresa", new[] { "idPropietario" });
            DropIndex("dbo.Comentario", new[] { "idEmpresa" });
            DropIndex("dbo.Comentario", new[] { "idUsuario" });
            DropTable("dbo.TipoEmpresaEmpresas");
            DropTable("dbo.FacilitadorEmpresas");
            DropTable("dbo.Propietario");
            DropTable("dbo.Valoracion");
            DropTable("dbo.TipoDenuncia");
            DropTable("dbo.Denuncia");
            DropTable("dbo.Empresa");
            DropTable("dbo.Comentario");
        }
    }
}
