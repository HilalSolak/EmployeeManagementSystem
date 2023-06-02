using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using çalışanyönetimsistemi.Models.Baglantisql;

namespace çalışanyönetimsistemi.Controllers
{
    public class admingirişiController : Controller
    {
        // GET: admingirişi
        çalışanyönetimsistemiEntities2 veri = new çalışanyönetimsistemiEntities2();
        [HttpGet]
        public ActionResult AdminGiriş()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminGiriş(admingirişi y)
        {
            var veriler = veri.admingirişi.FirstOrDefault(m => m.adminkullaniciadi == y.adminkullaniciadi && m.adminşifre == y.adminşifre);
            if (veriler != null)
            {
                FormsAuthentication.SetAuthCookie(veriler.adminkullaniciadi, false);
                Session["adminkullaniciadi"] = veriler.adminkullaniciadi.ToString();
                return RedirectToAction("Index", "adminsite");
            }
            else
            {
                Response.Write("<script lang='JavaScript'>alert('Biglilerinizi kontrol ediniz.');</script>");
                return RedirectToAction("AdminGiriş", "admingirişi");

            }
        }
    }
}