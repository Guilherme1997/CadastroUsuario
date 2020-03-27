namespace CadastroUsuario.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sexo",
                c => new
                    {
                        SexoID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.SexoID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 200),
                        DataNascimento = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 100),
                        Senha = c.String(maxLength: 30),
                        Ativo = c.Boolean(nullable: false),
                        SexoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioID)
                .ForeignKey("dbo.Sexo", t => t.SexoID, cascadeDelete: true)
                .Index(t => t.SexoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "SexoID", "dbo.Sexo");
            DropIndex("dbo.Usuario", new[] { "SexoID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Sexo");
        }
    }
}
