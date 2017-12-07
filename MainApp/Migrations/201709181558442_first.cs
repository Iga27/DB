namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Available = c.Boolean(nullable: false),
                        Url = c.String(),
                        Price = c.Int(nullable: false),
                        Delivery = c.Boolean(nullable: false),
                        LocalDeliveryCost = c.Int(nullable: false),
                        Name = c.String(),
                        Language = c.String(),
                        Binding = c.String(),
                        PageExtent = c.Int(nullable: false),
                        Description = c.String(),
                        SalesNotes = c.String(),
                        Barcode = c.Long(nullable: false),
                        Package_Weight = c.Int(nullable: false),
                        Package_Width = c.Int(nullable: false),
                        Package_Height = c.Int(nullable: false),
                        Package_Type = c.String(),
                        Package_ColorIllustrations = c.Boolean(nullable: false),
                        CategoryId = c.Int(),
                        AuthorId = c.Int(),
                        PublisherId = c.Int(),
                        YearId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Publishers", t => t.PublisherId)
                .ForeignKey("dbo.Years", t => t.YearId)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId)
                .Index(t => t.PublisherId)
                .Index(t => t.YearId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identificator = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("dbo.Books", t => t.BookId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PublisherId = c.Int(nullable: false, identity: true),
                        PublisherName = c.String(),
                    })
                .PrimaryKey(t => t.PublisherId);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        YearId = c.Int(nullable: false, identity: true),
                        YearName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.YearId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "YearId", "dbo.Years");
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Pictures", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Pictures", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "YearId" });
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropTable("dbo.Years");
            DropTable("dbo.Publishers");
            DropTable("dbo.Pictures");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
