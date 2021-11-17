using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SponsorBulmaSitesi.Controllers
{
    public class PartialController : Controller
    {
        
        
        DBBonusSMEntities1 db = new DBBonusSMEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult paketlerPartial()
        {
            var paketler = db.TblPaketler.Where(x=>x.Aktif=="Aktif"&&x.Kategori==1).OrderBy(x=>x.Fiyati).ToList();
            return PartialView("~/Views/PartialView/_Paketler.cshtml",paketler);
        }
        public ActionResult ozelpaketlerPartial()
        {
            var paketler = db.TblPaketler.Where(x => x.Aktif == "Aktif" && x.Kategori == 3).OrderBy(x => x.Fiyati).ToList();
            return PartialView("~/Views/PartialView/_OzelPaketler.cshtml", paketler);
        }
        public ActionResult yorumPartial()
        {
            var yorumlar = db.TblYorumlar.Where(x => x.YorumOnay == "AKTİF").OrderByDescending(x => x.Tarih).ToList();
            return PartialView("~/Views/PartialView/_Yorumlar.cshtml", yorumlar);
        }
        public ActionResult bankaListesi()
        {
            var Bankalar = db.TblBankalar.ToList();
            return PartialView("~/Views/PartialView/_Bankalar.cshtml", Bankalar);
        }
    
        public ActionResult listPaketlerDoldur()
        {
  
            ViewBag.Paketler = new SelectList((from m in db.TblPaketler.Where(x=>x.Aktif=="Aktif")
                                                 select new
                                                 {
                                                     Id = m.Id,
                                                     Paket = m.PaketAdi + " ( " + m.KTakipciSayisi+" ) "+" Katılım"
                                                 }),"Id", "Paket", null);


            return PartialView("~/Views/PartialView/_PaketCombo.cshtml");
        }
        public ActionResult listUyeSayfalar()
        {
            int id = int.Parse(Session["Kullanici"].ToString());
            ViewBag.Sayfalar = new SelectList((from s in db.TblSayfalar.Where(x => x.Uye == id)
                                               select new
                                               {
                                                   Id = s.Id,
                                                   Sayfa = s.SayfaAdi
                                               }), "Id", "Sayfa", null);


            return PartialView("~/Views/PartialView/_uyeSayfalarCombo.cshtml");
        }
        public ActionResult fenomenAnasayfa()
        {

            var fenomeler = db.TblFenomenler.ToList();
 
            return PartialView("~/Views/PartialView/_AnlasmaliSayfa.cshtml", fenomeler);
        }
        public ActionResult talepleriGetir()
        {

            var talepler = db.TblTalepler.ToList().OrderByDescending(x => x.TalepTarih).ToList();

            return PartialView("~/Views/PartialView/_TaleplerListeAnasayfa.cshtml", talepler);
        }
   
    }
}
