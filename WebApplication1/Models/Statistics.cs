using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Statistics
    {
        public Statistics(int id_dish, int counter_ingred, int counter_coincidence)
        {
            this.id_dish = id_dish;
            this.counter_ingred = counter_ingred;
            this.counter_coincidence = counter_coincidence;
        }
        public int id_dish { get; set; }
        public int counter_ingred { get; set; }
        public int counter_coincidence { get; set; }

        public override string ToString()
        {
            string str = "id_dish:" + id_dish + "\ncounter_ingred:" + counter_ingred + "\ncounter_coincidence:" + counter_coincidence + "\n";
            return str;
        }
    }
}