namespace PFEMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleViewModels",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);
            DropTable("dbo.RoleViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoleViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
