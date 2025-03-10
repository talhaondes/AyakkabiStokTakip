using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Abstract
{
    // Ürün Bilgileri
    public class Urun
    {
        public int UrunId { get; set; }

        [Required(ErrorMessage = "Ürün adı gereklidir.")]
        [StringLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter olabilir.")]
        public string UrunAdi { get; set; }

        [Required(ErrorMessage = "Fiyat gereklidir.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat sıfırdan büyük olmalıdır.")]
        public decimal Fiyat { get; set; }

        [Required(ErrorMessage = "Stok adedi gereklidir.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok adedi sıfır veya daha büyük olmalıdır.")]
        public int StokAdedi { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string UrunAciklamasi { get; set; }

        [Required(ErrorMessage = "Tedarikçi seçilmelidir.")]
        public int TedarikciId { get; set; } // Foreign Key

        public virtual Tedarikci Tedarikci { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public ICollection<StokTakip> Stoklar { get; set; } = new List<StokTakip>(); // Ürün-Mağaza ilişkisi

        // Kategori ile ilişki
        public int KategoriId { get; set; }  // Foreign Key
        public virtual Kategori Kategori { get; set; }  // Navigation property
    }

}
