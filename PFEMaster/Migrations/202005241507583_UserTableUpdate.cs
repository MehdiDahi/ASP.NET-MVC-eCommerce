namespace PFEMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetRoles", "ApplicationUser_Id");
            AddForeignKey("dbo.AspNetRoles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "UserRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
            DropForeignKey("dbo.AspNetRoles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetRoles", "ApplicationUser_Id");
        }
    }
}
