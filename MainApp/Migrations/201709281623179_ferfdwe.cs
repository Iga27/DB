namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ferfdwe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false, identity: true));
        }
    }
}
