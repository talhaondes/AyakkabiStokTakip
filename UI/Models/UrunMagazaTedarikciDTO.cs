using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Abstract;
using UI.Models;




namespace UI.Models
{
    public class UrunMagazaTedarikciDTO
    {
        public string UrunAdi { get; set; }
        public string MagazaAdi { get; set; }
        public string TedarikciAd { get; set; }
        public int StokAdedi { get; set; }
        public DateTime SiparisTarihi { get; set; } 
    }
}