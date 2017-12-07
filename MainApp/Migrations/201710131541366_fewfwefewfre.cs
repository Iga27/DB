namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewfwefewfre : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Years", "YearName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Years", "YearName", c => c.Int(nullable: false));
        }
    }
}
