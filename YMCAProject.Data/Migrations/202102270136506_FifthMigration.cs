namespace YMCAProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Invoices", "InvoiceNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "InvoiceNumber", c => c.Int(nullable: false));
        }
    }
}
