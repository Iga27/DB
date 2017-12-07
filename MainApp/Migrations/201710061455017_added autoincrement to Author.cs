namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedautoincrementtoAuthor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "Id", c => c.Int(nullable: false));
        }
    }
}
