namespace WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prva : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "imageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "imageURL");
        }
    }
}
