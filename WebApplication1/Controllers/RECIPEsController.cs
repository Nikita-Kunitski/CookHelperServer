using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RECIPEsController : Controller
    {
        private CookHelperEntities db = new CookHelperEntities();

        // GET: RECIPEs
        public ActionResult Index()
        {
            var rECIPEs = db.RECIPEs.Include(r => r.BOOK_DISH).Include(r => r.INGREDIENT);
            return View(rECIPEs.ToList());
        }

        // GET: RECIPEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECIPE rECIPE = db.RECIPEs.Find(id);
            if (rECIPE == null)
            {
                return HttpNotFound();
            }
            return View(rECIPE);
        }

        // GET: RECIPEs/Create
        public ActionResult Create()
        {
            ViewBag.C_id_dish = new SelectList(db.BOOK_DISH, "C_id_dish", "name_dish");
            ViewBag.C_id_ingred = new SelectList(db.INGREDIENTs, "C_id_ingred", "name_ingredient");
            return View();
        }

        // POST: RECIPEs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_id,C_id_ingred,C_id_dish,kol")] RECIPE rECIPE)
        {
            if (ModelState.IsValid)
            {
                db.RECIPEs.Add(rECIPE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.C_id_dish = new SelectList(db.BOOK_DISH, "C_id_dish", "name_dish", rECIPE.C_id_dish);
            ViewBag.C_id_ingred = new SelectList(db.INGREDIENTs, "C_id_ingred", "name_ingredient", rECIPE.C_id_ingred);
            return View(rECIPE);
        }

        // GET: RECIPEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECIPE rECIPE = db.RECIPEs.Find(id);
            if (rECIPE == null)
            {
                return HttpNotFound();
            }
            ViewBag.C_id_dish = new SelectList(db.BOOK_DISH, "C_id_dish", "name_dish", rECIPE.C_id_dish);
            ViewBag.C_id_ingred = new SelectList(db.INGREDIENTs, "C_id_ingred", "name_ingredient", rECIPE.C_id_ingred);
            return View(rECIPE);
        }

        // POST: RECIPEs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_id,C_id_ingred,C_id_dish,kol")] RECIPE rECIPE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rECIPE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.C_id_dish = new SelectList(db.BOOK_DISH, "C_id_dish", "name_dish", rECIPE.C_id_dish);
            ViewBag.C_id_ingred = new SelectList(db.INGREDIENTs, "C_id_ingred", "name_ingredient", rECIPE.C_id_ingred);
            return View(rECIPE);
        }

        // GET: RECIPEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECIPE rECIPE = db.RECIPEs.Find(id);
            if (rECIPE == null)
            {
                return HttpNotFound();
            }
            return View(rECIPE);
        }

        // POST: RECIPEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RECIPE rECIPE = db.RECIPEs.Find(id);
            db.RECIPEs.Remove(rECIPE);
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
