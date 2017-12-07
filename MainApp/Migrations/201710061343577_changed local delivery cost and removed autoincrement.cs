namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedlocaldeliverycostandremovedautoincrement : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "LocalDeliveryCost", c => c.Double(nullable: false));
            AlterColumn("dbo.Publishers", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Years", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Years", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Publishers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Books", "LocalDeliveryCost", c => c.Int(nullable: false));
        }
    }
}
