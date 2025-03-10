using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Data.Ef;
using Entities.Abstract;
using Microsoft.Ajax.Utilities;
using UI.Models;

namespace UI.Controllers
{
    public class UrunController : Controller
    {
        UrunManager um = new UrunManager(new EfUrunDal());
        MagazaManager MagazaManager = new MagazaManager(new EfMagazaDal());
        TedarikciManager TedarikciManager = new TedarikciManager(new EfTedarikciDal());
        UrunSatinAlmaManager usm = new UrunSatinAlmaManager(new EfUrunSatinAlmaDal());
        KategoriManager km=new KategoriManager(new EfKategoriDal());


        // GET: Urun
        [HttpGet]
        public ActionResult Index()
        {
            var tedarikciList = TedarikciManager.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.TedarikciAd,  // Tedarikçi adı
                    Value = x.TedarikciId.ToString()  // Tedarikçi ID'si
                }).ToList();

            ViewBag.TedarikciList = tedarikciList;

            // Başlangıçta tüm ürünleri getiriyoruz
            var urunlerTanim = (from urun in um.GetAll()
                                join tedarikci in TedarikciManager.GetAll()
                                on urun.TedarikciId equals tedarikci.TedarikciId
                                select new UrunlerTanim
                                {
                                    UrunId = urun.UrunId,
                                    UrunAdi = urun.UrunAdi,
                                    Fiyat = urun.Fiyat,
                                    StokAdedi = urun.StokAdedi,
                                    UrunAciklamasi = urun.UrunAciklamasi,
                                    TedarikciAd = tedarikci.TedarikciAd
                                }).ToList();

            return View(urunlerTanim);
        }

        [HttpPost]
        public ActionResult Index(int selectedTedarikciId)
        {
            var tedarikciList = TedarikciManager.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.TedarikciAd,
                    Value = x.TedarikciId.ToString()
                }).ToList();

            ViewBag.TedarikciList = tedarikciList;

            // Seçilen tedarikçiye göre ürünleri filtreleyin
            var urunlerTanim = (from urun in um.GetAll()
                                join tedarikci in TedarikciManager.GetAll()
                                on urun.TedarikciId equals tedarikci.TedarikciId
                                where urun.TedarikciId == selectedTedarikciId
                                select new UrunlerTanim
                                {
                                    UrunId = urun.UrunId,
                                    UrunAdi = urun.UrunAdi,
                                    Fiyat = urun.Fiyat,
                                    StokAdedi = urun.StokAdedi,
                                    UrunAciklamasi = urun.UrunAciklamasi,
                                    TedarikciAd = tedarikci.TedarikciAd
                                }).ToList();

            // Seçilen tedarikçiyi ViewBag'de gönderiyoruz
            ViewBag.selectedTedarikciId = selectedTedarikciId;

            return View(urunlerTanim);
        }


        [HttpGet]
        public ActionResult Add()
        {
            // Tedarikçi listesi
            var tedarikciList = TedarikciManager.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.TedarikciAd,  // Tedarikçi adı
                    Value = x.TedarikciId.ToString()  // Tedarikçi ID'si
                }).ToList();
            ViewBag.TedarikciList = tedarikciList;

            // Mağaza listesi
            var magazaList = MagazaManager.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.MagazaAdi,  // Mağaza adı
                    Value = x.MagazaId.ToString()  // Mağaza ID'si
                }).ToList();
            ViewBag.MagazaList = magazaList;

            // Kategori listesi
            var kategoriList = km.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.KategoriAdi,
                    Value = x.KategoriId.ToString()
                }).ToList();
            ViewBag.kategoriList = kategoriList;  // Burada doğru bir şekilde ViewBag'e set ediyoruz.

            return View();
        }
        [HttpPost]
        public ActionResult Add(Urun urun)
        {
            var olanurun = um.GetAll().FirstOrDefault(x => x.UrunAdi == urun.UrunAdi);
            if (olanurun != null)
            {
                TempData["ErrorMessage"] = "Bu ürün adı zaten mevcut.";
                return RedirectToAction("Add", "Urun");  // Burada Add action'ını doğru şekilde çağırıyoruz.
            }
            else if (ModelState.IsValid)
            {
                // Urun ekleme işlemi
                um.UrunAdd(urun);
                return RedirectToAction("Index", "Urun");  // Index action'ına yönlendiriyoruz.
            }

            return View(urun);
        }






        [HttpGet]
        public ActionResult Edit(int id)
        {
            var urun = um.GetById(id);
            if (urun == null)
            {
                return HttpNotFound();
            }

            // Tedarikçi listesi
            var tedarikciListesi = TedarikciManager.GetAll()
                .Select(x => new SelectListItem
                {
                    Text = x.TedarikciAd,  // Tedarikçi adı
                    Value = x.TedarikciId.ToString()  // Tedarikçi ID'si
                }).ToList();

            ViewBag.TedarikciListesi = tedarikciListesi;

            return View(urun);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Urun urun)
        {
            if (ModelState.IsValid)
            {
                var mevcutUrun = um.GetById(urun.UrunId);
                if (mevcutUrun == null)
                {
                    return HttpNotFound();
                }

                mevcutUrun.UrunAdi = urun.UrunAdi;
                mevcutUrun.Fiyat = urun.Fiyat;
                mevcutUrun.StokAdedi = urun.StokAdedi;
                mevcutUrun.UrunAciklamasi = urun.UrunAciklamasi;
                mevcutUrun.TedarikciId = urun.TedarikciId; // Tedarikçi ID'sini güncelledik


                um.UrunUpdate(mevcutUrun);

                return RedirectToAction("Index");
            }

            var tedarikciListesi = TedarikciManager.GetAll()
                   .Select(x => new SelectListItem
                   {
                       Text = x.TedarikciAd,
                       Value = x.TedarikciId.ToString()
                   }).ToList();

            ViewBag.TedarikciListesi = tedarikciListesi;

            return View(urun);
        }





        [HttpGet]
        public ActionResult Delete(int id)
        {
            var urun = um.GetById(id);

            if (urun == null)
            {
                return HttpNotFound(); // Ürün bulunamazsa hata döndür
            }

            return View(urun); // Kullanıcıya silme onayı sayfasını göster
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var urun = um.GetById(id);

            if (urun == null)
            {
                return HttpNotFound(); // Eğer ürün yoksa hata döndür
            }

            try
            {
                um.UrunDelete(urun); // Ürünü sil
                return RedirectToAction("Index"); // Başarılı ise listeye dön
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ürün silinirken bir hata oluştu: " + ex.Message);
                return View(urun); // Hata mesajını göstererek aynı sayfada kal
            }
        }


    }
}