namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dewd : DbMigration
    {
        public override void Up()
        {
           // DropColumn("dbo.Categories", "Identificator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Identificator", c => c.Int(nullable: false));
        }
    }
}
