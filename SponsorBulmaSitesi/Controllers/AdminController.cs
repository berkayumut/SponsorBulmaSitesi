using SponsorBulmaSitesi.Clases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SponsorBulmaSitesi.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin
        DBBonusSMEntities1 db = new DBBonusSMEntities1();
        mail email;
        public AdminController()
        {
            email = new mail();
        }
        private string KodUret(int size)
        {
            char[] cr = "0123456789abcsut".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                result += cr[r.Next(0, cr.Length - 1)].ToString();
            }

            return result;
        }

        public ActionResult Index()
        {
            return View();
        }
        [Route("admin/paketler")]
        public ActionResult Paketler()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int id = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(id);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");

                }
                else
                {
                    var paketler = db.TblPaketler.ToList();
                    return View(paketler);
                }
            }
          
        }
        [Route("admin/paket-ekle")]
        public ActionResult PaketEkle()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int id = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(id);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");

                }
                else
                {
                   
                    ViewBag.Kategoriler = new SelectList(db.TblPaketKategoriler, "Id", "KategoriAdi");
                    return View();
                }
            }
         
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaketEkle(string paketAdi,DateTime? CekilisTarihi,string odemelink, int Kategoriler, string TeslimSuresi, string paketAciklama, string takipciSayisi,string fiyati)
        {
            try {
                string UrlKod;
                for (; ; )
                {
                    UrlKod = "PKT" + KodUret(8);
                    var KodVarmi = db.TblPaketler.Where(x => x.PaketSeoUrl == UrlKod).FirstOrDefault();
                    if (KodVarmi == null)
                    {
                        break;
                    }
                }
                TblPaketler yeni = new TblPaketler();
                yeni.PaketAdi = paketAdi;
                yeni.Kategori = Kategoriler;
                yeni.TeslimSuresi = TeslimSuresi;
                yeni.CekilisTarihi = CekilisTarihi;
                yeni.PaketAciklama = paketAciklama;
                yeni.KTakipciSayisi = takipciSayisi;
                yeni.PaketSeoUrl = UrlKod;
                yeni.Fiyati = decimal.Parse(fiyati);
                yeni.Aktif = "Aktif";
                yeni.OdemeLink = odemelink;
                db.TblPaketler.Add(yeni);
                db.SaveChanges();
                return RedirectToAction("../admin/paketler");

            }

            catch
            {
                return HttpNotFound();
            }
           
        }
        public ActionResult PaketAktif(int id)
        {
            TblPaketler paket = db.TblPaketler.Find(id);
            if (paket.Aktif == "Aktif")
            {
                paket.Aktif = "Pasif";
                db.SaveChanges();
            }  
            else
            {
                paket.Aktif = "Aktif";
                db.SaveChanges();
            }
         
            return RedirectToAction("../admin/paketler");
        }
        [Route("admin/paket-guncelle")]
        public ActionResult PaketGuncelle(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblPaketler tblPaketler = db.TblPaketler.Find(id);
            if (tblPaketler == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kategori = new SelectList(db.TblPaketKategoriler, "Id", "KategoriAdi");
            return View(tblPaketler);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaketGuncelle([Bind(Include = "Id,Aktif,OdemeLink,Kategori,CekilisTarihi,TeslimSuresi,PaketAdi,PaketSeoUrl,PaketAciklama,KTakipciSayisi,Fiyati")] TblPaketler tblPaketler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPaketler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../admin/paketler");
            }
            return View(tblPaketler);
        }
        [Route("admin/fenomenler")]
        public ActionResult Fenomenler()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int id = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(id);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");

                }
                else
                {
                    var fenomen = db.TblFenomenler.ToList();
                    return View(fenomen);
                }
            }
          
        }
        [Route("admin/fenomen-ekle")]
        public ActionResult FenomenEkle()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int id = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(id);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");

                }
                else
                {
                    return View();
                }
            }
            
        }
       
        [HttpPost]
    
        public ActionResult FenomenEkle(string adi, string takipciSayisi,string instaurl, string takipciKapasite)
        { 
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int id = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(id);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");

                }
                else
                {
                    TblFenomenler yeni = new TblFenomenler();
                    if (Request.Files.Count > 0)
                    {
                        //Guid nesnesini benzersiz dosya adı oluşturmak için tanımladık ve Replace ile aradaki “-” işaretini atıp yan yana yazma işlemi yaptık.
                        string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                        //Kaydetceğimiz resmin uzantısını aldık.
                        string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                        string TamYolYeri = "~/Images/FenomenResimleri/" + DosyaAdi + uzanti;
                        //Eklediğimiz Resni Server.MapPath methodu ile Dosya Adıyla birlikte kaydettik.
                        Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
                        //Ve veritabanına kayıt için dosya adımızı değişkene aktarıyoruz.
                        yeni.Foto = DosyaAdi + uzanti;
                    }
                 
                    yeni.FenomenAdi = adi;
                    yeni.TakipciSayisi = takipciSayisi;
                    yeni.Durum = true;
                    yeni.TakipciKapasite = takipciKapasite;
                    yeni.InstaUrl = instaurl;
                    db.TblFenomenler.Add(yeni);
                    db.SaveChanges();
                    return RedirectToAction("../admin/fenomenler");
                }
            }

            
        }
        public ActionResult FenomenSil(int id)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    TblFenomenler fenomen = db.TblFenomenler.Find(id);
                    db.TblFenomenler.Remove(fenomen);
                    db.SaveChanges();
                    return RedirectToAction("../admin/fenomenler");
                }

            }

        }
        [Route("admin/fenomen-guncelle")]
        public ActionResult FenomenGuncelle(int id)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    TblFenomenler fenomen = db.TblFenomenler.Find(id);
                    if (fenomen == null)
                    {
                        return HttpNotFound();
                    }
                    return View(fenomen);
                }

            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FenomenGuncelle(string adi,int Id, string takipciSayisi,string Fotoo, string instaurl, string takipciKapasite)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    TblFenomenler fenom = db.TblFenomenler.Find(Id);
                    fenom.FenomenAdi = adi;
                    fenom.TakipciKapasite = takipciKapasite;
                    fenom.TakipciSayisi = takipciSayisi;
                    fenom.InstaUrl = instaurl;
                        if (Request.Files.Count > 0)
                        {
                            //Guid nesnesini benzersiz dosya adı oluşturmak için tanımladık ve Replace ile aradaki “-” işaretini atıp yan yana yazma işlemi yaptık.
                            string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
                            //Kaydetceğimiz resmin uzantısını aldık.
                            string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                            string TamYolYeri = "~/Images/FenomenResimleri/" + DosyaAdi + uzanti;
                            //Eklediğimiz Resni Server.MapPath methodu ile Dosya Adıyla birlikte kaydettik.
                            Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
                            //Ve veritabanına kayıt için dosya adımızı değişkene aktarıyoruz.
                            fenom.Foto = DosyaAdi + uzanti;
                    }
                    else
                    {
                        fenom.Foto = Fotoo;
                    }
                        db.Entry(fenom).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("../admin/fenomenler");
                }

            }

        }
        [Route("admin/giris")]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(string email, string password)
        {
            var admin = db.TblAdmin.Where(x => x.Mail == email && x.Sifre == password).FirstOrDefault();
            if (admin == null)
            {
                ViewBag.Uyari = "Giriş bilgileri yanlış. Tekrar deneyiniz.";
                return View();
            }
            else
            {
                Session["Kullanici"] = null;
                Session["Admin"] = admin.Id;
                return RedirectToAction("../admin/anasayfa");
            }
            
        }
        [Route("admin/anasayfa")]
        public ActionResult Anasayfa()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int id = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(id);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");

                }
                else
                {
                    return View();
                }
            }
        }
        public ActionResult MusteriTalep(int id)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");

                }
                else
                {
                    var talep = db.TblTalepler.Find(id);
                    return View(talep);
                }
            }
         
        }
        public ActionResult TalepGuncelle(int id)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");

                }
                else
                {
                   
                    var talep = db.TblTalepler.Find(id);
                    return View(talep);
                }
            }
         
        }
        [HttpPost]
        public ActionResult TalepGuncelle(string profillink,string Foto,string dekontdurumu, string durum, string odemedurum, string cekilislink, int id) //üye olmayanlar
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");

                }
                else
                {
                    TblTalepler talep = db.TblTalepler.Find(id);
                    talep.ProfilLink = profillink;
                    talep.DekontDurumu = dekontdurumu;
                    talep.TalepDurum = durum;
                    talep.TalepOdeme = odemedurum;
                    talep.DekontFoto = Foto;
                    talep.CekilisLink = cekilislink;
                    db.SaveChanges();
                    if (durum == "Onaylandı")
                    {
                        string sayfalinki = "http://cekilisevim.com/islemim" + talep.TalepKodu;
                        email.IslemOnaylandiMail(talep.Email, "TALEBİNİZ ONAYLANMIŞTIR.", talep.TalepKodu + " İşlem kodlu talebiniz onaylanmıştır. Yoğunluk durumuna göre 1 ile 5 gün içerisinde sonuçlandırılacaktır.", "PAKET ADI: " + talep.TblPaketler.PaketAdi + " | İŞLEM TUTARI: " + talep.TblPaketler.Fiyati + "TL | SAYFA ADI: " + talep.SayfaAdi, sayfalinki);
                    }
                    if (durum == "Onaylanmadı")
                    {
                        string sayfalinki = "http://cekilisevim.com/islemim" + talep.TalepKodu;
                        email.IslemOnaylanmadiMail(talep.Email, "TALEBİNİZ ONAYLANMAMIŞTIR.", talep.TalepKodu + " İşlem kodlu talebiniz reddedilmiştir. Dekont bilgileri doğru değil ve banka hesaplarında bir ödeme bulunamamıştır.", "PAKET ADI: " + talep.TblPaketler.PaketAdi + " | İŞLEM TUTARI: " + talep.TblPaketler.Fiyati + "TL | SAYFA ADI: " + talep.SayfaAdi, sayfalinki);
                    }
                    ViewBag.Bilgi = "Güncelleme Başarılı";
                    return View(talep);
                }
            }
            
           
        }
        //public ActionResult UyeTalep(int id)
        //{
        //    if (Session["Admin"] == null)
        //    {
        //        return RedirectToAction("../cekilisevim");
        //    }
        //    else
        //    {
        //        int idd = int.Parse(Session["Admin"].ToString());
        //        var adminmi = db.TblAdmin.Find(idd);
        //        if (adminmi == null)
        //        {
        //            return RedirectToAction("../cekilisevim");

        //        }
        //        else
        //        {
        //            var talep = db.TblSatilanPaketler.Find(id);
        //            return View(talep);
        //        }
        //    }

        //}
        //public ActionResult UyeTalepGuncelle(int id)
        //{
        //    if (Session["Admin"] == null)
        //    {
        //        return RedirectToAction("../cekilisevim");
        //    }
        //    else
        //    {
        //        int idd = int.Parse(Session["Admin"].ToString());
        //        var adminmi = db.TblAdmin.Find(idd);
        //        if (adminmi == null)
        //        {
        //            return RedirectToAction("../cekilisevim");

        //        }
        //        else
        //        {
        //            var talep = db.TblSatilanPaketler.Find(id);
        //            return View(talep);
        //        }
        //    }

        //}
        //[HttpPost]
        //public ActionResult UyeTalepGuncelle( string durum, string Foto,string dekontdurumu, string odemedurum, string cekilislink, int id)
        //{
        //    if (Session["Admin"] == null)
        //    {
        //        return RedirectToAction("../cekilisevim");
        //    }
        //    else
        //    {
        //        int idd = int.Parse(Session["Admin"].ToString());
        //        var adminmi = db.TblAdmin.Find(idd);
        //        if (adminmi == null)
        //        {
        //            return RedirectToAction("../cekilisevim");

        //        }
        //        else
        //        {
        //            TblSatilanPaketler talep = db.TblSatilanPaketler.Find(id);
        //            talep.Durum = durum;
        //            talep.DekontDurumu = dekontdurumu;
        //            talep.OdemeDurumu = odemedurum;
        //            talep.CekilisLink = cekilislink;
        //            talep.DekontFoto = Foto;
        //            db.SaveChanges();
        //            if (durum == "Onaylandı")
        //            {
        //                string sayfalinki = "http://cekilisevim.com/islemlerim";
        //                email.IslemOnaylandiMail(talep.TblSayfalar.TblUyeler.Email, "TALEBİNİZ ONAYLANMIŞTIR.", talep.SatisKodu + " İşlem kodlu talebiniz onaylanmıştır. Yoğunluk durumuna göre en geç 3 gün içerisinde sonuçlandırılacaktır.", "PAKET ADI: " + talep.TblPaketler.PaketAdi + " | İŞLEM TUTARI: " + talep.TblPaketler.Fiyati + "TL | SAYFA ADI: " + talep.TblSayfalar.SayfaAdi, sayfalinki);
        //            }
        //            ViewBag.Bilgi = "Güncelleme Başarılı";
        //            return View(talep);
        //        }
        //    }


        //}
        [Route("admin/cekilisler")]
        public ActionResult Cekilisler()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    var cekilis = db.TblCekilisler.ToList();
                    return View(cekilis);
                }

            }

        }
        [Route("admin/cekilis-ekle")]
        public ActionResult CekilisEkle()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    return View();
                }

            }
           

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CekilisEkle([Bind(Include = "Id,CekilisLinki,toplamOdul,CekilisDurumu,CekilisBitisTarihi")] TblCekilisler tblCekilisler)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        tblCekilisler.CekilisTarihi = DateTime.Now;
                        db.TblCekilisler.Add(tblCekilisler);
                        db.SaveChanges();
                        return RedirectToAction("../admin/cekilisler");
                    }

                    return View(tblCekilisler);
                }

            }
    
        }
        [Route("admin/cekilis-duzenle")]
        public ActionResult CekilisDuzenle(int? id)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    TblCekilisler tblCekilisler = db.TblCekilisler.Find(id);
                    if (tblCekilisler == null)
                    {
                        return HttpNotFound();
                    }
                    return View(tblCekilisler);
                }

            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CekilisDuzenle([Bind(Include = "Id,CekilisLinki,toplamOdul,CekilisDurumu,CekilisTarihi,CekilisBitisTarihi")] TblCekilisler tblCekilisler)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(tblCekilisler).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("../admin/cekilisler");
                    }
                    return View(tblCekilisler);
                }

            }
           
        }

        public ActionResult CekilisSil(int id)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    TblCekilisler cek = db.TblCekilisler.Find(id);
                    db.TblCekilisler.Remove(cek);
                    db.SaveChanges();
                    return RedirectToAction("../admin/cekilisler");
                }
              
            }
           

        }
        [Route("admin/banka-hesaplarim")]
        public ActionResult BankaHesaplarim()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    var hesaplar = db.TblBankalar.ToList();
                    return View(hesaplar);
                }

            }
           
        }
        [Route("admin/banka-hesabi-ekle")]
        public ActionResult BankaEkle()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    return View();
                }

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BankaEkle([Bind(Include = "Id,BankaAdi,IbanNo,HesapNo,Isim")] TblBankalar tblBankalar)
            {
                if (Session["Admin"] == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    int idd = int.Parse(Session["Admin"].ToString());
                    var adminmi = db.TblAdmin.Find(idd);
                    if (adminmi == null)
                    {
                        return RedirectToAction("../cekilisevim");
                    }
                    else
                    {
                    if (ModelState.IsValid)
                    {
                        db.TblBankalar.Add(tblBankalar);
                        db.SaveChanges();
                        return RedirectToAction("../admin/banka-hesaplarim");
                    }

                    return View(tblBankalar);
                }

                }

            }
        public ActionResult BankaSil(int id)
        {
            TblBankalar banka = db.TblBankalar.Find(id);
            db.TblBankalar.Remove(banka);
            db.SaveChanges();
            return RedirectToAction("../admin/banka-hesaplarim");
        }
        [Route("admin/yorumlar")]
        public ActionResult Yorumlar()
        {
            try
            {
                if (Session["Admin"] == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    int id = int.Parse(Session["Admin"].ToString());
                    var admin = db.TblAdmin.Find(id);
                    if (admin == null)
                    {
                        return RedirectToAction("../cekilisevim");
                    }
                    else
                    {
                        var yorumlar = db.TblYorumlar.ToList().OrderByDescending(x=>x.Tarih);
                        return View(yorumlar);
                    }
                }
            }
            catch
            {
                return HttpNotFound();
            }
          
        }
        public ActionResult YorumOnayla(int id)
        {
            try
            {
                if (Session["Admin"] == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    int idd = int.Parse(Session["Admin"].ToString());
                    var admin = db.TblAdmin.Find(idd);
                    if (admin == null)
                    {
                        return RedirectToAction("../cekilisevim");
                    }
                    else
                    {
                        var yorum = db.TblYorumlar.Find(id);
                        if (yorum.YorumOnay == "AKTİF")
                        {
                            yorum.YorumOnay = "PASİF";
                        }
                        else if (yorum.YorumOnay == "PASİF")
                        {
                            yorum.YorumOnay = "AKTİF";
                        }
               
                        db.SaveChanges();
                        return RedirectToAction("../admin/yorumlar");
                    }
                }
               
            }
            catch
            {
                return HttpNotFound();
            }
        }
        public ActionResult YorumSil(int id)
        {
            try
            {
                if (Session["Admin"] == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    int idd = int.Parse(Session["Admin"].ToString());
                    var admin = db.TblAdmin.Find(idd);
                    if (admin == null)
                    {
                        return RedirectToAction("../cekilisevim");
                    }
                    else
                    {
                        var yorum = db.TblYorumlar.Find(id);
                        db.TblYorumlar.Remove(yorum);
                        db.SaveChanges();
                        return RedirectToAction("../admin/yorumlar");
                    }
                }

            }
            catch
            {
                return HttpNotFound();
            }
        }
        public ActionResult CikisYap()
        {
            if (Session["Admin"] != null)
            {
                Session["Admin"] = null;
                return RedirectToAction("../admin/giris");
            }
            else
            {
                return RedirectToAction("../admin/giris");
            }

        }
        public ActionResult YaziEkle()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    ViewBag.Kategoriler = new SelectList((from s in db.TblYaziKategori.ToList()
                                                       select new
                                                       {
                                                           Id = s.Id,
                                                           Kategori = s.YaziKategorisi
                                                       }), "Id", "Kategori", null);
                    return View();
                }

            }
        }
        public static string seourldonus(string metin)
        {

            char[] türkcekarakterler = { 'ı', 'ğ', 'İ', 'Ğ', 'ç', 'Ç', 'ş', 'Ş', 'ö', 'Ö','ü','Ü', ' '};
            char[] ingilizce = { 'i', 'g', 'I', 'G', 'c', 'C', 's', 'S', 'o', 'O', 'u', 'U', '-' };//karakterler sırayla ingilizce karakter karşılıklarıyla yazıldı
            for (int i = 0; i < türkcekarakterler.Length; i++)
            {

                metin = metin.Replace(türkcekarakterler[i], ingilizce[i]);

            }
            return metin;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YaziEkle(Models.YaziModel degerler, int Kategoriler, string Durum )
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("../cekilisevim");
            }
            else
            {
                int idd = int.Parse(Session["Admin"].ToString());
                var adminmi = db.TblAdmin.Find(idd);
                if (adminmi == null)
                {
                    return RedirectToAction("../cekilisevim");
                }
                else
                {
                    TblYazilar yeni = new TblYazilar();
                    yeni.YaziBaslik = degerler.Baslik;
                    yeni.YaziMetin = degerler.Icerik;
                    yeni.YaziKategori = int.Parse(Kategoriler.ToString());
                    yeni.YaziTarih = DateTime.Now;
                    yeni.YaziDurum = Durum;
                    yeni.YaziSeoUrl = seourldonus(degerler.Baslik);
                    db.TblYazilar.Add(yeni);
                    db.SaveChanges();


                    return View();
                }

            }
        }


    }
}