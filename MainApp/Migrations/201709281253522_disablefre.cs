namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disablefre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: false));
            AddPrimaryKey("dbo.Categories", "Id");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Id");
            DropColumn("dbo.Categories", "Name2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Name2", c => c.String());
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Categories", "Id");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Id");
        }
    }
}
