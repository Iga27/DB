namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedtoBookId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "BookId", "dbo.Books");
            DropIndex("dbo.Pictures", new[] { "BookId" });
            AlterColumn("dbo.Pictures", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pictures", "BookId");
            AddForeignKey("dbo.Pictures", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "BookId", "dbo.Books");
            DropIndex("dbo.Pictures", new[] { "BookId" });
            AlterColumn("dbo.Pictures", "BookId", c => c.Int());
            CreateIndex("dbo.Pictures", "BookId");
            AddForeignKey("dbo.Pictures", "BookId", "dbo.Books", "Id");
        }
    }
}
