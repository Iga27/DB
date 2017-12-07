namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIdentificatortobook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Identificator", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Identificator");
        }
    }
}
