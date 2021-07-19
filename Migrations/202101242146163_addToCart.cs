namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addToCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicines", "addToCart", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medicines", "addToCart");
        }
    }
}
