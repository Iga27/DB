namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bgffewdf : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Authors", new[] { "AuthorName" });
            AlterColumn("dbo.Authors", "AuthorName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "AuthorName", c => c.String(maxLength: 300));
            CreateIndex("dbo.Authors", "AuthorName");
        }
    }
}
