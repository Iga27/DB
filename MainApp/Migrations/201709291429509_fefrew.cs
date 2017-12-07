namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fefrew : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "Ident");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Ident", c => c.String());
        }
    }
}
