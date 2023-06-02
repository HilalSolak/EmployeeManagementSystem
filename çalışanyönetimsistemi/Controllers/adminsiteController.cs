using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using çalışanyönetimsistemi.Models.Baglantisql;

namespace çalışanyönetimsistemi.Controllers
{
    public class adminsiteController : Controller
    {
        // GET: adminsite
        çalışanyönetimsistemiEntities2 veri = new çalışanyönetimsistemiEntities2();

        public ActionResult Index()
        {
            var veriler = veri.çalışanbilgileri.ToList();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult ÇalışanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ÇalışanEkle(çalışanbilgileri y)
        {
            if (y.çalışanad == null || y.soyad == null || y.tc == null || y.işebaşlamatarihi == null || y.görev == null || y.maaş == null)
            {
                Response.Write("<script lang='JavaScript'>alert('LÜTFEN TÜM ALANLARI DOLDURUN!');</script>");
                return View();
            }
            else
            {
                veri.çalışanbilgileri.Add(y);
                veri.SaveChanges();
                Response.Write("<script lang='JavaScript'>alert('Çalışan Eklenmiştir.');</script>");
                return RedirectToAction("Index", "adminsite");
            }

        }
        public ActionResult İzinTalepListesi()
        {
            var izintaleplisteçek = veri.izintalep.ToList();
            return View(izintaleplisteçek);
        }
        public ActionResult AvansTalepListesi()
        {
            var avanstaleplistesi = veri.avanstalep.ToList();
            return View(avanstaleplistesi);
        }
        public ActionResult KullanıcıBilgileri()
        {
            var kullanıcıbilgileri = veri.kullanicigirişi.ToList();
            return View(kullanıcıbilgileri);
        }
        public ActionResult GelenMesajlar()
        {
            var gelenmesajlar = veri.iletişim.ToList();
            return View(gelenmesajlar);
        }
        public ActionResult SIL(int id)
        {
            var çalışanbilgileri = veri.çalışanbilgileri.Find(id);
            veri.çalışanbilgileri.Remove(çalışanbilgileri);
            veri.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÇalışanBilgiGetir(int id)
        {
            var doldur = veri.çalışanbilgileri.Find(id);
            return View("ÇalışanBilgiGetir", doldur);

        }
        public ActionResult Guncelle(çalışanbilgileri p1)
        {
            var doldur = veri.çalışanbilgileri.Find(p1.çalışanid);
            doldur.çalışanad = p1.çalışanad;
            doldur.soyad = p1.soyad;
            doldur.tc = p1.tc;
            doldur.işebaşlamatarihi = p1.işebaşlamatarihi;
            doldur.görev = p1.görev;
            doldur.maaş = p1.maaş;
            veri.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}