namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1mg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Magazas", "MagazaAdi", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Magazas", "MagazaAdres", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Uruns", "UrunAdi", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Uruns", "UrunAciklamasi", c => c.String(maxLength: 500));
            AlterColumn("dbo.Tedarikcis", "TedarikciAd", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tedarikcis", "TedarikciTelefon", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Tedarikcis", "TedarikciEmail", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.UrunSatinAlmas", "Status", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UrunSatinAlmas", "Status", c => c.String());
            AlterColumn("dbo.Tedarikcis", "TedarikciEmail", c => c.String());
            AlterColumn("dbo.Tedarikcis", "TedarikciTelefon", c => c.String());
            AlterColumn("dbo.Tedarikcis", "TedarikciAd", c => c.String());
            AlterColumn("dbo.Uruns", "UrunAciklamasi", c => c.String());
            AlterColumn("dbo.Uruns", "UrunAdi", c => c.String());
            AlterColumn("dbo.Magazas", "MagazaAdres", c => c.String());
            AlterColumn("dbo.Magazas", "MagazaAdi", c => c.String());
        }
    }
}
