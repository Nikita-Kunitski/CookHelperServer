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
    public class INGREDIENTsController : Controller
    {
        private CookHelperEntities db = new CookHelperEntities();

        // GET: INGREDIENTs
        public ActionResult Index()
        {
            var iNGREDIENTs = db.INGREDIENTs.Include(i => i.UNIT_MEASURE);
            return View(iNGREDIENTs.ToList());
        }

        // GET: INGREDIENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGREDIENT iNGREDIENT = db.INGREDIENTs.Find(id);
            if (iNGREDIENT == null)
            {
                return HttpNotFound();
            }
            return View(iNGREDIENT);
        }

        // GET: INGREDIENTs/Create
        public ActionResult Create()
        {
            ViewBag.id_unit_measure = new SelectList(db.UNIT_MEASURE, "id_unit_measure", "name_unit_measure");
            return View();
        }

        // POST: INGREDIENTs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_id_ingred,name_ingredient,id_unit_measure")] INGREDIENT iNGREDIENT)
        {
            if (ModelState.IsValid)
            {
                db.INGREDIENTs.Add(iNGREDIENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_unit_measure = new SelectList(db.UNIT_MEASURE, "id_unit_measure", "name_unit_measure", iNGREDIENT.id_unit_measure);
            return View(iNGREDIENT);
        }

        // GET: INGREDIENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGREDIENT iNGREDIENT = db.INGREDIENTs.Find(id);
            if (iNGREDIENT == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_unit_measure = new SelectList(db.UNIT_MEASURE, "id_unit_measure", "name_unit_measure", iNGREDIENT.id_unit_measure);
            return View(iNGREDIENT);
        }

        // POST: INGREDIENTs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_id_ingred,name_ingredient,id_unit_measure")] INGREDIENT iNGREDIENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNGREDIENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_unit_measure = new SelectList(db.UNIT_MEASURE, "id_unit_measure", "name_unit_measure", iNGREDIENT.id_unit_measure);
            return View(iNGREDIENT);
        }

        // GET: INGREDIENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INGREDIENT iNGREDIENT = db.INGREDIENTs.Find(id);
            if (iNGREDIENT == null)
            {
                return HttpNotFound();
            }
            return View(iNGREDIENT);
        }

        // POST: INGREDIENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INGREDIENT iNGREDIENT = db.INGREDIENTs.Find(id);
            db.INGREDIENTs.Remove(iNGREDIENT);
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
