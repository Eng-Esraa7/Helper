namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class medid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddtoCarts", "medId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AddtoCarts", "medId");
        }
    }
}
