namespace PFEMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "ContactName", c => c.String());
            AlterColumn("dbo.Addresses", "Country", c => c.String());
            AlterColumn("dbo.Addresses", "Address", c => c.String());
            AlterColumn("dbo.Addresses", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "ZipCode", c => c.String(maxLength: 8));
            AlterColumn("dbo.Addresses", "Address", c => c.String(maxLength: 100));
            AlterColumn("dbo.Addresses", "Country", c => c.String(maxLength: 8));
            AlterColumn("dbo.Addresses", "ContactName", c => c.String(maxLength: 100));
        }
    }
}
