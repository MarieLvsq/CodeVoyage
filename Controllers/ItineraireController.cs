using CodeVoyage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeVoyage.Controllers

{
    public class ItineraireController : Controller
    {
        public IActionResult CreerItineraire()

        {
            return View();
        }

       
        
        [HttpPost]
        public IActionResult CreerItineraire(string LieuDepart, String Destination, double Prix, MoyenDeTransport Transport, int NombreVoyageur, DateTime DateDepart, DateTime DateArrivee)
        {


            using (Dal dal = new Dal())
            {
                dal.CreerItineraire(LieuDepart, Destination, Prix, Transport, NombreVoyageur, DateDepart, DateArrivee);


                return RedirectToAction("CreerItineraire");
            }
        }

        public ActionResult AfficherTousLesItineraires()

        {
            List<Itineraire> itineraire;
            using (Dal dal = new Dal())
            {
                itineraire = dal.ObtientTousLesItineraires();
            }

            return View(itineraire);

        }

        //Méthodes Modifier

        public IActionResult ModifierItineraire(int id)
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Itineraire itineraire = dal.ObtientTousLesItineraires().Where(s => s.Id == id).FirstOrDefault();
                    if (itineraire == null)
                    {
                        return View("Error");
                    }
                    return View(itineraire);
                }
            }
            return View("Error");

        }

        [HttpPost]
        public IActionResult ModifierItineraire(Itineraire itineraire)
        {

            if (!ModelState.IsValid)
                return View(itineraire);

            if (itineraire.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifierItineraire(itineraire);
                    return RedirectToAction("ModifierItineraire", new { @id = itineraire.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult SupprimerItineraire(int Id)
        {
            using (Dal dal = new Dal())
            {
                dal.SupprimerItineraire(Id);


                return RedirectToAction("AfficherTousLesItineraires");
            }
        }

        




        }
    }

