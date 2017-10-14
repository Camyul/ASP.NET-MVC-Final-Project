namespace TelerikAcademy.FinalProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixErrors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 40),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderId = c.Guid(),
                        ProductId = c.Guid(),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderedDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HasBeenConfirmed = c.Boolean(nullable: false),
                        HasBeenShipped = c.Boolean(nullable: false),
                        HasBeenClosed = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CustomerID = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 40),
                        LastName = c.String(nullable: false, maxLength: 40),
                        PhoneNumber = c.String(nullable: false),
                        AddressLine = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 40),
                        Area = c.String(nullable: false, maxLength: 40),
                        PostCode = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerID)
                .Index(t => t.CustomerID)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.Products", "LongDescription", c => c.String(storeType: "ntext"));
            AddColumn("dbo.Products", "CategoryId", c => c.Guid());
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ContactInfoes", "CustomerID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ContactInfoes", new[] { "IsDeleted" });
            DropIndex("dbo.ContactInfoes", new[] { "CustomerID" });
            DropIndex("dbo.Orders", new[] { "IsDeleted" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderDetails", new[] { "IsDeleted" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "IsDeleted" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "LongDescription");
            DropTable("dbo.ContactInfoes");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Categories");
        }
    }
}
