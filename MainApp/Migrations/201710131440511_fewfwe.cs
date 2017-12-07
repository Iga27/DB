namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewfwe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropPrimaryKey("dbo.Authors");
            AlterColumn("dbo.Authors", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Authors", "Id");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropPrimaryKey("dbo.Authors");
            AlterColumn("dbo.Authors", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Authors", "Id");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id");
        }
    }
}
