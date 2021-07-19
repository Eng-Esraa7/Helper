namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicines", "noOfCategory", c => c.Single(nullable: false));
            DropColumn("dbo.Medicines", "total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicines", "total", c => c.Single(nullable: false));
            DropColumn("dbo.Medicines", "noOfCategory");
        }
    }
}
