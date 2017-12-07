namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorIdtoId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropPrimaryKey("dbo.Authors");
            DropColumn("dbo.Authors", "AuthorId");
            AddColumn("dbo.Authors", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Authors", "Id");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
             
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "AuthorId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropPrimaryKey("dbo.Authors");
            DropColumn("dbo.Authors", "Id");
            AddPrimaryKey("dbo.Authors", "AuthorId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
        }
    }
}
