using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Data.Ef;
using UI.Models;

namespace UI.Controllers
{
    public class StokTakipController : Controller
    {
        TedarikciManager TedarikciManager = new TedarikciManager(new EfTedarikciDal());
        UrunManager um = new UrunManager(new EfUrunDal());
        MagazaManager mag = new MagazaManager(new EfMagazaDal());
        StokTakipManager stok = new StokTakipManager(new EfStokTakipDal());
        UrunSatinAlmaManager UrunSatinAlmaManager = new UrunSatinAlmaManager(new EfUrunSatinAlmaDal());


        public ActionResult Index()
        {
            // Gönderilen ürünlerin bilgilerini alıyoruz
            var gonderilenUrunler = (from stokTakip in stok.GetAll()
                                     join urun in um.GetAll() on stokTakip.UrunId equals urun.UrunId
                                     join magaza in mag.GetAll() on stokTakip.MagazaId equals magaza.MagazaId
                                     join urunSatinAlma in UrunSatinAlmaManager.GetAll() on stokTakip.UrunId equals urunSatinAlma.UrunId
                                     select new GonderilenUrunler
                                     {
                                         UrunAdi = urun.UrunAdi,
                                         MagazaAdi = magaza.MagazaAdi,
                                         gonderilentarih = stokTakip.Tarih,
                                         gonderilenadet = stokTakip.StokAdedi,
                                         durumu = urunSatinAlma.Status  // Durum burada alınmalı
                                     }).ToList();

            return View(gonderilenUrunler);
        }

    }
}