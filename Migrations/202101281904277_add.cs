namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddtoCarts", "name", c => c.String());
            AddColumn("dbo.AddtoCarts", "price", c => c.String());
            AddColumn("dbo.AddtoCarts", "noCategory", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AddtoCarts", "noCategory");
            DropColumn("dbo.AddtoCarts", "price");
            DropColumn("dbo.AddtoCarts", "name");
        }
    }
}
