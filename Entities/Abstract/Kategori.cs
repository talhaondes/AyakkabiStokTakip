using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Abstract
{
    public class Kategori
    {
        public int KategoriId { get; set; }

        [Required(ErrorMessage = "Kategori adı gereklidir.")]
        [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
        public string KategoriAdi { get; set; }

        [StringLength(500, ErrorMessage = "Kategori açıklaması en fazla 500 karakter olabilir.")]
        public string KategoriAciklamasi { get; set; }

        // Ürünler ile ilişki (Bir kategoriye birden fazla ürün ait olabilir)
        public ICollection<Urun> Urunler { get; set; } = new List<Urun>();

        // Kategoriye ait durum bilgisi (örneğin aktif ya da pasif)
        [StringLength(50, ErrorMessage = "Durum en fazla 50 karakter olabilir.")]
        public string Durum { get; set; } // Örn: "Aktif", "Pasif"
    }

}
