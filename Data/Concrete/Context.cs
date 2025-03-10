using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Data.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }    //kategoriler tablosu
        public DbSet<Urun> Urunler { get; set; } // Ürün tablosu
        public DbSet<Magaza> Magazalar { get; set; } // Mağazalar tablosu
        public DbSet<StokTakip> StokTakipleri { get; set; } // Stok takip tablosu
        public DbSet<Tedarikci> Tedarikciler { get; set; } // Tedarikçiler tablosu
        public DbSet<UrunSatinAlma> UrunSatinAlmalari { get; set; } // Ürün satın alma tablosu
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // UrunSatinAlma → Urun FK ilişkisinde silme işlemini iptal et
            modelBuilder.Entity<UrunSatinAlma>()
                .HasRequired(u => u.Urun)
                .WithMany()
                .HasForeignKey(u => u.UrunId)
                .WillCascadeOnDelete(false);

            // UrunSatinAlma → Tedarikci FK ilişkisinde silme işlemini iptal et
            modelBuilder.Entity<UrunSatinAlma>()
                .HasRequired(u => u.Tedarikci)
                .WithMany()
                .HasForeignKey(u => u.TedarikciId)
                .WillCascadeOnDelete(false);
        }

    }
}
