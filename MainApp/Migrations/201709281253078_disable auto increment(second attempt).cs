namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disableautoincrementsecondattempt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Name2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Name2");
        }
    }
}
