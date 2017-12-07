namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Indexattribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "AuthorName", c => c.String(maxLength: 300));
            CreateIndex("dbo.Authors", "AuthorName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Authors", new[] { "AuthorName" });
            AlterColumn("dbo.Authors", "AuthorName", c => c.String());
        }
    }
}
