﻿using CodeVoyage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace CodeVoyage.Controllers
{
    public class ReservationController : Controller
    {

        // Méthodes CreerReservation

        public IActionResult CreerReservation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReserverOffre(Membre Membre, OffreVoyage OffrePayee)
        {


            using (Dal dal = new Dal())
            {
                dal.CreerReservation(Membre,OffrePayee);
                return RedirectToAction("CreerReservation");
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
        
    }


}

