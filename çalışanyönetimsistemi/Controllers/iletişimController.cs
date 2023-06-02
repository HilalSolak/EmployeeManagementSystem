using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using çalışanyönetimsistemi.Models.Baglantisql;

namespace çalışanyönetimsistemi.Controllers
{
    public class iletişimController : Controller
    {
        // GET: iletişim
        çalışanyönetimsistemiEntities2 veri = new çalışanyönetimsistemiEntities2();
        [HttpGet]
        public ActionResult İletişim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult İletişim(iletişim y)
        {
            if (y.ad == null || y.email == null || y.telefon == null || y.mesaj == null)
            {
                Response.Write("<script lang='JavaScript'>alert('LÜTFEN TÜM ALANLARI DOLDURUN!');</script>");
                return View();
            }
            else
            {
                veri.iletişim.Add(y);
                veri.SaveChanges();
                Response.Write("<script lang='JavaScript'>alert('Mesajınız Gönderilmiştir.');</script>");
                return RedirectToAction("Index", "site");
            }

        }
    }
}