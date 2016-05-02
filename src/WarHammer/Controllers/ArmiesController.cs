using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WarHammer.Models;
using Microsoft.Data.Entity;
using WarHammer.Models.Repositories;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WarHammer.Controllers
{
    public class ArmiesController : Controller
    {
        private IArmyRepository armyRepo;

        public ArmiesController(IArmyRepository thisRepo = null)
        {

            if (thisRepo == null)
            {
                this.armyRepo = new EFArmyRepository();
            }
            else
            {
                this.armyRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            return View(armyRepo.Armies.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisArmy = armyRepo.Armies.FirstOrDefault(x => x.ArmyId == id);
            return View(thisArmy);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Army army)
        {
            armyRepo.Save(army);
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var thisArmy = armyRepo.Armies.FirstOrDefault(x => x.ArmyId == id);
            return View(thisArmy);
        }

        [HttpPost]
        public IActionResult Edit(Army army)
        {
            armyRepo.Edit(army);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            var thisArmy = armyRepo.Armies.FirstOrDefault(x => x.ArmyId == id);
            armyRepo.Remove(thisArmy);
            return RedirectToAction("Index");
        }

    }
}
