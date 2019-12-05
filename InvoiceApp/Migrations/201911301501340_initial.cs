namespace InvoiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        BrojDokument = c.String(nullable: false, maxLength: 10),
                        BrojFakture = c.Int(nullable: false),
                        Ukupno = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.BrojDokument, unique: true);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RedniBroj = c.Int(nullable: false),
                        Cena = c.Double(nullable: false),
                        Kolicina = c.Double(nullable: false),
                        Ukupno = c.Double(nullable: false),
                        Document_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Documents", t => t.Document_id, cascadeDelete: true)
                .Index(t => t.RedniBroj, unique: true)
                .Index(t => t.Document_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Document_id", "dbo.Documents");
            DropIndex("dbo.Tasks", new[] { "Document_id" });
            DropIndex("dbo.Tasks", new[] { "RedniBroj" });
            DropIndex("dbo.Documents", new[] { "BrojDokument" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Documents");
        }
    }
}
