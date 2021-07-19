namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AddtoCarts", "medicines_id", "dbo.Medicines");
            DropIndex("dbo.AddtoCarts", new[] { "medicines_id" });
            AddColumn("dbo.AddtoCarts", "UserId", c => c.String());
            DropColumn("dbo.AddtoCarts", "medecineId");
            DropColumn("dbo.AddtoCarts", "medicines_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AddtoCarts", "medicines_id", c => c.Int());
            AddColumn("dbo.AddtoCarts", "medecineId", c => c.String());
            DropColumn("dbo.AddtoCarts", "UserId");
            CreateIndex("dbo.AddtoCarts", "medicines_id");
            AddForeignKey("dbo.AddtoCarts", "medicines_id", "dbo.Medicines", "id");
        }
    }
}
