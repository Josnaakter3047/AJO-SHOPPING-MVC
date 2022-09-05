namespace MvcECommerceWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomersId = c.Guid(nullable: false),
                        UserName = c.String(),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomersId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
