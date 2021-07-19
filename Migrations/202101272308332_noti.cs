namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noti : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doners", "notification", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doners", "notification");
        }
    }
}
