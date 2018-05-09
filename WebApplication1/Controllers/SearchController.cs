using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SearchController : Controller
    {
        
        // GET: Search
        [HttpGet]
        public ActionResult Index()
        {
          
            int index = 0;
            List<string> index_ = new List<string>();//список id ингредиентов, которые были в запросе
            using (CookHelperEntities db = new CookHelperEntities())
            {
                List<string>arr =Request.Params.AllKeys.ToList();//получить все ключи параметров запроса
               
                foreach (var item in arr)
                {
                    if (!item.Equals("ingredient" + (index + 1)))
                        break;
                    index_.Add(Request.Params[item]);
                    index++;
                }              
                List<Statistics> statistics = new List<Statistics>();
                List<RECIPE> recipe = db.RECIPEs.ToList();
                List<INGREDIENT> ingred = db.INGREDIENTs.ToList();
                var group_recipes = from item in recipe
                                    group item by item.C_id_dish;
                foreach (IGrouping<int, RECIPE> g in group_recipes)
                {
                    int index_coincidence = 0;
                    foreach (var ingr_dish in g)
                    {
                        foreach (var item in index_)
                        {

                            if (ingred.ElementAt(ingr_dish.C_id_ingred - 1).name_ingredient.Equals(item))
                                index_coincidence++;
                        }
                    }
                    statistics.Add(new Statistics(g.Key, g.Count(), index_coincidence));
                }


            }
           return View();
        }
    }
}