namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dadddd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Books", "Identificator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Identificator", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false));
        }
    }
}
