namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ferf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "Iden");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Iden", c => c.Int(nullable: false));
        }
    }
}
