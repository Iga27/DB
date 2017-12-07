namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fefrewdwefre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Price");
        }
    }
}
