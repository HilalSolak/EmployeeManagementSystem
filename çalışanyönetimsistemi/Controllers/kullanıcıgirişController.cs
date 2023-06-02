using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using çalışanyönetimsistemi.Models.Baglantisql;

namespace çalışanyönetimsistemi.Controllers
{
    public class kullanıcıgirişController : Controller
    {
        // GET: kullanıcıgiriş
        çalışanyönetimsistemiEntities2 veri = new çalışanyönetimsistemiEntities2();
        [HttpGet]
        public ActionResult KullanıcıGiriş()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KullanıcıGiriş(kullaniciadi y)
        {
            var veriler = veri.kullanicigirişi.FirstOrDefault(m => m.kullaniciadi == y.kullaniciadi && m.şifre == y.şifre);
            if (veriler != null)
            {
                FormsAuthentication.SetAuthCookie(veriler.kullaniciadi, false);
                Session["kullaniciadi"] = veriler.kullaniciadi.ToString();
                Session.Add("kullaniciadi", y.ad);
                return RedirectToAction("Index", "site");
            }
            else
            {
                Response.Write("<script lang='JavaScript'>alert('Biglilerinizi kontrol ediniz.');</script>");
                return RedirectToAction("KullanıcıGiriş", "kullanıcıgiriş");

            }
        }
    }
}