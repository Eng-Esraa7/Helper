namespace Helper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactUs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Message = c.String(maxLength: 100),
                        PhoneNumber = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactUs");
        }
    }
}
