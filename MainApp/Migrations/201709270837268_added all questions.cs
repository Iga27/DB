namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedallquestions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Books", "YearId", "dbo.Years");
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "YearId" });
            AlterColumn("dbo.Books", "CategoryId", c => c.Int());
            AlterColumn("dbo.Books", "AuthorId", c => c.Int());
            AlterColumn("dbo.Books", "PublisherId", c => c.Int());
            AlterColumn("dbo.Books", "YearId", c => c.Int());
            CreateIndex("dbo.Books", "CategoryId");
            CreateIndex("dbo.Books", "AuthorId");
            CreateIndex("dbo.Books", "PublisherId");
            CreateIndex("dbo.Books", "YearId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id");
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Publishers", "Id");
            AddForeignKey("dbo.Books", "YearId", "dbo.Years", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "YearId", "dbo.Years");
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "YearId" });
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            AlterColumn("dbo.Books", "YearId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "PublisherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "YearId");
            CreateIndex("dbo.Books", "PublisherId");
            CreateIndex("dbo.Books", "AuthorId");
            CreateIndex("dbo.Books", "CategoryId");
            AddForeignKey("dbo.Books", "YearId", "dbo.Years", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Publishers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Books", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
    }
}
