namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                {
                    Id = c.Int(nullable: false, identity: false),
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
        }
        
        public override void Down()
        {
        }
    }
}
