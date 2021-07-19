namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AddtoCarts", "price", c => c.Single(nullable: false));
            AlterColumn("dbo.Medicines", "noOfCategory", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Medicines", "noOfCategory", c => c.String());
            AlterColumn("dbo.AddtoCarts", "price", c => c.String());
        }
    }
}
