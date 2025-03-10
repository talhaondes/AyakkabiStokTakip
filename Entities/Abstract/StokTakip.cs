using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    // Stok Takip
    public class StokTakip
    {
        public int StokTakipId { get; set; }
        public int UrunId { get; set; }  // Foreign Key
        public virtual Urun Urun { get; set; }
        public int MagazaId { get; set; } // Foreign Key
        public virtual Magaza Magaza { get; set; }
        public int StokAdedi { get; set; }
        public DateTime Tarih { get; set; }
    }



}
