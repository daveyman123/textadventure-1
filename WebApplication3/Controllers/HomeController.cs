using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace WebApplication3.Controllers
{

    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            using (var db = new Database1Entities())
            {
                var curTable = db.Tables.Single(c => c.Id == 1);
                return View(curTable);


            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public JsonResult Choice(int i)
        {
            string hunger = "Hunger";
            string morale = "Morale";
            string skill = "Skill";
            string model = "blah";
            if (i == 1)
            {
                model = "you chose right and your hunger increased by 1";

                using (var db = new Database1Entities())
                {

                    var curTable = db.Tables.Single(c => c.Id == 1);
                    curTable.Hunger += 1;
                    db.SaveChanges();
                    hunger = "Hunger = " + curTable.Hunger.ToString();
                    morale = "Morale = " + curTable.Morale.ToString();
                    skill = "Skill = " + curTable.Skill.ToString();

                }
            }
            if (i == 2)
            {
                model = "you chose left and your morale increased by 1";

                using (var db = new Database1Entities())
                {

                    var curTable = db.Tables.Single(c => c.Id == 1);
                    curTable.Morale += 1;
                    db.SaveChanges();
                    hunger = "Experience = " + curTable.Hunger.ToString();
                    morale = "Morale = " + curTable.Morale.ToString();
                    skill = "Skill = " + curTable.Skill.ToString();


                }
            }
            return new JsonResult { Data = new { model, hunger, morale, skill } };
        }


    }
}