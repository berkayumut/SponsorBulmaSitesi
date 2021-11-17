using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SponsorBulmaSitesi;

namespace SponsorBulmaSitesi.Controllers
{
    public class TblPaketlersController : Controller
    {
        private DBBonusSMEntities1 db = new DBBonusSMEntities1();

        // GET: TblPaketlers
        public ActionResult Index()
        {
            return View(db.TblPaketler.ToList());
        }

        // GET: TblPaketlers/Details/5
        public ActionResult Details(int? id)
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
            return View(tblPaketler);
        }

        // GET: TblPaketlers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TblPaketlers/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PaketAdi,PaketAciklama,KTakipciSayisi,Fiyati")] TblPaketler tblPaketler)
        {
            if (ModelState.IsValid)
            {
                db.TblPaketler.Add(tblPaketler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPaketler);
        }

        // GET: TblPaketlers/Edit/5
        public ActionResult Edit(int? id)
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
            return View(tblPaketler);
        }

        // POST: TblPaketlers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PaketAdi,PaketAciklama,KTakipciSayisi,Fiyati")] TblPaketler tblPaketler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPaketler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPaketler);
        }

        // GET: TblPaketlers/Delete/5
        public ActionResult Delete(int? id)
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
            return View(tblPaketler);
        }

        // POST: TblPaketlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblPaketler tblPaketler = db.TblPaketler.Find(id);
            db.TblPaketler.Remove(tblPaketler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
