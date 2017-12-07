namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fwefe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "CategoryId", c => c.Int());
            AlterColumn("dbo.Books", "AuthorId", c => c.Int());
            AlterColumn("dbo.Books", "PublisherId", c => c.Int());
            AlterColumn("dbo.Books", "YearId", c => c.Int());
            AlterColumn("dbo.Pictures", "BookId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pictures", "BookId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "YearId", c => c.Int());
            AlterColumn("dbo.Books", "PublisherId", c => c.Int());
            AlterColumn("dbo.Books", "AuthorId", c => c.Int());
            AlterColumn("dbo.Books", "CategoryId", c => c.Int());
        }
    }
}
