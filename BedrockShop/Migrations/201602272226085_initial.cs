namespace BedrockShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SSN = c.Int(nullable: false),
                        Address = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderHeaders",
                c => new
                    {
                        OrderHeaderId = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderHeaderId)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrdetailId = c.Int(nullable: false, identity: true),
                        OrderHeadId = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderHeader_OrderHeaderId = c.Int(),
                    })
                .PrimaryKey(t => t.OrdetailId)
                .ForeignKey("dbo.OrderHeaders", t => t.OrderHeader_OrderHeaderId)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.OrderHeader_OrderHeaderId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Descripion = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        ShoppingCart_ShoppingCartId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCart_ShoppingCartId)
                .Index(t => t.ShoppingCart_ShoppingCartId);
            
            CreateTable(
                "dbo.ShoppingCartDetails",
                c => new
                    {
                        ShoppingCartDetailId = c.Int(nullable: false, identity: true),
                        ShoppingCartId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ShoppingCartDetailId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCarts", t => t.ShoppingCartId, cascadeDelete: true)
                .Index(t => t.ShoppingCartId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartId = c.Int(nullable: false, identity: true),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingCartId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCartDetails", "ShoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Products", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ShoppingCarts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ShoppingCartDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderHeader_OrderHeaderId", "dbo.OrderHeaders");
            DropForeignKey("dbo.OrderHeaders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.ShoppingCarts", new[] { "CustomerId" });
            DropIndex("dbo.ShoppingCartDetails", new[] { "ProductId" });
            DropIndex("dbo.ShoppingCartDetails", new[] { "ShoppingCartId" });
            DropIndex("dbo.Products", new[] { "ShoppingCart_ShoppingCartId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderHeader_OrderHeaderId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.OrderHeaders", new[] { "CustomerID" });
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.ShoppingCartDetails");
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.OrderHeaders");
            DropTable("dbo.Customers");
        }
    }
}
