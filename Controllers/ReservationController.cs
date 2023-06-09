using CodeVoyage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using static CodeVoyage.Models.IDal;

namespace CodeVoyage.Controllers
{
    public class ReservationController : Controller
    {

        public IActionResult Index() 
        {
            return View();
        }

        public IActionResult Index1()
        {
            return View();
        }


        // Méthodes CreerReservation
        [Authorize]

        public IActionResult ReserverOffre(int id)
        {

            Dal dal = new Dal();
            OffreVoyage offre = dal.ObtientToutesLesOffresVoyages().Where(o=>o.Id == id).FirstOrDefault();
            return View(offre);
        }

        [HttpPost]
        public IActionResult ReserverOffre(OffreVoyage OffreVoyage)
        {
            
            using (Dal dal = new Dal())
            {
                Membre membre = dal.ObtenirMembre(User.Identity.Name);
                dal.CreerReservation(membre,OffreVoyage);
                return Redirect("/Reservation/Index");
            }


        }
        //Méthodes Supprimer

        public IActionResult SupprimerReservation(int id)

        {
            using (Dal dal = new Dal())
            {
                dal.SupprimerReservation(id);

                return RedirectToAction("AfficherToutesLesReservations");

            }
        }
        //Méthodes Modifier

        public IActionResult ModifierReservation(int id)
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Reservation reservation = dal.ObtientToutesLesReservations().Where(s => s.Id == id).FirstOrDefault();
                    if (reservation == null)
                    {
                        return View("Error");
                    }
                    return View(reservation);
                }
            }
            return View("Error");

        }

        [HttpPost]
        public IActionResult ModifierReservation(Reservation reservation)
        {

            if (!ModelState.IsValid)
                return View(reservation);

            if (reservation.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.Modifier(reservation);
                    return RedirectToAction("ModifierReservation", new { @id = reservation.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }

        //Méthodes affichage 


        public ActionResult AfficherToutesLesReservations()

        {
            List<Reservation> reservations;
            using (Dal dal = new Dal())
            {
                reservations = dal.ObtientToutesLesReservations();
            }


            return View(reservations);

        }

        public ActionResult AfficherToutesLesReservationsMembre()

        {
            List<Reservation> reservations;
            using (Dal dal = new Dal())
            {
                Membre membre = dal.ObtenirMembre(User.Identity.Name);
                reservations = dal.ObtientToutesLesReservations().Where(r=>r.MembreId == membre.Id).ToList();
            }


            return View(reservations);

        }

    }


}

