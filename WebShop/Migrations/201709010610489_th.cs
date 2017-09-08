namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class th : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AddressInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AddressInfoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        ZipCode = c.Int(nullable: false),
                        TelephoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
