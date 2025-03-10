namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false, maxLength: 100),
                        KategoriAciklamasi = c.String(maxLength: 500),
                        Durum = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.KategoriId);
            
            AddColumn("dbo.Uruns", "KategoriId", c => c.Int(nullable: false));
            CreateIndex("dbo.Uruns", "KategoriId");
            AddForeignKey("dbo.Uruns", "KategoriId", "dbo.Kategoris", "KategoriId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Uruns", "KategoriId", "dbo.Kategoris");
            DropIndex("dbo.Uruns", new[] { "KategoriId" });
            DropColumn("dbo.Uruns", "KategoriId");
            DropTable("dbo.Kategoris");
        }
    }
}
