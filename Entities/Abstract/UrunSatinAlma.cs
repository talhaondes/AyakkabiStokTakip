using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Abstract
{
    // Ürün Satın Alma İşlemleri
    public class UrunSatinAlma
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tedarikçi seçilmelidir.")]
        public int TedarikciId { get; set; } // Foreign Key
        public Tedarikci Tedarikci { get; set; }

        [Required(ErrorMessage = "Ürün seçilmelidir.")]
        public int UrunId { get; set; } // Foreign Key
        public virtual Urun Urun { get; set; }

        [Required(ErrorMessage = "Mağaza seçilmelidir.")]
        public int MagazaId { get; set; } // Foreign Key - Ürün hangi mağazaya alındı?
        public virtual Magaza Magaza { get; set; }

        [Required(ErrorMessage = "Satın alma tarihi gereklidir.")]
        [DataType(DataType.Date, ErrorMessage = "Geçersiz tarih formatı.")]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Toplam tutar gereklidir.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Toplam tutar sıfırdan büyük olmalıdır.")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Durum gereklidir.")]
        [StringLength(50, ErrorMessage = "Durum en fazla 50 karakter olabilir.")]
        public string Status { get; set; } // Örn: "Beklemede", "Tamamlandı"
    }
}
