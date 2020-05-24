namespace PFEMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productUpdateImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageUrl", c => c.String(nullable: false));
            DropColumn("dbo.Products", "ProductImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductImagePath", c => c.String());
            DropColumn("dbo.Products", "ImageUrl");
        }
    }
}
