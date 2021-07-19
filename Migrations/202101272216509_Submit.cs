namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Submit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Submits",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Phone = c.String(),
                        DonersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Doners", t => t.DonersId, cascadeDelete: true)
                .Index(t => t.DonersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submits", "DonersId", "dbo.Doners");
            DropIndex("dbo.Submits", new[] { "DonersId" });
            DropTable("dbo.Submits");
        }
    }
}
