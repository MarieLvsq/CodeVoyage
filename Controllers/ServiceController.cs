using CodeVoyage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeVoyage.Controllers
{
    public class ServiceController : Controller
    {

        // Méthodes Créer

        public IActionResult CreerService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreerService(string nomService, TypeService TypeService, int Capacite, DateTime DateDeb, DateTime DateFin, double Prix)
        {


            using (Dal dal = new Dal())
            {
                dal.CreerService(nomService, TypeService, Capacite, DateDeb, DateFin, Prix);
                return RedirectToAction("CreerService");
            }


        }
        //Méthodes Supprimer

        public IActionResult SupprimerService(int id)

        {
            using (Dal dal = new Dal())
            {
                dal.SupprimerService(id);
                
                return RedirectToAction("AfficherTousLesServices");

            }
        }
        //Méthodes Modifier

        public IActionResult ModifierService(int id)
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Service service = dal.ObtientTousLesServices().Where(s => s.Id == id).FirstOrDefault();
                    if (service == null)
                    {
                        return View("Error");
                    }
                    return View(service);
                }
            }
            return View("Error");

        }

        [HttpPost]
        public IActionResult ModifierService(Service service)
        {

            if (!ModelState.IsValid)
                return View(service);

            if (service.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifierService(service);
                    return RedirectToAction("ModifierService", new { @id = service.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }

        //Méthodes affichage 


        public ActionResult AfficherTousLesServices()

        {
            List<Service> services;
            using (Dal dal = new Dal())
            {
                services = dal.ObtientTousLesServices();
            }


            return View(services);

            }


        }


}
