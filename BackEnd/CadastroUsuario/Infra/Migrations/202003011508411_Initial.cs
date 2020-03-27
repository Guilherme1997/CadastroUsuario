namespace EasyContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        ContatoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Email = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContatoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contato");
        }
    }
}
