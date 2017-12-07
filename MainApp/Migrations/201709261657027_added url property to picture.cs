namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedurlpropertytopicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pictures", "Url");
        }
    }
}
