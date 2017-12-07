namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewfwefew : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Books", "YearId", "dbo.Years");
            DropPrimaryKey("dbo.Publishers");
            DropPrimaryKey("dbo.Years");
            AddColumn("dbo.Books", "Type", c => c.String());
            AddColumn("dbo.Books", "CurrencyId", c => c.String());
            AddColumn("dbo.Books", "Store", c => c.Boolean(nullable: false));
            AddColumn("dbo.Books", "Pickup", c => c.Boolean(nullable: false));
            AddColumn("dbo.Books", "Series", c => c.String());
            AddColumn("dbo.Books", "ISBN", c => c.String());
            AddColumn("dbo.Books", "Dimensions", c => c.String());
            AlterColumn("dbo.Publishers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Years", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Publishers", "Id");
            AddPrimaryKey("dbo.Years", "Id");
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Publishers", "Id");
            AddForeignKey("dbo.Books", "YearId", "dbo.Years", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "YearId", "dbo.Years");
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropPrimaryKey("dbo.Years");
            DropPrimaryKey("dbo.Publishers");
            AlterColumn("dbo.Years", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Publishers", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Dimensions");
            DropColumn("dbo.Books", "ISBN");
            DropColumn("dbo.Books", "Series");
            DropColumn("dbo.Books", "Pickup");
            DropColumn("dbo.Books", "Store");
            DropColumn("dbo.Books", "CurrencyId");
            DropColumn("dbo.Books", "Type");
            AddPrimaryKey("dbo.Years", "Id");
            AddPrimaryKey("dbo.Publishers", "Id");
            AddForeignKey("dbo.Books", "YearId", "dbo.Years", "Id");
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Publishers", "Id");
        }
    }
}
