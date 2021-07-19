namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.checkOuts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.checkOuts");
        }
    }
}
