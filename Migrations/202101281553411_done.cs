namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class done : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submits", "done", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submits", "done");
        }
    }
}
