namespace eService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorDBconstraints : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Towns", new[] { "Name" });
            AlterColumn("dbo.Towns", "Name", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.Towns", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Towns", new[] { "Name" });
            AlterColumn("dbo.Towns", "Name", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Towns", "Name", unique: true);
        }
    }
}
