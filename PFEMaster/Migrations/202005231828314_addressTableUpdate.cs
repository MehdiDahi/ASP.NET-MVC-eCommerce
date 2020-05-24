namespace PFEMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addressTableUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Addresses", name: "UserId", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Addresses", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Addresses", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Addresses", name: "ApplicationUser_Id", newName: "UserId");
        }
    }
}
