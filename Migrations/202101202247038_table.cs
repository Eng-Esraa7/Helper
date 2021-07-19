namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        NoOfPiece = c.Int(nullable: false),
                        price = c.Single(nullable: false),
                        pharmecyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Pharmecies", t => t.pharmecyId, cascadeDelete: true)
                .Index(t => t.pharmecyId);
            
            CreateTable(
                "dbo.Pharmecies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.medicines",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        NoOfPiece = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.Medicines", "pharmecyId", "dbo.Pharmecies");
            DropIndex("dbo.Medicines", new[] { "pharmecyId" });
            DropTable("dbo.Pharmecies");
            DropTable("dbo.Medicines");
        }
    }
}
