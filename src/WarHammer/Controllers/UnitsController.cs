using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WarHammer.Models;

namespace WarHammer.Controllers
{
    public class UnitsController : Controller
    {
        // GET: /<controller>/
        private WarHammerContext db = new WarHammerContext();
        public IActionResult Index()
        {
            return View(db.Units.Include(x => x.Army).ToList());
        }

        public IActionResult Details (int id)
        {
            var thisUnit = db.Units.FirstOrDefault(x => x.UnitId == id);
            return View(thisUnit);
        }

        public ActionResult Create()
        {
            ViewBag.ArmyId = new SelectList(db.Armies, "ArmyId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create (Unit unit)
        {
            db.Units.Add(unit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
