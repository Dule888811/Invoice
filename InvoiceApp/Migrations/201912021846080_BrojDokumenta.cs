namespace InvoiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BrojDokumenta : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Documents", new[] { "BrojDokument" });
            AlterColumn("dbo.Documents", "BrojDokument", c => c.String(maxLength: 10));
            CreateIndex("dbo.Documents", "BrojDokument", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Documents", new[] { "BrojDokument" });
            AlterColumn("dbo.Documents", "BrojDokument", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.Documents", "BrojDokument", unique: true);
        }
    }
}
