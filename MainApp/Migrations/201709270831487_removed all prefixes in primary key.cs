namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedallprefixesinprimarykey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Books", "YearId", "dbo.Years");
            DropPrimaryKey("dbo.Pictures");
            DropPrimaryKey("dbo.Publishers");
            DropPrimaryKey("dbo.Years");
            DropColumn("dbo.Pictures", "PictureId");
            DropColumn("dbo.Publishers", "PublisherId");
            DropColumn("dbo.Years", "YearId");
            AddColumn("dbo.Pictures", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Publishers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Years", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Pictures", "Id");
            AddPrimaryKey("dbo.Publishers", "Id");
            AddPrimaryKey("dbo.Years", "Id");
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Publishers", "Id");
            AddForeignKey("dbo.Books", "YearId", "dbo.Years", "Id", cascadeDelete: true);
             
        }
        
        public override void Down()
        {
            AddColumn("dbo.Years", "YearId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Publishers", "PublisherId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Pictures", "PictureId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Books", "YearId", "dbo.Years");
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropPrimaryKey("dbo.Years");
            DropPrimaryKey("dbo.Publishers");
            DropPrimaryKey("dbo.Pictures");
            DropColumn("dbo.Years", "Id");
            DropColumn("dbo.Publishers", "Id");
            DropColumn("dbo.Pictures", "Id");
            AddPrimaryKey("dbo.Years", "YearId");
            AddPrimaryKey("dbo.Publishers", "PublisherId");
            AddPrimaryKey("dbo.Pictures", "PictureId");
            AddForeignKey("dbo.Books", "YearId", "dbo.Years", "YearId", cascadeDelete: true);
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Publishers", "PublisherId");
        }
    }
}
