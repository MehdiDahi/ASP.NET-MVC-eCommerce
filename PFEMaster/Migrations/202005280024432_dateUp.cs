namespace PFEMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateUp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "CreatedDate");
            DropColumn("dbo.Products", "ModifiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
