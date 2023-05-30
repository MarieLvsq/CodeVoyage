using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeVoyage.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeVoyage.Controllers
{
    public class EvenementController : Controller
    {
        // GET: /<controller>/
        // methode creer événements

        public IActionResult CreerEvenement()
        {

            return View();
          
        }

        [HttpPost]
        public IActionResult CreerEvenement(string Nom, DateTime Date, string Localisation, TypeEvenement TypeEvent)
        {
             
           
                using (Dal dal = new Dal())
                {
                    dal.CreerEvenement(Nom, Date, Localisation,TypeEvent);
                    return RedirectToAction("CreerEvenement");
                }
            
            
        }
        // methode modifier 
        public IActionResult ModifierEvenement(int id)
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Evenement evenement = dal.ObtientTousLesEvenements().Where(e => e.Id == id).FirstOrDefault();
                    if (evenement == null)
                    {
                        return View("Error");
                    }
                    return View(evenement);
                }
            }
            return View("Error");

        }

        [HttpPost]
        public IActionResult ModifierEvenement (Evenement evenement)
        {

            if (!ModelState.IsValid)
                return View(evenement);

            if (evenement.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifierEvenement(evenement);
                    return RedirectToAction("ModifierService", new { @id = evenement.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult SupprimerEvenement(int id)

        {
            using (Dal dal = new Dal())
            {
                dal.SupprimerEvenement(id);
                return RedirectToAction("SupprimerEvenement");

            }
        }
        public ActionResult AfficherTousLesEvenements()

        {
            List<Evenement> evenements;
            using (Dal dal = new Dal())
            {
                evenements = dal.ObtientTousLesEvenements();
            }

            return View(evenements);

        }

    }
}
