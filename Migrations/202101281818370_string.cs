namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AddtoCarts", "medecineId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AddtoCarts", "medecineId", c => c.Int(nullable: false));
        }
    }
}
