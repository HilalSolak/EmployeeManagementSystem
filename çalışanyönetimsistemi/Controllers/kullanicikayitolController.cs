using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using çalışanyönetimsistemi.Models.Baglantisql;

namespace çalışanyönetimsistemi.Controllers
{
    public class kullanicikayitolController : Controller
    {
        // GET: kullanicikayitol
        çalışanyönetimsistemiEntities2 veri = new çalışanyönetimsistemiEntities2();
        [HttpGet]
        public ActionResult KullaniciKayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KullaniciKayit(kullaniciadi x1)
        {
            if (x1.ad == null || x1.soyad == null || x1.email == null || x1.tel == null || x1.kullaniciadi == null || x1.şifre == null)
            {
                Response.Write("<script lang='JavaScript'>alert('Tüm alanları doldurun!');</script>");
                return View();
            }
            else
            {
                veri.kullanicigirişi.Add(x1);
                veri.SaveChanges();
                Response.Write("<script lang='JavaScript'>alert('Kullanıcı başarıyla eklenmiştir.');</script>");
                return RedirectToAction("KullanıcıGiriş", "kullanıcıgiriş");
            }

        }
    }
}