using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StartController : Controller
    {
        CookHelperEntities db = new CookHelperEntities();

        // GET: Start
        public ActionResult Index()
        {
            var dish = db.BOOK_DISH.Include(path=>path.RECIPEs);
            return View(dish.ToList());
        }
    }
}