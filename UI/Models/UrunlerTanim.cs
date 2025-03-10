using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Concrete;
using Data.Ef;

namespace UI.Models
{
    public class UrunlerTanim
    {
        public int UrunId { get; set; } 
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int StokAdedi { get; set; }
        public string UrunAciklamasi { get; set; }
        public string TedarikciAd { get; set; }
    }
}