//namespace TelerikAcademy.FinalProject.Data.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class AddContactInfoandsomepropertiesforothermodels : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.OrderDetails",
//                c => new
//                    {
//                        Id = c.Guid(nullable: false),
//                        OrderId = c.Guid(),
//                        ProductId = c.Guid(),
//                        Quantity = c.Int(nullable: false),
//                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        OrderedDate = c.DateTime(nullable: false),
//                        IsDeleted = c.Boolean(nullable: false),
//                        DeletedOn = c.DateTime(),
//                        CreatedOn = c.DateTime(),
//                        ModifiedOn = c.DateTime(),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Orders", t => t.OrderId)
//                .ForeignKey("dbo.Products", t => t.ProductId)
//                .Index(t => t.OrderId)
//                .Index(t => t.ProductId)
//                .Index(t => t.IsDeleted);
            
//        }
        
//        public override void Down()
//        {
//            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
//            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
//            DropIndex("dbo.OrderDetails", new[] { "IsDeleted" });
//            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
//            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
//            DropTable("dbo.OrderDetails");
//        }
//    }
//}
