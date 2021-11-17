using SponsorBulmaSitesi.Clases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SponsorBulmaSitesi.Controllers
{
    public class UyeController : Controller
    {
        private string KodUret(int size)
        {
            char[] cr = "0123456789".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                result += cr[r.Next(0, cr.Length - 1)].ToString();
            }

            return result;
        }
        // GET: Uye
        DBBonusSMEntities1 Db = new DBBonusSMEntities1();
        mail email;
        public UyeController()
        {
            email = new mail();
        }
        public ActionResult Index()
        {
            return View();
        }
        //[Route("kayit-ol")]
        //public ActionResult UyeOl()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult UyeOl(string name,string surname,string phone,string email,string password,string remember)
        //{
        //    if (Session["Kullanici"] == null)
        //    {
        //        TblUyeler yeni = new TblUyeler();
        //        var kullaniciEmail = Db.TblUyeler.Where(x => x.Email == email).FirstOrDefault();
        //        var kullaniciPhone = Db.TblUyeler.Where(x => x.Telefon == phone).FirstOrDefault();
        //        if (kullaniciEmail != null)
        //        {
        //            ViewBag.Uyari = "Bu mail adresi sistemimizde kayıtlı.";
        //            return View();
        //        }
        //        else if (kullaniciPhone != null)
        //        {
        //            ViewBag.Uyari = "Bu telefon numarası sistemimizde kayıtlı.";
        //            return View();
        //        }
        //        else
        //        {
        //            yeni.Adi = name;
        //            yeni.Soyadi = surname;
        //            yeni.Email = email;
        //            yeni.Telefon = phone;
        //            yeni.Sifre = password;
        //            Db.TblUyeler.Add(yeni);
        //            Db.SaveChanges();
        //            return RedirectToAction("../giris-yap");
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("../cekilisevim");
        //    }



        //}
        //[Route("giris-yap")]
        //public ActionResult Login()
        //{
        //    if (Session["Kullanici"] != null)
        //    {
        //         return RedirectToAction("../cekilisevim");
        //    }
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Login(string email, string password)
        //{
        //    if (Session["Kullanici"] == null)
        //    {
        //        var kullanici = Db.TblUyeler.Where(x => x.Email == email && x.Sifre == password).FirstOrDefault();
        //        if (kullanici == null)
        //        {
        //            ViewBag.Uyari = "Kullanıcı Bulunamadı. Bilgileri Kontrol Ediniz.";
        //            return View();

        //        }
        //        else
        //        {
        //            ViewBag.Uyari = "";
        //            Session["Admin"] = null;
        //            Session["Kullanici"] = kullanici.Id;
        //            return RedirectToAction("../cekilisevim");
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("../cekilisevim");
        //    }



        //}
        //public ActionResult Logout()
        //{
        //    Session["Kullanici"] = null;
        //    return RedirectToAction("../giris-yap");
        //}
        //public ActionResult Profil()
        //{
        //    if (Session["Kullanici"] !=null)
        //    {
        //        int KulId =int.Parse(Session["Kullanici"].ToString());
        //        var Kullanici = Db.TblUyeler.Find(KulId);
        //        Session["Kullanici"] = KulId;
        //        return View();

        //    }
        //     return RedirectToAction("../cekilisevim");
        //}
        //[Route("islemlerim")]
        //public  ActionResult Islemlerim()
        //{
        //    if (Session["Kullanici"] == null)
        //    {
        //         return RedirectToAction("../cekilisevim");
        //    }
        //    else
        //    {
        //        int id = int.Parse(Session["Kullanici"].ToString());
        //        var sayfalar = Db.TblSayfalar.Where(x => x.Uye == id).ToList();
        //        var islemler = Db.TblSatilanPaketler.Where(x => x.TblSayfalar.TblUyeler.Id == id).ToList();
        //        return View(islemler);
        //    }

        //}
        //[Route("instagram-sayfalarim")]
        //public ActionResult Sayfalarim()
        //{
        //    if (Session["Kullanici"] == null)
        //    {
        //         return RedirectToAction("../cekilisevim");
        //    }
        //    else
        //    {
        //        int id = int.Parse(Session["Kullanici"].ToString());
        //        var sayfalar = Db.TblSayfalar.Where(x => x.TblUyeler.Id == id).ToList();
        //        return View(sayfalar);

        //    }


        //}

        //[HttpPost]
        //public ActionResult Sayfalarim(string sayfaadi)
        //{
        //    if (Session["Kullanici"] == null)
        //    {
        //         return RedirectToAction("../cekilisevim");
        //    }
        //    else
        //    {
        //        int id = int.Parse(Session["Kullanici"].ToString());

        //        TblSayfalar yeni = new TblSayfalar();
        //        yeni.SayfaAdi = sayfaadi;
        //        yeni.Uye = id;
        //        Db.TblSayfalar.Add(yeni);
        //        Db.SaveChanges();
        //        return RedirectToAction("../instagram-sayfalarim");
        //    }
        //}
        //public ActionResult SayfaSil(int id)
        //{
        //    if (Session["Kullanici"] == null)
        //    {
        //         return RedirectToAction("../cekilisevim");
        //    }
        //    else
        //    {
        //        var sayfa = Db.TblSayfalar.Find(id);
        //        Db.TblSayfalar.Remove(sayfa);
        //        Db.SaveChanges();
        //        return RedirectToAction("instagram-sayfalarim");
        //    }
        //}
        //[Route("sayfa-guncelle/{id}")]
        //public ActionResult SayfaGuncelle(int id)
        //{
        //    if (Session["Kullanici"] == null)
        //    {
        //        return RedirectToAction("../cekilisevim");
        //    }
        //    else
        //    {
        //        TblSayfalar sayfa = Db.TblSayfalar.Find(id);
        //        return View(sayfa);
        //    }
        //}
        //[HttpPost]
        //public ActionResult SayfaGuncelle([Bind(Include = "Id,SayfaAdi,Uye")] TblSayfalar tblSayfalar)
        //{
        //    if (Session["Kullanici"] == null)
        //    {
        //        return RedirectToAction("../cekilisevim");
        //    }
        //    else
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Db.Entry(tblSayfalar).State = EntityState.Modified;
        //            Db.SaveChanges();
        //            return RedirectToAction("../instagram-sayfalarim");
        //        }
        //        return View(tblSayfalar);
        //    }
        //}
        //[Route("uye-odeme-islemi/{id}")]
        //public ActionResult OdemeSayfasiUye(int id)
        //{
        //    if (Session["Kullanici"] == null)
        //    {
        //        return RedirectToAction("../cekilisevim");
        //    }
        //    else
        //    {
        //        var siparis = Db.TblSatilanPaketler.Find(id);
        //        return View(siparis);
        //    }

        //}
        //[HttpPost]
        //public ActionResult OdemeSayfasiUye(HttpPostedFileBase uploadfile ,int id)
        //{
        //    try
        //    {
        //        TblSatilanPaketler satilanPaket = Db.TblSatilanPaketler.Find(id);
        //        if (Request.Files.Count > 0)
        //        {


        //            //Guid nesnesini benzersiz dosya adı oluşturmak için tanımladık ve Replace ile aradaki “-” işaretini atıp yan yana yazma işlemi yaptık.
        //            string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
        //            //Kaydetceğimiz resmin uzantısını aldık.
        //            string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
        //            string TamYolYeri = "~/Images/Dekontlar/" + DosyaAdi + uzanti;
        //            //Eklediğimiz Resni Server.MapPath methodu ile Dosya Adıyla birlikte kaydettik.
        //            Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
        //            //Ve veritabanına kayıt için dosya adımızı değişkene aktarıyoruz.
        //            satilanPaket.DekontFoto = DosyaAdi + uzanti;
        //            satilanPaket.DekontDurumu = "Gönderildi";
        //            Db.SaveChanges();
        //            ViewBag.Bilgi = "Dekont başarıyla yüklenmiştir. 24 saat içerisinde onaylanacaktır. İşlem kodunuz ile aratarak durumunu izleyebilirsiniz.";
        //            return View(satilanPaket);

        //        }
        //        else
        //        {
        //            ViewBag.Bilgi = "Dekont yüklenemedi. Whatsapp numarasından işlem koduyla birlikte yollayabilirsiniz.";
        //            return View(satilanPaket);
        //        }
        //    }
        //    catch
        //    {
        //        return RedirectToAction("../cekilisevim");

        //    }

        //}
        //[Route("islemim")]


        //[Route("odeme-islemi-kart/{kod}")]
        //public ActionResult OdemeSayfasiKart(string kod)
        //{
        //    try
        //    {
        //        if (Session["Kullanici"] != null)
        //        {
        //            return RedirectToAction("../cekilisevim");
        //        }
        //        else
        //        {
        //            var siparis = Db.TblTalepler.Where(x => x.TalepKodu == kod).FirstOrDefault();
        //            if (siparis == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            else
        //            {
        //                return View(siparis);

        //            }

        //        }
        //    }
        //    catch
        //    {
        //        return HttpNotFound();
        //    }


        //}

        //[Route("odeme-islemi/{kod}")]
        //public ActionResult OdemeSayfasi(string kod)
        //{
        //    try
        //    {
        //        if (Session["Kullanici"] != null)
        //        {
        //            return RedirectToAction("../cekilisevim");
        //        }
        //        else
        //        {
        //            var siparis = Db.TblTalepler.Where(x => x.TalepKodu == kod).FirstOrDefault();
        //            if (siparis == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            else
        //            {
        //                return View(siparis);

        //            }
                   
        //        }
        //    }
        //    catch
        //    {
        //        return HttpNotFound();
        //    }
           

        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult OdemeSayfasi(HttpPostedFileBase uploadfile, int id)
        //{
        //    try
        //    {
        //        TblTalepler talep = Db.TblTalepler.Find(id);
        //        if (Request.Files.Count > 0)
        //        {
        //            string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
        //            string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
        //            string TamYolYeri = "~/Images/Dekontlar/" + DosyaAdi + uzanti;
        //            Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
        //            talep.DekontFoto = DosyaAdi + uzanti;
        //            talep.DekontDurumu = "Gönderildi";
        //            Db.SaveChanges();
        //            email.dekontBilgiMail("busahiner96@gmail.com", "DEKONT YATTI.", talep.TalepKodu + " İşlem kodlu müşteri dekontunu yatırmıştır.", "PAKET ADI: " + talep.TblPaketler.PaketAdi + " | İŞLEM TUTARI: " + talep.TblPaketler.Fiyati + "TL | SAYFA ADI: " + talep.SayfaAdi);
        //            ViewBag.Bilgi = "Dekont başarıyla yüklenmiştir. 24 saat içerisinde onaylanacaktır. İşlem kodunuz ile aratarak durumunu izleyebilirsiniz.";
        //            return RedirectToAction("../talep-islemim/" + talep.TalepKodu);

        //        }
        //        else
        //        {
        //            ViewBag.Bilgi = "Dekont yüklenemedi. Whatsapp numarasından işlem koduyla birlikte yollayabilirsiniz.";
        //            return View(talep);
        //        }
        //    }
        //    catch
        //    {

        //        return HttpNotFound();
        //    }
        //}
        //[Route("talep-islemim/{kod}")]
        //public ActionResult Islemim(string kod)
        //{
        //    try
        //    {
        //        var islem = Db.TblTalepler.Where(x => x.TalepKodu == kod).FirstOrDefault();
        //        return View(islem);
        //    }
        //    catch
        //    {
        //        return HttpNotFound();
        //    }
            

        //}
       
        [Route("talep-olustur/{paket}")]
        public ActionResult TalepOlustur(string paket)
        {
            try
            {
                if (Session["Token"] != null)
                {
                    if (Session["Token"].ToString() == "Paketler")
                    {
                        TblPaketler pkt = Db.TblPaketler.Where(x => x.PaketSeoUrl == paket).FirstOrDefault();
                        Session.Remove("Token");
                        return View(pkt);
                    }
                    Session.Remove("Token");
                     return RedirectToAction("../cekilisevim");
                }
                else
                {
                    Session.Remove("Token");
                    return RedirectToAction("../cekilisevim");
                }

                
               
            }
            catch
            {
                return HttpNotFound();
            }
      
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TalepOlustur(string paket,string profillink,string whatsapp, string mail,string isim, string instaadi, string telefon, string aciklama)
        {
            try
            {
                string Kod;
                for (; ; )
                {
                    Kod = "TKP" + KodUret(6);
                    var KodVarmi = Db.TblTalepler.Where(x => x.TalepKodu == Kod).FirstOrDefault();
                    if (KodVarmi == null)
                    {
                        break;
                    }
                }
                TblPaketler pkt = Db.TblPaketler.Where(x=>x.PaketSeoUrl==paket).FirstOrDefault();
                TblTalepler yeni = new TblTalepler();
                yeni.TalepKodu = Kod;
                yeni.Paket = pkt.Id;
                yeni.Adi = isim;
                yeni.SayfaAdi = instaadi;
                yeni.WhatsapGrubu = whatsapp;
                yeni.Telefon = telefon;
                yeni.Email = mail;
                yeni.ProfilLink = profillink;
                yeni.TalepAciklama = aciklama;
                yeni.TalepTarih = DateTime.Now;
                yeni.TalepDurum = "Beklemede";
                yeni.TalepOdeme = "Ödenmedi";
                yeni.DekontDurumu = "Gönderilmedi";
                Db.TblTalepler.Add(yeni);
                string sayfalinki = "https://cekilisevim.com/";
                email.talepMail(mail, "TALEBİNİZ ALINMIŞTIR.", Kod + " İşlem kodlu talebiniz alınmıştır. Sizinle iletişime geçilecektir. İsterseniz iletişim bilgilerindeki whatsapp numarası beklemeden iletişime geçebilirsiniz.", "PAKET ADI: " + pkt.PaketAdi + " | İŞLEM TUTARI: " + pkt.Fiyati + "TL | SAYFA ADI: " + instaadi, sayfalinki);
                email.talepBilgiMail("busahiner96@gmail.com", " YENİ TALEP ALINDI.", yeni.TalepKodu + " İşlem kodlu yeni talep alındı.", "PAKET ADI: " + yeni.TblPaketler.PaketAdi + " | İŞLEM TUTARI: " + yeni.TblPaketler.Fiyati + "TL | SAYFA ADI: " + yeni.SayfaAdi);
                Db.SaveChanges();
                ViewBag.Uyari = "";
                ViewBag.Bilgi = "Talebiniz gönderildi. En kısa zamanda sizile iletişime geçilecektir. İsterseniz beklemeden WhatSapp ile iletişime geçebilirsiniz";
                return View(pkt);


            }
            catch
            {
                try
                {
                    TblPaketler pktt = Db.TblPaketler.Find(paket);
                    ViewBag.Bilgi = "";
                    ViewBag.Uyari = "Talep oluşturulurken bir hata oldu. İsterseniz WhatSapp iletişime geçebilir ya da daha sonra tekrar deneyebilirsiniz.";
                    return View(pktt);
                }
                catch
                {
                    return HttpNotFound();
                }
               
            }
        }

        [HttpPost]
        public JsonResult YorumYap(string isim, string mail, string yorum)
        {
            var model = new TblYorumlar
            {
                Yorum = yorum,
                YorumAdi = isim,
                YorumMail = mail,
                Tarih = DateTime.Now,
                YorumOnay = "PASİF"
                
            
            };
            Db.TblYorumlar.Add(model);

            Db.SaveChanges();
            return Json("1");
        }
        //[HttpPost]
        //public JsonResult IslemTakip(string kod)
        //{
        //    try
        //    {
        //        var islem = Db.TblTalepler.Where(x => x.TalepKodu == kod).FirstOrDefault();
        //        if (islem == null)
        //        {
        //            return Json("Yok");
        //        }
        //        else
        //        {
        //            return Json(kod);
        //        }
        //    }
        //    catch
        //    {
        //        return Json("hata");
        //    }




        //}
        //[Route("takipci-paketleri-panel")]
        //public ActionResult OtomatikTakipciPaketleri()
        //{
        //    try
        //    {
        //        var urunler = Db.TblPaketler.Where(x => x.Aktif == "Aktif" && x.Kategori == 2);

        //        return View(urunler);
        //    }
        //    catch
        //    {
        //        return HttpNotFound();
        //    }
           
        //}

    }
}