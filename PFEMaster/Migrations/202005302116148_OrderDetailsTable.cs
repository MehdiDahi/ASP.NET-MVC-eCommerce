namespace PFEMaster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDetailsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailsId = c.Int(nullable: false, identity: true),
                        Qte = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Order_OrderId = c.Int(),
                        Products_ProductsId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderDetailsId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .ForeignKey("dbo.Products", t => t.Products_ProductsId)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Products_ProductsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Products_ProductsId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "Products_ProductsId" });
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderId" });
            DropTable("dbo.OrderDetails");
        }
    }
}
