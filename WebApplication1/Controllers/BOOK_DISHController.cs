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
    public class BOOK_DISHController : Controller
    {
        private CookHelperEntities db = new CookHelperEntities();

        // GET: BOOK_DISH
        public ActionResult Index()
        {
            var bOOK_DISH = db.BOOK_DISH.Include(b => b.COOKING_METHOD).Include(b => b.CUISINE_NATIONAL).Include(b => b.CUISINE_TYPE).Include(b => b.TYPE_DISH);
            return View(bOOK_DISH.ToList());
        }

        // GET: BOOK_DISH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK_DISH bOOK_DISH = db.BOOK_DISH.Find(id);
            if (bOOK_DISH == null)
            {
                return HttpNotFound();
            }
            return View(bOOK_DISH);
        }

        // GET: BOOK_DISH/Create
        public ActionResult Create()
        {
            ViewBag.C_id_cooking_method = new SelectList(db.COOKING_METHOD, "C_id_cooking_method", "name_method");
            ViewBag.C_id_cuisine_national = new SelectList(db.CUISINE_NATIONAL, "C_id_cuisine_national", "name_cuisine");
            ViewBag.C_id_cuisine_type = new SelectList(db.CUISINE_TYPE, "C_id_cuisine_type", "name_cuisine");
            ViewBag.C_id_type_dish = new SelectList(db.TYPE_DISH, "C_id_type_dish", "name_type");
            return View();
        }

        // POST: BOOK_DISH/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "C_id_dish,name_dish,time_pr,C_id_cuisine_national,C_id_cooking_method,C_id_type_dish,C_id_cuisine_type,calories,imageData")] BOOK_DISH bOOK_DISH)
        {
            if (ModelState.IsValid)
            {
                db.BOOK_DISH.Add(bOOK_DISH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.C_id_cooking_method = new SelectList(db.COOKING_METHOD, "C_id_cooking_method", "name_method", bOOK_DISH.C_id_cooking_method);
            ViewBag.C_id_cuisine_national = new SelectList(db.CUISINE_NATIONAL, "C_id_cuisine_national", "name_cuisine", bOOK_DISH.C_id_cuisine_national);
            ViewBag.C_id_cuisine_type = new SelectList(db.CUISINE_TYPE, "C_id_cuisine_type", "name_cuisine", bOOK_DISH.C_id_cuisine_type);
            ViewBag.C_id_type_dish = new SelectList(db.TYPE_DISH, "C_id_type_dish", "name_type", bOOK_DISH.C_id_type_dish);
            return View(bOOK_DISH);
        }

        // GET: BOOK_DISH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK_DISH bOOK_DISH = db.BOOK_DISH.Find(id);
            if (bOOK_DISH == null)
            {
                return HttpNotFound();
            }
            ViewBag.C_id_cooking_method = new SelectList(db.COOKING_METHOD, "C_id_cooking_method", "name_method", bOOK_DISH.C_id_cooking_method);
            ViewBag.C_id_cuisine_national = new SelectList(db.CUISINE_NATIONAL, "C_id_cuisine_national", "name_cuisine", bOOK_DISH.C_id_cuisine_national);
            ViewBag.C_id_cuisine_type = new SelectList(db.CUISINE_TYPE, "C_id_cuisine_type", "name_cuisine", bOOK_DISH.C_id_cuisine_type);
            ViewBag.C_id_type_dish = new SelectList(db.TYPE_DISH, "C_id_type_dish", "name_type", bOOK_DISH.C_id_type_dish);
            return View(bOOK_DISH);
        }

        // POST: BOOK_DISH/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "C_id_dish,name_dish,time_pr,C_id_cuisine_national,C_id_cooking_method,C_id_type_dish,C_id_cuisine_type,calories,imageData")] BOOK_DISH bOOK_DISH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOK_DISH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.C_id_cooking_method = new SelectList(db.COOKING_METHOD, "C_id_cooking_method", "name_method", bOOK_DISH.C_id_cooking_method);
            ViewBag.C_id_cuisine_national = new SelectList(db.CUISINE_NATIONAL, "C_id_cuisine_national", "name_cuisine", bOOK_DISH.C_id_cuisine_national);
            ViewBag.C_id_cuisine_type = new SelectList(db.CUISINE_TYPE, "C_id_cuisine_type", "name_cuisine", bOOK_DISH.C_id_cuisine_type);
            ViewBag.C_id_type_dish = new SelectList(db.TYPE_DISH, "C_id_type_dish", "name_type", bOOK_DISH.C_id_type_dish);
            return View(bOOK_DISH);
        }

        // GET: BOOK_DISH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK_DISH bOOK_DISH = db.BOOK_DISH.Find(id);
            if (bOOK_DISH == null)
            {
                return HttpNotFound();
            }
            return View(bOOK_DISH);
        }

        // POST: BOOK_DISH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOOK_DISH bOOK_DISH = db.BOOK_DISH.Find(id);
            db.BOOK_DISH.Remove(bOOK_DISH);
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
