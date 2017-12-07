namespace MainApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedautoincrementinAuthors : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "Id", c => c.Int(nullable: false, identity: true));
        }
    }
}
