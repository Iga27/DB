namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Indexuni : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Authors", new[] { "AuthorName" });
            AlterColumn("dbo.Authors", "AuthorName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "AuthorName", c => c.String(maxLength: 900));
            CreateIndex("dbo.Authors", "AuthorName");
        }
    }
}
