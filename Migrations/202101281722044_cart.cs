namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddtoCarts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        medecineId = c.Int(nullable: false),
                        medicines_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Medicines", t => t.medicines_id)
                .Index(t => t.medicines_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddtoCarts", "medicines_id", "dbo.Medicines");
            DropIndex("dbo.AddtoCarts", new[] { "medicines_id" });
            DropTable("dbo.AddtoCarts");
        }
    }
}
