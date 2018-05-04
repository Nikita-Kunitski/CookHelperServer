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
    public class COOKING_STAGESController : Controller
    {
        private CookHelperEntities db = new CookHelperEntities();

        // GET: COOKING_STAGES
        public ActionResult Index()
        {
            var cOOKING_STAGES = db.COOKING_STAGES.Include(c => c.BOOK_DISH);
            return View(cOOKING_STAGES.ToList());
        }

        // GET: COOKING_STAGES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COOKING_STAGES cOOKING_STAGES = db.COOKING_STAGES.Find(id);
            if (cOOKING_STAGES == null)
            {
                return HttpNotFound();
            }
            return View(cOOKING_STAGES);
        }

        // GET: COOKING_STAGES/Create
        public ActionResult Create()
        {
            ViewBag.C_id_dish = new SelectList(db.BOOK_DISH, "C_id_dish", "name_dish");
            return View();
        }

        // POST: COOKING_STAGES/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_id_cooking_stages,C_id_dish,C_text")] COOKING_STAGES cOOKING_STAGES)
        {
            if (ModelState.IsValid)
            {
                db.COOKING_STAGES.Add(cOOKING_STAGES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.C_id_dish = new SelectList(db.BOOK_DISH, "C_id_dish", "name_dish", cOOKING_STAGES.C_id_dish);
            return View(cOOKING_STAGES);
        }

        // GET: COOKING_STAGES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COOKING_STAGES cOOKING_STAGES = db.COOKING_STAGES.Find(id);
            if (cOOKING_STAGES == null)
            {
                return HttpNotFound();
            }
            ViewBag.C_id_dish = new SelectList(db.BOOK_DISH, "C_id_dish", "name_dish", cOOKING_STAGES.C_id_dish);
            return View(cOOKING_STAGES);
        }

        // POST: COOKING_STAGES/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_id_cooking_stages,C_id_dish,C_text")] COOKING_STAGES cOOKING_STAGES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOOKING_STAGES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.C_id_dish = new SelectList(db.BOOK_DISH, "C_id_dish", "name_dish", cOOKING_STAGES.C_id_dish);
            return View(cOOKING_STAGES);
        }

        // GET: COOKING_STAGES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COOKING_STAGES cOOKING_STAGES = db.COOKING_STAGES.Find(id);
            if (cOOKING_STAGES == null)
            {
                return HttpNotFound();
            }
            return View(cOOKING_STAGES);
        }

        // POST: COOKING_STAGES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COOKING_STAGES cOOKING_STAGES = db.COOKING_STAGES.Find(id);
            db.COOKING_STAGES.Remove(cOOKING_STAGES);
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
