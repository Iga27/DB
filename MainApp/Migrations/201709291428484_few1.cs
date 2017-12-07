namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class few1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Ident", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Ident");
        }
    }
}
