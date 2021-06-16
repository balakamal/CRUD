namespace CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemInCart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodItems", t => t.ItemInCart_Id)
                .Index(t => t.ItemInCart_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ItemInCart_Id", "dbo.FoodItems");
            DropIndex("dbo.Carts", new[] { "ItemInCart_Id" });
            DropTable("dbo.Carts");
        }
    }
}
