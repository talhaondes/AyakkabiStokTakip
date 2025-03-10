using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Abstract
{
    public class Magaza
    {
        public int MagazaId { get; set; }

        [Required(ErrorMessage = "Mağaza adı gereklidir.")]
        [StringLength(100, ErrorMessage = "Mağaza adı en fazla 100 karakter olabilir.")]
        public string MagazaAdi { get; set; }

        [Required(ErrorMessage = "Mağaza adresi gereklidir.")]
        [StringLength(200, ErrorMessage = "Mağaza adresi en fazla 200 karakter olabilir.")]
        public string MagazaAdres { get; set; }

        public ICollection<StokTakip> Stoklar { get; set; } = new List<StokTakip>();

        public ICollection<Tedarikci> Tedarikciler { get; set; } = new List<Tedarikci>();
    }
}
