namespace BedrockShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Products", "ShoppingCart_ShoppingCartId", c => c.Int());
            CreateIndex("dbo.Products", "ShoppingCart_ShoppingCartId");
            AddForeignKey("dbo.Products", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ShoppingCart_ShoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.ShoppingCarts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ShoppingCarts", new[] { "CustomerId" });
            DropIndex("dbo.Products", new[] { "ShoppingCart_ShoppingCartId" });
            DropColumn("dbo.Products", "ShoppingCart_ShoppingCartId");
            DropTable("dbo.ShoppingCarts");
        }
    }
}
