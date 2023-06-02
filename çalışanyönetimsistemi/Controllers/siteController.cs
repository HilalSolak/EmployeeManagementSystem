using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using çalışanyönetimsistemi.Models.Baglantisql;

namespace çalışanyönetimsistemi.Controllers
{
    public class siteController : Controller
    {
        // GET: site
        çalışanyönetimsistemiEntities2 veri = new çalışanyönetimsistemiEntities2();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult İzinTalepEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult İzinTalepEkle(izintalep y)
        {
            if (y.çalışanad == null || y.soyad == null || y.tc == null || y.izinbaslangıctarihi == null || y.istenilenizinmiktar == null || y.açıklama == null)
            {
                Response.Write("<script lang='JavaScript'>alert('LÜTFEN TÜM ALANLARI DOLDURUN!');</script>");
                return View();
            }
            else
            {
                veri.izintalep.Add(y);
                veri.SaveChanges();
                Response.Write("<script lang='JavaScript'>alert('Talebiniz Alınmıştır.');</script>");
                return RedirectToAction("Index", "site");
            }

        }
        [HttpGet]
        public ActionResult AvansTalepEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AvansTalepEkle(avanstalep y)
        {
            if (y.tarih == null || y.adsoyad == null || y.avansmiktar == null)
            {
                Response.Write("<script lang='JavaScript'>alert('LÜTFEN TÜM ALANLARI DOLDURUN!');</script>");
                return View();
            }
            else
            {
                veri.avanstalep.Add(y);
                veri.SaveChanges();
                Response.Write("<script lang='JavaScript'>alert('Talebiniz Alınmıştır.');</script>");
                return RedirectToAction("Index", "site");
            }

        }
    }
}