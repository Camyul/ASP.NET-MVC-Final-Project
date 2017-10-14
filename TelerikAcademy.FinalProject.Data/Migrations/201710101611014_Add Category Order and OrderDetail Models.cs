//namespace TelerikAcademy.FinalProject.Data.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class AddCategoryOrderandOrderDetailModels : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Categories",
//                c => new
//                    {
//                        Id = c.Guid(nullable: false),
//                        Name = c.String(nullable: false, maxLength: 40),
//                        IsDeleted = c.Boolean(nullable: false),
//                        DeletedOn = c.DateTime(),
//                        CreatedOn = c.DateTime(),
//                        ModifiedOn = c.DateTime(),
//                    })
//                .PrimaryKey(t => t.Id)
//                .Index(t => t.Name, unique: true)
//                .Index(t => t.IsDeleted);
            
//            AddColumn("dbo.Products", "LongDescription", c => c.String(storeType: "ntext"));
//            AddColumn("dbo.Products", "CategoryId", c => c.Guid());
//            CreateIndex("dbo.Products", "CategoryId");
//            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id");
//        }
        
//        public override void Down()
//        {
//            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
//            DropIndex("dbo.Categories", new[] { "IsDeleted" });
//            DropIndex("dbo.Categories", new[] { "Name" });
//            DropIndex("dbo.Products", new[] { "CategoryId" });
//            DropColumn("dbo.Products", "CategoryId");
//            DropColumn("dbo.Products", "LongDescription");
//            DropTable("dbo.Categories");
//        }
//    }
//}
