namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lsa : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Categories", "Id");
            // AddColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: false));
            // AddColumn("dbo.Categories", "Identificator", c => c.Int(nullable: false));
            CreateTable(
                 "dbo.Categories",
                 c => new
                 {
                     Id = c.Int(nullable: false, identity: false),
                     ParentId = c.Int(nullable: false),
                     Name = c.String(),
                 })
                 .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Identificator");
        }
    }
}
