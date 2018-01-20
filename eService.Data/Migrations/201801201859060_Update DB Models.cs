namespace eService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDBModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "WarrantyCardNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "WarrantyCardDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Article", c => c.String());
            AddColumn("dbo.Orders", "Defect", c => c.String());
            DropColumn("dbo.Orders", "InvoiceNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "InvoiceNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Defect");
            DropColumn("dbo.Orders", "Article");
            DropColumn("dbo.Orders", "WarrantyCardDate");
            DropColumn("dbo.Orders", "WarrantyCardNumber");
        }
    }
}
