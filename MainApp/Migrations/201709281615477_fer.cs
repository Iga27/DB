namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Iden", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Iden");
        }
    }
}
