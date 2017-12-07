namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fefrewdwe : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Price", c => c.Double(nullable: false));
        }
    }
}
