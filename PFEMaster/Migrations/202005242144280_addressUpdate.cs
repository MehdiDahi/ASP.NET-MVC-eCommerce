namespace PFEMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addressUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "UserId", c => c.String());
            AddColumn("dbo.Addresses", "IsDefault", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "IsDefault");
            DropColumn("dbo.Addresses", "UserId");
        }
    }
}
