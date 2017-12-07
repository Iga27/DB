namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disableautoincrement : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Categories", "Id");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Id");
            DropColumn("dbo.Categories", "Identificator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Identificator", c => c.Int(nullable: false));
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "Id");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Id");
        }
    }
}
