using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WarHammer.Models;
using Microsoft.Data.Entity;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WarHammer.Controllers
{
    public class ArmiesController : Controller
    {
    
        private WarHammerContext db = new WarHammerContext();

        public IActionResult Index()
        {
            return View(db.Armies.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisArmy = db.Armies.FirstOrDefault(x => x.ArmyId == id);
            return View(thisArmy);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Army army)
        {
            db.Armies.Add(army);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var thisArmy = db.Armies.FirstOrDefault(x => x.ArmyId == id);
            return View(thisArmy);
        }

        [HttpPost]
        public IActionResult Edit(Army army)
        {
            db.Entry(army).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public IActionResult Delete(int id)
        //{
        //    var thisArmy = db.Armies.FirstOrDefault(x => x.ArmyId == id);
        //    return View(thisArmy);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    var thisArmy = db.Armies.FirstOrDefault(x => x.ArmyId == id);
        //    db.Armies.Remove(thisArmy);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var thisArmy = db.Armies.FirstOrDefault(x => x.ArmyId == id);
            db.Armies.Remove(thisArmy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
