namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.checkOuts", "medName", c => c.String());
            AddColumn("dbo.checkOuts", "NoOfCategory", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.checkOuts", "NoOfCategory");
            DropColumn("dbo.checkOuts", "medName");
        }
    }
}
