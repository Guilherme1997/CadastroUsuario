namespace EasyContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "DataNascimento", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "DataNascimento", c => c.Int(nullable: false));
        }
    }
}
