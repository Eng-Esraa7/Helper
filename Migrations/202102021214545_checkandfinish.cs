namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkandfinish : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddtoCarts", "check", c => c.Boolean(nullable: false));
            AddColumn("dbo.checkOuts", "finish", c => c.Boolean(nullable: false));
            AlterColumn("dbo.checkOuts", "FullName", c => c.String(nullable: false));
            DropColumn("dbo.checkOuts", "medName");
            DropColumn("dbo.checkOuts", "NoOfCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.checkOuts", "NoOfCategory", c => c.Int(nullable: false));
            AddColumn("dbo.checkOuts", "medName", c => c.String());
            AlterColumn("dbo.checkOuts", "FullName", c => c.String());
            DropColumn("dbo.checkOuts", "finish");
            DropColumn("dbo.AddtoCarts", "check");
        }
    }
}
