using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class GonderilenUrunler
    {
        public string UrunAdi { get; set; }
        public string MagazaAdi { get; set; }
        public DateTime gonderilentarih { get; set; }
        public int gonderilenadet { get; set; }
        public string durumu { get; set; }  // Durum özelliği burada tanımlı olmalı
    }

}