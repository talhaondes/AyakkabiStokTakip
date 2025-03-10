using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Abstract
{
    // Tedarikçi Bilgileri
    public class Tedarikci
    {
        public int TedarikciId { get; set; }

        [Required(ErrorMessage = "Tedarikçi adı gereklidir.")]
        [StringLength(100, ErrorMessage = "Tedarikçi adı en fazla 100 karakter olabilir.")]
        public string TedarikciAd { get; set; }

        [Required(ErrorMessage = "Tedarikçi telefon numarası gereklidir.")]
        [Phone(ErrorMessage = "Geçersiz telefon numarası formatı.")]
        [StringLength(15, ErrorMessage = "Telefon numarası en fazla 15 karakter olabilir.")]
        public string TedarikciTelefon { get; set; }

        [Required(ErrorMessage = "Tedarikçi email adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçersiz email formatı.")]
        [StringLength(100, ErrorMessage = "Email adresi en fazla 100 karakter olabilir.")]
        public string TedarikciEmail { get; set; }

        public ICollection<Urun> Urunler { get; set; } = new List<Urun>();
    }
}
