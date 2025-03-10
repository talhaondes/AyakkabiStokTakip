using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Data.Concrete;
using Data.Ef;
using Entities.Abstract;
using UI.Models;

namespace UI.Controllers
{
    public class UrunAlmaController : Controller
    {
        UrunSatinAlmaManager UrunSatinAlmaManager = new UrunSatinAlmaManager(new EfUrunSatinAlmaDal());
        UrunManager UrunManager = new UrunManager(new EfUrunDal());
        TedarikciManager TedarikciManager = new TedarikciManager(new EfTedarikciDal());
        MagazaManager MagazaManager = new MagazaManager(new EfMagazaDal());
        StokTakipManager stokTakipManager = new StokTakipManager(new EfStokTakipDal());



        public ActionResult Index()
        {
            var alinanUrunler = (from urunSatinAlma in UrunSatinAlmaManager.GetAll()
                                 join urun in UrunManager.GetAll() on urunSatinAlma.UrunId equals urun.UrunId
                                 join magaza in MagazaManager.GetAll() on urunSatinAlma.MagazaId equals magaza.MagazaId
                                 join tedarikci in TedarikciManager.GetAll() on urun.TedarikciId equals tedarikci.TedarikciId
                                 select new AlinanUrunler
                                 {
                                     UrunAdi = urun.UrunAdi,
                                     TedarikciAd = tedarikci.TedarikciAd,
                                     MagazaAdi = magaza.MagazaAdi,
                                     satinalinan = urunSatinAlma.PurchaseDate,
                                     odenenfiyat = urunSatinAlma.TotalAmount,
                                     durumu = urunSatinAlma.Status
                                 }).ToList();

            return View(alinanUrunler);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> urunList = (from x in UrunManager.GetAll()
                                             select new SelectListItem
                                             {
                                                 Text = x.UrunAdi,
                                                 Value = x.UrunId.ToString()
                                             }).ToList();
            ViewBag.Urunler = urunList;  // Verileri manuel olarak ViewBag'e ekleyin

            List<SelectListItem> urunList2 = (from x in UrunManager.GetAll()
                                              where x.StokAdedi > 0
                                              select new SelectListItem
                                              {
                                                  Text = x.UrunAdi,
                                                  Value = x.UrunId.ToString()
                                              }).ToList();
            ViewBag.Urunler1 = urunList2;

            List<SelectListItem> tedarikciList = (from x in TedarikciManager.GetAll()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.TedarikciAd,
                                                      Value = x.TedarikciId.ToString()
                                                  }).ToList();
            ViewBag.TedarikciList = tedarikciList;

            List<SelectListItem> magazaList = (from x in MagazaManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.MagazaAdi,
                                                   Value = x.MagazaId.ToString()
                                               }).ToList();
            ViewBag.MagazaList = magazaList;

            return View();
        }

        [HttpPost]
        public ActionResult Add(UrunSatinAlma urunSatinAlma)
        {
            if (ModelState.IsValid)
            {
                UrunSatinAlmaManager.UrunSatinAlmaAdd(urunSatinAlma);


                var urun = UrunManager.GetById(urunSatinAlma.UrunId);
                if (urun != null)
                {
                    urun.StokAdedi += (int)urunSatinAlma.TotalAmount;
                    UrunManager.UrunUpdate(urun);
                }
                return RedirectToAction("Index");
            }





            ViewBag.Urunler = UrunManager.GetAll();
            return View(urunSatinAlma);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(UrunSatinAlma urunSatinAlma)
        {
            if (ModelState.IsValid)
            {
                var urun = UrunManager.GetById(urunSatinAlma.UrunId);
                if (urun != null)
                {
                    if (urun.StokAdedi < urunSatinAlma.TotalAmount)
                    {
                        ModelState.AddModelError("", $"Yeterli stok bulunmamaktadır. Mevcut stok: {urun.StokAdedi}");

                        // Dropdown listeleri tekrar yükle
                        ViewBag.Urunler = UrunManager.GetAll()
                            .Select(x => new SelectListItem { Text = x.UrunAdi, Value = x.UrunId.ToString() })
                            .ToList();

                        ViewBag.Urunler1 = UrunManager.GetAll()
                            .Where(x => x.StokAdedi > 0)
                            .Select(x => new SelectListItem { Text = x.UrunAdi, Value = x.UrunId.ToString() })
                            .ToList();

                        ViewBag.MagazaList = MagazaManager.GetAll()
                            .Select(x => new SelectListItem { Text = x.MagazaAdi, Value = x.MagazaId.ToString() })
                            .ToList();

                        ViewBag.TedarikciList = TedarikciManager.GetAll()
                            .Select(x => new SelectListItem { Text = x.TedarikciAd, Value = x.TedarikciId.ToString() })
                            .ToList();

                        return View("Add", urunSatinAlma);
                    }
                    if (urunSatinAlma.UrunId == 0 || urunSatinAlma.MagazaId == 0)
                    {
                        ModelState.AddModelError("", "Geçerli bir ürün ve mağaza seçilmelidir.");
                    }

                    // Stok yeterliyse işlemi devam ettir
                    StokTakip stokTakipSilinen = new StokTakip
                    {
                        UrunId = urunSatinAlma.UrunId,
                        MagazaId = urunSatinAlma.MagazaId,
                        StokAdedi = (int)urunSatinAlma.TotalAmount,
                        Tarih = urunSatinAlma.PurchaseDate
                    };
                    stokTakipManager.StokTakipAdd(stokTakipSilinen);

                    urun.StokAdedi -= (int)urunSatinAlma.TotalAmount;

                    UrunManager.UrunUpdate(urun);
                }
                return RedirectToAction("Index");
            }

            return View(urunSatinAlma);
        }
    }
}
