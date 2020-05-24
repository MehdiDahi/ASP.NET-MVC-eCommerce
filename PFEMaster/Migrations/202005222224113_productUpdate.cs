namespace PFEMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductImagePath", c => c.String(nullable: false));
        }
    }
}
