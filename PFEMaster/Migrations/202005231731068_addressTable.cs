namespace PFEMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addressTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressesId = c.Int(nullable: false, identity: true),
                        ContactName = c.String(maxLength: 100),
                        Country = c.String(maxLength: 8),
                        Address = c.String(maxLength: 100),
                        ZipCode = c.String(maxLength: 8),
                        Mobile = c.String(maxLength: 10),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AddressesId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Addresses", new[] { "UserId" });
            DropTable("dbo.Addresses");
        }
    }
}
