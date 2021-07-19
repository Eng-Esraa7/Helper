namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.checkOuts", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.checkOuts", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.checkOuts", "FullName", c => c.String(nullable: false));
            DropColumn("dbo.checkOuts", "UserId");
        }
    }
}
