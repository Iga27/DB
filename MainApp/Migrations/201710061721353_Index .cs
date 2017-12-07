namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Index : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Authors", new[] { "AuthorName" });
            AlterColumn("dbo.Authors", "AuthorName", c => c.String(maxLength: 900));
            CreateIndex("dbo.Authors", "AuthorName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Authors", new[] { "AuthorName" });
            AlterColumn("dbo.Authors", "AuthorName", c => c.String(maxLength: 300, unicode: false));
            CreateIndex("dbo.Authors", "AuthorName");
        }
    }
}
