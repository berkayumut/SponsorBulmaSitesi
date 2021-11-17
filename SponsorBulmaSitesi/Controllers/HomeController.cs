using SponsorBulmaSitesi.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace SponsorBulmaSitesi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DBBonusSMEntities1 db = new DBBonusSMEntities1();

        [Route("~/")]
        [Route("cekilisevim")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Instagram-Cekilisleri")]
        public ActionResult AktifCekilisler()
        {
            try
            {
                var gecmis = db.TblCekilisler.Where(x => x.CekilisBitisTarihi < DateTime.Now).ToList();
                if (gecmis.Count !=0)
                {
                    db.TblCekilisler.RemoveRange(gecmis);
                    db.SaveChanges();
                }
                var cekilisler = db.TblCekilisler.Where(x => x.CekilisDurumu == "Aktif").OrderBy(x => x.CekilisBitisTarihi).ToList();

                return View(cekilisler);

            }
            catch
            {
                return HttpNotFound();
            }
           
        }
        [HttpPost]
        public ActionResult IslemAra(string takipKodu)
        {
            return View();
        }
        mail email;

        public HomeController()
        {
            email = new mail();
        }
        [HttpGet]
        public ActionResult EMailSender()
        {
            return View();
        }
        public ActionResult SiteMap()
        {

            Response.Clear();
            //Response.ContentTpye ile bu Action'ın View'ını XML tabanlı olarak ayarlıyoruz.
            Response.ContentType = "text/xml";
            XmlTextWriter xr = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
            xr.WriteStartDocument();
            xr.WriteStartElement("urlset");//urlset etiketi açıyoruz
            xr.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
            xr.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xr.WriteAttributeString("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/siteindex.xsd");
            /* sitemap dosyamızın olmazsa olmazını ekledik. Şeması bu dedik buraya kadar.  */

            xr.WriteStartElement("url");
            xr.WriteElementString("loc", "http://cekilisevim.com/");
            xr.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
            xr.WriteElementString("changefreq", "daily");
            xr.WriteElementString("priority", "1");
            xr.WriteEndElement();

            //Burada veritabanımızdaki Personelleri SiteMap'e ekliyoruz.
            var s = db.TblCekilisler.ToList();
            foreach (var a in s)
            {
                xr.WriteStartElement("url");
                xr.WriteElementString("loc", "http://cekilisevim.com/instagram-cekilisleri");
                xr.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
                xr.WriteElementString("priority", "0.5");
                xr.WriteElementString("changefreq", "monthly");
                xr.WriteEndElement();
            }

            //Aynı şekilde burada da Bolgeleri SiteMap'e ekliyoruz.
            var k = db.TblPaketler.ToList();
            foreach (var b in k)
            {
                xr.WriteStartElement("url");
                xr.WriteElementString("loc", "http://cekilisevim.com/cekilisevim/#paketler");
                xr.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd"));
                xr.WriteElementString("priority", "1");
                xr.WriteElementString("changefreq", "monthly");
                xr.WriteEndElement();
            }

            xr.WriteEndDocument();
            //urlset etiketini kapattık
            xr.Flush();
            xr.Close();
            Response.End();
            return View();
        }
        [Route("kullanim-sozlesmesi")]
        public ActionResult KullanimSozlesmesi()
        {
            try
            {
                return View();
            }
            catch
            {
                return HttpNotFound();
            }
           
        }
        [Route("hakkimizda")]
        public ActionResult Hakkimizda()
        {
            try
            {
                return View();
            }
            catch
            {
                return HttpNotFound();
            }

        }
        [Route("bloglar")]
        public ActionResult Blog()
        {
            var bloglar = db.TblYazilar.Where(x => x.YaziDurum == "Yayınlanmış").ToList();
            return View(bloglar);
        }
        [Route("blog/{baslikurl}")]
        public ActionResult Blog(string baslikurl)
        {
            var yazi = db.TblYazilar.Where(x => x.YaziSeoUrl == baslikurl).FirstOrDefault();
            return View();
        }
        public ActionResult aaaa()
        {
          
            return View();
        }
    }
}